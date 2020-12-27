using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Utilities;
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
    public partial class ShipLobby : Form
    {

        //utility class objects
        FormStyler formStyler;
        FormHandler formHandler;
        Form activeMainContent = null;

        //Database Handlers
        EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();

        public ShipLobby()
        {
            InitializeComponent();
            formStyler = new FormStyler(this);
            formHandler = new FormHandler(this.panelMainContainer);
            SessionManager.currentLobby = this;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SessionManager.flushSession();
            this.Close();
        }

        private void ShipLobby_Load(object sender, EventArgs e)
        {
            if (SessionManager.sessionState == SessionState.SESSION_ISNOTSET)
            {
                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();
                this.Close();
            }
            else
            {
                //display username/firstname on main UI header
                refreshSessionInfo();
            }

            //hiding unneccessary controls
            //TODO: Implement in later versions
            sm_shipping.Height = 52;
            btnViewShippedGoods.Visible = false;
            btnCargoLoadingMgmt.Visible = false;

            btnLobby.PerformClick();
        }

        public void refreshSessionInfo()
        {
            lblUsername.Text = "@" + SessionManager.user.firstName;
            if (SessionManager.user.profilePicture != null)
            {
                pbDP.BackgroundImage = ImageTools.getImageFromByteArray(SessionManager.user.profilePicture);
            }
        }

        private void ShipLobby_FormClosed(object sender, FormClosedEventArgs e)
        {
            //check session state on form closing
            if (SessionManager.sessionState == SessionState.SESSION_ISNOTSET)
            {
                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnLobby, null, null);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ShipLobbyChild")
            {
                activeMainContent = new ShipLobbyChild();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnShipping_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, null);
            btnViewShipShedules.PerformClick();
        }

        private void btnViewShipShedules_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, this.btnViewShipShedules);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageShippingShedules")
            {
                activeMainContent = new ManageShippingShedules();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnCargoLoadingMgmt_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, this.btnCargoLoadingMgmt);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageCargoLoading")
            {
                activeMainContent = new ManageCargoLoading();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnViewShippedGoods_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, this.btnViewShippedGoods);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageShipping")
            {
                activeMainContent = new ManageShipping();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnReports, this.sm_reports, null);
            btnReqReports.PerformClick();
        }

        private void btnReqReports_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnReports, this.sm_reports, this.btnReqReports);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "RequestReports")
            {
                activeMainContent = new RequestReports();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnProfile, this.sm_profile, null);
            btnViewProfile.PerformClick();
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnProfile, this.sm_profile, this.btnViewProfile);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageProfile")
            {
                activeMainContent = new ManageProfile();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnProfileSecurity_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnProfile, this.sm_profile, this.btnProfileSecurity);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageSecurity")
            {
                activeMainContent = new ManageSecurity();
                formHandler.changeMainContent(activeMainContent);
            }
        }
    }
}
