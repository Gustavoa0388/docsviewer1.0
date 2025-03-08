using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace DocumentosOrtobio
{
    public partial class SettingsForm : Form
    {
        private readonly string basePath = @"\\D4MDP574\Doc Viewer$\Banco de dados";
        private readonly Dictionary<string, List<string>> categoriesWithSubmenus = new Dictionary<string, List<string>>
        {
            { "Documentos Vigentes", new List<string> { "DT", "EC", "EMF", "GR", "NP", "RM", "RMP", "SF" } },
            { "Documentos Obsoletos", new List<string> { "DT", "EC", "EMF", "GR", "NP", "RM", "RMP", "SF" } },
            { "Validações", new List<string> { "Validações" } }
        };
        private readonly string loggedInUser;

        public SettingsForm(string loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            InitializeComponent();
        }

        private void BtnManageDocuments_Click(object sender, EventArgs e)
        {
            if (CurrentUserIsAdmin())
            {
                var docManagementForm = new DocumentManagementForm(@"\\D4MDP574\Doc Viewer\Documentos", loggedInUser, categoriesWithSubmenus);
                docManagementForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acesso negado. Apenas administradores podem acessar esta funcionalidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CurrentUserIsAdmin()
        {
            // Implementar a lógica para verificar se o usuário atual é administrador
            // Por exemplo, verificando um campo na classe de usuário atual
            return true; // Substituir pela lógica real
        }

        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm(loggedInUser);
            if (createUserForm.ShowDialog() == DialogResult.OK)
            {
                ActivityLogger.Log("Criou um novo usuário.", loggedInUser);
            }
        }

        private void BtnGenerateLogReport_Click(object sender, EventArgs e)
        {
            GenerateLogReport();
        }

        private void GenerateLogReport()
        {
            try
            {
                // Abrir dialog para salvar o relatório
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string logReportPath = Path.Combine(folderBrowserDialog.SelectedPath, "log_report.txt");
                    string logFilePath = Path.Combine(basePath, "activity_log.txt");
                    string logContent = File.ReadAllText(logFilePath);
                    File.WriteAllText(logReportPath, logContent);
                    MessageBox.Show($"Relatório de logs gerado em: {logReportPath}");
                    ActivityLogger.Log("Gerou um relatório de logs.", loggedInUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de logs: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOnlineUsers_Click(object sender, EventArgs e)
        {
            OnlineUsersForm onlineUsersForm = new OnlineUsersForm();
            onlineUsersForm.ShowDialog();
            ActivityLogger.Log("Abriu o painel de controle de usuários online.", loggedInUser);
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                string logFilePath = Path.Combine(basePath, "activity_log.txt");
                if (File.Exists(logFilePath))
                {
                    File.WriteAllText(logFilePath, string.Empty);
                    MessageBox.Show("Log de atividades foi limpo.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Log de atividades não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar log: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportUserReport_Click(object sender, EventArgs e)
        {
            ExportUserReport();
        }

        private void ExportUserReport()
        {
            try
            {
                string usersFilePath = Path.Combine(basePath, "users.json");
                string userPermissionsFilePath = Path.Combine(basePath, "userPermissions.json");

                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));
                var userPermissions = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(userPermissionsFilePath));

                // Abrir dialog para salvar o relatório
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string reportPath = Path.Combine(folderBrowserDialog.SelectedPath, "user_report.xls");
                    IWorkbook workbook = new HSSFWorkbook();
                    ISheet sheet = workbook.CreateSheet("User Report");

                    // Cabeçalho
                    IRow headerRow = sheet.CreateRow(0);
                    headerRow.CreateCell(0).SetCellValue("Username");
                    headerRow.CreateCell(1).SetCellValue("Password");
                    headerRow.CreateCell(2).SetCellValue("Role");
                    headerRow.CreateCell(3).SetCellValue("Permissions");

                    // Dados dos usuários
                    for (int i = 0; i < users.Count; i++)
                    {
                        var user = users[i];
                        IRow row = sheet.CreateRow(i + 1);
                        row.CreateCell(0).SetCellValue(user.Username);
                        row.CreateCell(1).SetCellValue(user.Password);
                        row.CreateCell(2).SetCellValue(user.Role);
                        string permissions = string.Join(", ", userPermissions.ContainsKey(user.Username) ? userPermissions[user.Username] : new List<string>());
                        row.CreateCell(3).SetCellValue(permissions);
                    }

                    // Salvar o arquivo
                    using (var fileData = new FileStream(reportPath, FileMode.Create))
                    {
                        workbook.Write(fileData);
                    }

                    MessageBox.Show($"Relatório de usuários exportado em: {reportPath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActivityLogger.Log("Exportou um relatório de usuários.", loggedInUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar relatório de usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}