using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DocumentosOrtobio
{
    public partial class CreateUserForm : Form
    {
        private readonly string basePath = @"\\D4MDP574\Doc Viewer$\Banco de dados";
        private readonly string loggedInUser;

        public CreateUserForm(string username)
        {
            InitializeComponent();
            loggedInUser = username;

            // Inicialize o CategoryManager com as categorias e subcategorias
            var initialCategoriesWithSubmenus = GetCategoriesFromDirectory(@"\\D4MDP574\Doc Viewer$\Documentos");
            CategoryManager.Initialize(initialCategoriesWithSubmenus);

            PopulateCheckedListBox();
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

        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem.ToString();

            string usersFilePath = Path.Combine(basePath, "users.json");
            string userPermissionsFilePath = Path.Combine(basePath, "userPermissions.json");

            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersFilePath));

            if (users.Any(u => u.Username == username))
            {
                MessageBox.Show("Usuário já existe!");
                return;
            }

            var selectedPermissions = new List<string>();
            foreach (string item in checkedListBoxCategories.CheckedItems)
            {
                selectedPermissions.Add(item.Trim());
            }

            var newUser = new User { Username = username, Password = password, Role = role };
            users.Add(newUser);

            var userPermissions = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(userPermissionsFilePath));
            userPermissions[username] = selectedPermissions;

            File.WriteAllText(usersFilePath, JsonConvert.SerializeObject(users, Formatting.Indented));
            File.WriteAllText(userPermissionsFilePath, JsonConvert.SerializeObject(userPermissions, Formatting.Indented));

            ActivityLogger.Log($"Usuário {username} criado com sucesso.", loggedInUser);
            MessageBox.Show("Usuário criado com sucesso!");
            this.Close();
        }

        private void BtnViewUsers_Click(object sender, EventArgs e)
        {
            ViewUsersForm viewUsersForm = new ViewUsersForm(loggedInUser);
            viewUsersForm.ShowDialog();
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