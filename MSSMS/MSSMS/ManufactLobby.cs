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
    public partial class ManufactLobby : Form
    {

        //utility class objects
        FormStyler formStyler;
        FormHandler formHandler;
        Form activeMainContent = null;

        //Database Handlers
        EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();

        public ManufactLobby()
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

        private void ManufactLobby_Load(object sender, EventArgs e)
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

            //hiding tasks -> this is an additional function and is incomplete
            btnTasks.Visible = false;
            sm_tasks.Visible = false;

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

        private void ManufactLobby_FormClosed(object sender, FormClosedEventArgs e)
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
            if (activeMainContent == null || activeMainContent.Name != "ManufactLobbyChild")
            {
                activeMainContent = new ManufactLobbyChild();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTasks, this.sm_tasks, null);
            btnViewTasks.PerformClick();
        }

        private void btnViewTasks_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTasks, this.sm_tasks, this.btnViewTasks);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageAssignedTasks")
            {
                activeMainContent = new ManageAssignedTasks();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnManufact_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnManufact, this.sm_manufact, null);
            btnManageFG.PerformClick();
        }

        private void btnManageFG_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnManufact, this.sm_maintenance, this.btnManageFG);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageManufacturing")
            {
                activeMainContent = new ManageManufacturing();
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

        private void btnViewMachines_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnMaintenance, this.sm_maintenance, this.btnViewMachines);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageMachines")
            {
                activeMainContent = new ManageMachines();
                formHandler.changeMainContent(activeMainContent);
            }
        }
    }
}
