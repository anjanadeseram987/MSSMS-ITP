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
    public partial class HRLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData hrLobbyData = null;

        public HRLobbyChild()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void HRLobbyChild_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStats();
        }

        private void loadStats()
        {
            lblDepts.Text = "[N/A]";
            lblDesigs.Text = "[N/A]";
            lblEmps.Text = "[N/A]";

            try
            {
                hrLobbyData = lobbyDBHandler.getHRLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (hrLobbyData != null)
            {
                lblDepts.Text = hrLobbyData.deptCount.ToString();
                lblDesigs.Text = hrLobbyData.desigCount.ToString();
                lblEmps.Text = hrLobbyData.employeeCount.ToString();
            }
        }
    }
}
