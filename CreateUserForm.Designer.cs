namespace DocumentosOrtobio
{
    partial class CreateUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnViewUsers;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategories;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblCategories;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserForm));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnViewUsers = new System.Windows.Forms.Button();
            this.checkedListBoxCategories = new System.Windows.Forms.CheckedListBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(229, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(189, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(229, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(189, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "admin",
            "user"});
            this.cmbRole.Location = new System.Drawing.Point(229, 103);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(189, 21);
            this.cmbRole.TabIndex = 2;
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(23, 229);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(189, 23);
            this.btnCreateUser.TabIndex = 3;
            this.btnCreateUser.Text = "Criar Usuário";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.BtnCreateUser_Click);
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.Location = new System.Drawing.Point(23, 258);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(189, 23);
            this.btnViewUsers.TabIndex = 4;
            this.btnViewUsers.Text = "Visualizar Usuários";
            this.btnViewUsers.UseVisualStyleBackColor = true;
            this.btnViewUsers.Click += new System.EventHandler(this.BtnViewUsers_Click);
            // 
            // checkedListBoxCategories
            // 
            this.checkedListBoxCategories.FormattingEnabled = true;
            this.checkedListBoxCategories.Location = new System.Drawing.Point(232, 150);
            this.checkedListBoxCategories.Name = "checkedListBoxCategories";
            this.checkedListBoxCategories.Size = new System.Drawing.Size(189, 289);
            this.checkedListBoxCategories.TabIndex = 5;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(229, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(229, 48);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(229, 87);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(29, 13);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Role";
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(229, 132);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(57, 13);
            this.lblCategories.TabIndex = 9;
            this.lblCategories.Text = "Categories";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // CreateUserForm
            // 
            this.AcceptButton = this.btnCreateUser;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 454);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.checkedListBoxCategories);
            this.Controls.Add(this.btnViewUsers);
            this.Controls.Add(this.btnCreateUser);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Usuário";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}