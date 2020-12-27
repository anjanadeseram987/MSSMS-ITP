using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MSSMS.DBHandler
{
    public class OrderDBHandler:DBHandler
    {
        //add orderItem
        public bool addOrderItemWithNewOrderAndAddress(OrderItem orderItem)
        {
            String newOrderNo = null;
            int newShippingAddressId = -1;
            DateTime newPlacementDate = DateTime.Now;

            using (connection)
            {
                try
                {
                    connection.Open();
                    //inserting address
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `shippingdetails`(`shipping_buyer_id`, `shipping_location`, `shipping_address`) VALUES (@buyerId, @location, @address);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.shippingDetails.buyerId;
                        mySqlCommand.Parameters.Add("@location", MySqlDbType.VarChar).Value = orderItem.shippingDetails.location;
                        mySqlCommand.Parameters.Add("@address", MySqlDbType.VarChar).Value = orderItem.shippingDetails.address;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //retrieving new address id
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `shippingdetails` WHERE `shipping_buyer_id` = @buyerId AND `shipping_address` = @shippingAddress";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.buyerId;
                        mySqlCommand.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = orderItem.shippingDetails.address;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                int address_id = mySqlDataReader.GetInt32("shipping_address_id");
                                newShippingAddressId = address_id;
                            }
                        }
                    }

                    //inserting new order
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `order`(`buyer_id`, `order_placement_date`, `order_status`, `order_placed_by`) VALUES (@buyerId, @placementDate, @status, @managerId);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.buyerId;
                        mySqlCommand.Parameters.Add("@placementDate", MySqlDbType.DateTime).Value = DateTime.Now;
                        mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Pending";
                        mySqlCommand.Parameters.Add("@managerId", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //retrieving order number
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `order` WHERE buyer_id = @buyerId AND order_placed_by = @managerId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.buyerId;
                        mySqlCommand.Parameters.Add("@managerId", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String order_no = mySqlDataReader.GetString("order_no");
                                newOrderNo = order_no;
                            }
                        }
                    }


                    //inserting order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `orderitem`(`contract_no`, `order_no`, `barcode`, `productionmanager_id`, `orderitem_placement_date`, `address_id`, `productionplan_id`, `mc_quantity`, `mc_start`, `mc_end`, `orderitem_status`) VALUES (@contract_no ,@order_no ,@barcode ,@productionmanager_id ,@orderitem_placement_date ,@address_id ,@productionplan_id, @mc_quantity ,@mc_start ,@mc_end ,@orderitem_status);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@contract_no", MySqlDbType.VarChar).Value = orderItem.contractNo=="N/A" ? null : orderItem.contractNo;
                        mySqlCommand.Parameters.Add("@order_no", MySqlDbType.VarChar).Value = newOrderNo;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItem.barcode;
                        mySqlCommand.Parameters.Add("@productionmanager_id", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Parameters.Add("@orderitem_placement_date", MySqlDbType.DateTime).Value = newPlacementDate;
                        mySqlCommand.Parameters.Add("@address_id", MySqlDbType.Int32).Value = newShippingAddressId;
                        mySqlCommand.Parameters.Add("@productionplan_id", MySqlDbType.VarChar).Value = orderItem.productionPlanId == "N/A" ? null : orderItem.productionPlanId;
                        mySqlCommand.Parameters.Add("@mc_quantity", MySqlDbType.Int32).Value = orderItem.mcQuantity;
                        mySqlCommand.Parameters.Add("@mc_start", MySqlDbType.Int32).Value = orderItem.mcFirst;
                        mySqlCommand.Parameters.Add("@mc_end", MySqlDbType.Int32).Value = orderItem.mcLast;
                        mySqlCommand.Parameters.Add("@orderitem_status", MySqlDbType.VarChar).Value = "Pending";
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Place the Order " + ex.Message, "ERRORCODE");
                }
            }
        }

        public bool addOrderItemWithNewOrder(OrderItem orderItem)
        {
            String newOrderNo = null;
            DateTime newPlacementDate = DateTime.Now;

            using (connection)
            {
                try
                {
                    connection.Open();
                    //inserting new order
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `order`(`buyer_id`, `order_placement_date`, `order_status`, `order_placed_by`) VALUES (@buyerId, @placementDate, @status, @managerId);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.buyerId;
                        mySqlCommand.Parameters.Add("@placementDate", MySqlDbType.DateTime).Value = DateTime.Now;
                        mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Pending";
                        mySqlCommand.Parameters.Add("@managerId", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //retrieving order number
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `order` WHERE `buyer_id` = @buyerId AND `order_placed_by` = @managerId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.buyerId;
                        mySqlCommand.Parameters.Add("@managerId", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String order_no = mySqlDataReader.GetString("order_no");
                                newOrderNo = order_no;
                            }
                        }
                    }


                    //inserting order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `orderitem`(`contract_no`, `order_no`, `barcode`, `productionmanager_id`, `orderitem_placement_date`, `address_id`, `productionplan_id`, `mc_quantity`, `mc_start`, `mc_end`, `orderitem_status`) VALUES (@contract_no ,@order_no ,@barcode ,@productionmanager_id ,@orderitem_placement_date ,@address_id ,@productionplan_id, @mc_quantity ,@mc_start ,@mc_end ,@orderitem_status);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@contract_no", MySqlDbType.VarChar).Value = orderItem.contractNo == "N/A" ? null : orderItem.contractNo;
                        mySqlCommand.Parameters.Add("@order_no", MySqlDbType.VarChar).Value = newOrderNo;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItem.barcode;
                        mySqlCommand.Parameters.Add("@productionmanager_id", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Parameters.Add("@orderitem_placement_date", MySqlDbType.DateTime).Value = newPlacementDate;
                        mySqlCommand.Parameters.Add("@address_id", MySqlDbType.Int32).Value = orderItem.shippingDetails.addressId;
                        mySqlCommand.Parameters.Add("@productionplan_id", MySqlDbType.VarChar).Value = orderItem.productionPlanId == "N/A" ? null : orderItem.productionPlanId;
                        mySqlCommand.Parameters.Add("@mc_quantity", MySqlDbType.Int32).Value = orderItem.mcQuantity;
                        mySqlCommand.Parameters.Add("@mc_start", MySqlDbType.Int32).Value = orderItem.mcFirst;
                        mySqlCommand.Parameters.Add("@mc_end", MySqlDbType.Int32).Value = orderItem.mcLast;
                        mySqlCommand.Parameters.Add("@orderitem_status", MySqlDbType.VarChar).Value = "Pending";
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Place the Order " + ex.Message, "ERRORCODE");
                }
            }
        }

        public bool addOrderItemWithNewAddress(OrderItem orderItem)
        {
            int newShippingAddressId = -1;
            DateTime newPlacementDate = DateTime.Now;

            using (connection)
            {
                try
                {
                    connection.Open();
                    //inserting address
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `shippingdetails`(`shipping_buyer_id`, `shipping_location`, `shipping_address`) VALUES (@buyerId, @location, @address);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.shippingDetails.buyerId;
                        mySqlCommand.Parameters.Add("@location", MySqlDbType.VarChar).Value = orderItem.shippingDetails.location;
                        mySqlCommand.Parameters.Add("@address", MySqlDbType.VarChar).Value = orderItem.shippingDetails.address;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //retrieving new address id
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `shippingdetails` WHERE `shipping_buyer_id` = @buyerId AND `shipping_address` = @shippingAddress";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItem.buyerId;
                        mySqlCommand.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = orderItem.shippingDetails.address;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                int address_id = mySqlDataReader.GetInt32("shipping_address_id");
                                newShippingAddressId = address_id;
                            }
                        }
                    }

                    //inserting order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `orderitem`(`contract_no`, `order_no`, `barcode`, `productionmanager_id`, `orderitem_placement_date`, `address_id`, `productionplan_id`, `mc_quantity`, `mc_start`, `mc_end`, `orderitem_status`) VALUES (@contract_no ,@order_no ,@barcode ,@productionmanager_id ,@orderitem_placement_date ,@address_id ,@productionplan_id, @mc_quantity ,@mc_start ,@mc_end ,@orderitem_status);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@contract_no", MySqlDbType.VarChar).Value = orderItem.contractNo == "N/A" ? null : orderItem.contractNo;
                        mySqlCommand.Parameters.Add("@order_no", MySqlDbType.VarChar).Value = orderItem.orderNo;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItem.barcode;
                        mySqlCommand.Parameters.Add("@productionmanager_id", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Parameters.Add("@orderitem_placement_date", MySqlDbType.DateTime).Value = newPlacementDate;
                        mySqlCommand.Parameters.Add("@address_id", MySqlDbType.Int32).Value = newShippingAddressId;
                        mySqlCommand.Parameters.Add("@productionplan_id", MySqlDbType.VarChar).Value = orderItem.productionPlanId == "N/A" ? null : orderItem.productionPlanId;
                        mySqlCommand.Parameters.Add("@mc_quantity", MySqlDbType.Int32).Value = orderItem.mcQuantity;
                        mySqlCommand.Parameters.Add("@mc_start", MySqlDbType.Int32).Value = orderItem.mcFirst;
                        mySqlCommand.Parameters.Add("@mc_end", MySqlDbType.Int32).Value = orderItem.mcLast;
                        mySqlCommand.Parameters.Add("@orderitem_status", MySqlDbType.VarChar).Value = "Pending";
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Place the Order " + ex.Message, "ERRORCODE");
                }
            }
        }

        public bool addOrderItem(OrderItem orderItem)
        {
            DateTime newPlacementDate = DateTime.Now;

            using (connection)
            {
                try
                {
                    connection.Open();
                    
                    //inserting order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `orderitem`(`contract_no`, `order_no`, `barcode`, `productionmanager_id`, `orderitem_placement_date`, `address_id`, `productionplan_id`, `mc_quantity`, `mc_start`, `mc_end`, `orderitem_status`) VALUES (@contract_no ,@order_no ,@barcode ,@productionmanager_id ,@orderitem_placement_date ,@address_id ,@productionplan_id, @mc_quantity ,@mc_start ,@mc_end ,@orderitem_status);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@contract_no", MySqlDbType.VarChar).Value = orderItem.contractNo == "N/A" ? null : orderItem.contractNo;
                        mySqlCommand.Parameters.Add("@order_no", MySqlDbType.VarChar).Value = orderItem.orderNo;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItem.barcode;
                        mySqlCommand.Parameters.Add("@productionmanager_id", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                        mySqlCommand.Parameters.Add("@orderitem_placement_date", MySqlDbType.DateTime).Value = newPlacementDate;
                        mySqlCommand.Parameters.Add("@address_id", MySqlDbType.Int32).Value = orderItem.shippingDetails.addressId;
                        mySqlCommand.Parameters.Add("@productionplan_id", MySqlDbType.VarChar).Value = orderItem.productionPlanId == "N/A" ? null : orderItem.productionPlanId;
                        mySqlCommand.Parameters.Add("@mc_quantity", MySqlDbType.Int32).Value = orderItem.mcQuantity;
                        mySqlCommand.Parameters.Add("@mc_start", MySqlDbType.Int32).Value = orderItem.mcFirst;
                        mySqlCommand.Parameters.Add("@mc_end", MySqlDbType.Int32).Value = orderItem.mcLast;
                        mySqlCommand.Parameters.Add("@orderitem_status", MySqlDbType.VarChar).Value = "Pending";
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Place the Order " + ex.Message, "ERRORCODE");
                }
            }
        }

        //delete orderItem
        public bool deleteOrderItem(string orderItem_no)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `orderitem` WHERE `orderitem_no`=@orderitemNo";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@orderitemNo", MySqlDbType.VarChar).Value = orderItem_no;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Order Item. ", "ERRORCODE");
                    }
                }
            }
        }

        
        //get all orderItems
        public List<OrderItem> getAllOrderItems()
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `orderitem` oi, `order` o, `shippingdetails` s, `buyer` b, `brand` br, `orderitemcontents` oic, `teaproduct` tp  WHERE oi.address_id = s.shipping_address_id AND oi.barcode = oic.barcode AND oic.brand_id = br.brand_id AND br.buyer_id = b.buyer_id AND oic.teaproduct_id = tp.teaproduct_id AND oi.order_no = o.order_no;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

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
                        throw new MSSMUIException("Failed to fetch Order Items. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get all orders
        public List<Order> getAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `order` o, `buyer` b WHERE o.buyer_id = b.buyer_id";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");
                                String buyer_id = mySqlDataReader.GetString("buyer_id");
                                String buyer_name = mySqlDataReader.GetString("buyer_name");

                                Buyer buyer = new Buyer(buyer_id, buyer_name);
                                Order order = new Order(order_no, buyer, order_placement_date, order_status);
                                orders.Add(order);
                            }

                            return orders;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Orders " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        public List<ShippingDetails> getAllShippingAddressDetails()
        {
            List<ShippingDetails> shippingDetails = new List<ShippingDetails>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `shippingdetails`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String shipping_address_id = mySqlDataReader.GetString("shipping_address_id");   
                                String shipping_buyer_id = mySqlDataReader.GetString("shipping_buyer_id");
                                String shipping_location = mySqlDataReader.GetString("shipping_location");
                                String shipping_address = mySqlDataReader.GetString("shipping_address");

                                ShippingDetails shippingDetail = new ShippingDetails(shipping_address_id, shipping_location, shipping_address, shipping_buyer_id);
                                shippingDetails.Add(shippingDetail);
                            }

                            return shippingDetails;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Shipping Address Details " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }
    }
}
