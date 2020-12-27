using MSSMS.DBHandler;
using MSSMS.Enums;
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
    public partial class AddIssue : Form
    {
        MachineIssue issueToAdd = null;
        MachineIssue issueToUpdate = null;
        MachineryDBHandler machineDBHandler = new MachineryDBHandler();
        List<Machine> allMachines = new List<Machine>();
        Machine selectedMachine = null;
        ChildFormType childType;

        public AddIssue()
        {
            InitializeComponent(); 
            this.childType = FormHandler.childFormType;
            if (this.childType == ChildFormType.UPDATE)
            {
                issueToUpdate = (MachineIssue)FormHandler.newObject;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void AddIssue_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            resetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void resetForm()
        {
            comboBoxPriorityLevel.Items.Clear();
            comboBoxPriorityLevel.Items.Add("Very High");
            comboBoxPriorityLevel.Items.Add("High");
            comboBoxPriorityLevel.Items.Add("Moderate");
            comboBoxPriorityLevel.Items.Add("Low");
            comboBoxPriorityLevel.Items.Add("Very Low");
            comboBoxPriorityLevel.Items.Add("N/A");
            comboBoxPriorityLevel.SelectedItem = "N/A";
            comboBoxMachine.Items.Clear();
            comboBoxMachine.SelectedItem = "\0";
            this.textBoxIssueSubject.Text = "";
            this.textBoxIssueDescription.Text = "";
            selectedMachine = null;

            getAllMachines();

            if (this.childType == ChildFormType.UPDATE)
            {
                this.Text = "Update Machine Issue Details";
                this.lblTitle.Text = "UPDATE " + issueToUpdate.issue_id.ToUpper();
                this.lblDescription.Text = "Please make the neccessary changes and update the selected Issue.";
                this.textBoxIssueSubject.Text = issueToUpdate.subject;
                this.textBoxIssueDescription.Text = issueToUpdate.description;
                this.comboBoxPriorityLevel.SelectedItem = issueToUpdate.priority_level;

                foreach (Machine machine in allMachines)
                {
                    if (string.Equals(issueToUpdate.machine_id, machine.machineId, StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBoxMachine.SelectedItem = machine.machineId + " " + machine.name + " [SERIAL NO: " + machine.serialNumber + "]";
                    }
                }
            }
        }

        private void getAllMachines()
        {
            try
            {
                allMachines = machineDBHandler.getAllMachines();

                foreach (Machine machine in allMachines)
                {
                    comboBoxMachine.Items.Add(machine.machineId + " " + machine.name + " [SERIAL NO: " + machine.serialNumber + "]");
                }
            }
            catch (Exception ex)
            {
                //No locations found
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //front-end validation
            if (string.IsNullOrWhiteSpace(comboBoxMachine.Text) || string.IsNullOrEmpty(comboBoxMachine.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "A Machine should be specified before submitting issues.", NotificationStates.WARNING);
                return;
            }
            else
            {
                foreach (Machine machine in allMachines)
                {
                    if (string.Equals(machine.machineId + " " + machine.name + " [SERIAL NO: " + machine.serialNumber + "]", comboBoxMachine.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedMachine = machine;
                    }
                }

                if (selectedMachine == null)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The selected Machine is not valid.", NotificationStates.WARNING);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(textBoxIssueSubject.Text) || string.IsNullOrEmpty(textBoxIssueSubject.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please mention the Subject of the Issue before submitting.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxIssueDescription.Text) || string.IsNullOrEmpty(textBoxIssueDescription.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please provide a proper description before submitting issues.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxPriorityLevel.Text) || string.IsNullOrEmpty(comboBoxPriorityLevel.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "A priority level should be assigned before submitting issues.", NotificationStates.WARNING);
                return;
            }

            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    issueToAdd = new MachineIssue("", textBoxIssueSubject.Text, selectedMachine.machineId, SessionManager.user.employeeId, DateTime.Now, textBoxIssueDescription.Text, comboBoxPriorityLevel.Text, "Pending");
                    if (machineDBHandler.addMachineIssue(issueToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Issue submitted Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    issueToAdd = new MachineIssue(issueToUpdate.issue_id, textBoxIssueSubject.Text, selectedMachine.machineId, SessionManager.user.employeeId, issueToUpdate.submitted_date, textBoxIssueDescription.Text, comboBoxPriorityLevel.Text, issueToUpdate.status);
                    issueToAdd.machine = selectedMachine;

                    if (machineDBHandler.updateMachineIssue(issueToAdd) == true)
                    {
                        issueToUpdate = issueToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Issue Details Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageIssues")
                {
                    ManageIssues parentForm = (ManageIssues)FormHandler.parentForm;
                    parentForm.loadMachineIssues();
                }

            }
            catch (MSSMUIException ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                return;
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                return;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            comboBoxMachine.SelectedIndex = 0;
            this.textBoxIssueSubject.Text = "Not Usable";
            this.textBoxIssueDescription.Text = "This machine is currently used in critical situations and its faulty. Power goes ON and OFF and sometimes won't even start.";
            comboBoxPriorityLevel.SelectedIndex = 0;
        }
    }
}
