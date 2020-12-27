using MSSMS.DBHandler;
using MSSMS.Enums;
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
    public partial class RequestReports : Form
    {
        private ReportMachineViewer reportMachineViewer = new ReportMachineViewer();

        public RequestReports()
        {
            InitializeComponent();
        }

        private void RequestReports_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            resetForm();

            dateTimePickerMonthOnly.Format = DateTimePickerFormat.Custom;
            dateTimePickerYearOnly.Format = DateTimePickerFormat.Custom;
            dateTimePickerMonthOnly.CustomFormat = "MM/yyyy";
            dateTimePickerYearOnly.CustomFormat = "yyyy";
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnResetMonthlyReport_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void btnResetDailyReport_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void btnResetDurationReport_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void btnResetYearlyReport_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void resetForm()
        {
            comboBoxDailyReport.Items.Clear();
            comboBoxDurationReport.Items.Clear();
            comboBoxMonthlyReport.Items.Clear();
            comboBoxYearlyReport.Items.Clear();

            if (SessionManager.user.role == "ADMIN")
            {
                comboBoxMonthlyReport.Items.Add("Department Summery Report");
            }
            else if (SessionManager.user.role == "GLMGR")
            {
                comboBoxDailyReport.Items.Add("Machines Report");
                comboBoxDurationReport.Items.Add("Machines Report");
                comboBoxMonthlyReport.Items.Add("Machines Report");
                comboBoxYearlyReport.Items.Add("Machines Report");

                comboBoxMonthlyReport.Items.Add("Machine Issues Status Report");
                comboBoxMonthlyReport.Items.Add("Shipping Schedules Status Report");
                comboBoxMonthlyReport.Items.Add("Storage Status Report");
                comboBoxMonthlyReport.Items.Add("Department Summery Report");
                comboBoxMonthlyReport.Items.Add("Manufacturing Status Report");
                comboBoxMonthlyReport.Items.Add("Order Item Contents Report");
                comboBoxMonthlyReport.Items.Add("Tea Products Availability Report");
            }
            else if (SessionManager.user.role == "PRMGR")
            {
                comboBoxMonthlyReport.Items.Add("Manufacturing Status Report");
                comboBoxMonthlyReport.Items.Add("Order Item Contents Report");
                comboBoxMonthlyReport.Items.Add("Tea Products Availability Report");
            }
            else if (SessionManager.user.role == "HRMGR")
            {
                comboBoxMonthlyReport.Items.Add("Department Summery Report");
            }
            else if (SessionManager.user.role == "FGOPR")
            {
                comboBoxMonthlyReport.Items.Add("Manufacturing Status Report");
            }
            else if (SessionManager.user.role == "STKPR")
            {
                comboBoxMonthlyReport.Items.Add("Storage Status Report");
            }
            else if (SessionManager.user.role == "SHMGR")
            {
                comboBoxMonthlyReport.Items.Add("Shipping Schedules Status Report");
            }
            else if (SessionManager.user.role == "ENGNR")
            {
                comboBoxDailyReport.Items.Add("Machines Report");
                comboBoxDurationReport.Items.Add("Machines Report");
                comboBoxMonthlyReport.Items.Add("Machines Report");
                comboBoxYearlyReport.Items.Add("Machines Report");

                comboBoxMonthlyReport.Items.Add("Machine Issues Status Report");
            }
        }

        private void btnGenerateYearlyReport_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string year = dateTimePickerYearOnly.Value.ToString("yyyy");
            string type = "yearly";

            if (comboBoxYearlyReport.SelectedItem == "Machines Report")
            {
                if (reportMachineViewer.IsDisposed == true)
                {
                    reportMachineViewer = new ReportMachineViewer();
                }

                try
                {
                    reportMachineViewer.setYearYearly(year);
                    reportMachineViewer.setType(type);
                    reportMachineViewer.ShowDialog();
                }
                catch (Exception ex)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                }

            }
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid report.", NotificationStates.WARNING);
            }
        }

        private void btnGenerateDurationReport_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string dateStart = dateTimePickerDurationStart.Value.ToString("yyyy-MM-dd");
            string dateEnd = dateTimePickerDurationEnd.Value.ToString("yyyy-MM-dd");
            string type = "duration";

            if (comboBoxDurationReport.SelectedItem == "Machines Report")
            {
                if (reportMachineViewer.IsDisposed == true)
                {
                    reportMachineViewer = new ReportMachineViewer();
                }

                try
                {
                    reportMachineViewer.setDateStart(dateStart);
                    reportMachineViewer.setDateEnd(dateEnd);
                    reportMachineViewer.setType(type);
                    reportMachineViewer.ShowDialog();

                }
                catch (Exception ex)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                }

            }
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid report.", NotificationStates.WARNING);
            }
        }

        private void btnGenerateDailyReport_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string date = dateTimePickerDailyReport.Value.ToString("yyyy-MM-dd");
            string type = "daily";



            if (comboBoxDailyReport.SelectedItem == "Machines Report")
            {
                if (reportMachineViewer.IsDisposed == true)
                {
                    reportMachineViewer = new ReportMachineViewer();
                }

                try
                {
                    reportMachineViewer.setDateDaily(date);
                    reportMachineViewer.setType(type);
                    reportMachineViewer.ShowDialog();

                }
                catch (Exception ex)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                }

            }
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid report.", NotificationStates.WARNING);
            }
        }

        private void btnGenerateMonthlyReport_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            if (comboBoxMonthlyReport.SelectedItem == "Shipping Schedules Status Report")
            {
                ReportViewerScheduledShipmentStatus scheduledShipmentStatusReport = new ReportViewerScheduledShipmentStatus(ReportType.MONTHLY, dateTimePickerMonthOnly.Value, DateTime.MinValue);
                scheduledShipmentStatusReport.ShowDialog();
            }
            else if (comboBoxMonthlyReport.SelectedItem == "Machines Report")
            {
                string month = dateTimePickerMonthOnly.Value.ToString("MM");
                string year = dateTimePickerMonthOnly.Value.ToString("yyyy");
                string type = "monthly";


                if (reportMachineViewer.IsDisposed == true)
                {
                    reportMachineViewer = new ReportMachineViewer();
                }

                try
                {
                    reportMachineViewer.setMonthMonthly(month);
                    reportMachineViewer.setYearMonthly(year);
                    reportMachineViewer.setType(type);
                    reportMachineViewer.ShowDialog();
                }
                catch (Exception ex)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                }
            }
            else if (comboBoxMonthlyReport.SelectedItem == "Storage Status Report")
            {
                ReportViewerStorageStatus storageStatusReport = new ReportViewerStorageStatus(ReportType.MONTHLY, dateTimePickerMonthOnly.Value, DateTime.MinValue);
                storageStatusReport.ShowDialog();
            }
            else if (comboBoxMonthlyReport.SelectedItem == "Tea Products Availability Report")
            {
                ReportViewerTeaProductsAvailability teaProductsAvailabilityReport = new ReportViewerTeaProductsAvailability(ReportType.MONTHLY, dateTimePickerMonthOnly.Value, DateTime.MinValue);
                teaProductsAvailabilityReport.ShowDialog();
            }
            else if (comboBoxMonthlyReport.SelectedItem == "Order Item Contents Report")
            {
                ReportViewerOrderItemContents orderItemContentsReport = new ReportViewerOrderItemContents(ReportType.MONTHLY, dateTimePickerMonthOnly.Value, DateTime.MinValue);
                orderItemContentsReport.ShowDialog();
            }
            else if (comboBoxMonthlyReport.SelectedItem == "Machine Issues Status Report")
            {
                ReportViewerMachineIssueStatus machineIssueStatusReport = new ReportViewerMachineIssueStatus(ReportType.MONTHLY, dateTimePickerMonthOnly.Value, DateTime.MinValue);
                machineIssueStatusReport.ShowDialog();
            }
            else if (comboBoxMonthlyReport.SelectedItem == "Manufacturing Status Report")
            {
                ReportViewerManufacturingStatus manufacturingStatusReport = new ReportViewerManufacturingStatus(ReportType.MONTHLY, dateTimePickerMonthOnly.Value, DateTime.MinValue);
                manufacturingStatusReport.ShowDialog();
            }
            else if (comboBoxMonthlyReport.SelectedItem == "Department Summery Report")
            {
                ReportViewerEmployeeDetailsReport employeeDetailsReport = new ReportViewerEmployeeDetailsReport(ReportType.MONTHLY, dateTimePickerMonthOnly.Value, DateTime.MinValue);
                employeeDetailsReport.ShowDialog();
            }
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid report.", NotificationStates.WARNING);
            }


        }
    }
}
