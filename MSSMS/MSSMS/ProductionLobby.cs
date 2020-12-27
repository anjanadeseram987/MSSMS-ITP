using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;


namespace MSSMS
{
    public partial class ProductionLobby : Form
    {
        //utility class objects
        FormStyler formStyler;
        FormHandler formHandler;
        Form activeMainContent = null;

        //Database Handlers
        EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();

        //
        //summery
        //      initializes form stylers and handles when an instance is created
        public ProductionLobby()
        {
            InitializeComponent();
            formStyler = new FormStyler(this);
            formHandler = new FormHandler(this.panelMainContainer);
            SessionManager.currentLobby = this;
        }


        //
        //summery
        //      checks for a session on load. If there is no ongoing session, takes the user back to the login window.
        private void ProductionLobby_Load(object sender, EventArgs e)
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
            //TODO: Complete Tasks function
            btnTasks.Visible = false;
            sm_tasks.Visible = false;
            btnShipping.Visible = false;
            sm_shipping.Visible = false;

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

        //
        //summery
        //      flushes the current session and takes the user back to the login window.
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SessionManager.flushSession();
            this.Close();
        }

        //
        //summery
        //      checks if the user have properly signed out. if not, the application will close. otherwise the login window will appear.
        private void ProductionLobby_FormClosed(object sender, FormClosedEventArgs e)
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


        //
        //summery
        //      Sidebar button methods
        private void btnLobby_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnLobby, null, null);

            //show lobby child form on main UI content panel
            if (activeMainContent == null || activeMainContent.Name != "ProductionLobbyChild")
            {
                activeMainContent = new ProductionLobbyChild();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        //tea products
        private void btnTeaProd_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTeaProd, this.sm_tea, null);
            btnViewTea.PerformClick();
        }

        private void btnViewTea_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTeaProd, this.sm_tea, this.btnViewTea);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageTeaProducts")
            {
                activeMainContent = new ManageTeaProducts(employeeDBHandler);
                formHandler.changeMainContent(activeMainContent);
            }
        }


        private void btnViewTeabgs_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTeaProd, this.sm_tea, this.btnViewTeabgs);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageTeabags")
            {
                activeMainContent = new ManageTeabags();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        //buyer
        private void btnBuyer_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnBuyer, this.sm_buyer, null);
            btnViewOrderItemContents.PerformClick();
        }

        private void btnViewOrderItemContents_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnBuyer, this.sm_buyer, this.btnViewOrderItemContents);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageOrderItemContents")
            {
                activeMainContent = new ManageOrderItemContents();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnBuyers_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnBuyer, this.sm_buyer, this.btnBuyers);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageBuyers")
            {
                activeMainContent = new ManageBuyers();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnBuyer, this.sm_buyer, this.btnBrands);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageBrands")
            {
                activeMainContent = new ManageBrands();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        #region orders
        //orders
        private void btnOrders_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnOrders, this.sm_orders, null);
            btnAddOrder.PerformClick();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnOrders, this.sm_orders, this.btnAddOrder);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "AddNewOrder")
            {
                activeMainContent = new AddNewOrder();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnOrders, this.sm_orders, this.btnViewOrders);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageOrders")
            {
                activeMainContent = new ManageOrders();
                formHandler.changeMainContent(activeMainContent);
            }
        }
        #endregion

        #region tasks
        //tasks
        private void btnTasks_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTasks, this.sm_tasks, null);
            btnAssignTasks.PerformClick();
        }

        private void btnViewTasks_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTasks, this.sm_tasks, this.btnViewTasks);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageTasks")
            {
                activeMainContent = new ManageTasks();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnAssignTasks_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnTasks, this.sm_tasks, this.btnAssignTasks);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageAssignedTasks")
            {
                activeMainContent = new ManageAssignedTasks();
                formHandler.changeMainContent(activeMainContent);
            }
        }
        #endregion

        #region Manufacturing
        //finished goods
        private void btnManufact_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnManufact, this.sm_manufact, null);
            btnViewProductionPlans.PerformClick();
        }

        private void btnViewProductionPlans_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnManufact, this.sm_manufact, this.btnViewProductionPlans);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageProductionPlans")
            {
                activeMainContent = new ManageProductionPlans();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnViewFG_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnManufact, this.sm_manufact, this.btnViewFG);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageManufacturing")
            {
                activeMainContent = new ManageManufacturing();
                formHandler.changeMainContent(activeMainContent);
            }
        }
        #endregion

        #region Storage
        //storage
        private void btnStorage_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnStorage, this.sm_storage, null);
            btnViewSG.PerformClick();
        }

        private void btnViewSG_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnStorage, this.sm_storage, this.btnViewSG);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageStorage")
            {
                activeMainContent = new ManageStorage();
                formHandler.changeMainContent(activeMainContent);
            }
        }
        #endregion

        #region Shipping
        //shipping
        private void btnShipping_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, null);
            btnViewShipG.PerformClick();
        }

        private void btnViewShipG_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, this.btnViewShipG);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageShipping")
            {
                activeMainContent = new ManageShipping();
                formHandler.changeMainContent(activeMainContent);
            }
        }
        #endregion

        #region Machines
        //Machines
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
        #endregion

        #region Reports
        //reports
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
        #endregion

        #region Profile
        //profile
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
        #endregion
    }
}
