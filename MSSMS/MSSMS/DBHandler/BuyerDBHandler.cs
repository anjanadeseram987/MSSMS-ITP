using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MSSMS.DBHandler
{
    public class BuyerDBHandler:DBHandler
    {
        //add order item for a new buyer
        public bool addOrderItemContentWithBuyer(OrderItemContent orderItemContent)
        {
            using (connection)
            {
                string lastInsertedBuyerId = null;
                string lastInsertedBrandId = null;

                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `buyer`(`buyer_name`, `buyer_email`, `buyer_description`) VALUES (@buyerName, @buyerEmail , @buyerDesc)";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = orderItemContent.buyerName;
                        mySqlCommand.Parameters.Add("@buyerEmail", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@buyerDesc", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `buyer_id` FROM `buyer` WHERE `buyer_name`=@buyerName;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = orderItemContent.buyerName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBuyerId = mySqlDataReader.GetString("buyer_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `brand`(`buyer_id`, `brand_name`, `brand_description`, `brand_design_id`) VALUES (@buyerId, @brandName, @brandDesc, @designId);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = lastInsertedBuyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `brand_id` FROM `brand` WHERE `brand_name`=@brandName AND `buyer_id`=@buyerId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = lastInsertedBuyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBrandId = mySqlDataReader.GetString("brand_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `orderitemcontents`(`brand_id`, `barcode`, `teaproduct_id`, `teabagmaterial_id`, `ic_qantity`, `teabag_quantity`, `teabag_weight`, `mc_min_weight`, `mc_max_weight`, `content_remarks`) VALUES (@brandId, @barcode, @teaproductId, @teabagMaterialId, @icQuantity, @teabagQuantity, @teabagWeight, @mcMin, @mcMax, @remarks);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = lastInsertedBrandId;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItemContent.barcode;
                        mySqlCommand.Parameters.Add("@teaproductId", MySqlDbType.VarChar).Value = orderItemContent.teaproduct.teaProductId;
                        mySqlCommand.Parameters.Add("@teabagMaterialId", MySqlDbType.VarChar).Value = orderItemContent.teabag.materialId;
                        mySqlCommand.Parameters.Add("@icQuantity", MySqlDbType.Int32).Value = orderItemContent.icQuantity;
                        mySqlCommand.Parameters.Add("@teabagQuantity", MySqlDbType.Int32).Value = orderItemContent.teabagQuantity;
                        mySqlCommand.Parameters.Add("@teabagWeight", MySqlDbType.Decimal).Value = orderItemContent.teabagWeight;
                        mySqlCommand.Parameters.Add("@mcMin", MySqlDbType.Decimal).Value = orderItemContent.MCMinWeight;
                        mySqlCommand.Parameters.Add("@mcMax", MySqlDbType.Decimal).Value = orderItemContent.MCMaxWeight;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(orderItemContent.remark) || string.IsNullOrEmpty(orderItemContent.remark) ? "N/A" : orderItemContent.remark);
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to add the Order Content." + ex.Message, "ERRORCODE");
                }
            }
        }

        //add order item for a new brand
        public bool addOrderItemContentWithBrand(OrderItemContent orderItemContent)
        {
            using (connection)
            {
                string lastInsertedBrandId = null;

                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `brand`(`buyer_id`, `brand_name`, `brand_description`, `brand_design_id`) VALUES (@buyerId, @brandName, @brandDesc, @designId);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItemContent.buyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `brand_id` FROM `brand` WHERE `brand_name`=@brandName AND `buyer_id`=@buyerId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItemContent.buyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBrandId = mySqlDataReader.GetString("brand_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `orderitemcontents`(`brand_id`, `barcode`, `teaproduct_id`, `teabagmaterial_id`, `ic_qantity`, `teabag_quantity`, `teabag_weight`, `mc_min_weight`, `mc_max_weight`, `content_remarks`) VALUES (@brandId, @barcode, @teaproductId, @teabagMaterialId, @icQuantity, @teabagQuantity, @teabagWeight, @mcMin, @mcMax, @remarks);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = lastInsertedBrandId;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItemContent.barcode;
                        mySqlCommand.Parameters.Add("@teaproductId", MySqlDbType.VarChar).Value = orderItemContent.teaproduct.teaProductId;
                        mySqlCommand.Parameters.Add("@teabagMaterialId", MySqlDbType.VarChar).Value = orderItemContent.teabag.materialId;
                        mySqlCommand.Parameters.Add("@icQuantity", MySqlDbType.Int32).Value = orderItemContent.icQuantity;
                        mySqlCommand.Parameters.Add("@teabagQuantity", MySqlDbType.Int32).Value = orderItemContent.teabagQuantity;
                        mySqlCommand.Parameters.Add("@teabagWeight", MySqlDbType.Decimal).Value = orderItemContent.teabagWeight;
                        mySqlCommand.Parameters.Add("@mcMin", MySqlDbType.Decimal).Value = orderItemContent.MCMinWeight;
                        mySqlCommand.Parameters.Add("@mcMax", MySqlDbType.Decimal).Value = orderItemContent.MCMaxWeight;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(orderItemContent.remark) || string.IsNullOrEmpty(orderItemContent.remark) ? "N/A" : orderItemContent.remark);
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to add the Order Content." + ex.Message, "ERRORCODE");
                }
            }
        }

        //add order item content for an existing brand
        public bool addOrderItemContent(OrderItemContent orderItemContent)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `orderitemcontents`(`brand_id`, `barcode`, `teaproduct_id`, `teabagmaterial_id`, `ic_qantity`, `teabag_quantity`, `teabag_weight`, `mc_min_weight`, `mc_max_weight`, `content_remarks`) VALUES (@brandId, @barcode, @teaproductId, @teabagMaterialId, @icQuantity, @teabagQuantity, @teabagWeight, @mcMin, @mcMax, @remarks);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = orderItemContent.brandId;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItemContent.barcode;
                        mySqlCommand.Parameters.Add("@teaproductId", MySqlDbType.VarChar).Value = orderItemContent.teaproduct.teaProductId;
                        mySqlCommand.Parameters.Add("@teabagMaterialId", MySqlDbType.VarChar).Value = orderItemContent.teabag.materialId;
                        mySqlCommand.Parameters.Add("@icQuantity", MySqlDbType.Int32).Value = orderItemContent.icQuantity;
                        mySqlCommand.Parameters.Add("@teabagQuantity", MySqlDbType.Int32).Value = orderItemContent.teabagQuantity;
                        mySqlCommand.Parameters.Add("@teabagWeight", MySqlDbType.Decimal).Value = orderItemContent.teabagWeight;
                        mySqlCommand.Parameters.Add("@mcMin", MySqlDbType.Decimal).Value = orderItemContent.MCMinWeight;
                        mySqlCommand.Parameters.Add("@mcMax", MySqlDbType.Decimal).Value = orderItemContent.MCMaxWeight;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(orderItemContent.remark) || string.IsNullOrEmpty(orderItemContent.remark) ? "N/A" : orderItemContent.remark);
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to add the Order Content" + ex.Message, "ERRORCODE");
                }
            }
        }

        //update order item content and insert buyer and brand
        public bool updateOrderItemContentWithBuyer(OrderItemContent orderItemContent)
        {
            using (connection)
            {
                string lastInsertedBuyerId = null;
                string lastInsertedBrandId = null;

                try
                {
                    connection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `buyer`(`buyer_name`, `buyer_email`, `buyer_description`) VALUES (@buyerName, @buyerEmail , @buyerDesc)";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = orderItemContent.buyerName;
                        mySqlCommand.Parameters.Add("@buyerEmail", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@buyerDesc", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `buyer_id` FROM `buyer` WHERE `buyer_name`=@buyerName;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = orderItemContent.buyerName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBuyerId = mySqlDataReader.GetString("buyer_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `brand`(`buyer_id`, `brand_name`, `brand_description`, `brand_design_id`) VALUES (@buyerId, @brandName, @brandDesc, @designId);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = lastInsertedBuyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `brand_id` FROM `brand` WHERE `brand_name`=@brandName AND `buyer_id`=@buyerId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = lastInsertedBuyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBrandId = mySqlDataReader.GetString("brand_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitemcontents` SET `brand_id`=@brandId, `teaproduct_id`=@teaproductId, `teabagmaterial_id`=@teabagMaterialId, `ic_qantity`=@icQuantity, `teabag_quantity`=@teabagQuantity, `teabag_weight`=@teabagWeight, `mc_min_weight`=@mcMin, `mc_max_weight`=@mcMax, `content_remarks`=@remarks WHERE `barcode`=@barcode;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = lastInsertedBrandId;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItemContent.barcode;
                        mySqlCommand.Parameters.Add("@teaproductId", MySqlDbType.VarChar).Value = orderItemContent.teaproduct.teaProductId;
                        mySqlCommand.Parameters.Add("@teabagMaterialId", MySqlDbType.VarChar).Value = orderItemContent.teabag.materialId;
                        mySqlCommand.Parameters.Add("@icQuantity", MySqlDbType.Int32).Value = orderItemContent.icQuantity;
                        mySqlCommand.Parameters.Add("@teabagQuantity", MySqlDbType.Int32).Value = orderItemContent.teabagQuantity;
                        mySqlCommand.Parameters.Add("@teabagWeight", MySqlDbType.Decimal).Value = orderItemContent.teabagWeight;
                        mySqlCommand.Parameters.Add("@mcMin", MySqlDbType.Decimal).Value = orderItemContent.MCMinWeight;
                        mySqlCommand.Parameters.Add("@mcMax", MySqlDbType.Decimal).Value = orderItemContent.MCMaxWeight;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(orderItemContent.remark) || string.IsNullOrEmpty(orderItemContent.remark) ? "N/A" : orderItemContent.remark);
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();

                    }
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to update the Order Content " + ex.Message, "ERRORCODE");
                }
            }
        }

        //update order item content and insert brand
        public bool updateOrderItemContentWithBrand(OrderItemContent orderItemContent)
        {
            using (connection)
            {
                string lastInsertedBrandId = null;

                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `brand`(`buyer_id`, `brand_name`, `brand_description`, `brand_design_id`) VALUES (@buyerId, @brandName, @brandDesc, @designId);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItemContent.buyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `brand_id` FROM `brand` WHERE `brand_name`=@brandName AND `buyer_id`=@buyerId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = orderItemContent.buyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = orderItemContent.brandName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBrandId = mySqlDataReader.GetString("brand_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitemcontents` SET `brand_id`=@brandId, `teaproduct_id`=@teaproductId, `teabagmaterial_id`=@teabagMaterialId, `ic_qantity`=@icQuantity, `teabag_quantity`=@teabagQuantity, `teabag_weight`=@teabagWeight, `mc_min_weight`=@mcMin, `mc_max_weight`=@mcMax, `content_remarks`=@remarks WHERE `barcode`=@barcode;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = lastInsertedBrandId;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItemContent.barcode;
                        mySqlCommand.Parameters.Add("@teaproductId", MySqlDbType.VarChar).Value = orderItemContent.teaproduct.teaProductId;
                        mySqlCommand.Parameters.Add("@teabagMaterialId", MySqlDbType.VarChar).Value = orderItemContent.teabag.materialId;
                        mySqlCommand.Parameters.Add("@icQuantity", MySqlDbType.Int32).Value = orderItemContent.icQuantity;
                        mySqlCommand.Parameters.Add("@teabagQuantity", MySqlDbType.Int32).Value = orderItemContent.teabagQuantity;
                        mySqlCommand.Parameters.Add("@teabagWeight", MySqlDbType.Decimal).Value = orderItemContent.teabagWeight;
                        mySqlCommand.Parameters.Add("@mcMin", MySqlDbType.Decimal).Value = orderItemContent.MCMinWeight;
                        mySqlCommand.Parameters.Add("@mcMax", MySqlDbType.Decimal).Value = orderItemContent.MCMaxWeight;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(orderItemContent.remark) || string.IsNullOrEmpty(orderItemContent.remark) ? "N/A" : orderItemContent.remark);
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();

                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to update the Order Content." + ex.Message, "ERRORCODE");
                }
            }
        }

        //update order item content
        public bool updateOrderItemContent(OrderItemContent orderItemContent)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitemcontents` SET `brand_id`=@brandId, `teaproduct_id`=@teaproductId, `teabagmaterial_id`=@teabagMaterialId, `ic_qantity`=@icQuantity, `teabag_quantity`=@teabagQuantity, `teabag_weight`=@teabagWeight, `mc_min_weight`=@mcMin, `mc_max_weight`=@mcMax, `content_remarks`=@remarks WHERE `barcode`=@barcode;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = orderItemContent.brandId;
                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItemContent.barcode;
                        mySqlCommand.Parameters.Add("@teaproductId", MySqlDbType.VarChar).Value = orderItemContent.teaproduct.teaProductId;
                        mySqlCommand.Parameters.Add("@teabagMaterialId", MySqlDbType.VarChar).Value = orderItemContent.teabag.materialId;
                        mySqlCommand.Parameters.Add("@icQuantity", MySqlDbType.Int32).Value = orderItemContent.icQuantity;
                        mySqlCommand.Parameters.Add("@teabagQuantity", MySqlDbType.Int32).Value = orderItemContent.teabagQuantity;
                        mySqlCommand.Parameters.Add("@teabagWeight", MySqlDbType.Decimal).Value = orderItemContent.teabagWeight;
                        mySqlCommand.Parameters.Add("@mcMin", MySqlDbType.Decimal).Value = orderItemContent.MCMinWeight;
                        mySqlCommand.Parameters.Add("@mcMax", MySqlDbType.Decimal).Value = orderItemContent.MCMaxWeight;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(orderItemContent.remark) || string.IsNullOrEmpty(orderItemContent.remark) ? "N/A" : orderItemContent.remark);
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to update the Order Content " + ex.Message, "ERRORCODE");
                }
            }
        }

        //delete order item content
        public bool deleteOrderItemContent(string barcode)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `orderitemcontents` WHERE `barcode`=@barcode";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = barcode;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Order Content", "ERRORCODE");
                    }
                }
            }
        }

        //get all order item contents
        public List<OrderItemContent> getAllOrderItemContents()
        {
            List<OrderItemContent> orderItemContents = new List<OrderItemContent>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `buyer` byr, `brand` br, `orderitemcontents` o, `teaproduct` tp, `teabagmaterial` tbm WHERE (o.brand_id = br.brand_id AND br.buyer_id = byr.buyer_id AND o.teaproduct_id = tp.teaproduct_id AND o.teabagmaterial_id = tbm.teabagmaterial_id);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String barcode = mySqlDataReader.GetString("barcode");
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                int icQuantity = mySqlDataReader.GetInt32("ic_qantity");
                                int tbQuantity = mySqlDataReader.GetInt32("teabag_quantity");
                                Decimal tbWeight = mySqlDataReader.GetDecimal("teabag_weight");
                                Decimal mcMinWeight = mySqlDataReader.GetDecimal("mc_min_weight");
                                Decimal mcMaxWeight = mySqlDataReader.GetDecimal("mc_max_weight");
                                String remarks = mySqlDataReader.GetString("content_remarks");

                                String teaproductId = mySqlDataReader.GetString("teaproduct_id");
                                String teaproductSerialNo = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproductName = mySqlDataReader.GetString("teaproduct_name");
                                String teaproductFlavor = mySqlDataReader.GetString("teaproduct_flavor");

                                String teabagMaterialId = mySqlDataReader.GetString("teabagmaterial_id");
                                String teabagMaterialSerialNo = mySqlDataReader.GetString("teabag_serial_no");
                                String teabagMaterialName = mySqlDataReader.GetString("teabag_name");
                                String teabagMaterialType = mySqlDataReader.GetString("teabag_type");

                                TeaProduct teaProduct = new TeaProduct(teaproductId, teaproductName,teaproductFlavor, teaproductSerialNo,"","");
                                TeabagMaterial teabagMaterial = new TeabagMaterial(teabagMaterialId, teabagMaterialName, teabagMaterialType, teabagMaterialSerialNo,"","");
                                OrderItemContent orderItemContent = new OrderItemContent(buyerId, buyerName, brandId, brandName, barcode, teaProduct, teabagMaterial, icQuantity, tbQuantity, tbWeight, mcMinWeight,mcMaxWeight, remarks, -1);
                                orderItemContents.Add(orderItemContent);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Order Contents " + ex.Message, "ERRORCODE");
                    }
                }
            }

            return checkUsage(orderItemContents);
        }

        private List<OrderItemContent> checkUsage(List<OrderItemContent> orderItemContents)
        {
            int numberOfOrderItemsAvailable = 0;

            foreach (OrderItemContent orderItemContent in orderItemContents)
            {
                using (connection)
                {
                    connection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `total_items` FROM `orderitem` WHERE `barcode`=@barcode;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = orderItemContent.barcode;

                        try
                        {
                            using (MySqlDataReader getUsage = mySqlCommand.ExecuteReader())
                            {
                                if (getUsage.HasRows)
                                {
                                    getUsage.Read();
                                    numberOfOrderItemsAvailable = getUsage.IsDBNull(0) ? -1 : getUsage.GetInt32("total_items");
                                }
                            }

                            orderItemContent.numberOfOrderItemsAvailable = numberOfOrderItemsAvailable;
                        }
                        catch (Exception ex)
                        {
                            throw new MSSMUIException("Failed to fetch Order Contents " + ex.Message, "ERRORCODE");
                        }
                    }
                }
            }

            return orderItemContents;
        }


        //get available buyers, brands, teaproducts and teabag materials to fill comboboxes
        public OrderItemContentComboBoxData getComboBoxData()
        {
            OrderItemContentComboBoxData comboBoxData = null;
            List<Buyer> buyers = new List<Buyer>();
            List<Brand> brands = new List<Brand>();
            List<TeaProduct> teaProducts = new List<TeaProduct>();
            List<TeabagMaterial> teabagMaterials = new List<TeabagMaterial>();

            try
            {
                using (connection)
                {
                    connection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `buyer`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String buyer_id = mySqlDataReader.GetString("buyer_id");
                                String buyer_name = mySqlDataReader.GetString("buyer_name");

                                Buyer buyer = new Buyer(buyer_id, buyer_name);
                                buyers.Add(buyer);
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `brand` br, `buyer` byr WHERE br.`buyer_id` = byr.`buyer_id`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String buyer_id = mySqlDataReader.GetString("buyer_id");
                                String buyer_name = mySqlDataReader.GetString("buyer_name");
                                String brand_id = mySqlDataReader.GetString("brand_id");
                                String brand_name = mySqlDataReader.GetString("brand_name");

                                Brand brand = new Brand(buyer_id, buyer_name,brand_id, brand_name);
                                brands.Add(brand);
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `teaproduct`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String teaproduct_id = mySqlDataReader.GetString("teaproduct_id");
                                String teaproduct_serial_no = mySqlDataReader.GetString("teaproduct_serial_no");

                                TeaProduct teaProduct = new TeaProduct(teaproduct_id, teaproduct_serial_no);
                                teaProducts.Add(teaProduct);
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `teabagmaterial`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String material_id = mySqlDataReader.GetString("teabagmaterial_id");
                                String material_name = mySqlDataReader.GetString("teabag_serial_no");

                                TeabagMaterial teabagMaterial = new TeabagMaterial(material_id, material_name);
                                teabagMaterials.Add(teabagMaterial);
                            }
                        }
                    }

                    comboBoxData = new OrderItemContentComboBoxData(buyers, brands, teaProducts, teabagMaterials);

                }
            }
            catch (Exception ex)
            {
                throw new MSSMUIException("Failed to fetch combo box data for Order Contents " + ex.Message, "ERRORCODE");
            }

            return comboBoxData;
        }

        //get order item content by barcode
        public OrderItemContent getOrderItemContentByBarcode(string barcode)
        {
            OrderItemContent orderItemContent = null;

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `buyer` byr, `brand` br, `orderitemcontents` o, `teaproduct` tp, `teabagmaterial` tbm WHERE (o.brand_id = br.brand_id AND br.buyer_id = byr.buyer_id AND o.teaproduct_id = tp.teaproduct_id AND o.teabagmaterial_id = tbm.teabagmaterial_id AND o.`barcode`=@barcode);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = barcode;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                barcode = mySqlDataReader.GetString("barcode");
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                int icQuantity = mySqlDataReader.GetInt32("ic_qantity");
                                int tbQuantity = mySqlDataReader.GetInt32("teabag_quantity");
                                Decimal tbWeight = mySqlDataReader.GetDecimal("teabag_weight");
                                Decimal mcMinWeight = mySqlDataReader.GetDecimal("mc_min_weight");
                                Decimal mcMaxWeight = mySqlDataReader.GetDecimal("mc_max_weight");
                                String remarks = mySqlDataReader.GetString("content_remarks");

                                String teaproductId = mySqlDataReader.GetString("teaproduct_id");
                                String teaproductSerialNo = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproductName = mySqlDataReader.GetString("teaproduct_name");
                                String teaproductFlavor = mySqlDataReader.GetString("teaproduct_flavor");

                                String teabagMaterialId = mySqlDataReader.GetString("teabagmaterial_id");
                                String teabagMaterialSerialNo = mySqlDataReader.GetString("teabag_serial_no");
                                String teabagMaterialName = mySqlDataReader.GetString("teabag_name");
                                String teabagMaterialType = mySqlDataReader.GetString("teabag_type");

                                TeaProduct teaProduct = new TeaProduct(teaproductId, teaproductName, teaproductFlavor, teaproductSerialNo, "", "");
                                TeabagMaterial teabagMaterial = new TeabagMaterial(teabagMaterialId, teabagMaterialName, teabagMaterialType, teabagMaterialSerialNo, "", "");
                                orderItemContent = new OrderItemContent(buyerId, buyerName, brandId, brandName, barcode, teaProduct, teabagMaterial, icQuantity, tbQuantity, tbWeight, mcMinWeight, mcMaxWeight, remarks, -1);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Order Content " + ex.Message, "ERRORCODE");
                }
            }

            return orderItemContent;
        }


        //BUYERS
        //add buyer
        public bool addBuyer(Buyer buyer)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `buyer`(`buyer_name`, `buyer_email`, `buyer_description`) VALUES (@buyerName, @buyerEmail , @buyerDesc)";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = buyer.buyerName;
                    mySqlCommand.Parameters.Add("@buyerEmail", MySqlDbType.VarChar).Value = (string.IsNullOrEmpty(buyer.buyerEmail) || string.IsNullOrWhiteSpace(buyer.buyerEmail) ? "N/A" : buyer.buyerEmail);
                    mySqlCommand.Parameters.Add("@buyerDesc", MySqlDbType.VarChar).Value = (string.IsNullOrEmpty(buyer.buyerDescription) || string.IsNullOrWhiteSpace(buyer.buyerDescription) ? "N/A" : buyer.buyerDescription);
                    mySqlCommand.Prepare();
                    
                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to add the Buyer", "ERRORCODE");
                    }
                }
            }
        }

        //update buyer
        public bool updateBuyer(Buyer buyer)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `buyer` SET `buyer_name`=@buyerName, `buyer_email`=@buyerEmail, `buyer_description`=@buyerDesc WHERE `buyer_id`=@buyerID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = buyer.buyerName;
                    mySqlCommand.Parameters.Add("@buyerID", MySqlDbType.VarChar).Value = buyer.buyerId;
                    mySqlCommand.Parameters.Add("@buyerEmail", MySqlDbType.VarChar).Value = (string.IsNullOrEmpty(buyer.buyerEmail) || string.IsNullOrWhiteSpace(buyer.buyerEmail) ? "N/A" : buyer.buyerEmail);
                    mySqlCommand.Parameters.Add("@buyerDesc", MySqlDbType.VarChar).Value = (string.IsNullOrEmpty(buyer.buyerDescription) || string.IsNullOrWhiteSpace(buyer.buyerDescription) ? "N/A" : buyer.buyerDescription);

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Buyer " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete buyer
        public bool deleteBuyer(string buyer_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `buyer` WHERE `buyer_id`=@buyerID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@buyerID", MySqlDbType.VarChar).Value = buyer_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Buyer", "ERRORCODE");
                    }
                }
            }
        }

        //get all buyers
        public List<Buyer> getAllBuyers()
        {
            List<Buyer> buyers = new List<Buyer>();

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `buyer`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                String buyerEmail = mySqlDataReader.GetString("buyer_email");
                                String buyerDesc = mySqlDataReader.GetString("buyer_description");

                                Buyer buyer = new Buyer(buyerId, buyerName, buyerEmail, buyerDesc);
                                buyers.Add(buyer);
                            }
                        }

                    }

                    foreach (Buyer buyer in buyers)
                    {
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "SELECT COUNT(*) AS `total_items` FROM `brand` WHERE `buyer_id`=@buyerId;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = buyer.buyerId;

                            using (MySqlDataReader getUsage = mySqlCommand.ExecuteReader())
                            {
                                if (getUsage.HasRows)
                                {
                                    getUsage.Read();
                                    buyer.buyerUsage = getUsage.GetInt32("total_items");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Buyers. " + ex.Message, "ERRORCODE");
                }
            }
            return buyers;
        }

        //BRANDS
        //add brand with buyer
        public bool addBrandWithBuyer(Brand brand)
        {
            using (connection)
            {
                string lastInsertedBuyerId = null;

                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `buyer`(`buyer_name`, `buyer_email`, `buyer_description`) VALUES (@buyerName, @buyerEmail , @buyerDesc)";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = brand.buyerName;
                        mySqlCommand.Parameters.Add("@buyerEmail", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@buyerDesc", MySqlDbType.VarChar).Value = "N/A";

                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `buyer_id` FROM `buyer` WHERE `buyer_name`=@buyerName;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = brand.buyerName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBuyerId = mySqlDataReader.GetString("buyer_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `brand`(`buyer_id`, `brand_name`, `brand_description`, `brand_design_id`) VALUES (@buyerId, @brandName, @brandDesc, @designId);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = lastInsertedBuyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = brand.brandName;
                        mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(brand.brandDesc) || string.IsNullOrEmpty(brand.brandDesc) ? "N/A" : brand.brandDesc);
                        mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to add the Brand " + ex.Message, "ERRORCODE");
                }
            }
        }

        //add brand
        public bool addBrand(Brand brand)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `brand`(`brand_name`,`brand_description`,`buyer_id`,`brand_design_id`) VALUES (@brandName, @brandDesc, @buyerId, @designId)";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = brand.brandName;
                    mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(brand.brandDesc) || string.IsNullOrEmpty(brand.brandDesc) ? "N/A" : brand.brandDesc);
                    mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = brand.buyerId;
                    mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to add the Brand " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //update brand with buyer
        public bool updateBrandWithBuyer(Brand brand)
        {
            using (connection)
            {
                string lastInsertedBuyerId = null;

                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `buyer`(`buyer_name`, `buyer_email`, `buyer_description`) VALUES (@buyerName, @buyerEmail , @buyerDesc)";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = brand.buyerName;
                        mySqlCommand.Parameters.Add("@buyerEmail", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Parameters.Add("@buyerDesc", MySqlDbType.VarChar).Value = "N/A";
                        mySqlCommand.Prepare();
                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `buyer_id` FROM `buyer` WHERE `buyer_name`=@buyerName;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Parameters.Add("@buyerName", MySqlDbType.VarChar).Value = brand.buyerName;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                lastInsertedBuyerId = mySqlDataReader.GetString("buyer_id");
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `brand` SET `buyer_id`=@buyerId, `brand_name`=@brandName, `brand_description`=@brandDesc, `brand_design_id`=@designId WHERE `brand_id`=@brandId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = lastInsertedBuyerId;
                        mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = brand.buyerId;
                        mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = brand.brandName;
                        mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(brand.brandDesc) || string.IsNullOrEmpty(brand.brandDesc) ? "N/A" : brand.brandDesc);
                        mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;

                        mySqlCommand.ExecuteNonQuery();

                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to update the Brand " + ex.Message, "ERRORCODE");
                }
            }
        }

        //update brand
        public bool updateBrand(Brand brand)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `brand` SET `buyer_id`=@buyerId, `brand_name`=@brandName, `brand_description`=@brandDesc, `brand_design_id`=@designId WHERE `brand_id`=@brandId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection; 

                    mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = brand.brandId;
                    mySqlCommand.Parameters.Add("@buyerId", MySqlDbType.VarChar).Value = brand.buyerId;
                    mySqlCommand.Parameters.Add("@brandName", MySqlDbType.VarChar).Value = brand.brandName;
                    mySqlCommand.Parameters.Add("@brandDesc", MySqlDbType.VarChar).Value = (string.IsNullOrWhiteSpace(brand.brandDesc) || string.IsNullOrEmpty(brand.brandDesc) ? "N/A" : brand.brandDesc);
                    mySqlCommand.Parameters.Add("@designId", MySqlDbType.VarChar).Value = null;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Brand " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete brand
        public bool deleteBrand(string brand_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `brand` WHERE `brand_id`=@brandID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@brandID", MySqlDbType.VarChar).Value = brand_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Brand", "ERRORCODE");
                    }
                }
            }
        }

        //get all brands
        public List<Brand> getAllBrands()
        {
            List<Brand> brands = new List<Brand>();

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `buyer` byr, `brand` br WHERE br.buyer_id = byr.buyer_id;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");
                                String brandDesc = mySqlDataReader.GetString("brand_description");
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                
                                Brand brand = new Brand(buyerId, buyerName, brandId, brandName, brandDesc);
                                brands.Add(brand);
                            }
                        }
                    }

                    foreach (Brand brand in brands)
                    {
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "SELECT COUNT(*) AS `total_items` FROM `orderitemcontents` WHERE `brand_id`=@brandId;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = brand.brandId;

                            using (MySqlDataReader getUsage = mySqlCommand.ExecuteReader())
                            {
                                if (getUsage.HasRows)
                                {
                                    getUsage.Read();
                                    brand.brandUsage = getUsage.GetInt32("total_items");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Brand. " + ex.Message, "ERRORCODE");
                }
            }
            return brands;
        }

        //get brand by brand id
        public Brand getBrandByBrandId(string brand_id)
        {
            Brand brand = null;

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `buyer` byr, `brand` br, WHERE br.buyer_id = byr.buyer_id AND br.brand_id=@brandId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@brandId", MySqlDbType.VarChar).Value = brand_id;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");
                                String brandDesc = mySqlDataReader.GetString("brand_description");
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");

                                brand = new Brand(buyerId, buyerName, brandId, brandName, brandDesc);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch updated brand details " + ex.Message, "ERRORCODE");
                }
            }

            return brand;
        }

        //SEARCH QUERIES
        //BRANDS
        //search everywhere in brands
        public List<Brand> searchBrands(string keyword)
        {
            List<Brand> brands = new List<Brand>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `buyer` byr, `brand` br WHERE (br.buyer_id = byr.buyer_id) AND (`brand_id` LIKE @keyword OR `brand_name` LIKE @keyword OR `buyer_name` LIKE @keyword OR `brand_description` LIKE @keyword);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");
                                String brandDesc = mySqlDataReader.GetString("brand_description");
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");

                                Brand brand = new Brand(buyerId, buyerName, brandId, brandName, brandDesc);
                                brands.Add(brand);
                            }

                            return brands;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //search in brands by column
        public List<Brand> searchBrandsUsingColumn(string column, string keyword)
        {
            List<Brand> brands = new List<Brand>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `buyer` byr, `brand` br WHERE (br.buyer_id = byr.buyer_id) AND  `" + column + "` LIKE @keyword;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");
                                String brandDesc = mySqlDataReader.GetString("brand_description");
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");

                                Brand brand = new Brand(buyerId, buyerName, brandId, brandName, brandDesc);
                                brands.Add(brand);
                            }

                            return brands;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //BUYERS
        //search everywhere in buyers
        public List<Buyer> searchBuyers(string keyword)
        {
            List<Buyer> buyers = new List<Buyer>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `buyer` WHERE `buyer_id` LIKE @keyword OR `buyer_name` LIKE @keyword OR `buyer_email` LIKE @keyword OR `buyer_description` LIKE @keyword;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                String buyerEmail = mySqlDataReader.GetString("buyer_email");
                                String buyerDesc = mySqlDataReader.GetString("buyer_description");

                                Buyer buyer = new Buyer(buyerId, buyerName, buyerEmail, buyerDesc);
                                buyers.Add(buyer);
                            }
                        }
                        return buyers;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //search in buyers by column
        public List<Buyer> searchBuyersUsingColumn(string column, string keyword)
        {
            List<Buyer> buyers = new List<Buyer>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `buyer` WHERE `" + column + "` LIKE @keyword;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                String buyerEmail = mySqlDataReader.GetString("buyer_email");
                                String buyerDesc = mySqlDataReader.GetString("buyer_description");

                                Buyer buyer = new Buyer(buyerId, buyerName, buyerEmail, buyerDesc);
                                buyers.Add(buyer);
                            }
                        }
                        return buyers;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //ORDERITEMS
        //Search all columns in OI
        /*public List<OrderItem> searchOrderItems(string keyword)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `buyer` WHERE `buyer_id` LIKE @keyword OR `buyer_name` LIKE @keyword OR `buyer_email` LIKE @keyword OR `buyer_description` LIKE @keyword;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                String buyerEmail = mySqlDataReader.GetString("buyer_email");
                                String buyerDesc = mySqlDataReader.GetString("buyer_description");

                                OrderItem orderItem = new OrderItem();
                                orderItems.Add(orderItem);
                            }
                        }
                        return orderItems;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //Search by column only in OI
        public List<OrderItem> searchOrderItemsUsingColumn(string column, string keyword)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `buyer` WHERE `" + column + "` LIKE @keyword;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");
                                String buyerEmail = mySqlDataReader.GetString("buyer_email");
                                String buyerDesc = mySqlDataReader.GetString("buyer_description");

                                OrderItem orderItem = new OrderItem(buyerId, buyerName, buyerEmail, buyerDesc);
                                orderItems.Add(orderItem);
                            }
                        }
                        return orderItems;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }*/
    }
}