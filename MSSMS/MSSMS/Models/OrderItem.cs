using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class OrderItem
    {
        public string orderItemNo { get; private set; }
        public string orderNo { get; private set; }
        public string contractNo { get; private set; }
        public string buyerId { get; private set; }
        public string brandId { get; private set; }
        public string barcode { get; private set; }
        public ShippingDetails shippingDetails { get; private set; }
        public int mcQuantity { get; private set; }
        public int mcFirst { get; private set; }
        public int mcLast { get; private set; }
        public string productionPlanId { get; private set; }
        public string remarks { get; private set; }
        public Buyer buyer { get; private set; }
        public Brand brand { get; private set; }
        public TeaProduct teaProduct { get; private set; }
        public OrderItemContent orderItemContent { get; private set; }
        public Order order { get; private set; }
        public String productionmanager_id { get; private set; }
        public String orderitem_status { get; private set; }
        public DateTime orderitem_placement_date { get; private set; }
        public DateTime orderitem_production_startdate { get; private set; }
        public DateTime orderitem_production_enddate { get; private set; }
        public Contract contract { get; set; }
        public ShippingSchedule shippingSchedule { get; set; }
        public TeabagMaterial teabagMaterial { get; set; }
        public Location location { get; set; }
        public int mc_count { get;  set; }
        public int stored_mc_count { get; set; }
        public int stored_mc_exp_count { get; set; }
        public int loaded_mc_count { get; set; }
        public List<FinishedGood> finishedGoods { get; set; }
        public List<StoredGood> storedGoods { get; set; }
        public int manufact_mc_monthly { get; set; }
        public int manufact_mc { get; set; }

    public OrderItem(string orderItemNo, string orderItemStatus)
        {
            this.orderNo = orderNo;
            this.orderitem_status = orderItemStatus;
        }

        public OrderItem(string orderItemNo, string orderNo, string contractNo, string buyerId, string brandId, string barcode, ShippingDetails shippingDetails, int mcQuantity, int mcFirst, int mcLast, string productionPlanId, string remarks)
        {
            this.orderItemNo = orderItemNo;
            this.orderNo = orderNo;
            this.contractNo = contractNo;
            this.buyerId = buyerId;
            this.brandId = brandId;
            this.barcode = barcode;
            this.shippingDetails = shippingDetails;
            this.mcQuantity = mcQuantity;
            this.mcFirst = mcFirst;
            this.mcLast = mcLast;
            this.productionPlanId = productionPlanId;
            this.remarks = remarks;
        }

        public OrderItem(Buyer buyer, Brand brand, TeaProduct teaProduct, OrderItemContent orderItemContent, ShippingDetails shippingDetail, Order order, String orderitem_no ,String contract_no, String order_placed_by, DateTime orderitem_placement_date, String productionplan_id, int mc_quantity, int mc_start, int mc_end, String orderitem_status, DateTime orderitem_production_startdate, DateTime orderitem_production_enddate) {
            this.buyer = buyer;
            this.brand = brand;
            this.teaProduct = teaProduct;
            this.orderItemContent = orderItemContent;
            this.shippingDetails = shippingDetail;
            this.order = order;
            this.orderItemNo = orderitem_no;
            this.contractNo = contract_no;
            this.productionmanager_id = order_placed_by;
            this.orderitem_placement_date = orderitem_placement_date;
            this.productionPlanId = productionplan_id;
            this.mcQuantity = mc_quantity;
            this.mcFirst = mc_start;
            this.mcLast = mc_end;
            this.remarks = remarks;
            this.orderitem_status = orderitem_status;
            this.orderitem_production_startdate = orderitem_production_startdate;
            this.orderitem_production_enddate = orderitem_production_enddate;
        }
    }
}
