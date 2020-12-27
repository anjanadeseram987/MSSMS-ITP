using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Brand
    {
        public string buyerId { get; private set; }
        public string buyerName { get; private set; }
        public string brandId { get; private set; }
        public string brandName { get; private set; }
        public string brandDesc { get; private set; }
        public int brandUsage { get; set; } = -1;

        public Brand(string brandId, string brandName)
        {
            this.brandId = brandId;
            this.brandName = brandName;
        }

        public Brand(string buyerId, string buyerName, string brandId, string brandName) : this(brandId, brandName)
        {
            this.buyerId = buyerId;
            this.buyerName = buyerName;
        }

        public Brand(string buyerId, string buyerName, string brandId, string brandName, string brandDesc) : this(buyerId, buyerName, brandId, brandName)
        {
            this.brandDesc = brandDesc;
        }
    }
}
