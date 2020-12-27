using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class ManageUsers : Form
    {
        private UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();
        private List<UserAccount> userAccounts = new List<UserAccount>();
        private String selectedUserId = null;
        private String selectedUserRole = null;

        public ManageUsers()
        {
            InitializeComponent();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadUsers();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "ADMIN")
            {
                this.dataGridUsers.Columns["updateUserAccount"].Visible = false;
                this.dataGridUsers.Columns["deleteUserAccount"].Visible = false;
                this.dataGridUsers.Columns["user_authStatus"].Visible = false;
                this.btnAddUser.Visible = false;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddUser", ChildFormType.ADD, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadUsers();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridUsers.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridUsers.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridUsers.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridUsers.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridUsers.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridUsers.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excellApplication.Columns.AutoFit();
                excellApplication.Visible = true;

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Data Exported.", NotificationStates.SUCCESS);
            }
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Nothing to Export.", NotificationStates.INFORMATION);
            }
        }

        private void dataGridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridUsers.Columns[e.ColumnIndex].Name;

            if (column == "updateUserAccount")
            {
                selectedUserId = dataGridUsers.CurrentRow.Cells["user_empoyeeID"].FormattedValue.ToString();

                foreach (UserAccount userAccount in userAccounts)
                {
                    if (userAccount.employeeId == selectedUserId)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddUser", ChildFormType.UPDATE, userAccount);
                        break;
                    }
                }
            }
            else if (column == "deleteUserAccount")
            {
                selectedUserId = dataGridUsers.CurrentRow.Cells["user_empoyeeID"].FormattedValue.ToString();
                selectedUserRole = dataGridUsers.CurrentRow.Cells["user_role"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                if (selectedUserId == Properties.Settings.Default.DefaultAdmin)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Cannot delete the default admin account.", NotificationStates.ERROR);
                    return;
                }
                else if (selectedUserId == SessionManager.user.employeeId)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Cannot delete the currently logged in account.", NotificationStates.ERROR);
                    return;
                }
                else 
                { 
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show("The selected User Account will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        try
                        {
                            if (userAccountDBHandler.deleteUserAccount(selectedUserId, selectedUserRole) == true)
                            {
                                loadUsers();
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "User Account Deleted Successfully.", NotificationStates.SUCCESS);
                            }
                        }
                        catch (MSSMUIException ex)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                        }
                        catch (Exception ex)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                        }
                    }
                    else
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Deleting cancelled.", NotificationStates.WARNING);
                    }
                }

            }
            else if (column == "user_authStatus")
            {
                selectedUserId = dataGridUsers.CurrentRow.Cells["user_empoyeeID"].FormattedValue.ToString();
                string newAuthStatus = null;

                if (dataGridUsers.CurrentRow.Cells["user_auth"].FormattedValue.ToString() == "NAUTH")
                {
                    newAuthStatus = "AUTH";
                } 
                else if (dataGridUsers.CurrentRow.Cells["user_auth"].FormattedValue.ToString() == "AUTH")
                {
                    newAuthStatus = "NAUTH";
                }
                else
                {
                    newAuthStatus = "NAUTH";
                }

                NotificationManager.hideInAppNotification(panelInAppNotifications);

                if (selectedUserId == Properties.Settings.Default.DefaultAdmin)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Cannot edit authorization status of the default admin account.", NotificationStates.ERROR);
                    return;
                }
                else if (selectedUserId == SessionManager.user.employeeId)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Cannot edit authorization status of currently logged in account.", NotificationStates.ERROR);
                    return;
                }
                else
                {
                    try
                    {
                        if (userAccountDBHandler.modifyUserAccountAuthorizationLevel(newAuthStatus, SessionManager.user.employeeId, selectedUserId) == true)
                        {
                            loadUsers();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Authorization status of " + selectedUserId + " modified successfully.", NotificationStates.SUCCESS);
                        }
                    }
                    catch (MSSMUIException ex)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                    }
                    catch (Exception ex)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                    }
                }
            }
        }

        //load users
        public void loadUsers()
        {
            try
            {
                userAccounts = userAccountDBHandler.getAllUserAccounts();
                dataGridUsers.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (UserAccount userAccount in userAccounts)
                {
                    if(userAccount.authorizationStatus == "NAUTH")
                    {
                        dataGridUsers.Rows.Add(userAccount.employeeId, userAccount.fullName, userAccount.username, userAccount.primaryEmail, userAccount.secondaryEmail, userAccount.role, userAccount.authorizationStatus, userAccount.authorizedBy, "Update", "Delete", "Re-Authorize");
                    }
                    else
                    {
                        dataGridUsers.Rows.Add(userAccount.employeeId, userAccount.fullName, userAccount.username, userAccount.primaryEmail, userAccount.secondaryEmail, userAccount.role, userAccount.authorizationStatus, userAccount.authorizedBy, "Update", "Delete", "De-Authorize");
                    }
                }

            }
            catch (MSSMUIException ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
