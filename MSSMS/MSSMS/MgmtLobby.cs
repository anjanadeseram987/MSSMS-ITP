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
    public partial class MgmtLobby : Form
    {
        //utility class objects
        FormStyler formStyler;
        FormHandler formHandler;
        Form activeMainContent = null;

        //Database Handlers
        EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();

        public MgmtLobby()
        {
            InitializeComponent();
            formStyler = new FormStyler(this);
            formHandler = new FormHandler(this.panelMainContainer);
            SessionManager.currentLobby = this;
        }

        private void MgmtLobby_Load(object sender, EventArgs e)
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
            btnReviewCargo.Visible = false;
            btnViewShipG.Visible = false;

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

        private void MgmtLobby_FormClosed(object sender, FormClosedEventArgs e)
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
            if (activeMainContent == null || activeMainContent.Name != "ProductionLobbyChild")
            {
                activeMainContent = new ProductionLobbyChild();
                formHandler.changeMainContent(activeMainContent);
            }
        }

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

        private void btnBuyer_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnBuyer, this.sm_buyer, null);
            btnViewBuyers.PerformClick();
        }

        private void btnViewBuyers_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnBuyer, this.sm_buyer, this.btnViewBuyers);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageBuyers")
            {
                activeMainContent = new ManageOrderItemContents();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnOrders, this.sm_orders, null);
            btnViewOrders.PerformClick();
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

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_employees, null);
            btnViewAllEmployees.PerformClick();
        }

        private void btnViewAllEmployees_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_employees, btnViewAllEmployees);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageEmployees")
            {
                activeMainContent = new ManageEmployees();
                formHandler.changeMainContent(activeMainContent);
            }
        }

        private void btnViewDepts_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnEmployees, this.sm_employees, this.btnViewDepts);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageDepts")
            {
                activeMainContent = new ManageDepts();
                formHandler.changeMainContent(activeMainContent);
            }
        }

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

        private void btnShipping_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, null);
            btnShippingSchedules.PerformClick();
        }

        private void btnShippingSchedules_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, this.btnShippingSchedules);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageShippingShedules")
            {
                activeMainContent = new ManageShippingShedules();
                formHandler.changeMainContent(activeMainContent); 
            }
        }

        private void btnReviewCargo_Click(object sender, EventArgs e)
        {
            formStyler.sidebarButton_Click(this.btnShipping, this.sm_shipping, this.btnReviewCargo);

            //show child form
            if (activeMainContent == null || activeMainContent.Name != "ManageCargoLoading")
            {
                activeMainContent = new ManageCargoLoading();
                formHandler.changeMainContent(activeMainContent);
            }
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
