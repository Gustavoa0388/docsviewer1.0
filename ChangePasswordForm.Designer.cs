namespace DocumentosOrtobio
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.PictureBox pictureBoxLogo; // PictureBox para a logo

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(71, 130);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(70, 13);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "Nova Senha:";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(62, 180);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(88, 13);
            this.lblConfirmPassword.TabIndex = 2;
            this.lblConfirmPassword.Text = "Confirmar Senha:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(24, 150);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(164, 20);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(24, 200);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(164, 20);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(24, 230);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(164, 23);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "Alterar Senha";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(46, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(121, 100);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // ChangePasswordForm
            // 
            this.AcceptButton = this.btnChangePassword;
            this.ClientSize = new System.Drawing.Size(213, 275);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alterar Senha";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}