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
    public partial class AddShippingSchedules : Form
    {
        private List<OrderItem> allOrderItems = new List<OrderItem>();
        private String selectedOrderItem = "";
        private String savedShippingScheduleId = "";
        private ShippingSchedule shippingScheduleToAdd = null;
        private ShippingSchedule shippingScheduleToUpdate = null;
        private ShippingDBHandler shippingDBHandler = new ShippingDBHandler();
        private ChildFormType childType;

        public AddShippingSchedules()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
        }

        private void AddShippingSchedules_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (this.childType == ChildFormType.UPDATE)
            {
                shippingScheduleToUpdate = (ShippingSchedule)FormHandler.newObject;
                savedShippingScheduleId = shippingScheduleToUpdate.shippingschedule_id;
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

        private void dataGridStoredOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            if (string.IsNullOrEmpty(savedShippingScheduleId) || savedShippingScheduleId == "N/A")
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please save the shipping schedule first before adding order items.", NotificationStates.WARNING);
            }
            else
            {
                String column = dataGridOrderItems.Columns[e.ColumnIndex].Name;
                String columnValue = dataGridOrderItems.CurrentRow.Cells[column].FormattedValue.ToString();

                if (column == "AddToSchedule")
                {
                    try
                    {
                        if (columnValue == "Add to Schedule")
                        {
                            selectedOrderItem = dataGridOrderItems.CurrentRow.Cells["OrderItemNo"].FormattedValue.ToString();
                            if (shippingDBHandler.addOrderItemToSchedule(savedShippingScheduleId, selectedOrderItem) == true)
                            {
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Item was assigned to the Shipping Schedule Successfully.", NotificationStates.SUCCESS);
                                loadOrderItems(savedShippingScheduleId);
                            }
                        }
                        else if (columnValue == "Remove from Schedule")
                        {
                            selectedOrderItem = dataGridOrderItems.CurrentRow.Cells["OrderItemNo"].FormattedValue.ToString();

                            NotificationManager.hideInAppNotification(panelInAppNotifications);
                            DialogResult dialogResult;
                            dialogResult = MessageBox.Show("The selected Order Item will be removed from the current Shipping Schedule.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.OK)
                            {

                                if (shippingDBHandler.removeOrderItemFromSchedule(selectedOrderItem) == true)
                                {
                                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Item Removed from the Shipping Schedule Successfully.", NotificationStates.SUCCESS);
                                    loadOrderItems(savedShippingScheduleId);
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
            if (ValidationHandler.IsAftereDate(dateTimePickerLoadingDate.Value) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please pick a valid Loading Date.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrEmpty(textBoxDestination.Text) || string.IsNullOrWhiteSpace(textBoxDestination.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Destination cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrEmpty(textBoxAddress.Text) || string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Address cannot be empty.", NotificationStates.WARNING);
                return;
            }

            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    shippingScheduleToAdd = new ShippingSchedule("", dateTimePickerLoadingDate.Value, DateTime.MinValue, textBoxDestination.Text, textBoxAddress.Text, SessionManager.user.employeeId, DateTime.Now, null, DateTime.MinValue, textBoxInstructions.Text, "Pending");
                    savedShippingScheduleId = shippingDBHandler.addShippingSchedule(shippingScheduleToAdd);

                    if (!(string.IsNullOrEmpty(savedShippingScheduleId) || savedShippingScheduleId == "N/A"))
                    {
                        //changing to update interface if the plan was successfully added.
                        shippingScheduleToUpdate = shippingScheduleToAdd;
                        shippingScheduleToUpdate.shippingschedule_id = savedShippingScheduleId;
                        this.childType = ChildFormType.UPDATE;
                        resetForm();
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule Added Successfully.", NotificationStates.SUCCESS);
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    shippingScheduleToAdd = new ShippingSchedule(shippingScheduleToUpdate.shippingschedule_id, dateTimePickerLoadingDate.Value, DateTime.MinValue, textBoxDestination.Text, textBoxAddress.Text, shippingScheduleToUpdate.added_by, shippingScheduleToUpdate.added_date, shippingScheduleToUpdate.approved_by, shippingScheduleToUpdate.approved_date, textBoxInstructions.Text, shippingScheduleToUpdate.status);

                    if (shippingDBHandler.updateShippingSchedule(shippingScheduleToAdd) == true)
                    {
                        shippingScheduleToUpdate = shippingScheduleToAdd;
                        resetForm();
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule was uspdated successfully.", NotificationStates.SUCCESS);
                    }
                }


                if (FormHandler.parentFormName.Trim() == "ManageShippingShedules")
                {
                    ManageShippingShedules parentForm = (ManageShippingShedules)FormHandler.parentForm;
                    parentForm.loadShippingShedules();
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
            String scheduleId = "";
            dateTimePickerLoadingDate.Value = DateTime.Now;
            textBoxDestination.Text = "";
            textBoxAddress.Text = "";
            textBoxInstructions.Text = "";
            textBoxKeyword.Text = "";
            dataGridOrderItems.Rows.Clear();

            if (this.childType == ChildFormType.UPDATE)
            {
                this.Text = "Update Shipping Schedule";
                this.btnSave.Text = "Update Schedule";
                this.lblTitle.Text = "UPDATE " + shippingScheduleToUpdate.shippingschedule_id;
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected Shipping Schedule.";
                dateTimePickerLoadingDate.Value = shippingScheduleToUpdate.loading_date;
                textBoxDestination.Text = shippingScheduleToUpdate.destination;
                textBoxAddress.Text = shippingScheduleToUpdate.address;
                textBoxInstructions.Text = shippingScheduleToUpdate.remarks;
                scheduleId = shippingScheduleToUpdate.shippingschedule_id;
            }

            loadOrderItems(scheduleId);
        }

        public void loadOrderItems(String scheduleId)
        {
            try
            {
                dataGridOrderItems.Rows.Clear();
                allOrderItems = shippingDBHandler.getOrderItems(scheduleId);

                foreach (OrderItem orderItem in allOrderItems)
                {
                    if ((orderItem.shippingSchedule.shippingschedule_id == null || orderItem.shippingSchedule.shippingschedule_id == "" || orderItem.shippingSchedule.shippingschedule_id == "N/A"))
                    {
                        dataGridOrderItems.Rows.Add(orderItem.order.order_no, orderItem.orderItemNo, (orderItem.orderitem_production_enddate == DateTime.MinValue ? "N/A" : orderItem.orderitem_production_enddate.ToShortDateString()), orderItem.buyer.buyerName + "/" + orderItem.brand.brandName, orderItem.teaProduct.teaProductName + " (" + orderItem.teaProduct.teaProductserialNo + "), PACKAGING: [" + orderItem.orderItemContent.teabagWeight + "g] x [" + orderItem.orderItemContent.teabagQuantity + "] x [" + orderItem.orderItemContent.icQuantity + "]", orderItem.shippingDetails.address, orderItem.shippingDetails.location, orderItem.mcQuantity, orderItem.mc_count, orderItem.stored_mc_count, orderItem.loaded_mc_count, "Add to Schedule") ;
                    }
                    else if (orderItem.shippingSchedule.shippingschedule_id == scheduleId)
                    {
                        dataGridOrderItems.Rows.Add(orderItem.order.order_no, orderItem.orderItemNo, (orderItem.orderitem_production_enddate == DateTime.MinValue ? "N/A" : orderItem.orderitem_production_enddate.ToShortDateString()), orderItem.buyer.buyerName + "/" + orderItem.brand.brandName, orderItem.teaProduct.teaProductName + " (" + orderItem.teaProduct.teaProductserialNo + "), PACKAGING: [" + orderItem.orderItemContent.teabagWeight + "g] x [" + orderItem.orderItemContent.teabagQuantity + "] x [" + orderItem.orderItemContent.icQuantity + "]", orderItem.shippingDetails.address, orderItem.shippingDetails.location, orderItem.mcQuantity, orderItem.mc_count, orderItem.stored_mc_count, orderItem.loaded_mc_count, "Remove from Schedule");
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
            dateTimePickerLoadingDate.Value = DateTime.Parse("2020-11-25");
            textBoxDestination.Text = "Miami, USA";
            textBoxAddress.Text = "3275 NW 24th Street Rd - Miami FL";
            textBoxInstructions.Text = "MCs from 1st Order are to be wrapped with black tapes. Please keep the Sample MCs at the end of the container.";
        }
    }
}
