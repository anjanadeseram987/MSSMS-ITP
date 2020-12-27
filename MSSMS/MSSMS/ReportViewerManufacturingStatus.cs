﻿using MSSMS.DBHandler;
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
    public partial class ReportViewerManufacturingStatus : Form
    {
        private ReportType reportType = ReportType.NONE;
        private DateTime statDateTime = DateTime.MinValue;
        private DateTime endDateTime = DateTime.MinValue;
        private ReportsDBHandler reportsDBHandler = new ReportsDBHandler();
        private List<OrderItem> finishedOrderItems = new List<OrderItem>();

        public ReportViewerManufacturingStatus(ReportType reportType, DateTime startDateTime, DateTime endDateTime)
        {
            InitializeComponent();

            this.reportType = reportType;
            this.statDateTime = startDateTime;
            this.endDateTime = endDateTime;

            if (reportType == ReportType.MONTHLY)
            {
                generateMonthlyReport();
            }
        }

        private void ReportViewerManufacturingStatus_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridReport.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridReport.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridReport.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridReport.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridReport.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridReport.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excellApplication.Columns.AutoFit();
                excellApplication.Visible = true;

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Report Exported.", NotificationStates.SUCCESS);
            }
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Nothing to Export.", NotificationStates.INFORMATION);
            }
        }

        private void generateMonthlyReport()
        {
            this.labelInfo.Text = "REPORT ISSUED ON: " + DateTime.Now + "\nREPORT GENERATED BY: " + SessionManager.user.employeeId + "\n\nREPORT TYPE: MONTHLY REPORT.\nMONTH: " + this.statDateTime.ToString("MM-yyyy");

            NotificationManager.hideInAppNotification(panelInAppNotifications);

            try
            {
                finishedOrderItems = reportsDBHandler.getMonthlyManufacturingStatusReport(this.statDateTime);
                dataGridReport.Rows.Clear();

                //binding
                foreach (OrderItem orderItem in finishedOrderItems)
                {
                    dataGridReport.Rows.Add(orderItem.order.order_no, orderItem.orderItemNo, orderItem.buyer.buyerName + "/" + orderItem.brand.brandName, orderItem.teaProduct.teaProductName + " - " + orderItem.teaProduct.teaProductflavor, (orderItem.orderItemContent.teabagWeight * orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.mcQuantity).ToString() + " KG", (orderItem.orderItemContent.teabagWeight * orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.manufact_mc).ToString() + " KG", orderItem.manufact_mc > 0 ? (Math.Round((((orderItem.orderItemContent.teabagWeight * orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.manufact_mc) / (orderItem.orderItemContent.teabagWeight * orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.mcQuantity)) * 100), 2)) + "%" : "N/A", (orderItem.orderItemContent.teabagWeight * orderItem.orderItemContent.teabagQuantity * orderItem.orderItemContent.icQuantity * orderItem.manufact_mc_monthly).ToString() + " KG" , orderItem.orderitem_production_enddate == DateTime.MinValue ? "N/A" : orderItem.orderitem_production_enddate.ToShortDateString());
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
