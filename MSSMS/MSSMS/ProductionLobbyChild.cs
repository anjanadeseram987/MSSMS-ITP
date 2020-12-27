using MSSMS.DBHandler;
using MSSMS.Models;
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
    public partial class ProductionLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData productionLobbyData = null;

        public ProductionLobbyChild()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ProductionLobbyChild_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStats();
        }

        private void loadStats()
        {
            lblFinishedOrdersMonth.Text = "[N/A]";
            lblManufacturedMCMonth.Text = "[N/A]";
            lblOrdersInProgress.Text = "[N/A]";
            lblReceivedOrdersMonth.Text = "[N/A]";

            try
            {
                productionLobbyData = lobbyDBHandler.getProductionLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (productionLobbyData != null)
            {
                lblFinishedOrdersMonth.Text = productionLobbyData.completedOrdersDuringMonthCount.ToString();
                lblManufacturedMCMonth.Text = productionLobbyData.completedMCDuringMonthCount.ToString();
                lblOrdersInProgress.Text = productionLobbyData.ordersInProgressCount.ToString();
                lblReceivedOrdersMonth.Text = productionLobbyData.receivedOrdersDuringMonth.ToString();
            }
        }
    }
}
