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
    public partial class MgmtLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData mgmtLobbyData = null;

        public MgmtLobbyChild()
        {
            InitializeComponent();
        }

        private void MgmtLobbyChild_Load(object sender, EventArgs e)
        {

            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStats();
        }

        private void loadStats()
        {
            lblPPP.Text = "[N/A]";
            lblPSS.Text = "[N/A]";

            try
            {
                mgmtLobbyData = lobbyDBHandler.getMgmtLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (mgmtLobbyData != null)
            {
                lblPPP.Text = mgmtLobbyData.pendingProductionPlansNA.ToString();
                lblPSS.Text = mgmtLobbyData.pendingShippingSchedulesNA.ToString();
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }
    }
}
