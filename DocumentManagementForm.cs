using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DocumentosOrtobio
{
    public partial class DocumentManagementForm : Form
    {
        private readonly string basePath;
        private readonly string loggedInUser;
        private readonly Dictionary<string, List<string>> categoriesWithSubmenus;
        private readonly string documentsPath = @"\\D4MDP574\Doc Viewer$\Documentos";

        public DocumentManagementForm(string basePath, string loggedInUser, Dictionary<string, List<string>> categoriesWithSubmenus)
        {
            this.basePath = basePath;
            this.loggedInUser = loggedInUser;
            this.categoriesWithSubmenus = categoriesWithSubmenus;
            InitializeComponent();
            InitializeComboBoxes(cmbCategory, cmbSubCategory);
            InitializeComboBoxes(comboBoxCategorySearch, comboBoxSubCategorySearch);
            InitializeCategoryButtons();
            LoadCategoriesFromDirectory();
            LoadCategoriesIntoComboBoxes();
        }

        private void InitializeComboBoxes(ComboBox comboBoxCategory, ComboBox comboBoxSubCategory)
        {
            comboBoxCategory.SelectedIndexChanged += (sender, e) =>
            {
                var selectedCategory = comboBoxCategory.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    UpdateSubCategoryComboBox(comboBoxSubCategory, selectedCategory);
                }
            };
        }

        private void InitializeCategoryButtons()
        {
            btnAddCategory.Click += BtnAddCategory_Click;
            btnEditCategory.Click += BtnEditCategory_Click;
            btnDeleteCategory.Click += BtnDeleteCategory_Click;
            btnAddSubcategory.Click += BtnAddSubcategory_Click;
            btnEditSubcategory.Click += BtnEditSubcategory_Click;
            btnDeleteSubcategory.Click += BtnDeleteSubcategory_Click;
            listBoxCategories.SelectedIndexChanged += ListBoxCategories_SelectedIndexChanged;
            listBoxSubcategories.SelectedIndexChanged += ListBoxSubcategories_SelectedIndexChanged;
            btnUpdateCategories.Click += BtnUpdateCategories_Click;
        }

        private void LoadCategoriesFromDirectory()
        {
            var categoriesWithSubmenus = CategoryManager.LoadCategoriesFromDirectory(documentsPath);
            listBoxCategories.Items.Clear();
            listBoxCategories.Items.AddRange(categoriesWithSubmenus.Keys.ToArray());
        }

        private void LoadSubcategories(string category)
        {
            listBoxSubcategories.Items.Clear();
            var subcategories = CategoryManager.GetSubcategories(category);
            if (subcategories != null)
            {
                listBoxSubcategories.Items.AddRange(subcategories.ToArray());
            }
        }

        private void LoadCategoriesIntoComboBoxes()
        {
            CategoryManager.UpdateComboBoxes(cmbCategory, comboBoxCategorySearch);
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategory = Prompt.ShowDialog("Digite o nome da nova categoria:", "Adicionar Categoria");
            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                CategoryManager.AddCategory(documentsPath, newCategory);
                MessageBox.Show($@"Categoria '{newCategory}' adicionada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivityLogger.Log($"Adicionou a categoria '{newCategory}'", loggedInUser);
                LoadCategoriesFromDirectory();
                LoadCategoriesIntoComboBoxes();
            }
            else
            {
                MessageBox.Show("Categoria inválida ou já existente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategories.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCategory))
            {
                MessageBox.Show("Selecione uma categoria para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newCategoryName = Prompt.ShowDialog("Digite o novo nome da categoria:", "Editar Categoria", selectedCategory);
            if (!string.IsNullOrWhiteSpace(newCategoryName))
            {
                CategoryManager.EditCategory(documentsPath, selectedCategory, newCategoryName);
                MessageBox.Show($"Categoria '{selectedCategory}' renomeada para '{newCategoryName}' com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivityLogger.Log($"Renomeou a categoria '{selectedCategory}' para '{newCategoryName}'", loggedInUser);
                LoadCategoriesFromDirectory();
                LoadCategoriesIntoComboBoxes();
            }
            else
            {
                MessageBox.Show("Categoria inválida ou já existente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategories.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCategory))
            {
                MessageBox.Show("Selecione uma categoria para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Tem certeza de que deseja excluir a categoria '{selectedCategory}' e todas as suas subcategorias?", "Confirmação", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                CategoryManager.DeleteCategory(documentsPath, selectedCategory);
                MessageBox.Show($"Categoria '{selectedCategory}' excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivityLogger.Log($"Excluiu a categoria '{selectedCategory}'", loggedInUser);
                LoadCategoriesFromDirectory();
                LoadCategoriesIntoComboBoxes();
            }
        }

        private void BtnAddSubcategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategories.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCategory))
            {
                MessageBox.Show("Selecione uma categoria para adicionar uma subcategoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newSubcategory = Prompt.ShowDialog("Digite o nome da nova subcategoria:", "Adicionar Subcategoria");
            if (!string.IsNullOrWhiteSpace(newSubcategory))
            {
                CategoryManager.AddSubcategory(documentsPath, selectedCategory, newSubcategory);
                MessageBox.Show($"Subcategoria '{newSubcategory}' adicionada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivityLogger.Log($"Adicionou a subcategoria '{newSubcategory}' na categoria '{selectedCategory}'", loggedInUser);
                LoadSubcategories(selectedCategory);
            }
            else
            {
                MessageBox.Show("Subcategoria inválida ou já existente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditSubcategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategories.SelectedItem?.ToString();
            string selectedSubcategory = listBoxSubcategories.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCategory) || string.IsNullOrWhiteSpace(selectedSubcategory))
            {
                MessageBox.Show("Selecione uma categoria e uma subcategoria para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newSubcategoryName = Prompt.ShowDialog("Digite o novo nome da subcategoria:", "Editar Subcategoria", selectedSubcategory);
            if (!string.IsNullOrWhiteSpace(newSubcategoryName))
            {
                CategoryManager.EditSubcategory(documentsPath, selectedCategory, selectedSubcategory, newSubcategoryName);
                MessageBox.Show($"Subcategoria '{selectedSubcategory}' renomeada para '{newSubcategoryName}' com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivityLogger.Log($"Renomeou a subcategoria '{selectedSubcategory}' para '{newSubcategoryName}' na categoria '{selectedCategory}'", loggedInUser);
                LoadSubcategories(selectedCategory);
            }
            else
            {
                MessageBox.Show("Subcategoria inválida ou já existente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteSubcategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategories.SelectedItem?.ToString();
            string selectedSubcategory = listBoxSubcategories.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCategory) || string.IsNullOrWhiteSpace(selectedSubcategory))
            {
                MessageBox.Show("Selecione uma categoria e uma subcategoria para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Tem certeza de que deseja excluir a subcategoria '{selectedSubcategory}'?", "Confirmação", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                CategoryManager.DeleteSubcategory(documentsPath, selectedCategory, selectedSubcategory);
                MessageBox.Show($"Subcategoria '{selectedSubcategory}' excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivityLogger.Log($"Excluiu a subcategoria '{selectedSubcategory}' na categoria '{selectedCategory}'", loggedInUser);
                LoadSubcategories(selectedCategory);
            }
        }

        private void ListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategories.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedCategory))
            {
                LoadSubcategories(selectedCategory);
            }
        }

        private void ListBoxSubcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementar lógica adicional, se necessário, ao selecionar uma subcategoria
        }

        private void BtnLoadFiles_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lstFiles.Items.Clear();
                    foreach (var file in openFileDialog.FileNames)
                    {
                        lstFiles.Items.Add(file);
                    }
                    ActivityLogger.Log($"Carregou arquivos: {string.Join(", ", openFileDialog.FileNames.Select(Path.GetFileName))}", loggedInUser);
                }
            }
        }

        private void BtnSaveFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedItem == null || cmbSubCategory.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma categoria e uma subcategoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedCategory = cmbCategory.SelectedItem.ToString();
                var selectedSubCategory = cmbSubCategory.SelectedItem.ToString();
                var targetPath = Path.Combine(documentsPath, selectedCategory, selectedSubCategory);

                if (!Directory.Exists(targetPath))
                {
                    MessageBox.Show($"O caminho de destino não existe: {targetPath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var file in lstFiles.Items)
                {
                    var fileName = Path.GetFileName(file.ToString());
                    var destPath = Path.Combine(targetPath, fileName);

                    if (File.Exists(destPath))
                    {
                        var result = MessageBox.Show($"O arquivo '{fileName}' já existe na pasta de destino. Deseja substituí-lo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    File.Copy(file.ToString(), destPath, true);
                }

                ActivityLogger.Log($"Salvou arquivos na categoria '{selectedCategory}' e subcategoria '{selectedSubCategory}'", loggedInUser);
                MessageBox.Show("Arquivos salvos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar arquivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteFiles_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Tem certeza de que deseja excluir os documentos selecionados?", "Confirmação", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (var selectedItem in listBoxFiles.SelectedItems)
                    {
                        var fileName = selectedItem.ToString();
                        var filePath = GetFilePath(fileName);
                        if (filePath != null)
                        {
                            File.Delete(filePath);
                        }
                    }
                    ActivityLogger.Log($"Excluiu documentos: {string.Join(", ", listBoxFiles.SelectedItems.Cast<string>())}", loggedInUser);
                    MessageBox.Show("Documentos excluídos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBoxFiles.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Nenhum documento selecionado para exclusão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearFiles_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            ActivityLogger.Log("Limpou a lista de arquivos.", loggedInUser);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var searchPattern = textBoxSearch.Text;
            var selectedCategory = comboBoxCategorySearch.SelectedItem?.ToString() ?? "All Categories";
            var selectedSubCategory = comboBoxSubCategorySearch.SelectedItem?.ToString() ?? "All Subcategories";

            listBoxFiles.Items.Clear();

            if (selectedCategory == "All Categories")
            {
                foreach (var category in GetCategories())
                {
                    SearchFiles(category, selectedSubCategory, searchPattern, listBoxFiles);
                }
            }
            else
            {
                SearchFiles(selectedCategory, selectedSubCategory, searchPattern, listBoxFiles);
            }

            ActivityLogger.Log($"Realizou pesquisa por '{searchPattern}' na categoria '{selectedCategory}' e subcategoria '{selectedSubCategory}'", loggedInUser);
        }

        private void SearchFiles(string category, string subCategory, string searchPattern, ListBox listBox)
        {
            var categoryPath = Path.Combine(documentsPath, category);

            if (subCategory == "All Subcategories")
            {
                var subCategories = Directory.GetDirectories(categoryPath).Select(Path.GetFileName);
                foreach (var subCat in subCategories)
                {
                    var subCategoryPath = Path.Combine(categoryPath, subCat);
                    string[] files = Directory.GetFiles(subCategoryPath, "*" + searchPattern + "*.*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        listBox.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            else
            {
                var subCategoryPath = Path.Combine(categoryPath, subCategory);
                string[] files = Directory.GetFiles(subCategoryPath, "*" + searchPattern + "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    listBox.Items.Add(Path.GetFileName(file));
                }
            }
        }

        private string GetFilePath(string fileName)
        {
            foreach (var category in GetCategories())
            {
                string categoryPath = Path.Combine(documentsPath, category);
                var files = Directory.GetFiles(categoryPath, fileName, SearchOption.AllDirectories);
                if (files.Any())
                {
                    return files.First();
                }
                foreach (var subCategory in GetSubcategories(category))
                {
                    var subCategoryPath = Path.Combine(categoryPath, subCategory);
                    files = Directory.GetFiles(subCategoryPath, fileName, SearchOption.AllDirectories);
                    if (files.Any())
                    {
                        return files.First();
                    }
                }
            }
            return null;
        }

        private void BtnUpdateCategories_Click(object sender, EventArgs e)
        {
            LoadCategoriesFromDirectory();
            LoadCategoriesIntoComboBoxes();
            MessageBox.Show("Categorias e subcategorias atualizadas com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActivityLogger.Log("Atualizou categorias e subcategorias", loggedInUser);
        }

        private List<string> GetCategories()
        {
            if (Directory.Exists(documentsPath))
            {
                return Directory.GetDirectories(documentsPath).Select(Path.GetFileName).ToList();
            }
            return new List<string>();
        }

        private List<string> GetSubcategories(string category)
        {
            var subCategoryPath = Path.Combine(documentsPath, category);
            if (Directory.Exists(subCategoryPath))
            {
                return Directory.GetDirectories(subCategoryPath).Select(Path.GetFileName).ToList();
            }
            return new List<string>();
        }

        private void UpdateComboBoxes(params ComboBox[] comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                comboBox.Items.Clear();
                var categories = GetCategories();
                comboBox.Items.AddRange(categories.ToArray());
                if (categories.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        private void UpdateSubCategoryComboBox(ComboBox comboBox, string selectedCategory)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("All Subcategories");
            var subcategories = GetSubcategories(selectedCategory);
            if (subcategories != null)
            {
                comboBox.Items.AddRange(subcategories.ToArray());
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = defaultValue };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}