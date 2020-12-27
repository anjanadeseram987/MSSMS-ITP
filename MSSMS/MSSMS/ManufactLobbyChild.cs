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
    public partial class ManufactLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData manufactLobbyData = null;

        public ManufactLobbyChild()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManufactLobbyChild_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStats();
        }

        private void loadStats()
        {
            lblOIP.Text = "[N/A]";
            lblCO.Text = "[N/A]";
            lblCMC.Text = "[N/A]";

            try
            {
                manufactLobbyData = lobbyDBHandler.getManufactLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (manufactLobbyData != null)
            {
                lblOIP.Text = manufactLobbyData.ordersInProgressCount.ToString();
                lblCO.Text = manufactLobbyData.completedOrdersCount.ToString();
                lblCMC.Text = manufactLobbyData.completedMCDuringMonthCount.ToString();
            }
        }
    }
}
