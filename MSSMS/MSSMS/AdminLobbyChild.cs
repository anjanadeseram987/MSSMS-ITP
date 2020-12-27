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
    public partial class AdminLobbyChild : Form
    {
        LobbyDBHandler lobbyDBHandler = new LobbyDBHandler();
        LobbyData adminLobbyData = null;

        public AdminLobbyChild()
        {
            InitializeComponent();
        }

        private void AdminLobbyChild_Load(object sender, EventArgs e)
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
            lblUA.Text = "[N/A]";
            lblUUA.Text = "[N/A]";
            lblEMP.Text = "[N/A]";

            try
            {
                adminLobbyData = lobbyDBHandler.getAdminLobbyData();
            }
            catch (Exception)
            {
                //do nothing
            }

            if (adminLobbyData != null)
            {
                lblUA.Text = adminLobbyData.userAccountCount.ToString();
                lblUUA.Text = adminLobbyData.unauthorizedUACount.ToString();
                lblEMP.Text = adminLobbyData.employeeCount.ToString();
            }
        }
    }
}
