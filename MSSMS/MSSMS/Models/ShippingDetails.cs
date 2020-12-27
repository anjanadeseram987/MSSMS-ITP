using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class ShippingDetails
    {
        public string addressId { get; private set; }
        public string location { get; private set; }
        public string address { get; private set; }
        public string buyerId { get; private set; }

        public ShippingDetails(string location, string address)
        {
            this.location = location;
            this.address = address;
        }

        public ShippingDetails(string addressId, string location, string address, string buyerId)
        {
            this.addressId = addressId;
            this.location = location;
            this.address = address;
            this.buyerId = buyerId;
        }
    }
}
