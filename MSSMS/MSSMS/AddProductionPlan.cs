using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddProductionPlan : Form
    {
        private List<OrderItem> allOrderItems = new List<OrderItem>();
        private String selectedOrderItem = "";
        private String savedProductionPlanId = "";
        private ProductionPlan productionPlanToAdd = null;
        private ProductionPlan productionPlanToUpdate = null;
        private ProductionDBHandler productionDBHandler = new ProductionDBHandler();
        private ChildFormType childType;

        public AddProductionPlan()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
        }

        private void AddProductionPlan_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if(this.childType == ChildFormType.UPDATE)
            {
                productionPlanToUpdate = (ProductionPlan)FormHandler.newObject;
                savedProductionPlanId = productionPlanToUpdate.productionplan_id;
            }
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewPendingOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            if (string.IsNullOrEmpty(savedProductionPlanId) || savedProductionPlanId == "N/A")
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please save the production plan first before assigning orders.", NotificationStates.WARNING);
            }
            else
            {
                String column = dataGridViewPendingOrderItems.Columns[e.ColumnIndex].Name;
                String columnValue = dataGridViewPendingOrderItems.CurrentRow.Cells[column].FormattedValue.ToString();

                if (column == "AddToPlan")
                {
                    try
                    {
                        if (columnValue == "Add to Plan")
                        {
                            selectedOrderItem = dataGridViewPendingOrderItems.CurrentRow.Cells["OrderItemNo"].FormattedValue.ToString();
                            if (productionDBHandler.addOrderItemToPlan(savedProductionPlanId, selectedOrderItem) == true)
                            {
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Item was assigned to the Production Plan Successfully.", NotificationStates.SUCCESS);
                                loadPendingOrderItems(savedProductionPlanId);
                            }
                        }
                        else if (columnValue == "Remove from Plan")
                        {
                            selectedOrderItem = dataGridViewPendingOrderItems.CurrentRow.Cells["OrderItemNo"].FormattedValue.ToString();

                            NotificationManager.hideInAppNotification(panelInAppNotifications);
                            DialogResult dialogResult;
                            dialogResult = MessageBox.Show("The selected Order Item will be removed from this production plan.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.OK)
                            {

                                if (productionDBHandler.removeOrderItemFromPlan(selectedOrderItem) == true)
                                {
                                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Item Removed from the production plan Successfully.", NotificationStates.SUCCESS);
                                    loadPendingOrderItems(savedProductionPlanId);
                                }

                            }
                            else
                            {
                                //NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Deleting cancelled.", NotificationStates.WARNING);
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
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            
            //front-end validation
            if (string.IsNullOrEmpty(textBoxPlanName.Text) || string.IsNullOrWhiteSpace(textBoxPlanName.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please enter a valid plan name.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsAftereDate(dateTimePickerStartDate.Value) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please pick a valid Starting Date.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsAftereDate(dateTimePickerEndDate.Value) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please pick a valid Ending Date.", NotificationStates.WARNING);
                return;
            }

            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    productionPlanToAdd = new ProductionPlan("",textBoxPlanName.Text, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, SessionManager.user.employeeId, DateTime.Now, "N/A", DateTime.MinValue, textBoxInstruction.Text, "Pending");
                    //add production plan
                    savedProductionPlanId = productionDBHandler.addProductionPlan(productionPlanToAdd);

                    if (!(string.IsNullOrEmpty(savedProductionPlanId) || savedProductionPlanId == "N/A"))
                    {
                        //changing to update interface if the plan was successfully added.
                        productionPlanToUpdate = productionPlanToAdd;
                        productionPlanToUpdate.productionplan_id = savedProductionPlanId;
                        this.childType = ChildFormType.UPDATE;
                        resetForm();
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production Plan Added Successfully.", NotificationStates.SUCCESS);
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    productionPlanToAdd = new ProductionPlan(productionPlanToUpdate.productionplan_id, textBoxPlanName.Text, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, SessionManager.user.employeeId, DateTime.Now, productionPlanToUpdate.approved_by, productionPlanToUpdate.approved_date, textBoxInstruction.Text, productionPlanToUpdate.status);
                    
                    if(productionDBHandler.updateProductionPlan(productionPlanToAdd) == true)
                    {
                        productionPlanToUpdate = productionPlanToAdd;
                        resetForm();
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production Plan was uspdated successfully.", NotificationStates.SUCCESS);
                    }
                }


                if (FormHandler.parentFormName.Trim() == "ManageProductionPlans") 
                {
                    ManageProductionPlans parentForm = (ManageProductionPlans)FormHandler.parentForm;
                    parentForm.loadProductionPlans();
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

        private void resetForm()
        {
            String planId = "";

            textBoxPlanName.Text = "";
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerEndDate.Value = DateTime.Now;
            textBoxInstruction.Text = "";
            textBoxKeyword.Text = "";
            dataGridViewPendingOrderItems.Rows.Clear();

            if (this.childType == ChildFormType.UPDATE)
            {
                this.Text = "Update Production Plan";
                this.btnSave.Text = "Update Plan";
                this.lblTitle.Text = "UPDATE " + productionPlanToUpdate.productionplan_id;
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected production plan.";
                textBoxPlanName.Text = productionPlanToUpdate.productionplan_name;
                dateTimePickerStartDate.Value = productionPlanToUpdate.start_date;
                dateTimePickerEndDate.Value = productionPlanToUpdate.end_date;
                textBoxInstruction.Text = productionPlanToUpdate.remarks;
                planId = productionPlanToUpdate.productionplan_id;
            }

            loadPendingOrderItems(planId);
        }

        public void loadPendingOrderItems(String planId)
        {
            try
            {
                dataGridViewPendingOrderItems.Rows.Clear();
                allOrderItems = productionDBHandler.getAllPendingOrderItems(planId);

                foreach (OrderItem orderItem in allOrderItems)
                {
                    if((orderItem.productionPlanId == null || orderItem.productionPlanId == "" || orderItem.productionPlanId == "N/A") && (orderItem.orderitem_status == "Pending"))
                    {
                        dataGridViewPendingOrderItems.Rows.Add(orderItem.order.order_no, orderItem.contractNo, orderItem.orderItemNo, orderItem.buyer.buyerName, orderItem.brand.brandName, "", orderItem.orderItemContent.teabagWeight, orderItem.orderItemContent.teabagQuantity, orderItem.orderItemContent.icQuantity, orderItem.mcQuantity, (orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.mcQuantity), (orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.mcQuantity * orderItem.orderItemContent.teabagWeight) + " KG", "Add to Plan");
                    }
                    else if(orderItem.productionPlanId == planId)
                    {
                        dataGridViewPendingOrderItems.Rows.Add(orderItem.order.order_no, orderItem.contractNo, orderItem.orderItemNo, orderItem.buyer.buyerName, orderItem.brand.brandName, "", orderItem.orderItemContent.teabagWeight, orderItem.orderItemContent.teabagQuantity, orderItem.orderItemContent.icQuantity, orderItem.mcQuantity, (orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.mcQuantity), (orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.mcQuantity * orderItem.orderItemContent.teabagWeight) + " KG", "Remove from Plan");
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

        private void btnDemo_Click(object sender, EventArgs e)
        {
            textBoxPlanName.Text = "Production Plan 2021 DEC";
            dateTimePickerStartDate.Value = DateTime.Parse("2020-12-01");
            dateTimePickerEndDate.Value = DateTime.Parse("2020-12-12");
            textBoxInstruction.Text = "Inner Cartons of this production plan should be each assigned the same barcode clearly printed on the top surface.";
        }
    }
}
