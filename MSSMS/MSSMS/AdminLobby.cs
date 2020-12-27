using MaterialSkin;
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
    public partial class AdminLobby : Form
    {
        //utility class objects
        FormStyler formStyler;
        FormHandler formHandler;
        Form activeMainContent = null;

        //Database Handlers
        EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();

        public AdminLobby()
        {
            InitializeComponent();
            formStyler = new FormStyler(this);
            formHandler = new FormHandler(this.panelMainContainer);
            SessionManager.currentLobby = this;
        }

        private void AdminLobby_Load(object sender, EventArgs e)
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

            //hiding incomplete side menu buttons related to additional functions
            //TODO: Complete Settings function
            btnAppearence.Visible = false;
            btnAbout.Visible = false;
            sm_preferences.Height = 52;
            btnUsageLogs.Visible = false;
            sm_users.Height = 52;

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
            //clear session settings
            SessionManager.flushSession();
            this.Close();
        }

        private void AdminLobby_FormClosed(object sender, FormClosedEventArgs e)
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
            if (activeMainContent == null || activeMainContent.Name != "AdminLobbyChild")
            {
                activeMainContent = new AdminLobbyChild();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnUsers, this.sm_users, null);
            btnManageUsers.PerformClick();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnUsers, sm_users, btnManageUsers);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ManageUsers")
            {
                activeMainContent = new ManageUsers();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnUsageLogs_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnUsers, sm_users, btnUsageLogs);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ManageUserLogs")
            {
                activeMainContent = new ManageUserLogs();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_emps, null);
            btnViewEmployees.PerformClick();
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_emps, this.btnViewEmployees);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ManageEmployees")
            {
                activeMainContent = new ManageEmployees();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnPreferences_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnPreferences, this.sm_preferences, null);
            btnNetwork.PerformClick();
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnPreferences, this.sm_preferences, btnNetwork);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ServerSettings")
            {
                activeMainContent = new ServerSettings();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnAppearence_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnPreferences, this.sm_preferences, btnAppearence);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "AppearanceSettings")
            {
                activeMainContent = new AppearanceSettings();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnPreferences, this.sm_preferences, btnAbout);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "AboutWindow")
            {
                activeMainContent = new AboutWindow();
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

            //show lobby child form on main UI content panel
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

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ManageProfile")
            {
                activeMainContent = new ManageProfile();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnProfileSecurity_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnProfile, this.sm_profile, this.btnProfileSecurity);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ManageSecurity")
            {
                activeMainContent = new ManageSecurity();
                formHandler.changeMainContent(activeMainContent);
            }
        }

    }
}
