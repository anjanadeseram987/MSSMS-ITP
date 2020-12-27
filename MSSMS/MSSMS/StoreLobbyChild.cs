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
    public partial class StoreLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData shippingLobbyData = null;

        public StoreLobbyChild()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void StoreLobbyChild_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStats();
        }

        private void loadStats()
        {
            lblExpiredMCsMonth.Text = "[N/A]";
            lblIssuedMCs.Text = "[N/A]";
            lblStoredMCMonth.Text = "[N/A]";
            lblNearlyExpiredMCMonth.Text = "[N/A]";

            try
            {
                shippingLobbyData = lobbyDBHandler.getStoreLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (shippingLobbyData != null)
            {
                lblExpiredMCsMonth.Text = shippingLobbyData.expiredMCDuringMonthCount.ToString();
                lblStoredMCMonth.Text = shippingLobbyData.storedMCDuringMonthCount.ToString();
                lblNearlyExpiredMCMonth.Text = shippingLobbyData.nearlyExpiredMCDuringMonthCount.ToString();
                lblIssuedMCs.Text = "0";
            }
        }
    }
}
