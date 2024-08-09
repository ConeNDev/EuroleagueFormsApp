namespace ClientEuroleague
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(38, 109);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(197, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(38, 186);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(178, 40);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// txtUsername
			// 
			this.txtUsername.BackColor = System.Drawing.Color.OrangeRed;
			this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsername.ForeColor = System.Drawing.Color.White;
			this.txtUsername.Location = new System.Drawing.Point(241, 120);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(192, 30);
			this.txtUsername.TabIndex = 3;
			// 
			// txtPass
			// 
			this.txtPass.BackColor = System.Drawing.Color.OrangeRed;
			this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPass.ForeColor = System.Drawing.Color.White;
			this.txtPass.Location = new System.Drawing.Point(241, 196);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(192, 30);
			this.txtPass.TabIndex = 4;
			this.txtPass.Tag = "";
			// 
			// btnLogin
			// 
			this.btnLogin.BackColor = System.Drawing.Color.OrangeRed;
			this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogin.ForeColor = System.Drawing.Color.White;
			this.btnLogin.Location = new System.Drawing.Point(45, 282);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(388, 58);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Orange;
			this.BackgroundImage = global::EuroleagueApp.Properties.Resources.euroleague;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(896, 467);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LoginForm";
			this.Text = "Euroleague";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

