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
    public partial class AddNewBrand : Form
    {
        Brand brandToAdd = null;
        Brand brandToUpdate = null;
        List<Buyer> buyers = new List<Buyer>();
        List<Brand> brands = new List<Brand>();
        BuyerDBHandler buyerDBHandler = new BuyerDBHandler();
        ChildFormType childType;
        bool isValidBrandName = false;

        public AddNewBrand()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;

            if (this.childType == ChildFormType.UPDATE)
            {
                brandToUpdate = (Brand)FormHandler.newObject;
                this.Text = "Update Brand";
                this.btnSave.Text = "Update Brand";
                this.lblTitle.Text = "UPDATE BRAND " + brandToUpdate.brandId.ToUpper();
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected brand.";
            }

            resetForm();
        }

        private void resetForm()
        {
            comboBoxBuyer.Items.Clear();
            comboBoxBuyer.Text = "";
            comboBoxBuyer.SelectedItem = "\0";
            pictureBoxBrandStatus.BackgroundImage = null;

            textBoxBrand.Clear();
            textBoxDescription.Clear();

            getBuyerBrandData();

            if (this.childType == ChildFormType.UPDATE)
            {
                textBoxBrand.Text = brandToUpdate.brandName;
                textBoxDescription.Text = brandToUpdate.brandDesc;
            }
        }

        private void getBuyerBrandData()
        {
            try
            {
                buyers = buyerDBHandler.getAllBuyers();
                brands = buyerDBHandler.getAllBrands();

                if (buyers != null)
                {
                    foreach (Buyer buyer in buyers)
                    {
                        comboBoxBuyer.Items.Add(buyer.buyerName);
                        if (brandToUpdate != null)
                        {
                            if (buyer.buyerId == brandToUpdate.buyerId)
                            {
                                comboBoxBuyer.SelectedItem = buyer.buyerName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void AddNewBrand_Load(object sender, EventArgs e)
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

            //front-end validations
            if (string.IsNullOrWhiteSpace(comboBoxBuyer.Text) || string.IsNullOrEmpty(comboBoxBuyer.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Buyer name cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxBrand.Text) || string.IsNullOrEmpty(textBoxBrand.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand name cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (isValidBrandName == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "This Brand already exists. Please enter a different Brand name.", NotificationStates.WARNING);
                return;
            }

            //save
            string selectedBuyerId = null;

            try
            {
                //get combobox buyer id
                foreach (Buyer buyer in buyers)
                {
                    if (string.Equals(comboBoxBuyer.Text.ToString(), buyer.buyerName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedBuyerId = buyer.buyerId;
                    }
                }
                
                if (this.childType == ChildFormType.ADD)
                {
                    brandToAdd = new Brand(selectedBuyerId, comboBoxBuyer.Text.ToString(), null, textBoxBrand.Text.ToString(), textBoxDescription.Text);

                    if (selectedBuyerId == null)
                    {
                        if (buyerDBHandler.addBrandWithBuyer(brandToAdd) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand Added Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                    else if (selectedBuyerId != null)
                    {
                        if (buyerDBHandler.addBrand(brandToAdd) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand Added Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }

                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    brandToAdd = new Brand(selectedBuyerId, comboBoxBuyer.Text.ToString(), brandToUpdate.brandId, textBoxBrand.Text.ToString(),textBoxDescription.Text.ToString());

                    if (selectedBuyerId == null)
                    {
                        if (buyerDBHandler.updateBrandWithBuyer(brandToAdd) == true)
                        {
                            brandToUpdate = buyerDBHandler.getBrandByBrandId(brandToAdd.brandId);
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand Updated Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                    else if (selectedBuyerId != null)
                    {
                        if (buyerDBHandler.updateBrand(brandToAdd) == true)
                        {
                            brandToUpdate = brandToAdd;
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand Updated Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageBrands")
                {
                    ManageBrands parentForm = (ManageBrands)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadBrands();
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

        private void comboBoxBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //do nothing for now
        }

        private void comboBoxBuyer_TextChanged(object sender, EventArgs e)
        {
            string buyer_id = null;
            string buyer_name = comboBoxBuyer.Text.ToString();
            string brand_name = textBoxBrand.Text.ToString();
            
            foreach (Buyer buyer in buyers)
            {
                if (string.Equals(buyer_name, buyer.buyerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    buyer_id = buyer.buyerId;
                    break;
                }
            }

            if (!(string.IsNullOrEmpty(brand_name) || string.IsNullOrWhiteSpace(brand_name)))
            {
                foreach (Brand brand in brands)
                {
                    if (string.Equals(brand.brandName, brand_name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (brandToUpdate != null && brandToUpdate.brandName == brand_name)
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                            isValidBrandName = true;
                            break;
                        }
                        else
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.closeC;
                            isValidBrandName = false;
                            break;
                        }
                    }
                    else
                    {
                        pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                        isValidBrandName = true;
                    }
                }
            }
            else
            {
                pictureBoxBrandStatus.BackgroundImage = null;
                isValidBrandName = false;
            }
        }

        private void textBoxBrand_TextChanged(object sender, EventArgs e)
        {
            string buyer_name = comboBoxBuyer.Text.ToString();
            string brand_name = textBoxBrand.Text.ToString();

            if (!(string.IsNullOrEmpty(brand_name) || string.IsNullOrWhiteSpace(brand_name)))
            {
                foreach (Brand brand in brands)
                {
                    if (string.Equals(brand.brandName, brand_name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (brandToUpdate != null && brandToUpdate.brandName == brand_name)
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                            isValidBrandName = true;
                            break;
                        }
                        else
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.closeC;
                            isValidBrandName = false;
                            break;
                        }
                    }
                    else
                    {
                        pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                        isValidBrandName = true;
                    }
                }
            }
            else
            {
                pictureBoxBrandStatus.BackgroundImage = null;
                isValidBrandName = false;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            comboBoxBuyer.Text = "Yorkshire Tea";
            textBoxBrand.Text = "Proper Strong";
            textBoxDescription.Text = "A Brand of Black Tea by Taylors Yorkashire Tea, Available in Different Tea Bag Quantities inclueding, 100, 200, and 50.";
        }
    }
}
