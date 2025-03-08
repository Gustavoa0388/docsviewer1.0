using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DocumentosOrtobio
{
    public partial class ViewUsersForm : Form
    {
        private readonly string basePath = @"\\D4MDP574\Doc Viewer$\Banco de dados";
        private readonly string loggedInUser;

        public ViewUsersForm(string loggedInUser)
        {
            this.loggedInUser = loggedInUser;

            // Inicialize o CategoryManager com as categorias e subcategorias
            var initialCategoriesWithSubmenus = GetCategoriesFromDirectory(@"\\D4MDP574\Doc Viewer$\Documentos");
            CategoryManager.Initialize(initialCategoriesWithSubmenus);

            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            string usersFilePath = Path.Combine(basePath, "users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));
            listBoxUsers.Items.Clear();
            foreach (var user in users)
            {
                listBoxUsers.Items.Add(user.Username);
            }
        }

        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem != null)
            {
                string selectedUsername = listBoxUsers.SelectedItem.ToString();
                string usersFilePath = Path.Combine(basePath, "users.json");
                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));
                var user = users.First(u => u.Username == selectedUsername);
                txtUsername.Text = user.Username;
                txtPassword.Text = user.Password;
                cmbRole.SelectedItem = user.Role;

                string userPermissionsFilePath = Path.Combine(basePath, "userPermissions.json");
                var userPermissions = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(userPermissionsFilePath));
                PopulateCheckedListBox();
                CheckUserPermissions(userPermissions[selectedUsername]);
            }
        }

        private void PopulateCheckedListBox()
        {
            checkedListBoxCategories.Items.Clear();
            var categoriesWithSubmenus = CategoryManager.GetCategoriesWithSubmenus();
            foreach (var category in categoriesWithSubmenus.Keys)
            {
                checkedListBoxCategories.Items.Add(category);
                foreach (var subCategory in categoriesWithSubmenus[category])
                {
                    checkedListBoxCategories.Items.Add("  " + subCategory);
                }
            }
        }

        private void CheckUserPermissions(List<string> userPermissions)
        {
            for (int i = 0; i < checkedListBoxCategories.Items.Count; i++)
            {
                string item = checkedListBoxCategories.Items[i].ToString().Trim();
                checkedListBoxCategories.SetItemChecked(i, userPermissions.Contains(item));
            }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            string selectedUsername = listBoxUsers.SelectedItem.ToString();
            string usersFilePath = Path.Combine(basePath, "users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));
            var user = users.First(u => u.Username == selectedUsername);

            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            user.Role = cmbRole.SelectedItem.ToString();

            var selectedPermissions = new List<string>();
            foreach (string item in checkedListBoxCategories.CheckedItems)
            {
                selectedPermissions.Add(item.Trim());
            }

            string userPermissionsFilePath = Path.Combine(basePath, "userPermissions.json");
            var userPermissions = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(userPermissionsFilePath));
            userPermissions[selectedUsername] = selectedPermissions;

            File.WriteAllText(usersFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));
            File.WriteAllText(userPermissionsFilePath, JsonConvert.SerializeObject(userPermissions, Formatting.Indented));

            ActivityLogger.Log(loggedInUser, $"Atualizou o usuário: {selectedUsername}");

            MessageBox.Show("Usuário atualizado com sucesso!");
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem != null)
            {
                string selectedUsername = listBoxUsers.SelectedItem.ToString();
                string usersFilePath = Path.Combine(basePath, "users.json");
                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));
                string userPermissionsFilePath = Path.Combine(basePath, "userPermissions.json");
                var userPermissions = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(userPermissionsFilePath));

                users.RemoveAll(u => u.Username == selectedUsername);
                userPermissions.Remove(selectedUsername);

                File.WriteAllText(usersFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));
                File.WriteAllText(userPermissionsFilePath, JsonConvert.SerializeObject(userPermissions, Formatting.Indented));

                LoadUsers();

                ActivityLogger.Log(loggedInUser, $"Excluiu o usuário: {selectedUsername}");

                MessageBox.Show("Usuário excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para excluir.");
            }
        }

        private Dictionary<string, List<string>> GetCategoriesFromDirectory(string path)
        {
            var categories = new Dictionary<string, List<string>>();

            if (Directory.Exists(path))
            {
                var categoryDirs = Directory.GetDirectories(path);
                foreach (var categoryDir in categoryDirs)
                {
                    var category = Path.GetFileName(categoryDir);
                    var subcategories = Directory.GetDirectories(categoryDir).Select(Path.GetFileName).ToList();
                    categories[category] = subcategories;
                }
            }

            return categories;
        }
    }
}