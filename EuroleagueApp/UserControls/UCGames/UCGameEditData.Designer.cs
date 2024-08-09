namespace EuroleagueApp.UserControls.UCGames
{
    partial class UCGameEditData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdateGame = new System.Windows.Forms.Button();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.txtAwayTeamPoints = new System.Windows.Forms.TextBox();
            this.txtHomeTeamPoints = new System.Windows.Forms.TextBox();
            this.btnAddStats = new System.Windows.Forms.Button();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmbPlayer = new System.Windows.Forms.ComboBox();
            this.cmbAway = new System.Windows.Forms.ComboBox();
            this.btnShowPlayers = new System.Windows.Forms.Button();
            this.cmbHome = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGameDateTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.dgvPlayersStats = new System.Windows.Forms.DataGridView();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersStats)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateGame
            // 
            this.btnUpdateGame.BackColor = System.Drawing.Color.White;
            this.btnUpdateGame.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateGame.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateGame.Location = new System.Drawing.Point(554, 514);
            this.btnUpdateGame.Name = "btnUpdateGame";
            this.btnUpdateGame.Size = new System.Drawing.Size(210, 60);
            this.btnUpdateGame.TabIndex = 82;
            this.btnUpdateGame.Text = "Update Game";
            this.btnUpdateGame.UseVisualStyleBackColor = false;
            this.btnUpdateGame.Visible = false;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.BackColor = System.Drawing.Color.Transparent;
            this.lbl6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.ForeColor = System.Drawing.Color.White;
            this.lbl6.Location = new System.Drawing.Point(31, 553);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(161, 21);
            this.lbl6.TabIndex = 81;
            this.lbl6.Text = "Away Team Points";
            this.lbl6.Visible = false;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.BackColor = System.Drawing.Color.Transparent;
            this.lbl5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.ForeColor = System.Drawing.Color.White;
            this.lbl5.Location = new System.Drawing.Point(29, 503);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(163, 21);
            this.lbl5.TabIndex = 80;
            this.lbl5.Text = "Home Team Points";
            this.lbl5.Visible = false;
            // 
            // txtAwayTeamPoints
            // 
            this.txtAwayTeamPoints.BackColor = System.Drawing.Color.White;
            this.txtAwayTeamPoints.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAwayTeamPoints.ForeColor = System.Drawing.Color.Black;
            this.txtAwayTeamPoints.Location = new System.Drawing.Point(212, 550);
            this.txtAwayTeamPoints.Name = "txtAwayTeamPoints";
            this.txtAwayTeamPoints.Size = new System.Drawing.Size(75, 28);
            this.txtAwayTeamPoints.TabIndex = 79;
            this.txtAwayTeamPoints.Visible = false;
            this.txtAwayTeamPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoints_KeyPress);
            // 
            // txtHomeTeamPoints
            // 
            this.txtHomeTeamPoints.BackColor = System.Drawing.Color.White;
            this.txtHomeTeamPoints.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHomeTeamPoints.ForeColor = System.Drawing.Color.Black;
            this.txtHomeTeamPoints.Location = new System.Drawing.Point(212, 500);
            this.txtHomeTeamPoints.Name = "txtHomeTeamPoints";
            this.txtHomeTeamPoints.Size = new System.Drawing.Size(75, 28);
            this.txtHomeTeamPoints.TabIndex = 78;
            this.txtHomeTeamPoints.Visible = false;
            this.txtHomeTeamPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoints_KeyPress);
            // 
            // btnAddStats
            // 
            this.btnAddStats.BackColor = System.Drawing.Color.White;
            this.btnAddStats.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStats.ForeColor = System.Drawing.Color.Black;
            this.btnAddStats.Location = new System.Drawing.Point(554, 439);
            this.btnAddStats.Name = "btnAddStats";
            this.btnAddStats.Size = new System.Drawing.Size(196, 35);
            this.btnAddStats.TabIndex = 77;
            this.btnAddStats.Text = "Add statistic";
            this.btnAddStats.UseVisualStyleBackColor = false;
            this.btnAddStats.Visible = false;
            // 
            // txtPoints
            // 
            this.txtPoints.BackColor = System.Drawing.Color.White;
            this.txtPoints.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoints.ForeColor = System.Drawing.Color.Black;
            this.txtPoints.Location = new System.Drawing.Point(722, 393);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(52, 28);
            this.txtPoints.TabIndex = 76;
            this.txtPoints.Visible = false;
            this.txtPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoints_KeyPress);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BackColor = System.Drawing.Color.Transparent;
            this.lbl4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.ForeColor = System.Drawing.Color.White;
            this.lbl4.Location = new System.Drawing.Point(494, 396);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(58, 21);
            this.lbl4.TabIndex = 75;
            this.lbl4.Text = "Points";
            this.lbl4.Visible = false;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BackColor = System.Drawing.Color.Transparent;
            this.lbl3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.Color.White;
            this.lbl3.Location = new System.Drawing.Point(494, 341);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(59, 21);
            this.lbl3.TabIndex = 74;
            this.lbl3.Text = "Player";
            this.lbl3.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(483, 276);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(240, 27);
            this.lbl2.TabIndex = 73;
            this.lbl2.Text = "Add player\'s statistic";
            this.lbl2.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(174, 276);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(454, 27);
            this.lbl1.TabIndex = 72;
            this.lbl1.Text = "Select player to delete or update points";
            this.lbl1.Visible = false;
            // 
            // cmbPlayer
            // 
            this.cmbPlayer.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlayer.ForeColor = System.Drawing.Color.Black;
            this.cmbPlayer.FormattingEnabled = true;
            this.cmbPlayer.Location = new System.Drawing.Point(618, 338);
            this.cmbPlayer.Name = "cmbPlayer";
            this.cmbPlayer.Size = new System.Drawing.Size(156, 29);
            this.cmbPlayer.TabIndex = 71;
            this.cmbPlayer.Visible = false;
            // 
            // cmbAway
            // 
            this.cmbAway.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbAway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAway.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAway.ForeColor = System.Drawing.Color.Black;
            this.cmbAway.FormattingEnabled = true;
            this.cmbAway.Location = new System.Drawing.Point(554, 180);
            this.cmbAway.Name = "cmbAway";
            this.cmbAway.Size = new System.Drawing.Size(196, 29);
            this.cmbAway.TabIndex = 69;
            // 
            // btnShowPlayers
            // 
            this.btnShowPlayers.BackColor = System.Drawing.Color.White;
            this.btnShowPlayers.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPlayers.ForeColor = System.Drawing.Color.Black;
            this.btnShowPlayers.Location = new System.Drawing.Point(293, 219);
            this.btnShowPlayers.Name = "btnShowPlayers";
            this.btnShowPlayers.Size = new System.Drawing.Size(196, 35);
            this.btnShowPlayers.TabIndex = 68;
            this.btnShowPlayers.Text = "Show Game Players";
            this.btnShowPlayers.UseVisualStyleBackColor = false;
            // 
            // cmbHome
            // 
            this.cmbHome.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbHome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHome.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHome.ForeColor = System.Drawing.Color.Black;
            this.cmbHome.FormattingEnabled = true;
            this.cmbHome.Location = new System.Drawing.Point(554, 126);
            this.cmbHome.Name = "cmbHome";
            this.cmbHome.Size = new System.Drawing.Size(196, 29);
            this.cmbHome.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 21);
            this.label3.TabIndex = 66;
            this.label3.Text = "Away Team";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 65;
            this.label1.Text = "Home Team";
            // 
            // txtGameDateTime
            // 
            this.txtGameDateTime.BackColor = System.Drawing.Color.White;
            this.txtGameDateTime.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameDateTime.ForeColor = System.Drawing.Color.Red;
            this.txtGameDateTime.Location = new System.Drawing.Point(554, 74);
            this.txtGameDateTime.Name = "txtGameDateTime";
            this.txtGameDateTime.Size = new System.Drawing.Size(196, 28);
            this.txtGameDateTime.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 21);
            this.label2.TabIndex = 63;
            this.label2.Text = "Game Date Time ( format: MM/dd/yyyy )";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(317, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 34);
            this.lblTitle.TabIndex = 62;
            this.lblTitle.Text = "Edit Game";
            // 
            // dgvStats
            // 
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AllowUserToDeleteRows = false;
            this.dgvStats.BackgroundColor = System.Drawing.Color.LightSalmon;
            this.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStats.Location = new System.Drawing.Point(183, 316);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.RowHeadersWidth = 51;
            this.dgvStats.RowTemplate.Height = 24;
            this.dgvStats.Size = new System.Drawing.Size(445, 162);
            this.dgvStats.TabIndex = 83;
            this.dgvStats.Visible = false;
            // 
            // dgvPlayersStats
            // 
            this.dgvPlayersStats.AllowUserToAddRows = false;
            this.dgvPlayersStats.AllowUserToDeleteRows = false;
            this.dgvPlayersStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayersStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Player,
            this.PlayerPoints,
            this.PlayerId});
            this.dgvPlayersStats.Location = new System.Drawing.Point(29, 316);
            this.dgvPlayersStats.Name = "dgvPlayersStats";
            this.dgvPlayersStats.RowHeadersWidth = 51;
            this.dgvPlayersStats.RowTemplate.Height = 24;
            this.dgvPlayersStats.Size = new System.Drawing.Size(449, 158);
            this.dgvPlayersStats.TabIndex = 84;
            this.dgvPlayersStats.Visible = false;
            // 
            // Player
            // 
            this.Player.HeaderText = "Player";
            this.Player.MinimumWidth = 6;
            this.Player.Name = "Player";
            this.Player.ReadOnly = true;
            this.Player.Width = 125;
            // 
            // PlayerPoints
            // 
            this.PlayerPoints.HeaderText = "PlayerPoints";
            this.PlayerPoints.MinimumWidth = 6;
            this.PlayerPoints.Name = "PlayerPoints";
            this.PlayerPoints.ReadOnly = true;
            this.PlayerPoints.Width = 125;
            // 
            // PlayerId
            // 
            this.PlayerId.HeaderText = "PlayerId";
            this.PlayerId.MinimumWidth = 6;
            this.PlayerId.Name = "PlayerId";
            this.PlayerId.Visible = false;
            this.PlayerId.Width = 125;
            // 
            // UCGameEditData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EuroleagueApp.Properties.Resources.Screenshot_15_22;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.dgvPlayersStats);
            this.Controls.Add(this.dgvStats);
            this.Controls.Add(this.btnUpdateGame);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.txtAwayTeamPoints);
            this.Controls.Add(this.txtHomeTeamPoints);
            this.Controls.Add(this.btnAddStats);
            this.Controls.Add(this.txtPoints);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cmbPlayer);
            this.Controls.Add(this.cmbAway);
            this.Controls.Add(this.btnShowPlayers);
            this.Controls.Add(this.cmbHome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGameDateTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Name = "UCGameEditData";
            this.Size = new System.Drawing.Size(799, 599);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnUpdateGame;
        public System.Windows.Forms.Label lbl6;
        public System.Windows.Forms.Label lbl5;
        public System.Windows.Forms.TextBox txtAwayTeamPoints;
        public System.Windows.Forms.TextBox txtHomeTeamPoints;
        public System.Windows.Forms.Button btnAddStats;
        public System.Windows.Forms.TextBox txtPoints;
        public System.Windows.Forms.Label lbl4;
        public System.Windows.Forms.Label lbl3;
        public System.Windows.Forms.Label lbl2;
        public System.Windows.Forms.Label lbl1;
        public System.Windows.Forms.ComboBox cmbPlayer;
        public System.Windows.Forms.ComboBox cmbAway;
        public System.Windows.Forms.Button btnShowPlayers;
        public System.Windows.Forms.ComboBox cmbHome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtGameDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.DataGridView dgvStats;
        public System.Windows.Forms.DataGridView dgvPlayersStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
    }
}
