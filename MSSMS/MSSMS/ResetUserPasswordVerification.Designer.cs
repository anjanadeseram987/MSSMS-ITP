namespace MSSMS
{
    partial class ResetUserPasswordVerification
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
            this.panelPRS = new System.Windows.Forms.Panel();
            this.pictureBoxTokenStatus = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmailStatus = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxResetToken = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerifyToken = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendToken = new System.Windows.Forms.Button();
            this.lblTokenValidity = new System.Windows.Forms.Label();
            this.timerTokenCountdown = new System.Windows.Forms.Timer(this.components);
            this.lblReconnect = new System.Windows.Forms.LinkLabel();
            this.panelPRS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTokenStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmailStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPRS
            // 
            this.panelPRS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panelPRS.Controls.Add(this.lblReconnect);
            this.panelPRS.Controls.Add(this.pictureBoxTokenStatus);
            this.panelPRS.Controls.Add(this.pictureBoxEmailStatus);
            this.panelPRS.Controls.Add(this.panel1);
            this.panelPRS.Controls.Add(this.panel2);
            this.panelPRS.Controls.Add(this.textBoxResetToken);
            this.panelPRS.Controls.Add(this.textBoxEmail);
            this.panelPRS.Controls.Add(this.label2);
            this.panelPRS.Controls.Add(this.btnVerifyToken);
            this.panelPRS.Controls.Add(this.label1);
            this.panelPRS.Controls.Add(this.btnSendToken);
            this.panelPRS.Controls.Add(this.lblTokenValidity);
            this.panelPRS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPRS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelPRS.Location = new System.Drawing.Point(0, 0);
            this.panelPRS.Name = "panelPRS";
            this.panelPRS.Size = new System.Drawing.Size(793, 347);
            this.panelPRS.TabIndex = 26;
            // 
            // pictureBoxTokenStatus
            // 
            this.pictureBoxTokenStatus.BackgroundImage = global::MSSMS.Properties.Resources.closeC;
            this.pictureBoxTokenStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxTokenStatus.Location = new System.Drawing.Point(478, 217);
            this.pictureBoxTokenStatus.Name = "pictureBoxTokenStatus";
            this.pictureBoxTokenStatus.Size = new System.Drawing.Size(21, 28);
            this.pictureBoxTokenStatus.TabIndex = 40;
            this.pictureBoxTokenStatus.TabStop = false;
            // 
            // pictureBoxEmailStatus
            // 
            this.pictureBoxEmailStatus.BackgroundImage = global::MSSMS.Properties.Resources.closeC;
            this.pictureBoxEmailStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEmailStatus.Location = new System.Drawing.Point(478, 97);
            this.pictureBoxEmailStatus.Name = "pictureBoxEmailStatus";
            this.pictureBoxEmailStatus.Size = new System.Drawing.Size(21, 28);
            this.pictureBoxEmailStatus.TabIndex = 40;
            this.pictureBoxEmailStatus.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(262, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 2);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Location = new System.Drawing.Point(262, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 2);
            this.panel2.TabIndex = 39;
            // 
            // textBoxResetToken
            // 
            this.textBoxResetToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.textBoxResetToken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResetToken.Font = new System.Drawing.Font("Ubuntu", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResetToken.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxResetToken.Location = new System.Drawing.Point(262, 217);
            this.textBoxResetToken.Name = "textBoxResetToken";
            this.textBoxResetToken.Size = new System.Drawing.Size(210, 18);
            this.textBoxResetToken.TabIndex = 35;
            this.textBoxResetToken.TextChanged += new System.EventHandler(this.textBoxResetToken_TextChanged);
            this.textBoxResetToken.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxResetToken_KeyDown);
            this.textBoxResetToken.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxResetToken_KeyPress);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Font = new System.Drawing.Font("Ubuntu", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxEmail.Location = new System.Drawing.Point(262, 97);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(210, 18);
            this.textBoxEmail.TabIndex = 35;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            this.textBoxEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEmail_KeyDown);
            this.textBoxEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEmail_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(160, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Reset Token:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVerifyToken
            // 
            this.btnVerifyToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnVerifyToken.FlatAppearance.BorderSize = 0;
            this.btnVerifyToken.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnVerifyToken.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnVerifyToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifyToken.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerifyToken.Location = new System.Drawing.Point(505, 209);
            this.btnVerifyToken.Name = "btnVerifyToken";
            this.btnVerifyToken.Size = new System.Drawing.Size(119, 37);
            this.btnVerifyToken.TabIndex = 30;
            this.btnVerifyToken.Text = "&Verify Token";
            this.btnVerifyToken.UseVisualStyleBackColor = false;
            this.btnVerifyToken.Click += new System.EventHandler(this.btnVerifyToken_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(160, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Email Address:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSendToken
            // 
            this.btnSendToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSendToken.FlatAppearance.BorderSize = 0;
            this.btnSendToken.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSendToken.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnSendToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToken.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendToken.Location = new System.Drawing.Point(505, 89);
            this.btnSendToken.Name = "btnSendToken";
            this.btnSendToken.Size = new System.Drawing.Size(119, 37);
            this.btnSendToken.TabIndex = 30;
            this.btnSendToken.Text = "&Send New Token";
            this.btnSendToken.UseVisualStyleBackColor = false;
            this.btnSendToken.Click += new System.EventHandler(this.btnPRS_Click);
            // 
            // lblTokenValidity
            // 
            this.lblTokenValidity.AutoSize = true;
            this.lblTokenValidity.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokenValidity.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblTokenValidity.Location = new System.Drawing.Point(259, 253);
            this.lblTokenValidity.Name = "lblTokenValidity";
            this.lblTokenValidity.Size = new System.Drawing.Size(164, 18);
            this.lblTokenValidity.TabIndex = 28;
            this.lblTokenValidity.Text = "Token Valid for: Unknown";
            this.lblTokenValidity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerTokenCountdown
            // 
            this.timerTokenCountdown.Interval = 500;
            this.timerTokenCountdown.Tick += new System.EventHandler(this.timerTokenCountdown_Tick);
            // 
            // lblReconnect
            // 
            this.lblReconnect.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblReconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblReconnect.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblReconnect.Location = new System.Drawing.Point(642, 297);
            this.lblReconnect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReconnect.Name = "lblReconnect";
            this.lblReconnect.Size = new System.Drawing.Size(110, 17);
            this.lblReconnect.TabIndex = 41;
            this.lblReconnect.TabStop = true;
            this.lblReconnect.Text = "Reconnect";
            this.lblReconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblReconnect.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReconnect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReconnect_LinkClicked);
            // 
            // ResetUserPasswordVerification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(793, 347);
            this.Controls.Add(this.panelPRS);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResetUserPasswordVerification";
            this.Text = "ResetUserPasswordVerification";
            this.Load += new System.EventHandler(this.ResetUserPasswordVerification_Load);
            this.panelPRS.ResumeLayout(false);
            this.panelPRS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTokenStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmailStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPRS;
        private System.Windows.Forms.Button btnSendToken;
        private System.Windows.Forms.Label lblTokenValidity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxResetToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVerifyToken;
        private System.Windows.Forms.PictureBox pictureBoxTokenStatus;
        private System.Windows.Forms.PictureBox pictureBoxEmailStatus;
        private System.Windows.Forms.Timer timerTokenCountdown;
        private System.Windows.Forms.LinkLabel lblReconnect;
    }
}