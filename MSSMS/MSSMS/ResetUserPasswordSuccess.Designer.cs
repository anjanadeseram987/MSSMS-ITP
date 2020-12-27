namespace MSSMS
{
    partial class ResetUserPasswordSuccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetUserPasswordSuccess));
            this.panelPRS = new System.Windows.Forms.Panel();
            this.btnPRS = new System.Windows.Forms.Button();
            this.lblPRSdesc = new System.Windows.Forms.Label();
            this.lblPRSTitle = new System.Windows.Forms.Label();
            this.pbPRSIcon = new System.Windows.Forms.PictureBox();
            this.panelPRS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPRSIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPRS
            // 
            this.panelPRS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panelPRS.Controls.Add(this.pbPRSIcon);
            this.panelPRS.Controls.Add(this.btnPRS);
            this.panelPRS.Controls.Add(this.lblPRSdesc);
            this.panelPRS.Controls.Add(this.lblPRSTitle);
            this.panelPRS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPRS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelPRS.Location = new System.Drawing.Point(0, 0);
            this.panelPRS.Name = "panelPRS";
            this.panelPRS.Size = new System.Drawing.Size(793, 422);
            this.panelPRS.TabIndex = 25;
            // 
            // btnPRS
            // 
            this.btnPRS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnPRS.FlatAppearance.BorderSize = 0;
            this.btnPRS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnPRS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnPRS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPRS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPRS.Location = new System.Drawing.Point(510, 257);
            this.btnPRS.Name = "btnPRS";
            this.btnPRS.Size = new System.Drawing.Size(90, 37);
            this.btnPRS.TabIndex = 30;
            this.btnPRS.Text = "&Close";
            this.btnPRS.UseVisualStyleBackColor = false;
            this.btnPRS.Click += new System.EventHandler(this.btnPRS_Click);
            // 
            // lblPRSdesc
            // 
            this.lblPRSdesc.AutoSize = true;
            this.lblPRSdesc.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPRSdesc.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblPRSdesc.Location = new System.Drawing.Point(189, 258);
            this.lblPRSdesc.Name = "lblPRSdesc";
            this.lblPRSdesc.Size = new System.Drawing.Size(304, 36);
            this.lblPRSdesc.TabIndex = 28;
            this.lblPRSdesc.Text = "Your password has been successfully updated. \r\nPlease navigate to the login scree" +
    "n to log back in.";
            this.lblPRSdesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPRSTitle
            // 
            this.lblPRSTitle.AutoSize = true;
            this.lblPRSTitle.Font = new System.Drawing.Font("Ubuntu", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPRSTitle.Location = new System.Drawing.Point(264, 138);
            this.lblPRSTitle.Name = "lblPRSTitle";
            this.lblPRSTitle.Size = new System.Drawing.Size(353, 79);
            this.lblPRSTitle.TabIndex = 28;
            this.lblPRSTitle.Text = "Successful";
            this.lblPRSTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbPRSIcon
            // 
            this.pbPRSIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPRSIcon.BackgroundImage")));
            this.pbPRSIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPRSIcon.Location = new System.Drawing.Point(192, 138);
            this.pbPRSIcon.Name = "pbPRSIcon";
            this.pbPRSIcon.Size = new System.Drawing.Size(78, 79);
            this.pbPRSIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPRSIcon.TabIndex = 31;
            this.pbPRSIcon.TabStop = false;
            // 
            // ResetUserPasswordSuccess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(793, 422);
            this.Controls.Add(this.panelPRS);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(793, 347);
            this.Name = "ResetUserPasswordSuccess";
            this.Text = "ResetUserPasswordSuccess";
            this.Load += new System.EventHandler(this.ResetUserPasswordSuccess_Load);
            this.panelPRS.ResumeLayout(false);
            this.panelPRS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPRSIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPRS;
        private System.Windows.Forms.Button btnPRS;
        private System.Windows.Forms.Label lblPRSdesc;
        private System.Windows.Forms.Label lblPRSTitle;
        private System.Windows.Forms.PictureBox pbPRSIcon;
    }
}