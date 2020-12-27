using MSSMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class ResetUserPasswordSuccess : Form
    {
        private ResetUserPassword resetUserPasswordParent = null;
        private  bool isSuccessful = false;

        public ResetUserPasswordSuccess(Form resetUserPassword, bool isSuccessful)
        {
            InitializeComponent();
            this.resetUserPasswordParent = (ResetUserPassword)resetUserPassword;
            this.isSuccessful = isSuccessful;
        }

        private void ResetUserPasswordSuccess_Load(object sender, EventArgs e)
        {
            resetUserPasswordParent.panelInAppNotifications.Visible = false;
            resetUserPasswordParent.panelHeader.Visible = false;

            if (isSuccessful == true)
            {
                resetUserPasswordParent.Text = "Done";
                pbPRSIcon.BackgroundImage = Resources.tickPR;
                btnPRS.Text = "&Close";
                lblPRSTitle.Text = "Successful";
                lblPRSTitle.ForeColor = Color.FromArgb(255,255, 255);
                lblPRSdesc.Text = "Your password has been successfully updated.\nPlease navigate to the login screen to log back in.";
            }
            else
            {
                resetUserPasswordParent.panelInAppNotifications.Visible = true;
                resetUserPasswordParent.Text = "Done";
                pbPRSIcon.BackgroundImage = Resources.rePR;
                btnPRS.Text = "&Try Again";
                lblPRSTitle.Text = "Failed";
                lblPRSTitle.ForeColor = Color.FromArgb(239, 108, 0);
                lblPRSdesc.Text = "Error occured while resetting the password.\nPlease try again later or contact the administrator.";
            }
        }

        private void btnPRS_Click(object sender, EventArgs e)
        {
            if (isSuccessful == true)
            {
                resetUserPasswordParent.Close();
                resetUserPasswordParent.Dispose();
            }
            else
            {
                resetUserPasswordParent.openVerification();
            }
        }
    }
}
