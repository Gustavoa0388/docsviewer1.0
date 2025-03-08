using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DocumentosOrtobio
{
    public partial class ChangePasswordForm : Form
    {
        private readonly User loggedUser;
        private readonly string basePath = @"\\D4MDP574\Doc Viewer$\Banco de dados";

        public ChangePasswordForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("As senhas não coincidem. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("A nova senha não pode estar vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string usersFilePath = Path.Combine(basePath, "users.json");
                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));

                var user = users.Find(u => u.Username == loggedUser.Username);
                if (user != null)
                {
                    user.Password = newPassword;
                    File.WriteAllText(usersFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));

                    ActivityLogger.Log("Alterou a senha.", loggedUser.Username);
                    MessageBox.Show("Senha alterada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar a senha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            // Implementação necessária
        }
    }
}