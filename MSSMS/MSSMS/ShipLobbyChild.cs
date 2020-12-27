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
    public partial class ShipLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData shippingLobbyData = null;

        public ShipLobbyChild()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ShipLobbyChild_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStats();
        }

        private void loadStats()
        {
            lblPendingSchedules.Text = "[N/A]";
            lblSheduledShipments.Text = "[N/A]";
            lblShippedMC.Text = "[N/A]";

            try
            {
                shippingLobbyData = lobbyDBHandler.getShippingLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (shippingLobbyData != null)
            {
                lblPendingSchedules.Text = shippingLobbyData.pendingSchedulesCount.ToString();
                lblSheduledShipments.Text = shippingLobbyData.approvedSchedulesCount.ToString();
                lblShippedMC.Text = "0";
            }
        }
    }
}
