using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using Newtonsoft.Json;
using PdfiumViewer;

namespace DocumentosOrtobio
{
    public partial class Viewer1 : Form
    {
        private readonly User loggedUser;
        private string currentFilePath1;
        private string currentFilePath2;
        private bool isDarkMode = false;

        private readonly Dictionary<string, List<string>> userPermissions;
        private readonly string basePath = @"\\D4MDP574\Doc Viewer$\Banco de dados";
        private readonly string documentsPath = @"\\D4MDP574\Doc Viewer$\Documentos";

        private System.Timers.Timer inactivityTimer;

        // Importa a função SetWindowLong da API do Windows
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Importa a função GetWindowLong da API do Windows
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // Importa a função SystemParametersInfo da API do Windows
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref RECT pvParam, uint fWinIni);

        private const uint SPI_GETWORKAREA = 0x0030;

        // Estrutura RECT usada para obter a área de trabalho
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public Rectangle ToRectangle()
            {
                return new Rectangle(Left, Top, Right - Left, Bottom - Top);
            }
        }

        // Constantes usadas para definir o comportamento da janela
        private const int GWL_STYLE = -16;
        private const int WS_MINIMIZEBOX = 0x00020000;
        private const int WS_SYSMENU = 0x00080000;

        public Viewer1(User user)
        {
            InitializeComponent();
            loggedUser = user;

            try
            {
                userPermissions = LoadUserPermissions();
                LogActivity("Login");

                btnSettings.Visible = loggedUser.Role == "admin";
                btnChangePassword.Visible = loggedUser.Role == "viewer" || loggedUser.Role == "editor";
                ConfigurePdfViewerPermissions();
                PopulateCategoryComboBox(comboBoxCategory1);
                PopulateCategoryComboBox(comboBoxCategory2);

                LoadUserPreferences();
                SetupInactivityTimer();

                // Define o comportamento da janela para aparecer na barra de tarefas
                int style = GetWindowLong(this.Handle, GWL_STYLE);
                SetWindowLong(this.Handle, GWL_STYLE, style | WS_MINIMIZEBOX | WS_SYSMENU);

                // Ajusta o formulário para caber corretamente na área de trabalho
                AdjustFormToFitScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar o programa: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("Erro ao iniciar o programa: " + ex.Message);
                Application.Exit();
            }
        }

        private void AdjustFormToFitScreen()
        {
            RECT workArea = new RECT();
            if (SystemParametersInfo(SPI_GETWORKAREA, 0, ref workArea, 0))
            {
                Rectangle workRectangle = workArea.ToRectangle();

                // Define o tamanho e a posição do formulário para caber na área de trabalho
                this.Location = new Point(workRectangle.Left, workRectangle.Top);
                this.Size = new Size(workRectangle.Width, workRectangle.Height);
            }
            else
            {
                MessageBox.Show("Não foi possível obter a área de trabalho.");
            }
        }

        private Dictionary<string, List<string>> LoadUserPermissions()
        {
            string userPermissionsFilePath = Path.Combine(basePath, "userPermissions.json");
            if (!File.Exists(userPermissionsFilePath))
            {
                string errorMessage = "Arquivo de permissões não encontrado: " + userPermissionsFilePath;
                Logger.Log(errorMessage);
                throw new FileNotFoundException(errorMessage);
            }

            return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(userPermissionsFilePath));
        }

        private void SetupInactivityTimer()
        {
            inactivityTimer = new System.Timers.Timer(15 * 60 * 1000); // 15 minutes
            inactivityTimer.Elapsed += OnInactivity;
            inactivityTimer.AutoReset = false;
            inactivityTimer.Start();

            this.MouseMove += ResetInactivityTimer;
            this.KeyPress += ResetInactivityTimer;
        }

        private void OnInactivity(object sender, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Close()));
            }
            else
            {
                Close();
            }
        }

        private void ResetInactivityTimer(object sender, EventArgs e)
        {
            inactivityTimer.Stop();
            inactivityTimer.Start();
        }

        private void ConfigurePdfViewerPermissions()
        {
            var toolStrip1 = pdfViewer1.Controls.OfType<ToolStrip>().FirstOrDefault();
            var toolStrip2 = pdfViewer2.Controls.OfType<ToolStrip>().FirstOrDefault();

            if (toolStrip1 != null)
            {
                foreach (ToolStripItem item in toolStrip1.Items)
                {
                    if (item.Text == "Save")
                    {
                        item.Click += (s, e) =>
                        {
                            if (listBoxFiles1.SelectedItem != null)
                            {
                                string selectedFileName = listBoxFiles1.SelectedItem.ToString();
                                LogActivity($"Salvou o documento: {selectedFileName}");
                            }
                        };
                        item.Enabled = loggedUser.Role == "admin" || loggedUser.Role == "editor";
                    }
                    else if (item.Text == "Print")
                    {
                        item.Click += (s, e) =>
                        {
                            if (listBoxFiles1.SelectedItem != null)
                            {
                                string selectedFileName = listBoxFiles1.SelectedItem.ToString();
                                LogActivity($"Imprimiu o documento: {selectedFileName}");
                            }
                        };
                        item.Enabled = loggedUser.Role == "admin" || loggedUser.Role == "editor";
                    }
                }
            }

            if (toolStrip2 != null)
            {
                foreach (ToolStripItem item in toolStrip2.Items)
                {
                    if (item.Text == "Save")
                    {
                        item.Click += (s, e) =>
                        {
                            if (listBoxFiles2.SelectedItem != null)
                            {
                                string selectedFileName = listBoxFiles2.SelectedItem.ToString();
                                LogActivity($"Salvou o documento: {selectedFileName}");
                            }
                        };
                        item.Enabled = loggedUser.Role == "admin" || loggedUser.Role == "editor";
                    }
                    else if (item.Text == "Print")
                    {
                        item.Click += (s, e) =>
                        {
                            if (listBoxFiles2.SelectedItem != null)
                            {
                                string selectedFileName = listBoxFiles2.SelectedItem.ToString();
                                LogActivity($"Imprimiu o documento: {selectedFileName}");
                            }
                        };
                        item.Enabled = loggedUser.Role == "admin" || loggedUser.Role == "editor";
                    }
                }
            }
        }

        private void PopulateCategoryComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("All Categories");

            if (Directory.Exists(documentsPath))
            {
                var categories = Directory.GetDirectories(documentsPath).Select(Path.GetFileName);
                foreach (var category in categories)
                {
                    if (UserCanAccessCategory(category))
                    {
                        comboBox.Items.Add(category);
                    }
                }
            }
            else
            {
                string errorMessage = "Diretório de documentos não encontrado: " + documentsPath;
                Logger.Log(errorMessage);
                throw new DirectoryNotFoundException(errorMessage);
            }

            comboBox.SelectedIndex = 0;
        }

        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                var subCategoryComboBox = comboBox == comboBoxCategory1 ? comboBoxSubCategory1 : comboBoxSubCategory2;
                PopulateSubCategoryComboBox(subCategoryComboBox, comboBox.SelectedItem.ToString());
            }
        }

        private void PopulateSubCategoryComboBox(ComboBox comboBox, string selectedCategory)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("All Subcategories");

            var subCategoryPath = Path.Combine(documentsPath, selectedCategory);
            if (Directory.Exists(subCategoryPath))
            {
                var subCategories = Directory.GetDirectories(subCategoryPath).Select(Path.GetFileName);
                foreach (var subCategory in subCategories)
                {
                    if (UserCanAccessSubCategory(selectedCategory, subCategory))
                    {
                        comboBox.Items.Add(subCategory);
                    }
                }
            }

            comboBox.SelectedIndex = 0;
        }

        private void ButtonSearch1_Click(object sender, EventArgs e)
        {
            LogActivity("Buscou na Categoria 1");
            string searchPattern = textBoxSearch1.Text;
            string selectedCategory = comboBoxCategory1.SelectedItem.ToString();
            string selectedSubCategory = comboBoxSubCategory1.SelectedItem.ToString();
            listBoxFiles1.Items.Clear();

            if (selectedCategory == "All Categories")
            {
                var categories = Directory.GetDirectories(documentsPath).Select(Path.GetFileName);
                foreach (var category in categories)
                {
                    if (UserCanAccessCategory(category))
                    {
                        SearchFiles(category, selectedSubCategory, searchPattern, listBoxFiles1);
                    }
                }
            }
            else
            {
                SearchFiles(selectedCategory, selectedSubCategory, searchPattern, listBoxFiles1);
            }
        }

        private void ButtonSearch2_Click(object sender, EventArgs e)
        {
            LogActivity("Buscou na Categoria 2");
            string searchPattern = textBoxSearch2.Text;
            string selectedCategory = comboBoxCategory2.SelectedItem.ToString();
            string selectedSubCategory = comboBoxSubCategory2.SelectedItem.ToString();
            listBoxFiles2.Items.Clear();

            if (selectedCategory == "All Categories")
            {
                var categories = Directory.GetDirectories(documentsPath).Select(Path.GetFileName);
                foreach (var category in categories)
                {
                    if (UserCanAccessCategory(category))
                    {
                        SearchFiles(category, selectedSubCategory, searchPattern, listBoxFiles2);
                    }
                }
            }
            else
            {
                SearchFiles(selectedCategory, selectedSubCategory, searchPattern, listBoxFiles2);
            }
        }

        private void SearchFiles(string category, string subCategory, string searchPattern, ListBox listBox)
        {
            var categoryPath = Path.Combine(documentsPath, category);

            if (subCategory == "All Subcategories")
            {
                var subCategories = Directory.GetDirectories(categoryPath).Select(Path.GetFileName);
                foreach (var subCat in subCategories)
                {
                    if (UserCanAccessSubCategory(category, subCat))
                    {
                        string subCategoryPath = Path.Combine(categoryPath, subCat);
                        string[] files = Directory.GetFiles(subCategoryPath, "*" + searchPattern + "*.pdf", SearchOption.AllDirectories);

                        foreach (string file in files)
                        {
                            listBox.Items.Add(Path.GetFileName(file));
                        }
                    }
                }
            }
            else
            {
                if (UserCanAccessSubCategory(category, subCategory))
                {
                    string subCategoryPath = Path.Combine(categoryPath, subCategory);
                    string[] files = Directory.GetFiles(subCategoryPath, "*" + searchPattern + "*.pdf", SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        listBox.Items.Add(Path.GetFileName(file));
                    }
                }
            }
        }

        private void ListBoxFiles1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFiles1.SelectedItem != null)
            {
                string selectedFileName = listBoxFiles1.SelectedItem.ToString();
                currentFilePath1 = GetFilePath(selectedFileName);
                DisplayPdf1(currentFilePath1);
                LogActivity($"Visualizou o arquivo {selectedFileName} na Categoria 1");
            }
        }

        private void ListBoxFiles2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFiles2.SelectedItem != null)
            {
                string selectedFileName = listBoxFiles2.SelectedItem.ToString();
                currentFilePath2 = GetFilePath(selectedFileName);
                DisplayPdf2(currentFilePath2);
                LogActivity($"Visualizou o arquivo {selectedFileName} na Categoria 2");
            }
        }

        private string GetFilePath(string fileName)
        {
            var categories = Directory.GetDirectories(documentsPath);
            foreach (var categoryPath in categories)
            {
                var files = Directory.GetFiles(categoryPath, fileName, SearchOption.AllDirectories);
                if (files.Any())
                {
                    return files.First();
                }
                var subCategories = Directory.GetDirectories(categoryPath);
                foreach (var subCategoryPath in subCategories)
                {
                    files = Directory.GetFiles(subCategoryPath, fileName, SearchOption.AllDirectories);
                    if (files.Any())
                    {
                        return files.First();
                    }
                }
            }
            return null;
        }

        private void DisplayPdf1(string filePath)
        {
            if (filePath != null)
            {
                var pdfDocument = PdfDocument.Load(filePath);
                pdfViewer1.Document = pdfDocument;
            }
        }

        private void DisplayPdf2(string filePath)
        {
            if (filePath != null)
            {
                var pdfDocument = PdfDocument.Load(filePath);
                pdfViewer2.Document = pdfDocument;
            }
        }

        private bool UserCanAccessCategory(string category)
        {
            return userPermissions.ContainsKey(loggedUser.Username) && userPermissions[loggedUser.Username].Contains(category);
        }

        private bool UserCanAccessSubCategory(string category, string subCategory)
        {
            return userPermissions.ContainsKey(loggedUser.Username) && userPermissions[loggedUser.Username].Contains(subCategory);
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(loggedUser);
            changePasswordForm.ShowDialog();
            LogActivity("Abriu a tela de alteração de senha.");
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(loggedUser.Username);
            settingsForm.ShowDialog();
            LogActivity("Abriu o painel de configurações.");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LogActivity("Logout");
            UpdateUserLoginStatus(loggedUser.Username, false);
            UpdateUserOnlineTime(loggedUser.Username);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateUserLoginStatus(loggedUser.Username, false);
            UpdateUserOnlineTime(loggedUser.Username);

            // Verificar e remover usuários com status false
            CheckAndRemoveLoggedOutUsers();

            // Registrar a saída do usuário
            LogActivity("Logout");

            // Fechar o aplicativo completamente
            Application.Exit();
        }

        private void CheckAndRemoveLoggedOutUsers()
        {
            string userLoginStatusFilePath = Path.Combine(basePath, "userLoginStatus.json");
            string currentUserDetailsFilePath = Path.Combine(basePath, "currentUsers.json");

            if (File.Exists(userLoginStatusFilePath) && File.Exists(currentUserDetailsFilePath))
            {
                var userLoginStatus = JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(userLoginStatusFilePath));
                var currentUserDetails = JsonConvert.DeserializeObject<List<UserLoginDetail>>(File.ReadAllText(currentUserDetailsFilePath));
                var usersToRemove = currentUserDetails.Where(u => userLoginStatus.ContainsKey(u.Username) && !userLoginStatus[u.Username]).ToList();

                if (usersToRemove.Any())
                {
                    foreach (var userDetail in usersToRemove)
                    {
                        userDetail.OnlineTime = (DateTime.Now - DateTime.ParseExact(userDetail.LoginTime, "dd-MM-yyyy HH:mm:ss", null)).ToString(@"hh\:mm\:ss");
                        SaveUserLoginDetails(userDetail);
                        currentUserDetails.Remove(userDetail);
                    }
                    File.WriteAllText(currentUserDetailsFilePath, JsonConvert.SerializeObject(currentUserDetails, Formatting.Indented));
                }
            }
        }

        private void SaveUserLoginDetails(UserLoginDetail userDetail)
        {
            string userLoginDetailsFilePath = Path.Combine(basePath, "userLoginDetails.json");
            var userLoginDetails = File.Exists(userLoginDetailsFilePath)
                ? JsonConvert.DeserializeObject<List<UserLoginDetail>>(File.ReadAllText(userLoginDetailsFilePath))
                : new List<UserLoginDetail>();

            userLoginDetails.Add(userDetail);

            File.WriteAllText(userLoginDetailsFilePath, JsonConvert.SerializeObject(userLoginDetails, Formatting.Indented));
        }

        private void LogActivity(string activity)
        {
            string logMessage = $"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - {GetLocalIPAddress()} - {loggedUser.Username} - {activity}";
            try
            {
                string logFilePath = Path.Combine(basePath, "activity_log.txt");
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar atividade: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Local IP Address Not Found!";
        }

        private void UpdateUserLoginStatus(string username, bool status)
        {
            string userLoginStatusFilePath = Path.Combine(basePath, "userLoginStatus.json");
            var userLoginStatus = File.Exists(userLoginStatusFilePath)
                ? JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(userLoginStatusFilePath))
                : new Dictionary<string, bool>();

            userLoginStatus[username] = status;
            File.WriteAllText(userLoginStatusFilePath, JsonConvert.SerializeObject(userLoginStatus, Formatting.Indented));
        }

        private void UpdateUserOnlineTime(string username)
        {
            string userLoginDetailsFilePath = Path.Combine(basePath, "userLoginDetails.json");
            if (File.Exists(userLoginDetailsFilePath))
            {
                var userLoginDetails = JsonConvert.DeserializeObject<List<UserLoginDetail>>(File.ReadAllText(userLoginDetailsFilePath));
                var userDetail = userLoginDetails.FirstOrDefault(u => u.Username == username && u.OnlineTime == "00:00:00");

                if (userDetail != null)
                {
                    userDetail.OnlineTime = (DateTime.Now - DateTime.ParseExact(userDetail.LoginTime, "dd-MM-yyyy HH:mm:ss", null)).ToString(@"hh\:mm\:ss");
                    File.WriteAllText(userLoginDetailsFilePath, JsonConvert.SerializeObject(userLoginDetails, Formatting.Indented));
                }
            }
        }

        private void BtnToggleDarkMode_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ToggleDarkMode(isDarkMode);
            SaveUserPreferences();
        }

        private void ToggleDarkMode(bool darkMode)
        {
            var backColor = darkMode ? System.Drawing.Color.FromArgb(45, 45, 48) : System.Drawing.Color.White;
            var foreColor = darkMode ? System.Drawing.Color.White : System.Drawing.Color.Black;

            this.BackColor = backColor;
            this.ForeColor = foreColor;

            foreach (Control control in this.Controls)
            {
                ToggleControlDarkMode(control, darkMode);
            }
        }

        private void ToggleControlDarkMode(Control control, bool darkMode)
        {
            var backColor = darkMode ? System.Drawing.Color.FromArgb(45, 45, 48) : System.Drawing.Color.White;
            var foreColor = darkMode ? System.Drawing.Color.White : System.Drawing.Color.Black;

            control.BackColor = backColor;
            control.ForeColor = foreColor;

            if (control is ComboBox || control is TextBox || control is ListBox)
            {
                control.BackColor = darkMode ? System.Drawing.Color.FromArgb(30, 30, 30) : System.Drawing.Color.White;
            }

            foreach (Control childControl in control.Controls)
            {
                ToggleControlDarkMode(childControl, darkMode);
            }
        }

        private void LoadUserPreferences()
        {
            string userPreferencesFilePath = Path.Combine(basePath, "userPreferences.json");
            if (File.Exists(userPreferencesFilePath))
            {
                var userPreferences = JsonConvert.DeserializeObject<Dictionary<string, UserPreferences>>(File.ReadAllText(userPreferencesFilePath));
                if (userPreferences.ContainsKey(loggedUser.Username))
                {
                    var preferences = userPreferences[loggedUser.Username];
                    isDarkMode = preferences.IsDarkMode;
                    ToggleDarkMode(isDarkMode);

                    if (preferences.IsSimpleView)
                    {
                        this.Hide();
                        DocumentViewerForm documentViewerForm = new DocumentViewerForm(loggedUser);
                        documentViewerForm.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private void SaveUserPreferences()
        {
            string userPreferencesFilePath = Path.Combine(basePath, "userPreferences.json");
            var userPreferences = File.Exists(userPreferencesFilePath)
                ? JsonConvert.DeserializeObject<Dictionary<string, UserPreferences>>(File.ReadAllText(userPreferencesFilePath))
                : new Dictionary<string, UserPreferences>();

            userPreferences[loggedUser.Username] = new UserPreferences
            {
                IsDarkMode = isDarkMode,
                IsSimpleView = false // As this is the Form1, it's the dual view
            };

            File.WriteAllText(userPreferencesFilePath, JsonConvert.SerializeObject(userPreferences, Formatting.Indented));
        }

        private void BtnVisualizacaoSimples_Click(object sender, EventArgs e)
        {
            SaveUserPreferencesForSimpleView();
            DocumentViewerForm documentViewerForm = new DocumentViewerForm(loggedUser);
            documentViewerForm.Show();
            this.Hide();
        }

        private void SaveUserPreferencesForSimpleView()
        {
            string userPreferencesFilePath = Path.Combine(basePath, "userPreferences.json");
            var userPreferences = File.Exists(userPreferencesFilePath)
                ? JsonConvert.DeserializeObject<Dictionary<string, UserPreferences>>(File.ReadAllText(userPreferencesFilePath))
                : new Dictionary<string, UserPreferences>();

            userPreferences[loggedUser.Username] = new UserPreferences
            {
                IsDarkMode = isDarkMode,
                IsSimpleView = true // Setting the preference for simple view
            };

            File.WriteAllText(userPreferencesFilePath, JsonConvert.SerializeObject(userPreferences, Formatting.Indented));
        }

        // Métodos adicionados para resolver os erros de método não encontrado
        private void ComboBoxSubCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementação necessária
        }

        private void ComboBoxSubCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementação necessária
        }

        private void TextBoxSearch2_TextChanged(object sender, EventArgs e)
        {
            // Implementação necessária
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}