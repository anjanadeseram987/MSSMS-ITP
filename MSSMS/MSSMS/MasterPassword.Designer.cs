namespace MSSMS
{
    partial class MasterPassword
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
            this.panelContents = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.peakPasswords = new System.Windows.Forms.PictureBox();
            this.pictureBoxPWStatus = new System.Windows.Forms.PictureBox();
            this.panelContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakPasswords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPWStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContents
            // 
            this.panelContents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panelContents.Controls.Add(this.peakPasswords);
            this.panelContents.Controls.Add(this.pictureBoxPWStatus);
            this.panelContents.Controls.Add(this.panel2);
            this.panelContents.Controls.Add(this.textBoxPW);
            this.panelContents.Controls.Add(this.btnGo);
            this.panelContents.Controls.Add(this.label1);
            this.panelContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContents.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelContents.Location = new System.Drawing.Point(0, 0);
            this.panelContents.Name = "panelContents";
            this.panelContents.Size = new System.Drawing.Size(793, 347);
            this.panelContents.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Location = new System.Drawing.Point(306, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 2);
            this.panel2.TabIndex = 49;
            // 
            // textBoxPW
            // 
            this.textBoxPW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.textBoxPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPW.Font = new System.Drawing.Font("Ubuntu", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPW.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxPW.Location = new System.Drawing.Point(306, 153);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.PasswordChar = '●';
            this.textBoxPW.Size = new System.Drawing.Size(293, 18);
            this.textBoxPW.TabIndex = 47;
            this.textBoxPW.TextChanged += new System.EventHandler(this.textBoxPW_TextChanged);
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnGo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGo.Location = new System.Drawing.Point(480, 221);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(119, 37);
            this.btnGo.TabIndex = 42;
            this.btnGo.Text = "&Confirm";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(160, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Master Password:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // peakPasswords
            // 
            this.peakPasswords.BackgroundImage = global::MSSMS.Properties.Resources.showpw;
            this.peakPasswords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.peakPasswords.Location = new System.Drawing.Point(433, 223);
            this.peakPasswords.Name = "peakPasswords";
            this.peakPasswords.Size = new System.Drawing.Size(30, 30);
            this.peakPasswords.TabIndex = 50;
            this.peakPasswords.TabStop = false;
            this.peakPasswords.MouseDown += new System.Windows.Forms.MouseEventHandler(this.peakPasswords_MouseDown);
            this.peakPasswords.MouseUp += new System.Windows.Forms.MouseEventHandler(this.peakPasswords_MouseUp);
            // 
            // pictureBoxPWStatus
            // 
            this.pictureBoxPWStatus.BackgroundImage = global::MSSMS.Properties.Resources.closeC;
            this.pictureBoxPWStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxPWStatus.Location = new System.Drawing.Point(605, 153);
            this.pictureBoxPWStatus.Name = "pictureBoxPWStatus";
            this.pictureBoxPWStatus.Size = new System.Drawing.Size(21, 23);
            this.pictureBoxPWStatus.TabIndex = 50;
            this.pictureBoxPWStatus.TabStop = false;
            this.pictureBoxPWStatus.Visible = false;
            // 
            // MasterPassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(793, 347);
            this.Controls.Add(this.panelContents);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MasterPassword";
            this.Text = "MasterPassword";
            this.panelContents.ResumeLayout(false);
            this.panelContents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakPasswords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPWStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContents;
        private System.Windows.Forms.PictureBox peakPasswords;
        private System.Windows.Forms.PictureBox pictureBoxPWStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxPW;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
    }
}