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
    public partial class MaintenanceLobby : Form
    {
        //utility class objects
        FormStyler formStyler;
        FormHandler formHandler;
        Form activeMainContent = null;

        //Database Handlers
        MachineryDBHandler employeeDBHandler = new MachineryDBHandler();

        public MaintenanceLobby()
        {
            InitializeComponent();
            formStyler = new FormStyler(this);
            formHandler = new FormHandler(this.panelMainContainer);
            SessionManager.currentLobby = this;
        }

        private void MaintenanceLobby_Load(object sender, EventArgs e)
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

            //hiding sidebuttons of incomplete additional functions
            //TODO: complete maintenance plans functionalities
            sm_maintenance.Height = 52;
            btnManageMaintenance.Visible = false;

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

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SessionManager.flushSession();
            this.Close();
        }

        private void MaintenanceLobby_FormClosed(object sender, FormClosedEventArgs e)
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
            if (activeMainContent == null || activeMainContent.Name != "MaintenanceLobbyChild")
            {
                activeMainContent = new MaintenanceLobbyChild();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnMachines_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnMachines, this.sm_machines, null);
            btnManageMachines.PerformClick();
        }

        private void btnManageMachines_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnMachines, this.sm_machines, this.btnManageMachines);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageMachines")
            {
                activeMainContent = new ManageMachines();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnMaintenance, this.sm_maintenance, null);
            btnManageIssues.PerformClick();
        }

        private void btnManageIssues_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnMaintenance, this.sm_maintenance, this.btnManageIssues);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageIssues")
            {
                activeMainContent = new ManageIssues();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnManageMaintenance_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnMaintenance, this.sm_maintenance, this.btnManageMaintenance);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageMaintenancePlans")
            {
                activeMainContent = new ManageMaintenancePlans();
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
