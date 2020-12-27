using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class OrderItemContent
    {
        public string buyerId { get; private set; }
        public string buyerName { get; private set; }
        public string brandId { get; private set; }
        public string brandName { get; private set; }
        public string barcode { get; private set; }
        public TeaProduct teaproduct { get; private set; }
        public TeabagMaterial teabag { get; private set; }
        public int icQuantity { get; private set; }
        public int teabagQuantity { get; private set; }
        public decimal teabagWeight { get; private set; }
        public decimal MCMinWeight { get; private set; }
        public decimal MCMaxWeight { get; private set; }
        public string remark { get; private set; }
        public int numberOfOrderItemsAvailable { get; set; }


        public OrderItemContent(string buyerName, string brandName, string barcode, TeaProduct teaproduct, TeabagMaterial teabag, int icQuantity, int teabagQuantity, decimal teabagWeight, decimal mCMinWeight, decimal mCMaxWeight, string remark)
        {
            this.buyerName = buyerName;
            this.brandName = brandName;
            this.barcode = barcode;
            this.teaproduct = teaproduct;
            this.teabag = teabag;
            this.icQuantity = icQuantity;
            this.teabagQuantity = teabagQuantity;
            this.teabagWeight = teabagWeight;
            MCMinWeight = mCMinWeight;
            MCMaxWeight = mCMaxWeight;
            this.remark = remark;
        }

        public OrderItemContent(string buyerId, string buyerName, string brandId, string brandName, string barcode, TeaProduct teaproduct, TeabagMaterial teabag, int icQuantity, int teabagQuantity, decimal teabagWeight, decimal mCMinWeight, decimal mCMaxWeight, string remark)
        {
            this.buyerId = buyerId;
            this.buyerName = buyerName;
            this.brandId = brandId;
            this.brandName = brandName;
            this.barcode = barcode;
            this.teaproduct = teaproduct;
            this.teabag = teabag;
            this.icQuantity = icQuantity;
            this.teabagQuantity = teabagQuantity;
            this.teabagWeight = teabagWeight;
            MCMinWeight = mCMinWeight;
            MCMaxWeight = mCMaxWeight;
            this.remark = remark;
        }

        public OrderItemContent(string buyerId, string buyerName, string brandId, string brandName, string barcode, TeaProduct teaproduct, TeabagMaterial teabag, int icQuantity, int teabagQuantity, decimal teabagWeight, decimal mCMinWeight, decimal mCMaxWeight, string remark, int numberOfOrderItemsAvailable)
        {
            this.buyerId = buyerId;
            this.buyerName = buyerName;
            this.brandId = brandId;
            this.brandName = brandName;
            this.barcode = barcode;
            this.teaproduct = teaproduct;
            this.teabag = teabag;
            this.icQuantity = icQuantity;
            this.teabagQuantity = teabagQuantity;
            this.teabagWeight = teabagWeight;
            MCMinWeight = mCMinWeight;
            MCMaxWeight = mCMaxWeight;
            this.remark = remark;
            this.numberOfOrderItemsAvailable = numberOfOrderItemsAvailable;
        }
    }
}
