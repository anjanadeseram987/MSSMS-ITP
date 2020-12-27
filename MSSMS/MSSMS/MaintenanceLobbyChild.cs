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
    public partial class MaintenanceLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData engLobbyData = null;

        public MaintenanceLobbyChild()
        {
            InitializeComponent();
        }

        private void MaintenanceLobbyChild_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStats();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void loadStats()
        {
            lblMachines.Text = "[N/A]";
            lblIssues.Text = "[N/A]";
            lblIssueFixes.Text = "[N/A]";

            try
            {
                engLobbyData = lobbyDBHandler.getEngineerLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (engLobbyData != null)
            {
                lblMachines.Text = engLobbyData.machineCount.ToString();
                lblIssues.Text = engLobbyData.issueCount.ToString();
                lblIssueFixes.Text = engLobbyData.issueFixesCount.ToString();
            }
        }
    }
}
