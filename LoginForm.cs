using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DocumentosOrtobio
{
    public partial class LoginForm : Form
    {
        private Dictionary<string, bool> userLoginStatus;
        private readonly string basePath = @"\\D4MDP574\Doc Viewer$\Banco de dados";
        private readonly string localAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DocsViewer");

        public LoginForm()
        {
            InitializeComponent();
            try
            {
                LoadUserLoginStatus();
                LoadLastLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar status de login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("Erro ao carregar status de login: " + ex.Message);
                Application.Exit();
            }
        }

        private void LoadUserLoginStatus()
        {
            string userLoginStatusFilePath = Path.Combine(basePath, "userLoginStatus.json");

            if (File.Exists(userLoginStatusFilePath))
            {
                userLoginStatus = JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(userLoginStatusFilePath));
            }
            else
            {
                userLoginStatus = new Dictionary<string, bool>();
                Logger.Log("Arquivo de status de login não encontrado. Criando novo.");
            }
        }

        private void SaveUserLoginStatus()
        {
            try
            {
                string userLoginStatusFilePath = Path.Combine(basePath, "userLoginStatus.json");
                File.WriteAllText(userLoginStatusFilePath, JsonConvert.SerializeObject(userLoginStatus, Formatting.Indented));
                Logger.Log("Status de login salvo com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar status de login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("Erro ao salvar status de login: " + ex.Message);
            }
        }

        private void LoadLastLogin()
        {
            string lastLoginFilePath = Path.Combine(localAppDataPath, "lastLogin.json");

            if (File.Exists(lastLoginFilePath))
            {
                var lastLogin = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(lastLoginFilePath));
                if (lastLogin.ContainsKey("LastUsername"))
                {
                    txtUsername.Text = lastLogin["LastUsername"];
                }
            }
        }

        private void SaveLastLogin(string username)
        {
            try
            {
                if (!Directory.Exists(localAppDataPath))
                {
                    Directory.CreateDirectory(localAppDataPath);
                }

                string lastLoginFilePath = Path.Combine(localAppDataPath, "lastLogin.json");
                var lastLogin = new Dictionary<string, string>
                {
                    { "LastUsername", username }
                };
                File.WriteAllText(lastLoginFilePath, JsonConvert.SerializeObject(lastLogin, Formatting.Indented));
                Logger.Log("Último login salvo com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar último login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("Erro ao salvar último login: " + ex.Message);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                string usersFilePath = Path.Combine(basePath, "users.json");

                if (!File.Exists(usersFilePath))
                {
                    MessageBox.Show("Arquivo de usuários não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Log("Arquivo de usuários não encontrado: " + usersFilePath);
                    return;
                }

                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));
                var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    if (userLoginStatus.ContainsKey(username) && userLoginStatus[username])
                    {
                        MessageBox.Show("O usuário já está logado em outro terminal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Logger.Log("Tentativa de login múltiplo para o usuário: " + username);
                        return;
                    }

                    userLoginStatus[username] = true;
                    SaveUserLoginStatus();

                    // Atualizar LastLogin e salvar os detalhes do usuário
                    user.LastLogin = DateTime.Now;
                    SaveUserDetails(users); // Salvar os detalhes do usuário

                    SaveCurrentUserDetails(username, GetLocalIPAddress(), DateTime.Now);
                    SaveLastLogin(username);

                    Viewer1 mainForm = new Viewer1(user);
                    mainForm.Show();
                    this.Hide();

                    Logger.Log($"Usuário {username} fez login com sucesso.");
                }
                else
                {
                    MessageBox.Show("Credenciais inválidas.");
                    Logger.Log("Tentativa de login falhou para o usuário: " + username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar realizar login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("Erro ao tentar realizar login: " + ex.Message);
            }
        }

        private void SaveCurrentUserDetails(string username, string ip, DateTime loginTime)
        {
            try
            {
                string currentUserDetailsFilePath = Path.Combine(basePath, "currentUsers.json");
                var currentUserDetails = File.Exists(currentUserDetailsFilePath)
                    ? JsonConvert.DeserializeObject<List<UserLoginDetail>>(File.ReadAllText(currentUserDetailsFilePath))
                    : new List<UserLoginDetail>();

                currentUserDetails.Add(new UserLoginDetail
                {
                    Username = username,
                    IPAddress = ip,
                    LoginTime = loginTime.ToString("dd-MM-yyyy HH:mm:ss"),
                    OnlineTime = TimeSpan.Zero.ToString(@"hh\:mm\:ss") // Inicialmente zero, será atualizado posteriormente
                });

                File.WriteAllText(currentUserDetailsFilePath, JsonConvert.SerializeObject(currentUserDetails, Formatting.Indented));
                Logger.Log("Detalhes do usuário atual salvos com sucesso para o usuário: " + username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar detalhes do usuário atual: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("Erro ao salvar detalhes do usuário atual: " + ex.Message);
            }
        }

        private void SaveUserDetails(List<User> users)
        {
            try
            {
                string usersFilePath = Path.Combine(basePath, "users.json");
                File.WriteAllText(usersFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));
                Logger.Log("Detalhes do usuário salvos com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar detalhes do usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("Erro ao salvar detalhes do usuário: " + ex.Message);
            }
        }

        private string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "Local IP Address Not Found!";
            }
            catch (Exception ex)
            {
                Logger.Log("Erro ao obter endereço IP local: " + ex.Message);
                return "Erro ao obter IP!";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Fecha o aplicativo completamente
            Application.Exit();
        }
    }
}