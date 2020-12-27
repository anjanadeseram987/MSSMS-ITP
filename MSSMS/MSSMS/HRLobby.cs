using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class HRLobby : Form
    {
        //utility class objects
        FormStyler formStyler;
        FormHandler formHandler;
        Form activeMainContent = null;

        Form parentForm = null;

        //Database Handlers
        EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();

        public HRLobby()
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

        private void HRLobby_Load(object sender, EventArgs e)
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

        private void HRLobby_FormClosed(object sender, FormClosedEventArgs e)
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
            if (activeMainContent == null || activeMainContent.Name != "HRLobbyChild")
            {
                activeMainContent = new HRLobbyChild();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_emps, null);
            btnManageEmployees.PerformClick();
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_emps, this.btnManageEmployees);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageEmployees")
            {
                activeMainContent = new ManageEmployees();
                formHandler.changeMainContent(activeMainContent);
            }
        }
        private void btnDepts_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_emps, this.btnDepts);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageDepts")
            {
                activeMainContent = new ManageDepts();
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

        private void btnDesig_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_emps, this.btnDesig);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageDesigs")
            {
                activeMainContent = new ManageDesigs();
                formHandler.changeMainContent(activeMainContent);
            }
        }
    }
}
