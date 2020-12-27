using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class TeaProduct
    {
        public string teaProductId { get; private set; }
        public string teaProductName { get; private set; }
        public string teaProductflavor { get; private set; }
        public string teaProductserialNo { get; private set; }
        public string teaProductdescription { get; private set; }
        public string teaProductavailability { get; private set; }
        public int used_by_items_count { get; set; }
        public int total_items_count { get; set; }

        public TeaProduct(string teaProductId, string teaProductserialNo)
        {
            this.teaProductId = teaProductId;
            this.teaProductserialNo = teaProductserialNo;
        }

        public TeaProduct(string teaProductName, string teaProductflavor, string teaProductserialNo, string teaProductdescription, string teaProductavailability)
        {
            this.teaProductName = teaProductName;
            this.teaProductflavor = teaProductflavor;
            this.teaProductserialNo = teaProductserialNo;
            this.teaProductdescription = teaProductdescription;
            this.teaProductavailability = teaProductavailability;
        }

        public TeaProduct(string teaProductId, string teaProductName, string teaProductflavor, string teaProductserialNo, string teaProductdescription, string teaProductavailability)
        {
            this.teaProductId = teaProductId;
            this.teaProductName = teaProductName;
            this.teaProductflavor = teaProductflavor;
            this.teaProductserialNo = teaProductserialNo;
            this.teaProductdescription = teaProductdescription;
            this.teaProductavailability = teaProductavailability;
        }
    }
}
