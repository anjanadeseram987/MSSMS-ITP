using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Properties;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddNewBuyer : Form
    {
        Buyer buyerToAdd = null;
        Buyer buyerToUpdate = null;
        List<Buyer> buyers = new List<Buyer>();
        BuyerDBHandler buyerDBHandler = new BuyerDBHandler();
        ChildFormType childType;
        bool isValidBuyer = false;

        public AddNewBuyer()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;

            if (this.childType == ChildFormType.UPDATE)
            {
                buyerToUpdate = (Buyer)FormHandler.newObject;
                this.Text = "Update Buyer";
                this.btnSave.Text = "Update Buyer";
                this.lblTitle.Text = "UPDATE BUYER " + buyerToUpdate.buyerId.ToUpper();
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected buyer.";
            }

            resetForm();
        }

        private void resetForm()
        {
            pictureBoxBuyerStatus.BackgroundImage = null;

            textBoxBuyer.Clear();
            textBoxEmail.Clear();
            textBoxDescription.Clear();

            getBuyerData();

            if (this.childType == ChildFormType.UPDATE)
            {
                textBoxBuyer.Text = buyerToUpdate.buyerName;
                textBoxEmail.Text = buyerToUpdate.buyerEmail;
                textBoxDescription.Text = buyerToUpdate.buyerDescription;
            }
        }

        private void getBuyerData()
        {
            try
            {
                buyers = buyerDBHandler.getAllBuyers();
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void AddNewBuyer_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //front-end validation
            if (string.IsNullOrWhiteSpace(textBoxBuyer.Text) || string.IsNullOrEmpty(textBoxBuyer.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Buyer name cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if(isValidBuyer == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "This Buyer already exists. Please enter a different Buyer name.", NotificationStates.WARNING);
                return;
            }

            if (! string.IsNullOrEmpty(textBoxEmail.Text))
            {
                if (ValidationHandler.IsValidEmail(textBoxEmail.Text) == false)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Email Address.", NotificationStates.WARNING);
                    return;
                }
            }

            //save
            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    buyerToAdd = new Buyer("",textBoxBuyer.Text.ToString(), textBoxEmail.Text.ToString(), textBoxDescription.Text.ToString());

                    if (buyerDBHandler.addBuyer(buyerToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Buyer Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    buyerToAdd = new Buyer(buyerToUpdate.buyerId, textBoxBuyer.Text.ToString(), textBoxEmail.Text.ToString(), textBoxDescription.Text.ToString());

                    if (buyerDBHandler.updateBuyer(buyerToAdd) == true)
                    {
                        buyerToUpdate = buyerToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Buyer Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageBuyers")
                {
                    ManageBuyers parentForm = (ManageBuyers)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadBuyers();
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

        private void textBoxBuyer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBuyer.Text) || string.IsNullOrWhiteSpace(textBoxBuyer.Text))
            {
                pictureBoxBuyerStatus.BackgroundImage = null;
            }
            else
            {
                foreach (Buyer buyer in buyers) {
                    if (string.Equals(textBoxBuyer.Text, buyer.buyerName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (buyerToUpdate != null && buyer.buyerId == buyerToUpdate.buyerId)
                        {
                            pictureBoxBuyerStatus.BackgroundImage = Resources.tickC;
                            isValidBuyer = true;
                            break;
                        }
                        else
                        {
                            pictureBoxBuyerStatus.BackgroundImage = Resources.closeC;
                            isValidBuyer = false;
                            break;
                        }
                    }
                    else
                    {
                        pictureBoxBuyerStatus.BackgroundImage = Resources.tickC;
                        isValidBuyer = true;
                    }
                }
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Email Address cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            textBoxBuyer.Text = "Harney & Sons.";
            textBoxEmail.Text = "contact@harneyandsons.com";
            textBoxDescription.Text = "Harney & Sons is a buyer registered under a 2 year contract for jafferjee brothers tea division.";
        }
    }
}
