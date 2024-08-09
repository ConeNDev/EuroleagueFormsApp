namespace ServerEuroleague
{
    partial class ServerForm
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
			this.lblStanje = new System.Windows.Forms.Label();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblStanje
			// 
			this.lblStanje.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblStanje.AutoSize = true;
			this.lblStanje.BackColor = System.Drawing.Color.Transparent;
			this.lblStanje.Font = new System.Drawing.Font("Century Gothic", 22.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStanje.ForeColor = System.Drawing.Color.White;
			this.lblStanje.Location = new System.Drawing.Point(386, 157);
			this.lblStanje.Name = "lblStanje";
			this.lblStanje.Size = new System.Drawing.Size(409, 46);
			this.lblStanje.TabIndex = 8;
			this.lblStanje.Text = "Server nije pokrenut!";
			// 
			// btnStop
			// 
			this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnStop.BackColor = System.Drawing.Color.OrangeRed;
			this.btnStop.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStop.ForeColor = System.Drawing.Color.White;
			this.btnStop.Location = new System.Drawing.Point(483, 262);
			this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(158, 76);
			this.btnStop.TabIndex = 7;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = false;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnStart.BackColor = System.Drawing.Color.OrangeRed;
			this.btnStart.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStart.ForeColor = System.Drawing.Color.White;
			this.btnStart.Location = new System.Drawing.Point(236, 262);
			this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(158, 76);
			this.btnStart.TabIndex = 6;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 22.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(69, 157);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(294, 46);
			this.label1.TabIndex = 9;
			this.label1.Text = "Status servera:";
			// 
			// ServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackgroundImage = global::ServerEuroleague.Properties.Resources.bg_31;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(884, 496);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblStanje);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Name = "ServerForm";
			this.Text = "ServerForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStanje;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
    }
}