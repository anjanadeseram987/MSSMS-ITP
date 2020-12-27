using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;

namespace MSSMS
{
    public partial class AddMachines : Form
    {
        Machine machineToAdd = null;
        Machine machineToUpdate = null;
        MachineryDBHandler machineDBHandler = new MachineryDBHandler();
        List<Location> allLocations = new List<Location>();
        ChildFormType childType;

        public AddMachines()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
            if (this.childType == ChildFormType.UPDATE)
            {
                machineToUpdate = (Machine)FormHandler.newObject;
            }
        }

        private void AddMachines_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            resetForm();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void resetForm()
        {
            comboBoxLocation.Items.Clear();
            comboBoxWorkingState.Items.Clear();

            comboBoxWorkingState.Items.Clear();
            comboBoxWorkingState.Items.Add("Working");
            comboBoxWorkingState.Items.Add("Not Working");
            comboBoxWorkingState.SelectedItem = "\0";


            comboBoxLocation.Items.Clear();
            comboBoxLocation.SelectedItem = "\0";
            this.textBoxSerialNumber.Text = "";
            this.textBoxMachineName.Text = "";
            this.textBoxDescription.Text = "";

            getAlllocations();

            if (this.childType == ChildFormType.UPDATE)
            {
                this.Text = "Update Machine Details";
                this.btnSave.Text = "Update Machine";
                this.lblTitle.Text = "UPDATE " + machineToUpdate.machineId.ToUpper();
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected Machine.";
                this.textBoxSerialNumber.Text = machineToUpdate.serialNumber;
                this.textBoxMachineName.Text = machineToUpdate.name;
                this.comboBoxWorkingState.SelectedItem = machineToUpdate.workingState;
                this.textBoxDescription.Text = machineToUpdate.description;

                foreach (Location location in allLocations)
                {
                    if (string.Equals(machineToUpdate.locationId, location.location_id, StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBoxLocation.SelectedItem = location.location_id + " " + location.location_name;
                    }
                }
            }
        }

        private void getAlllocations()
        {
            try
            {
                allLocations = machineDBHandler.getAvailableLocations();

                foreach (Location location in allLocations)
                {
                    comboBoxLocation.Items.Add(location.location_id + " " + location.location_name);
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
            if (string.IsNullOrWhiteSpace(textBoxSerialNumber.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Serial Number Fields cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxMachineName.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Name Fields cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxLocation.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Location cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxWorkingState.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Working State cannot be empty.", NotificationStates.WARNING);
                return;
            }

            String selectedLocationId = null;

            foreach (Location location in allLocations)
            {
                if (string.Equals(location.location_id + " " + location.location_name, comboBoxLocation.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedLocationId = location.location_id;
                }
            }


            try
            {

                if (this.childType == ChildFormType.ADD)
                {
                    machineToAdd = new Machine(selectedLocationId, textBoxSerialNumber.Text, textBoxMachineName.Text, comboBoxWorkingState.Text, SessionManager.user.employeeId, DateTime.Now, textBoxDescription.Text);

                    //add new employee
                    if (machineDBHandler.addMachine(machineToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    //update
                    machineToAdd = new Machine(machineToUpdate.machineId, textBoxSerialNumber.Text, textBoxMachineName.Text, selectedLocationId, comboBoxWorkingState.Text, textBoxDescription.Text);
                    //update employee
                    if (machineDBHandler.updateMachine(machineToAdd) == true)
                    {

                        machineToUpdate = machineToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Details Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageMachines")
                {
                    ManageMachines parentForm = (ManageMachines)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadMachines();
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
            textBoxSerialNumber.Text = "23";
            textBoxMachineName.Text = "Leveling and Packager";
            comboBoxLocation.SelectedIndex = 0;
            comboBoxWorkingState.SelectedIndex = 0;
            textBoxDescription.Text = "Levels and Packages cartons";
        }
    }
}
