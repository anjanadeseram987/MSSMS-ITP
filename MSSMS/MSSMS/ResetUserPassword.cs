using MSSMS.DBHandler;
using System;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class ResetUserPassword : Form
    {
        public LoginHandler loginHandler = null;

        public ResetUserPassword(LoginHandler loginHandler)
        {
            InitializeComponent();
            this.loginHandler = loginHandler;
        }

        private void ResetUserPassword_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
            openVerification();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        public void openVerification()
        {
            FormHandler formHandler = new FormHandler(panelPRContainer);
            formHandler.changeMainContent(new ResetUserPasswordVerification(this));
        }

        public void openUpdate(string email)
        {
            FormHandler formHandler = new FormHandler(panelPRContainer);
            formHandler.changeMainContent(new ResetUserPasswordNewPassword(this, email));
        }

        public void openSuccess(bool isSuccessful)
        {
            FormHandler formHandler = new FormHandler(panelPRContainer);
            formHandler.changeMainContent(new ResetUserPasswordSuccess(this, isSuccessful));
        }
    }
}
