using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MSSMS.DBHandler
{
    public class ProductionDBHandler : DBHandler
    {
        //add plan
        public String addProductionPlan(ProductionPlan productionPlan)
        {
            String planId = null;
            using (connection)
            {
                try
                {
                    connection.Open();

                    //inserting plan
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `productionplan`(`productionplan_name`, `productionplan_start_date`, `productionplan_end_date`, `productionplan_added_by`, `productionplan_added_date`, `productionplan_approved_by`, `productionplan_approved_date`, `productionplan_status`, `productionplan_remarks`) VALUES (@planName, @startDate, @endDate, @addedBy, @addedDate, @approvedBy, null, @status, @remarks);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planName", MySqlDbType.VarChar).Value = productionPlan.productionplan_name;
                        mySqlCommand.Parameters.Add("@startDate", MySqlDbType.DateTime).Value = productionPlan.start_date;
                        mySqlCommand.Parameters.Add("@endDate", MySqlDbType.DateTime).Value = productionPlan.end_date;
                        mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = productionPlan.added_by;
                        mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = productionPlan.added_date;
                        mySqlCommand.Parameters.Add("@approvedBy", MySqlDbType.VarChar).Value = null;
                        mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = productionPlan.status;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = productionPlan.remarks;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //reading last insert plan id
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `productionplan` WHERE `productionplan_name`=@planName AND `productionplan_added_by`=@addedBy;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planName", MySqlDbType.VarChar).Value = productionPlan.productionplan_name;
                        mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = productionPlan.added_by;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                planId = mySqlDataReader.GetString("productionplan_id");
                            }
                        }
                    }

                    connection.Close();
                    return planId;

                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Add the Production Plan " + ex.Message, "ERRORCODE");
                }
            }
        }

        //update plan
        public Boolean updateProductionPlan(ProductionPlan productionPlan)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `productionplan` SET `productionplan_name`=@planName,`productionplan_start_date`=@startDate,`productionplan_end_date`=@endDate,`productionplan_added_by`=@addedBy,`productionplan_added_date`=@addedDate,`productionplan_approved_by`=null,`productionplan_approved_date`= null,`productionplan_status`=@status,`productionplan_remarks`=@remarks WHERE `productionplan_id`=@planId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = productionPlan.productionplan_id;
                    mySqlCommand.Parameters.Add("@planName", MySqlDbType.VarChar).Value = productionPlan.productionplan_name;
                    mySqlCommand.Parameters.Add("@startDate", MySqlDbType.DateTime).Value = productionPlan.start_date;
                    mySqlCommand.Parameters.Add("@endDate", MySqlDbType.DateTime).Value = productionPlan.end_date;
                    mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = productionPlan.added_by;
                    mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = productionPlan.added_date;
                    mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = productionPlan.status;
                    mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = productionPlan.remarks;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Production Plan Details " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete plan
        public Boolean deleteProductionPlan(String planId)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    //setting order item status back to pending if still in production
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitem` SET `orderitem_status`='Pending' WHERE `productionplan_id`=@planId AND `orderitem_status`='In Production';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }


                    //update order status

                    //detaching production plan
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitem` SET `productionplan_id`=null WHERE `productionplan_id`=@planId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //deleting the plan
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "DELETE FROM `productionplan` WHERE `productionplan_id`= @planId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new MSSMUIException("Failed to delete the Production Plan", "ERRORCODE");
                }
            }
        }

        //add oi to plan
        public Boolean addOrderItemToPlan(String planId, String orderItemNo)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    //updating production plan id in order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitem` SET `productionplan_id`=@planId WHERE `orderitem_no`=@orderItemNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;
                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Add Item to the Production Plan " + ex.Message, "ERRORCODE");
                }
            }
        }

        //remove oi from plan
        public Boolean removeOrderItemFromPlan(String orderItemNo)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    //removing production plan id from order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitem` SET `productionplan_id`=null WHERE `orderitem_no`=@orderItemNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Remove item from the Production Plan " + ex.Message, "ERRORCODE");
                }
            }
        }

        //get all plans
        public List<ProductionPlan> getAllProductionPlans()
        {
            List<ProductionPlan> productionPlans = new List<ProductionPlan>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `productionplan` ORDER BY `productionplan_start_date`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String productionplan_id = mySqlDataReader.GetString("productionplan_id");               
                                String productionplan_name = mySqlDataReader.GetString("productionplan_name");
                                DateTime productionplan_start_date = mySqlDataReader.GetDateTime("productionplan_start_date");
                                DateTime productionplan_end_date = mySqlDataReader.GetDateTime("productionplan_end_date"); 
                                String productionplan_added_by = mySqlDataReader.GetString("productionplan_added_by");
                                DateTime productionplan_added_date =  mySqlDataReader.GetDateTime("productionplan_added_date");
                                String productionplan_approved_by = mySqlDataReader.IsDBNull(6) ? "N/A" : mySqlDataReader.GetString("productionplan_approved_by");
                                DateTime productionplan_approved_date = mySqlDataReader.IsDBNull(7) ? DateTime.MinValue : mySqlDataReader.GetDateTime("productionplan_approved_date");
                                String productionplan_status = mySqlDataReader.GetString("productionplan_status");
                                String productionplan_remarks = mySqlDataReader.GetString("productionplan_remarks");

                                ProductionPlan productionPlan = new ProductionPlan(productionplan_id, productionplan_name, productionplan_start_date, productionplan_end_date, productionplan_added_by, productionplan_added_date, productionplan_approved_by, productionplan_approved_date, productionplan_remarks, productionplan_status);
                                productionPlans.Add(productionPlan);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Utilities.MSSMUIException("Failed to fetch Production Plans " + ex.Message, "ERRORCODE");
                    }
                }
            }

            productionPlans = getOrderCountPerProductionPlan(productionPlans);
            return productionPlans;
        }

        //get all ois by plan id
        public List<OrderItem> getAllPendingOrderItems(String planId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `orderitem` oi, `order` o, `shippingdetails` s, `buyer` b, `brand` br, `orderitemcontents` oic, `teaproduct` tp  WHERE oi.address_id = s.shipping_address_id AND oi.barcode = oic.barcode AND oic.brand_id = br.brand_id AND br.buyer_id = b.buyer_id AND oic.teaproduct_id = tp.teaproduct_id AND oi.order_no = o.order_no AND (oi.productionplan_id is null OR oi.productionplan_id = @planId);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;

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

                                //shipping details
                                String shipping_address_id = mySqlDataReader.GetString("shipping_address_id");
                                String shipping_location = mySqlDataReader.GetString("shipping_location");
                                String shipping_address = mySqlDataReader.GetString("shipping_address");

                                ShippingDetails shippingDetail = new ShippingDetails(shipping_address_id, shipping_location, shipping_address, "");


                                //order
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");

                                Order order = new Order(order_no, null, order_placement_date, order_status);

                                String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                String contract_no = mySqlDataReader.IsDBNull(1) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                String order_placed_by = mySqlDataReader.GetString("productionmanager_id");
                                DateTime orderitem_placement_date = mySqlDataReader.GetDateTime("orderitem_placement_date");
                                String productionplan_id = mySqlDataReader.IsDBNull(7) ? "N/A" : mySqlDataReader.GetString("productionplan_id");
                                int mc_quantity = mySqlDataReader.GetInt32("mc_quantity");
                                int mc_end = mySqlDataReader.GetInt32("mc_end");
                                int mc_start = mySqlDataReader.GetInt32("mc_start");
                                String orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                DateTime orderitem_production_startdate = mySqlDataReader.IsDBNull(12) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_startdate");
                                DateTime orderitem_production_enddate = mySqlDataReader.IsDBNull(13) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_enddate");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, shippingDetail, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, productionplan_id, mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItems.Add(orderItem);
                            }

                            return orderItems;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Pending Order Items. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        private List<ProductionPlan> getOrderCountPerProductionPlan(List<ProductionPlan> productionPlans)
        {
            foreach(ProductionPlan productionPlan in productionPlans)
            {
                using (connection)
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `orderitem_count` FROM `orderitem` WHERE `productionplan_id`=@planId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = productionPlan.productionplan_id;

                        try
                        {
                            using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                            {
                                while (mySqlDataReader.Read())
                                {
                                    int orderitem_count = mySqlDataReader.GetInt32("orderitem_count");
                                    productionPlan.oi_count = orderitem_count;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new MSSMUIException("Failed to fetch Production Plans " + ex.Message, "ERRORCODE");
                        }
                    }
                }
            }

            return productionPlans;
        }

        public Boolean modifyApprovalState(DateTime approvedDate, String approvedBy, String planId)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `productionplan` SET `productionplan_approved_by`=@approvedBy, `productionplan_approved_date`=@approvedDate WHERE `productionplan_id`=@planId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@approvedBy", MySqlDbType.VarChar).Value = approvedBy;
                    mySqlCommand.Parameters.Add("@approvedDate", MySqlDbType.DateTime).Value = approvedDate;
                    mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw new MSSMUIException("Failed to modify approval status." + e.Message, "ERRORCODE");
                    }
                }
            }
        }

        public Boolean changePlanStatus(String planStatus, String planId)
        {

            using (connection)
            {
                try
                {
                    connection.Open();
                    switch (planStatus)
                    {
                        case "Pending":
                            //seeting order item status back to pending if still in production
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "UPDATE `orderitem` SET `orderitem_status`='Pending' WHERE `productionplan_id`=@planId AND `orderitem_status`='In Production';";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }

                            List<String> orderNumbers = new List<string>();

                            //get related order numbers
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "SELECT `order_no` FROM `orderitem` WHERE `productionplan_id`=@planId GROUP BY `order_no`;";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;
                                mySqlCommand.Prepare();

                                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                                {
                                    while (mySqlDataReader.Read())
                                    {
                                        string order_no = mySqlDataReader.GetString("order_no");
                                        orderNumbers.Add(order_no);
                                    }
                                }
                            }

                            //read order items along with status and count
                            List<OrderItemStatusCount> orderItemStatusCounts = new List<OrderItemStatusCount>();

                            foreach (String orderNumber in orderNumbers)
                            {
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "SELECT `order_no`, `orderitem_status` FROM `orderitem` WHERE `order_no`=@orderNo GROUP BY `order_no`, `orderitem_status`;";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@orderNo", MySqlDbType.VarChar).Value = orderNumber;
                                    mySqlCommand.Prepare();

                                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                                    {
                                        while (mySqlDataReader.Read())
                                        {
                                            string order_no = mySqlDataReader.GetString("order_no");
                                            string orderitem_status = mySqlDataReader.GetString("orderitem_status");

                                            Boolean isPresent = false;
                                            foreach (OrderItemStatusCount orderItemStatusCount in orderItemStatusCounts)
                                            {
                                                if (orderItemStatusCount.order_no == order_no)
                                                {
                                                    if (orderitem_status == "Pending")
                                                    {
                                                        orderItemStatusCount.orderitem_pending_count++;
                                                    }
                                                    else
                                                    {
                                                        orderItemStatusCount.orderitem_other_count++;
                                                    }
                                                    isPresent = true;
                                                    break;
                                                }
                                                else
                                                {
                                                    isPresent = false;
                                                }
                                            }

                                            if (isPresent == false)
                                            {
                                                OrderItemStatusCount newOrderItemStatusCount = new OrderItemStatusCount(order_no);
                                                newOrderItemStatusCount.orderitem_pending_count = 0;
                                                newOrderItemStatusCount.orderitem_other_count = 0;
                                                if (orderitem_status == "Pending")
                                                {
                                                    newOrderItemStatusCount.orderitem_pending_count++;
                                                }
                                                else
                                                {
                                                    newOrderItemStatusCount.orderitem_other_count++;
                                                }

                                                orderItemStatusCounts.Add(newOrderItemStatusCount);
                                            }
                                        }
                                    }
                                }
                            }

                            String newOrderStatus = "";

                            foreach(OrderItemStatusCount orderItemStatusCount in orderItemStatusCounts)
                            {
                                if(orderItemStatusCount.orderitem_other_count > 0 && orderItemStatusCount.orderitem_pending_count > 0)
                                {
                                    newOrderStatus = "In Production";
                                }
                                else if(orderItemStatusCount.orderitem_pending_count>0)
                                {
                                    newOrderStatus = "Pending";
                                }

                                //update order status
                                if(!string.IsNullOrEmpty(newOrderStatus) && !string.IsNullOrWhiteSpace(newOrderStatus))
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "UPDATE `order` SET `order_status`=@newStatus WHERE `order_no`=@orderNumber;";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@orderNumber", MySqlDbType.VarChar).Value = orderItemStatusCount.order_no;
                                    mySqlCommand.Parameters.Add("@newStatus", MySqlDbType.VarChar).Value = newOrderStatus;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                            }

                            break;

                        case "In Production":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "UPDATE `orderitem` SET `orderitem_status`='In Production' WHERE `productionplan_id`=@planId AND `orderitem_status`='Pending';";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }

                            //read order numbers from the same plan
                            List<String> ordersNumbers = new List<String>();

                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "SELECT `order_no` FROM `orderitem` WHERE `productionplan_id`=@planId GROUP BY `order_no`;";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;
                                mySqlCommand.Prepare();

                                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                                {
                                    while (mySqlDataReader.Read())
                                    {
                                        string order_no = mySqlDataReader.GetString("order_no");
                                        ordersNumbers.Add(order_no);
                                    }
                                }
                            }

                            //update order status
                            foreach (String orderNumber in ordersNumbers)
                            {
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "UPDATE `order` SET `order_status`='In Production' WHERE `order_no`=@orderNumber;";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@orderNumber", MySqlDbType.VarChar).Value = orderNumber;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                            }

                            break;

                        default:
                            //do nothing
                            break;
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `productionplan` SET `productionplan_status`=@planStatus WHERE `productionplan_id`=@planId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@planStatus", MySqlDbType.VarChar).Value = planStatus ;
                        mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = planId;

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new MSSMUIException("Failed to change Production Plan Status", "ERRORCODE");
                }
            }
        }
    }
}
