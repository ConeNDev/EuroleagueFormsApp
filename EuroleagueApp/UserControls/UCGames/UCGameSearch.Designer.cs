namespace EuroleagueApp.UserControls.UCGames
{
    partial class UCGameSearch
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGames = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 39);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Search for a Game";
            this.lblTitle.UseWaitCursor = true;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.ForeColor = System.Drawing.Color.White;
            this.txtBoxSearch.Location = new System.Drawing.Point(390, 57);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(357, 32);
            this.txtBoxSearch.TabIndex = 10;
            this.txtBoxSearch.Text = "Search by Team name";
            this.txtBoxSearch.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(79, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 39);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select Game for Game Edit";
            this.label1.UseWaitCursor = true;
            // 
            // dgvGames
            // 
            this.dgvGames.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Location = new System.Drawing.Point(230, 281);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.RowHeadersWidth = 51;
            this.dgvGames.RowTemplate.Height = 24;
            this.dgvGames.Size = new System.Drawing.Size(630, 217);
            this.dgvGames.TabIndex = 16;
            this.dgvGames.UseWaitCursor = true;
            // 
            // UCGameSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EuroleagueApp.Properties.Resources.Euro_League_MAIN_scaled;
            this.Controls.Add(this.dgvGames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBoxSearch);
            this.Name = "UCGameSearch";
            this.Size = new System.Drawing.Size(898, 599);
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvGames;
    }
}
