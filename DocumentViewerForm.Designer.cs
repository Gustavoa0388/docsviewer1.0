namespace DocumentosOrtobio
{
    partial class DocumentViewerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxSearch3;
        private System.Windows.Forms.Button buttonSearch3;
        private System.Windows.Forms.ListBox listBoxFiles3;
        private PdfiumViewer.PdfViewer pdfViewer3;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ComboBox comboBoxCategory3;
        private System.Windows.Forms.ComboBox comboBoxSubCategory3;
        private System.Windows.Forms.Button btnToggleDarkMode;
        private System.Windows.Forms.Button btnVisualizacaoDupla;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentViewerForm));
            this.textBoxSearch3 = new System.Windows.Forms.TextBox();
            this.buttonSearch3 = new System.Windows.Forms.Button();
            this.listBoxFiles3 = new System.Windows.Forms.ListBox();
            this.pdfViewer3 = new PdfiumViewer.PdfViewer();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.comboBoxCategory3 = new System.Windows.Forms.ComboBox();
            this.comboBoxSubCategory3 = new System.Windows.Forms.ComboBox();
            this.btnToggleDarkMode = new System.Windows.Forms.Button();
            this.btnVisualizacaoDupla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSearch3
            // 
            this.textBoxSearch3.Location = new System.Drawing.Point(12, 43);
            this.textBoxSearch3.Name = "textBoxSearch3";
            this.textBoxSearch3.Size = new System.Drawing.Size(126, 20);
            this.textBoxSearch3.TabIndex = 0;
            // 
            // buttonSearch3
            // 
            this.buttonSearch3.Location = new System.Drawing.Point(144, 41);
            this.buttonSearch3.Name = "buttonSearch3";
            this.buttonSearch3.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch3.TabIndex = 2;
            this.buttonSearch3.Text = "Procurar";
            this.buttonSearch3.UseVisualStyleBackColor = true;
            this.buttonSearch3.Click += new System.EventHandler(this.ButtonSearch3_Click);
            // 
            // listBoxFiles3
            // 
            this.listBoxFiles3.FormattingEnabled = true;
            this.listBoxFiles3.Location = new System.Drawing.Point(12, 71);
            this.listBoxFiles3.Name = "listBoxFiles3";
            this.listBoxFiles3.Size = new System.Drawing.Size(300, 888);
            this.listBoxFiles3.TabIndex = 4;
            this.listBoxFiles3.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles3_SelectedIndexChanged);
            // 
            // pdfViewer3
            // 
            this.pdfViewer3.AutoSize = true;
            this.pdfViewer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pdfViewer3.Location = new System.Drawing.Point(329, 71);
            this.pdfViewer3.Name = "pdfViewer3";
            this.pdfViewer3.Size = new System.Drawing.Size(1300, 900);
            this.pdfViewer3.TabIndex = 6;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1797, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 36);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(1544, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(85, 36);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "Configurações";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // comboBoxCategory3
            // 
            this.comboBoxCategory3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory3.FormattingEnabled = true;
            this.comboBoxCategory3.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCategory3.Name = "comboBoxCategory3";
            this.comboBoxCategory3.Size = new System.Drawing.Size(126, 21);
            this.comboBoxCategory3.TabIndex = 11;
            this.comboBoxCategory3.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategory_SelectedIndexChanged);
            // 
            // comboBoxSubCategory3
            // 
            this.comboBoxSubCategory3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubCategory3.FormattingEnabled = true;
            this.comboBoxSubCategory3.Location = new System.Drawing.Point(144, 12);
            this.comboBoxSubCategory3.Name = "comboBoxSubCategory3";
            this.comboBoxSubCategory3.Size = new System.Drawing.Size(126, 21);
            this.comboBoxSubCategory3.TabIndex = 12;
            // 
            // btnToggleDarkMode
            // 
            this.btnToggleDarkMode.Location = new System.Drawing.Point(1716, 12);
            this.btnToggleDarkMode.Name = "btnToggleDarkMode";
            this.btnToggleDarkMode.Size = new System.Drawing.Size(75, 36);
            this.btnToggleDarkMode.TabIndex = 15;
            this.btnToggleDarkMode.Text = "Modo Escuro";
            this.btnToggleDarkMode.UseVisualStyleBackColor = true;
            this.btnToggleDarkMode.Click += new System.EventHandler(this.BtnToggleDarkMode_Click);
            // 
            // btnVisualizacaoDupla
            // 
            this.btnVisualizacaoDupla.Location = new System.Drawing.Point(1635, 12);
            this.btnVisualizacaoDupla.Name = "btnVisualizacaoDupla";
            this.btnVisualizacaoDupla.Size = new System.Drawing.Size(75, 36);
            this.btnVisualizacaoDupla.TabIndex = 16;
            this.btnVisualizacaoDupla.Text = "Visualização Dupla";
            this.btnVisualizacaoDupla.UseVisualStyleBackColor = true;
            this.btnVisualizacaoDupla.Click += new System.EventHandler(this.BtnVisualizacaoDupla_Click);
            // 
            // DocumentViewerForm
            // 
            this.AcceptButton = this.buttonSearch3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 1057);
            this.Controls.Add(this.btnVisualizacaoDupla);
            this.Controls.Add(this.btnToggleDarkMode);
            this.Controls.Add(this.comboBoxSubCategory3);
            this.Controls.Add(this.comboBoxCategory3);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.pdfViewer3);
            this.Controls.Add(this.listBoxFiles3);
            this.Controls.Add(this.buttonSearch3);
            this.Controls.Add(this.textBoxSearch3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocumentViewerForm";
            this.Text = "Visualizador de Documentos - Visualização Simples";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentViewerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}