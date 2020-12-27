using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MSSMS.DBHandler
{
    public class ReportsDBHandler : DBHandler
    {
        //REPORTS
        //OIC
        public List<OrderItem> getMonthlyOrderItemContentsReport(DateTime month)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `orderitem` oi LEFT JOIN `order` o ON oi.order_no = o.order_no LEFT JOIN `contractschedule` cs ON cs.contract_no= oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id = cs.schedule_id LEFT JOIN `orderitemcontents` oic ON oic.barcode = oi.barcode LEFT JOIN `brand` br ON oic.brand_id = br.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = br.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_count` FROM `finishedgoods` WHERE `fg_status`='In Storage' GROUP BY `fg_orderitem_no`) sgc ON sgc.fg_orderitem_no = oi.orderitem_no LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `sg_exp_count` FROM `finishedgoods` WHERE `fg_status`='In Storage' AND `fg_exp_date` <= @date GROUP BY `fg_orderitem_no`) sgec ON sgec.fg_orderitem_no = oi.orderitem_no WHERE MONTH(oi.orderitem_placement_date)= MONTH(@date) AND YEAR(oi.orderitem_placement_date) = YEAR(@date);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = month;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                //buyer
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");

                                Buyer buyer = new Buyer(buyerId, buyerName, "", "");

                                //brand
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");

                                Brand brand = new Brand("", "", brandId, brandName, "");

                                //tea product
                                String teaproductId = mySqlDataReader.GetString("teaproduct_id");
                                String teaproductSerialNo = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproductName = mySqlDataReader.GetString("teaproduct_name");
                                String teaproductFlavor = mySqlDataReader.GetString("teaproduct_flavor");

                                TeaProduct teaProduct = new TeaProduct(teaproductId, teaproductName, teaproductFlavor, teaproductSerialNo, "", "");

                                //orderitemcontents
                                String barcode = mySqlDataReader.GetString("barcode");
                                int icQuantity = mySqlDataReader.GetInt32("ic_qantity");
                                int tbQuantity = mySqlDataReader.GetInt32("teabag_quantity");
                                Decimal tbWeight = mySqlDataReader.GetDecimal("teabag_weight");
                                Decimal mcMinWeight = mySqlDataReader.GetDecimal("mc_min_weight");
                                Decimal mcMaxWeight = mySqlDataReader.GetDecimal("mc_max_weight");

                                OrderItemContent orderItemContent = new OrderItemContent("", "", "", "", barcode, teaProduct, null, icQuantity, tbQuantity, tbWeight, mcMinWeight, mcMaxWeight, "", -1);

                                //Shipping Schedule
                                String schedule_id = mySqlDataReader.IsDBNull(20) ? "N/A" : mySqlDataReader.GetString("ss_schedule_id");
                                DateTime loading_date = mySqlDataReader.IsDBNull(23) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_loading_date");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(schedule_id, loading_date, DateTime.MinValue);

                                //order
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");

                                Order order = new Order(order_no, null, order_placement_date, order_status);

                                //orderitem
                                String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                String contract_no = mySqlDataReader.IsDBNull(1) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                String order_placed_by = mySqlDataReader.GetString("productionmanager_id");
                                DateTime orderitem_placement_date = mySqlDataReader.GetDateTime("orderitem_placement_date");
                                int mc_quantity = mySqlDataReader.GetInt32("mc_quantity");
                                int mc_end = mySqlDataReader.GetInt32("mc_end");
                                int mc_start = mySqlDataReader.GetInt32("mc_start");
                                String orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                DateTime orderitem_production_startdate = DateTime.MinValue;
                                DateTime orderitem_production_enddate = DateTime.MinValue;

                                int stored_mc_quantity = mySqlDataReader.IsDBNull(58) ? 0 : mySqlDataReader.GetInt32("fg_count");
                                int stored_mc_exp_quantity = mySqlDataReader.IsDBNull(60) ? 0 : mySqlDataReader.GetInt32("fg_count");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, null, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, "", mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItem.shippingSchedule = shippingSchedule;
                                orderItem.stored_mc_count = stored_mc_quantity;
                                orderItem.stored_mc_exp_count = stored_mc_exp_quantity;

                                orderItems.Add(orderItem);
                            }

                            return orderItems;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to generate the Requested Report. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //EMPLOYEE
        public List<Department> getMonthlyDepartmentSummeryReport(DateTime month)
        {
            List<Department> departments = new List<Department>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT d.*, y.tot_emp FROM `department` d LEFT JOIN (SELECT x.dept_id, SUM(x.totepdes) AS `tot_emp` FROM (SELECT desig.desig_id, desig.dept_id, desemp.totepdes FROM `designation` desig LEFT JOIN (SELECT `desig_id`, COUNT(*) AS `totepdes` FROM `employee` GROUP BY `desig_id`) desemp ON desemp.desig_id = desig.desig_id) x GROUP BY x.dept_id ) y ON y.dept_id=d.dept_id";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = month;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String dept_id = mySqlDataReader.GetString("dept_id");
                                String dept_name = mySqlDataReader.GetString("dept_name");
                                String dept_desc = mySqlDataReader.GetString("dept_description");
                                String dept_email = mySqlDataReader.GetString("dept_email");
                                String dept_contact = mySqlDataReader.GetString("dept_phone");

                                int tot_emp = mySqlDataReader.IsDBNull(5) ? 0 : mySqlDataReader.GetInt32("tot_emp");
                                //int tot_nemp = mySqlDataReader.IsDBNull(6) ? 0 : mySqlDataReader.GetInt32("tot_nemp");

                                Department department = new Department(dept_id, dept_name, dept_desc, dept_contact, dept_email);
                                department.tot_emp = tot_emp;
                                //department.tot_nemp = tot_nemp;
                                departments.Add(department);
                            }
                        }
                        return departments;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to generate the Requested Report. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //TEAPRODUCT/TBAGS
        public List<TeaProduct> getMonthlyTeaProductAvailabilityReport(DateTime month)
        {
            List<TeaProduct> teaProducts = new List<TeaProduct>();

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT tp.*, getcount.item_count  FROM `teaproduct` tp LEFT JOIN (SELECT `teaproduct_id`, SUM(`oi_count`) AS `item_count` FROM `orderitemcontents` oic LEFT JOIN (SELECT `barcode`, COUNT(*) AS `oi_count` FROM `orderitem` WHERE MONTH(`orderitem_placement_date`) = MONTH(@date) AND YEAR(`orderitem_placement_date`) = YEAR(@date) GROUP BY `barcode`) oicount ON oicount.barcode = oic.barcode GROUP BY `teaproduct_id`) getcount ON getcount.teaproduct_id = tp.teaproduct_id;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = month;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String teaproduct_id = mySqlDataReader.GetString("teaproduct_id");
                                String teaproduct_serial = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproduct_name = mySqlDataReader.GetString("teaproduct_name");
                                String teaproduct_flavor = mySqlDataReader.GetString("teaproduct_flavor");
                                String teaproduct_description = mySqlDataReader.GetString("teaproduct_description");
                                String teaproduct_availability = mySqlDataReader.GetString("teaproduct_availability");
                                int item_count = mySqlDataReader.IsDBNull(6) ? 0 : mySqlDataReader.GetInt32("item_count");

                                TeaProduct teaProduct = new TeaProduct(teaproduct_id, teaproduct_name, teaproduct_flavor, teaproduct_serial, teaproduct_description, teaproduct_availability);
                                teaProduct.used_by_items_count = item_count;
                                teaProducts.Add(teaProduct);
                            }
                        }
                    }
                                       
                    int total_orderitem_count = 0;

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `tot_item_count` FROM `orderitem` WHERE MONTH(`orderitem_placement_date`) = MONTH(@date) AND YEAR(`orderitem_placement_date`) = YEAR(@date);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@date", MySqlDbType.VarChar).Value = month.ToString("yyyy-MM-dd");
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                total_orderitem_count = mySqlDataReader.IsDBNull(0) ? 0 : mySqlDataReader.GetInt32("tot_item_count");
                            }
                        }
                    }

                    foreach (TeaProduct getFetchedTeaProduct in teaProducts)
                    {
                        getFetchedTeaProduct.total_items_count = total_orderitem_count;
                    }

                    return teaProducts;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to generate the Requested Report. " + ex.Message, "ERRORCODE");
                }

            }
        }

        //FINISHEDGOODS/OIC/O
        public List<OrderItem> getMonthlyManufacturingStatusReport(DateTime month)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `orderitem` oi LEFT JOIN `order` o ON oi.order_no = o.order_no LEFT JOIN `contractschedule` cs ON cs.contract_no= oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id = cs.schedule_id LEFT JOIN `orderitemcontents` oic ON oic.barcode = oi.barcode LEFT JOIN `brand` br ON oic.brand_id = br.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = br.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_count` FROM `finishedgoods` GROUP BY `fg_orderitem_no`) sgc ON sgc.fg_orderitem_no = oi.orderitem_no LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fgm_count` FROM `finishedgoods` WHERE MONTH(`fg_added_date`) = MONTH(@date) AND YEAR(`fg_added_date`) = YEAR(@date) GROUP BY `fg_orderitem_no`) sgec ON sgec.fg_orderitem_no = oi.orderitem_no WHERE MONTH(oi.orderitem_placement_date)= MONTH(@date) AND YEAR(oi.orderitem_placement_date) = YEAR(@date);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = month;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                //buyer
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");

                                Buyer buyer = new Buyer(buyerId, buyerName, "", "");

                                //brand
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");

                                Brand brand = new Brand("", "", brandId, brandName, "");

                                //tea product
                                String teaproductId = mySqlDataReader.GetString("teaproduct_id");
                                String teaproductSerialNo = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproductName = mySqlDataReader.GetString("teaproduct_name");
                                String teaproductFlavor = mySqlDataReader.GetString("teaproduct_flavor");

                                TeaProduct teaProduct = new TeaProduct(teaproductId, teaproductName, teaproductFlavor, teaproductSerialNo, "", "");

                                //orderitemcontents
                                String barcode = mySqlDataReader.GetString("barcode");
                                int icQuantity = mySqlDataReader.GetInt32("ic_qantity");
                                int tbQuantity = mySqlDataReader.GetInt32("teabag_quantity");
                                Decimal tbWeight = mySqlDataReader.GetDecimal("teabag_weight");
                                Decimal mcMinWeight = mySqlDataReader.GetDecimal("mc_min_weight");
                                Decimal mcMaxWeight = mySqlDataReader.GetDecimal("mc_max_weight");

                                OrderItemContent orderItemContent = new OrderItemContent("", "", "", "", barcode, teaProduct, null, icQuantity, tbQuantity, tbWeight, mcMinWeight, mcMaxWeight, "", -1);

                                //Shipping Schedule
                                String schedule_id = mySqlDataReader.IsDBNull(20) ? "N/A" : mySqlDataReader.GetString("ss_schedule_id");
                                DateTime loading_date = mySqlDataReader.IsDBNull(23) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_loading_date");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(schedule_id, loading_date, DateTime.MinValue);

                                //order
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");

                                Order order = new Order(order_no, null, order_placement_date, order_status);

                                //orderitem
                                String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                String contract_no = mySqlDataReader.IsDBNull(1) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                String order_placed_by = mySqlDataReader.GetString("productionmanager_id");
                                DateTime orderitem_placement_date = mySqlDataReader.GetDateTime("orderitem_placement_date");
                                int mc_quantity = mySqlDataReader.GetInt32("mc_quantity");
                                int mc_end = mySqlDataReader.GetInt32("mc_end");
                                int mc_start = mySqlDataReader.GetInt32("mc_start");
                                String orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                DateTime orderitem_production_startdate = DateTime.MinValue;
                                DateTime orderitem_production_enddate = mySqlDataReader.IsDBNull(13) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_enddate");

                                int manufact_mc_quantity_during_month = mySqlDataReader.IsDBNull(58) ? 0 : mySqlDataReader.GetInt32("fgm_count");
                                int manufact_mc_exp_quantity = mySqlDataReader.IsDBNull(60) ? 0 : mySqlDataReader.GetInt32("fg_count");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, null, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, "", mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItem.shippingSchedule = shippingSchedule;
                                orderItem.manufact_mc_monthly = manufact_mc_quantity_during_month;
                                orderItem.manufact_mc = manufact_mc_exp_quantity;

                                orderItems.Add(orderItem);
                            }

                            return orderItems;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to generate the Requested Report. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //STORAGE/OIC/O
        public List<OrderItem> getMonthlyStorageStatusReport (DateTime month)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `orderitem` oi LEFT JOIN `order` o ON oi.order_no = o.order_no LEFT JOIN `contractschedule` cs ON cs.contract_no= oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id = cs.schedule_id LEFT JOIN `orderitemcontents` oic ON oic.barcode = oi.barcode LEFT JOIN `brand` br ON oic.brand_id = br.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = br.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_count` FROM `finishedgoods` WHERE `fg_status`='In Storage' GROUP BY `fg_orderitem_no`) sgc ON sgc.fg_orderitem_no = oi.orderitem_no LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `sg_exp_count` FROM `finishedgoods` WHERE `fg_status`='In Storage' AND `fg_exp_date` <= @date GROUP BY `fg_orderitem_no`) sgec ON sgec.fg_orderitem_no = oi.orderitem_no WHERE MONTH(oi.orderitem_placement_date)= MONTH(@date) AND YEAR(oi.orderitem_placement_date) = YEAR(@date);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = month;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                //buyer
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");

                                Buyer buyer = new Buyer(buyerId, buyerName, "", "");

                                //brand
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");

                                Brand brand = new Brand("", "", brandId, brandName, "");

                                //tea product
                                String teaproductId = mySqlDataReader.GetString("teaproduct_id");
                                String teaproductSerialNo = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproductName = mySqlDataReader.GetString("teaproduct_name");
                                String teaproductFlavor = mySqlDataReader.GetString("teaproduct_flavor");

                                TeaProduct teaProduct = new TeaProduct(teaproductId, teaproductName, teaproductFlavor, teaproductSerialNo, "", "");

                                //orderitemcontents
                                String barcode = mySqlDataReader.GetString("barcode");
                                int icQuantity = mySqlDataReader.GetInt32("ic_qantity");
                                int tbQuantity = mySqlDataReader.GetInt32("teabag_quantity");
                                Decimal tbWeight = mySqlDataReader.GetDecimal("teabag_weight");
                                Decimal mcMinWeight = mySqlDataReader.GetDecimal("mc_min_weight");
                                Decimal mcMaxWeight = mySqlDataReader.GetDecimal("mc_max_weight");

                                OrderItemContent orderItemContent = new OrderItemContent("", "", "", "", barcode, teaProduct, null, icQuantity, tbQuantity, tbWeight, mcMinWeight, mcMaxWeight, "", -1);

                                //Shipping Schedule
                                String schedule_id = mySqlDataReader.IsDBNull(20) ? "N/A" : mySqlDataReader.GetString("ss_schedule_id");
                                DateTime loading_date = mySqlDataReader.IsDBNull(23) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_loading_date");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(schedule_id, loading_date, DateTime.MinValue);

                                //order
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");

                                Order order = new Order(order_no, null, order_placement_date, order_status);

                                //orderitem
                                String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                String contract_no = mySqlDataReader.IsDBNull(1) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                String order_placed_by = mySqlDataReader.GetString("productionmanager_id");
                                DateTime orderitem_placement_date = mySqlDataReader.GetDateTime("orderitem_placement_date");
                                int mc_quantity = mySqlDataReader.GetInt32("mc_quantity");
                                int mc_end = mySqlDataReader.GetInt32("mc_end");
                                int mc_start = mySqlDataReader.GetInt32("mc_start");
                                String orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                DateTime orderitem_production_startdate = DateTime.MinValue;
                                DateTime orderitem_production_enddate = DateTime.MinValue;

                                int stored_mc_quantity = mySqlDataReader.IsDBNull(58) ? 0 : mySqlDataReader.GetInt32("fg_count");
                                int stored_mc_exp_quantity = mySqlDataReader.IsDBNull(60) ? 0 : mySqlDataReader.GetInt32("sg_exp_count");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, null, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, "", mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItem.shippingSchedule = shippingSchedule;
                                orderItem.stored_mc_count = stored_mc_quantity;
                                orderItem.stored_mc_exp_count = stored_mc_exp_quantity;

                                orderItems.Add(orderItem);
                            }

                            return orderItems;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to generate the Requested Report. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //SHIPPING SCHEDULE/OIC/O
        public List<ShippingSchedule> getMonthlyShipmentStatusReport(DateTime month)
        {
            List<ShippingSchedule> shippingSchedules = new List<ShippingSchedule>();

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `shippingschedule` ss LEFT JOIN `contractschedule` cs ON cs.schedule_id = ss.ss_schedule_id LEFT JOIN (SELECT `contract_no`, COUNT(*) AS `oi_count` FROM `orderitem` GROUP BY `contract_no`) cc ON cc.contract_no = cs.contract_no LEFT JOIN (SELECT  `contract_no`, SUM(`mc_quantity`) AS `total_mc_count` FROM `orderitem` GROUP BY `contract_no`) oi ON oi.contract_no = cc.contract_no WHERE MONTH(ss.ss_loading_date) = MONTH(@date) AND YEAR(ss.ss_loading_date) = YEAR(@date) ORDER BY ss.`ss_loading_date`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = month;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String schedule_id = mySqlDataReader.GetString("ss_schedule_id");
                                DateTime loading_date = mySqlDataReader.GetDateTime("ss_loading_date");
                                String destination = mySqlDataReader.GetString("ss_destination");
                                String address = mySqlDataReader.GetString("ss_address");
                                String added_by = mySqlDataReader.GetString("ss_added_by");
                                DateTime added_date = mySqlDataReader.GetDateTime("ss_added_date");
                                String approved_by = mySqlDataReader.IsDBNull(7) ? "N/A" : mySqlDataReader.GetString("ss_approved_by");
                                DateTime approved_date = mySqlDataReader.IsDBNull(8) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_approved_date");
                                String status = mySqlDataReader.IsDBNull(6) ? "N/A" : mySqlDataReader.GetString("ss_status");
                                String remarks = mySqlDataReader.IsDBNull(10) ? "N/A" : mySqlDataReader.GetString("ss_remarks");
                                String contract_no = mySqlDataReader.IsDBNull(11) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                int oi_count = mySqlDataReader.IsDBNull(14) ? 0 : mySqlDataReader.GetInt32("oi_count");
                                int total_mc_count = mySqlDataReader.IsDBNull(16) ? 0 : mySqlDataReader.GetInt32("total_mc_count");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(schedule_id, loading_date, DateTime.MinValue, destination, address, added_by, added_date, approved_by, approved_date, remarks, status);
                                shippingSchedule.oi_per_ss_count = oi_count;
                                shippingSchedule.contract_no = contract_no;
                                shippingSchedule.total_mc_count = total_mc_count;
                                shippingSchedules.Add(shippingSchedule);
                            }
                        }
                    }
                    return shippingSchedules;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to generate the Requested Report " + ex.Message, "ERRORCODE");
                }
            }
        }

        //MACHINES
        //get daily report of machines
        public List<Machine> searchMachineReportDaily(string date)
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE CAST(added_date AS Date) = '" + date + "';";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);
                                machines.Add(machine);
                            }

                            return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get monthly report of machines
        public List<Machine> searchMachineReportMonthly(string month, string year)
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE MONTH(added_date) = " + Convert.ToInt32(month) + " AND YEAR(added_date) = " + Convert.ToInt32(year) + " ;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);
                                machines.Add(machine);
                            }

                            return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get yearly report of machines
        public List<Machine> searchMachineReportYearly(string year)
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE YEAR(added_date) = " + Convert.ToInt32(year) + " ;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);
                                machines.Add(machine);
                            }

                            return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get duration report of machines
        public List<Machine> searchMachineReportDuration(string dateStart, string dateEnd)
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE CAST(added_date AS Date) >= '" + dateStart + "' AND CAST(added_date AS Date) <= '" + dateEnd + "';";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);
                                machines.Add(machine);
                            }

                            return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //MACHINE ISSUES
        public List<Machine> getMonthlyMachineIssuesStatusReport(DateTime month)
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `machine` m LEFT JOIN (SELECT `location_id`, `location_name` FROM `location`) loc ON loc.location_id = m.location_id LEFT JOIN (SELECT `issue_machine_id`, COUNT(*) AS `tot_issues` FROM `issue` WHERE MONTH(`issue_submitted_date`) = MONTH(@date) AND YEAR(`issue_submitted_date`) = YEAR(@date) GROUP BY `issue_machine_id`) tmi  ON tmi.issue_machine_id = m.machine_id LEFT JOIN (SELECT `issue_machine_id`, COUNT(*) AS `critical_issues` FROM `issue` WHERE `issue_priority_level` = 'High' AND MONTH(`issue_submitted_date`) = MONTH(@date) AND YEAR(`issue_submitted_date`) = YEAR(@date) GROUP BY `issue_machine_id` ) cmi  ON cmi.issue_machine_id = m.machine_id LEFT JOIN (SELECT `issue_machine_id`, COUNT(*) AS `resolved_issues` FROM `issue` WHERE `issue_status` = 'Resolved' AND MONTH(`issue_submitted_date`) = MONTH(@date) AND YEAR(`issue_submitted_date`) = YEAR(@date)  GROUP BY `issue_machine_id` ) rmi  ON rmi.issue_machine_id = m.machine_id;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = month;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                String location_name = mySqlDataReader.GetString("location_name");

                                int critical_machine_issues = mySqlDataReader.IsDBNull(13) ? 0 : mySqlDataReader.GetInt32("critical_issues");
                                int total_machine_issues = mySqlDataReader.IsDBNull(11) ? 0 : mySqlDataReader.GetInt32("tot_issues");
                                int resolved_machine_issues = mySqlDataReader.IsDBNull(15) ? 0 : mySqlDataReader.GetInt32("resolved_issues");
                               
                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);
                                machine.loc_name = location_name;
                                machine.critical_machine_issues = critical_machine_issues;
                                machine.resolved_machine_issues = resolved_machine_issues;
                                machine.total_machine_issues = total_machine_issues;
                                machines.Add(machine);
                            }

                            return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to generate the Requested Report. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }
        
    }
}
