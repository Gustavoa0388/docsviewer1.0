namespace DocumentosOrtobio
{
    partial class Viewer1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxSearch1;
        private System.Windows.Forms.TextBox textBoxSearch2;
        private System.Windows.Forms.Button buttonSearch1;
        private System.Windows.Forms.Button buttonSearch2;
        private System.Windows.Forms.ListBox listBoxFiles1;
        private System.Windows.Forms.ListBox listBoxFiles2;
        private PdfiumViewer.PdfViewer pdfViewer1;
        private PdfiumViewer.PdfViewer pdfViewer2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ComboBox comboBoxCategory1;
        private System.Windows.Forms.ComboBox comboBoxCategory2;
        private System.Windows.Forms.ComboBox comboBoxSubCategory1;
        private System.Windows.Forms.ComboBox comboBoxSubCategory2;
        private System.Windows.Forms.Button btnToggleDarkMode;
        private System.Windows.Forms.Button btnVisualizacaoSimples;
        private System.Windows.Forms.Button btnChangePassword; // Novo botão para alterar senha

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer1));
            this.textBoxSearch1 = new System.Windows.Forms.TextBox();
            this.textBoxSearch2 = new System.Windows.Forms.TextBox();
            this.buttonSearch1 = new System.Windows.Forms.Button();
            this.buttonSearch2 = new System.Windows.Forms.Button();
            this.listBoxFiles1 = new System.Windows.Forms.ListBox();
            this.listBoxFiles2 = new System.Windows.Forms.ListBox();
            this.pdfViewer1 = new PdfiumViewer.PdfViewer();
            this.pdfViewer2 = new PdfiumViewer.PdfViewer();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.comboBoxCategory1 = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory2 = new System.Windows.Forms.ComboBox();
            this.comboBoxSubCategory1 = new System.Windows.Forms.ComboBox();
            this.comboBoxSubCategory2 = new System.Windows.Forms.ComboBox();
            this.btnToggleDarkMode = new System.Windows.Forms.Button();
            this.btnVisualizacaoSimples = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSearch1
            // 
            this.textBoxSearch1.Location = new System.Drawing.Point(12, 34);
            this.textBoxSearch1.Name = "textBoxSearch1";
            this.textBoxSearch1.Size = new System.Drawing.Size(130, 20);
            this.textBoxSearch1.TabIndex = 0;
            // 
            // textBoxSearch2
            // 
            this.textBoxSearch2.Location = new System.Drawing.Point(947, 33);
            this.textBoxSearch2.Name = "textBoxSearch2";
            this.textBoxSearch2.Size = new System.Drawing.Size(130, 20);
            this.textBoxSearch2.TabIndex = 1;
            this.textBoxSearch2.TextChanged += new System.EventHandler(this.TextBoxSearch2_TextChanged);
            // 
            // buttonSearch1
            // 
            this.buttonSearch1.Location = new System.Drawing.Point(151, 35);
            this.buttonSearch1.Name = "buttonSearch1";
            this.buttonSearch1.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch1.TabIndex = 2;
            this.buttonSearch1.Text = "Procurar";
            this.buttonSearch1.UseVisualStyleBackColor = true;
            this.buttonSearch1.Click += new System.EventHandler(this.ButtonSearch1_Click);
            // 
            // buttonSearch2
            // 
            this.buttonSearch2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSearch2.Location = new System.Drawing.Point(1085, 34);
            this.buttonSearch2.Name = "buttonSearch2";
            this.buttonSearch2.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch2.TabIndex = 3;
            this.buttonSearch2.Text = "Procurar";
            this.buttonSearch2.UseVisualStyleBackColor = true;
            this.buttonSearch2.Click += new System.EventHandler(this.ButtonSearch2_Click);
            // 
            // listBoxFiles1
            // 
            this.listBoxFiles1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.listBoxFiles1.FormattingEnabled = true;
            this.listBoxFiles1.HorizontalScrollbar = true;
            this.listBoxFiles1.Location = new System.Drawing.Point(11, 64);
            this.listBoxFiles1.Name = "listBoxFiles1";
            this.listBoxFiles1.Size = new System.Drawing.Size(221, 914);
            this.listBoxFiles1.TabIndex = 4;
            this.listBoxFiles1.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles1_SelectedIndexChanged);
            // 
            // listBoxFiles2
            // 
            this.listBoxFiles2.FormattingEnabled = true;
            this.listBoxFiles2.HorizontalScrollbar = true;
            this.listBoxFiles2.Location = new System.Drawing.Point(947, 63);
            this.listBoxFiles2.Name = "listBoxFiles2";
            this.listBoxFiles2.Size = new System.Drawing.Size(213, 914);
            this.listBoxFiles2.TabIndex = 5;
            this.listBoxFiles2.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles2_SelectedIndexChanged);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.AutoSize = true;
            this.pdfViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pdfViewer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pdfViewer1.Location = new System.Drawing.Point(238, 64);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(700, 915);
            this.pdfViewer1.TabIndex = 6;
            this.pdfViewer1.Load += new System.EventHandler(this.pdfViewer1_Load);
            // 
            // pdfViewer2
            // 
            this.pdfViewer2.AutoSize = true;
            this.pdfViewer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pdfViewer2.Location = new System.Drawing.Point(1168, 63);
            this.pdfViewer2.Name = "pdfViewer2";
            this.pdfViewer2.Size = new System.Drawing.Size(700, 910);
            this.pdfViewer2.TabIndex = 7;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1796, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 36);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(1543, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(85, 36);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "Configurações";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // comboBoxCategory1
            // 
            this.comboBoxCategory1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory1.FormattingEnabled = true;
            this.comboBoxCategory1.Location = new System.Drawing.Point(12, 6);
            this.comboBoxCategory1.Name = "comboBoxCategory1";
            this.comboBoxCategory1.Size = new System.Drawing.Size(130, 21);
            this.comboBoxCategory1.TabIndex = 10;
            this.comboBoxCategory1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategory_SelectedIndexChanged);
            // 
            // comboBoxCategory2
            // 
            this.comboBoxCategory2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory2.FormattingEnabled = true;
            this.comboBoxCategory2.Location = new System.Drawing.Point(947, 5);
            this.comboBoxCategory2.Name = "comboBoxCategory2";
            this.comboBoxCategory2.Size = new System.Drawing.Size(130, 21);
            this.comboBoxCategory2.TabIndex = 11;
            this.comboBoxCategory2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategory_SelectedIndexChanged);
            // 
            // comboBoxSubCategory1
            // 
            this.comboBoxSubCategory1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubCategory1.FormattingEnabled = true;
            this.comboBoxSubCategory1.Location = new System.Drawing.Point(151, 6);
            this.comboBoxSubCategory1.Name = "comboBoxSubCategory1";
            this.comboBoxSubCategory1.Size = new System.Drawing.Size(130, 21);
            this.comboBoxSubCategory1.TabIndex = 12;
            this.comboBoxSubCategory1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubCategory1_SelectedIndexChanged);
            // 
            // comboBoxSubCategory2
            // 
            this.comboBoxSubCategory2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubCategory2.FormattingEnabled = true;
            this.comboBoxSubCategory2.Location = new System.Drawing.Point(1085, 5);
            this.comboBoxSubCategory2.Name = "comboBoxSubCategory2";
            this.comboBoxSubCategory2.Size = new System.Drawing.Size(130, 21);
            this.comboBoxSubCategory2.TabIndex = 13;
            this.comboBoxSubCategory2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubCategory2_SelectedIndexChanged);
            // 
            // btnToggleDarkMode
            // 
            this.btnToggleDarkMode.Location = new System.Drawing.Point(1715, 12);
            this.btnToggleDarkMode.Name = "btnToggleDarkMode";
            this.btnToggleDarkMode.Size = new System.Drawing.Size(75, 36);
            this.btnToggleDarkMode.TabIndex = 14;
            this.btnToggleDarkMode.Text = "Modo Escuro";
            this.btnToggleDarkMode.UseVisualStyleBackColor = true;
            this.btnToggleDarkMode.Click += new System.EventHandler(this.BtnToggleDarkMode_Click);
            // 
            // btnVisualizacaoSimples
            // 
            this.btnVisualizacaoSimples.Location = new System.Drawing.Point(1634, 12);
            this.btnVisualizacaoSimples.Name = "btnVisualizacaoSimples";
            this.btnVisualizacaoSimples.Size = new System.Drawing.Size(75, 36);
            this.btnVisualizacaoSimples.TabIndex = 15;
            this.btnVisualizacaoSimples.Text = "Visualização Simples";
            this.btnVisualizacaoSimples.UseVisualStyleBackColor = true;
            this.btnVisualizacaoSimples.Click += new System.EventHandler(this.BtnVisualizacaoSimples_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(1553, 12);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(75, 36);
            this.btnChangePassword.TabIndex = 16;
            this.btnChangePassword.Text = "Alterar Senha";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // Viewer1
            // 
            this.AcceptButton = this.buttonSearch1;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1883, 1061);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnVisualizacaoSimples);
            this.Controls.Add(this.btnToggleDarkMode);
            this.Controls.Add(this.comboBoxSubCategory2);
            this.Controls.Add(this.comboBoxSubCategory1);
            this.Controls.Add(this.comboBoxCategory2);
            this.Controls.Add(this.comboBoxCategory1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.pdfViewer2);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.listBoxFiles2);
            this.Controls.Add(this.listBoxFiles1);
            this.Controls.Add(this.buttonSearch2);
            this.Controls.Add(this.buttonSearch1);
            this.Controls.Add(this.textBoxSearch2);
            this.Controls.Add(this.textBoxSearch1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Viewer1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador de Documentos - Visualização Dupla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}