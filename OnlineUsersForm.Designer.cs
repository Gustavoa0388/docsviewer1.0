namespace DocumentosOrtobio
{
    partial class OnlineUsersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxOnlineUsers;
        private System.Windows.Forms.Button btnLogoutUser;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineUsersForm));
            this.listBoxOnlineUsers = new System.Windows.Forms.ListBox();
            this.btnLogoutUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxOnlineUsers
            // 
            this.listBoxOnlineUsers.FormattingEnabled = true;
            this.listBoxOnlineUsers.Location = new System.Drawing.Point(12, 210);
            this.listBoxOnlineUsers.Name = "listBoxOnlineUsers";
            this.listBoxOnlineUsers.Size = new System.Drawing.Size(308, 238);
            this.listBoxOnlineUsers.TabIndex = 0;
            this.listBoxOnlineUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxOnlineUsers_SelectedIndexChanged);
            // 
            // btnLogoutUser
            // 
            this.btnLogoutUser.Location = new System.Drawing.Point(67, 454);
            this.btnLogoutUser.Name = "btnLogoutUser";
            this.btnLogoutUser.Size = new System.Drawing.Size(198, 23);
            this.btnLogoutUser.TabIndex = 1;
            this.btnLogoutUser.Text = "Deslogar Usuário";
            this.btnLogoutUser.UseVisualStyleBackColor = true;
            this.btnLogoutUser.Click += new System.EventHandler(this.BtnLogoutUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(79, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // OnlineUsersForm
            // 
            this.ClientSize = new System.Drawing.Size(332, 509);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogoutUser);
            this.Controls.Add(this.listBoxOnlineUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnlineUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Usuários Online";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}