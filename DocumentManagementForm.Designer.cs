namespace DocumentosOrtobio
{
    partial class DocumentManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadFiles;
        private System.Windows.Forms.Button btnSaveFiles;
        private System.Windows.Forms.Button btnDeleteFiles;
        private System.Windows.Forms.Button btnClearFiles;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbSubCategory;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboBoxCategorySearch;
        private System.Windows.Forms.ComboBox comboBoxSubCategorySearch;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.ListBox listBoxSubcategories;
        private System.Windows.Forms.Button btnAddSubcategory;
        private System.Windows.Forms.Button btnEditSubcategory;
        private System.Windows.Forms.Button btnDeleteSubcategory;
        private System.Windows.Forms.Button btnUpdateCategories;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentManagementForm));
            this.btnLoadFiles = new System.Windows.Forms.Button();
            this.btnSaveFiles = new System.Windows.Forms.Button();
            this.btnDeleteFiles = new System.Windows.Forms.Button();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboBoxCategorySearch = new System.Windows.Forms.ComboBox();
            this.comboBoxSubCategorySearch = new System.Windows.Forms.ComboBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.listBoxSubcategories = new System.Windows.Forms.ListBox();
            this.btnAddSubcategory = new System.Windows.Forms.Button();
            this.btnEditSubcategory = new System.Windows.Forms.Button();
            this.btnDeleteSubcategory = new System.Windows.Forms.Button();
            this.btnUpdateCategories = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadFiles
            // 
            this.btnLoadFiles.Location = new System.Drawing.Point(21, 12);
            this.btnLoadFiles.Name = "btnLoadFiles";
            this.btnLoadFiles.Size = new System.Drawing.Size(150, 23);
            this.btnLoadFiles.TabIndex = 0;
            this.btnLoadFiles.Text = "Carregar Arquivos";
            this.btnLoadFiles.UseVisualStyleBackColor = true;
            this.btnLoadFiles.Click += new System.EventHandler(this.BtnLoadFiles_Click);
            // 
            // btnSaveFiles
            // 
            this.btnSaveFiles.Location = new System.Drawing.Point(21, 339);
            this.btnSaveFiles.Name = "btnSaveFiles";
            this.btnSaveFiles.Size = new System.Drawing.Size(150, 23);
            this.btnSaveFiles.TabIndex = 4;
            this.btnSaveFiles.Text = "Salvar Arquivos";
            this.btnSaveFiles.UseVisualStyleBackColor = true;
            this.btnSaveFiles.Click += new System.EventHandler(this.BtnSaveFiles_Click);
            // 
            // btnDeleteFiles
            // 
            this.btnDeleteFiles.Location = new System.Drawing.Point(422, 338);
            this.btnDeleteFiles.Name = "btnDeleteFiles";
            this.btnDeleteFiles.Size = new System.Drawing.Size(150, 23);
            this.btnDeleteFiles.TabIndex = 5;
            this.btnDeleteFiles.Text = "Excluir Arquivos";
            this.btnDeleteFiles.UseVisualStyleBackColor = true;
            this.btnDeleteFiles.Click += new System.EventHandler(this.BtnDeleteFiles_Click);
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Location = new System.Drawing.Point(193, 339);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(150, 23);
            this.btnClearFiles.TabIndex = 7;
            this.btnClearFiles.Text = "Limpar Lista de Arquivos";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.BtnClearFiles_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(21, 41);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(322, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.Location = new System.Drawing.Point(21, 68);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(322, 21);
            this.cmbSubCategory.TabIndex = 2;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(21, 95);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(322, 238);
            this.lstFiles.TabIndex = 3;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(422, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 20);
            this.textBoxSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(742, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // comboBoxCategorySearch
            // 
            this.comboBoxCategorySearch.FormattingEnabled = true;
            this.comboBoxCategorySearch.Location = new System.Drawing.Point(422, 41);
            this.comboBoxCategorySearch.Name = "comboBoxCategorySearch";
            this.comboBoxCategorySearch.Size = new System.Drawing.Size(150, 21);
            this.comboBoxCategorySearch.TabIndex = 10;
            // 
            // comboBoxSubCategorySearch
            // 
            this.comboBoxSubCategorySearch.FormattingEnabled = true;
            this.comboBoxSubCategorySearch.Location = new System.Drawing.Point(582, 41);
            this.comboBoxSubCategorySearch.Name = "comboBoxSubCategorySearch";
            this.comboBoxSubCategorySearch.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSubCategorySearch.TabIndex = 11;
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(422, 68);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Size = new System.Drawing.Size(395, 264);
            this.listBoxFiles.TabIndex = 12;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(21, 368);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(114, 23);
            this.btnAddCategory.TabIndex = 13;
            this.btnAddCategory.Text = "Adicionar Categoria";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.BtnAddCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(141, 368);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(100, 23);
            this.btnEditCategory.TabIndex = 14;
            this.btnEditCategory.Text = "Editar Categoria";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.BtnEditCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(247, 368);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(96, 23);
            this.btnDeleteCategory.TabIndex = 20;
            this.btnDeleteCategory.Text = "Excluir Categoria";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.BtnDeleteCategory_Click);
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.Location = new System.Drawing.Point(21, 397);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(322, 238);
            this.listBoxCategories.TabIndex = 15;
            this.listBoxCategories.SelectedIndexChanged += new System.EventHandler(this.ListBoxCategories_SelectedIndexChanged);
            // 
            // listBoxSubcategories
            // 
            this.listBoxSubcategories.FormattingEnabled = true;
            this.listBoxSubcategories.Location = new System.Drawing.Point(422, 397);
            this.listBoxSubcategories.Name = "listBoxSubcategories";
            this.listBoxSubcategories.Size = new System.Drawing.Size(362, 238);
            this.listBoxSubcategories.TabIndex = 16;
            this.listBoxSubcategories.SelectedIndexChanged += new System.EventHandler(this.ListBoxSubcategories_SelectedIndexChanged);
            // 
            // btnAddSubcategory
            // 
            this.btnAddSubcategory.Location = new System.Drawing.Point(422, 368);
            this.btnAddSubcategory.Name = "btnAddSubcategory";
            this.btnAddSubcategory.Size = new System.Drawing.Size(125, 23);
            this.btnAddSubcategory.TabIndex = 17;
            this.btnAddSubcategory.Text = "Adicionar Subcategoria";
            this.btnAddSubcategory.UseVisualStyleBackColor = true;
            this.btnAddSubcategory.Click += new System.EventHandler(this.BtnAddSubcategory_Click);
            // 
            // btnEditSubcategory
            // 
            this.btnEditSubcategory.Location = new System.Drawing.Point(553, 368);
            this.btnEditSubcategory.Name = "btnEditSubcategory";
            this.btnEditSubcategory.Size = new System.Drawing.Size(110, 23);
            this.btnEditSubcategory.TabIndex = 18;
            this.btnEditSubcategory.Text = "Editar Subcategoria";
            this.btnEditSubcategory.UseVisualStyleBackColor = true;
            this.btnEditSubcategory.Click += new System.EventHandler(this.BtnEditSubcategory_Click);
            // 
            // btnDeleteSubcategory
            // 
            this.btnDeleteSubcategory.Location = new System.Drawing.Point(669, 368);
            this.btnDeleteSubcategory.Name = "btnDeleteSubcategory";
            this.btnDeleteSubcategory.Size = new System.Drawing.Size(115, 23);
            this.btnDeleteSubcategory.TabIndex = 21;
            this.btnDeleteSubcategory.Text = "Excluir Subcategoria";
            this.btnDeleteSubcategory.UseVisualStyleBackColor = true;
            this.btnDeleteSubcategory.Click += new System.EventHandler(this.BtnDeleteSubcategory_Click);
            // 
            // btnUpdateCategories
            // 
            this.btnUpdateCategories.Location = new System.Drawing.Point(594, 641);
            this.btnUpdateCategories.Name = "btnUpdateCategories";
            this.btnUpdateCategories.Size = new System.Drawing.Size(150, 23);
            this.btnUpdateCategories.TabIndex = 19;
            this.btnUpdateCategories.Text = "Atualizar Categorias";
            this.btnUpdateCategories.UseVisualStyleBackColor = true;
            this.btnUpdateCategories.Click += new System.EventHandler(this.BtnUpdateCategories_Click);
            // 
            // DocumentManagementForm
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(843, 680);
            this.Controls.Add(this.btnUpdateCategories);
            this.Controls.Add(this.btnDeleteSubcategory);
            this.Controls.Add(this.btnEditSubcategory);
            this.Controls.Add(this.btnAddSubcategory);
            this.Controls.Add(this.listBoxSubcategories);
            this.Controls.Add(this.listBoxCategories);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnEditCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.comboBoxSubCategorySearch);
            this.Controls.Add(this.comboBoxCategorySearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.btnLoadFiles);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbSubCategory);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnSaveFiles);
            this.Controls.Add(this.btnDeleteFiles);
            this.Controls.Add(this.btnClearFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentManagementForm";
            this.Text = "Gerenciamento de Documentos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}