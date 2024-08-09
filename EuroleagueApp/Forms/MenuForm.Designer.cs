namespace EuroleagueApp.Forms
{
    partial class MenuForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.createPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPlayerToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.createGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.menuStrip1.Size = new System.Drawing.Size(822, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoToolTip = true;
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTeamToolStripMenuItem,
            this.searchTeamToolStripMenuItem,
            this.editTeamToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(68, 0, 68, 0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 32);
            this.toolStripMenuItem1.Text = "Teams";
            // 
            // createTeamToolStripMenuItem
            // 
            this.createTeamToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.createTeamToolStripMenuItem.Name = "createTeamToolStripMenuItem";
            this.createTeamToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.createTeamToolStripMenuItem.Text = "Create Team";
            this.createTeamToolStripMenuItem.Click += new System.EventHandler(this.createTeamToolStripMenuItem_Click);
            // 
            // searchTeamToolStripMenuItem
            // 
            this.searchTeamToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.searchTeamToolStripMenuItem.Name = "searchTeamToolStripMenuItem";
            this.searchTeamToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.searchTeamToolStripMenuItem.Text = "Search Team";
            this.searchTeamToolStripMenuItem.Click += new System.EventHandler(this.searchTeamToolStripMenuItem_Click);
            // 
            // editTeamToolStripMenuItem
            // 
            this.editTeamToolStripMenuItem.Enabled = false;
            this.editTeamToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.editTeamToolStripMenuItem.Name = "editTeamToolStripMenuItem";
            this.editTeamToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.editTeamToolStripMenuItem.Text = "Edit Team";
            this.editTeamToolStripMenuItem.Click += new System.EventHandler(this.editTeamToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPlayerToolStripMenuItem,
            this.searchPlayerToolStripMenuItem,
            this.editPlayerToolStripMenuItem4});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Padding = new System.Windows.Forms.Padding(68, 0, 68, 0);
            this.toolStripMenuItem2.Size = new System.Drawing.Size(220, 32);
            this.toolStripMenuItem2.Text = "Players";
            // 
            // createPlayerToolStripMenuItem
            // 
            this.createPlayerToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.createPlayerToolStripMenuItem.Name = "createPlayerToolStripMenuItem";
            this.createPlayerToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.createPlayerToolStripMenuItem.Text = "Create Player";
            this.createPlayerToolStripMenuItem.Click += new System.EventHandler(this.createPlayerToolStripMenuItem_Click);
            // 
            // searchPlayerToolStripMenuItem
            // 
            this.searchPlayerToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.searchPlayerToolStripMenuItem.Name = "searchPlayerToolStripMenuItem";
            this.searchPlayerToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.searchPlayerToolStripMenuItem.Text = "Search Player";
            this.searchPlayerToolStripMenuItem.Click += new System.EventHandler(this.searchPlayerToolStripMenuItem_Click);
            // 
            // editPlayerToolStripMenuItem4
            // 
            this.editPlayerToolStripMenuItem4.Enabled = false;
            this.editPlayerToolStripMenuItem4.ForeColor = System.Drawing.Color.OrangeRed;
            this.editPlayerToolStripMenuItem4.Name = "editPlayerToolStripMenuItem4";
            this.editPlayerToolStripMenuItem4.Size = new System.Drawing.Size(226, 32);
            this.editPlayerToolStripMenuItem4.Text = "Edit Player";
            this.editPlayerToolStripMenuItem4.Click += new System.EventHandler(this.editPlayerToolStripMenuItem4_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackgroundImage = global::EuroleagueApp.Properties.Resources.maxresdefault4;
            this.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMenu.Location = new System.Drawing.Point(0, 37);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(825, 404);
            this.pnlMenu.TabIndex = 1;
            // 
            // createGameToolStripMenuItem
            // 
            this.createGameToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.createGameToolStripMenuItem.Name = "createGameToolStripMenuItem";
            this.createGameToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.createGameToolStripMenuItem.Text = "Create Game";
            this.createGameToolStripMenuItem.Click += new System.EventHandler(this.createGameToolStripMenuItem_Click);
            // 
            // gameSearchToolStripMenuItem
            // 
            this.gameSearchToolStripMenuItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.gameSearchToolStripMenuItem.Name = "gameSearchToolStripMenuItem";
            this.gameSearchToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.gameSearchToolStripMenuItem.Text = "Game Search";
            this.gameSearchToolStripMenuItem.Click += new System.EventHandler(this.gameSearchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createGameToolStripMenuItem,
            this.gameSearchToolStripMenuItem,
            this.editGameToolStripMenuItem});
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Padding = new System.Windows.Forms.Padding(68, 0, 68, 0);
            this.toolStripMenuItem3.Size = new System.Drawing.Size(215, 32);
            this.toolStripMenuItem3.Text = "Games";
            // 
            // editGameToolStripMenuItem
            // 
            this.editGameToolStripMenuItem.Enabled = false;
            this.editGameToolStripMenuItem.Name = "editGameToolStripMenuItem";
            this.editGameToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.editGameToolStripMenuItem.Text = "Edit Game";
            this.editGameToolStripMenuItem.Click += new System.EventHandler(this.editGameToolStripMenuItem_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 441);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuForm";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
		public System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem createTeamToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchTeamToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem createPlayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchPlayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem editTeamToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMenu;
        public System.Windows.Forms.ToolStripMenuItem editPlayerToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem createGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameSearchToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem editGameToolStripMenuItem;
    }
}