namespace EuroleagueApp.UserControls.UCTeams
{
	partial class UCTeamSearch
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
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeams
            // 
            this.dgvTeams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvTeams.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.GridColor = System.Drawing.Color.Orange;
            this.dgvTeams.Location = new System.Drawing.Point(131, 113);
            this.dgvTeams.MultiSelect = false;
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.RowHeadersWidth = 51;
            this.dgvTeams.RowTemplate.Height = 24;
            this.dgvTeams.Size = new System.Drawing.Size(630, 251);
            this.dgvTeams.TabIndex = 0;
            this.dgvTeams.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeams_CellContentClick);
            this.dgvTeams.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTeams_RowHeaderMouseClick);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.ForeColor = System.Drawing.Color.White;
            this.txtBoxSearch.Location = new System.Drawing.Point(404, 3);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(357, 32);
            this.txtBoxSearch.TabIndex = 2;
            this.txtBoxSearch.Text = "Search by name";
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitle.Location = new System.Drawing.Point(56, -4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(276, 39);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Search for Team";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PeachPuff;
            this.label1.Location = new System.Drawing.Point(158, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Team for Team Edit";
            // 
            // UCTeamSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EuroleagueApp.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.dgvTeams);
            this.Name = "UCTeamSearch";
            this.Size = new System.Drawing.Size(898, 599);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.DataGridView dgvTeams;
		private System.Windows.Forms.Label lblTitle;
		public System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label1;
    }
}
