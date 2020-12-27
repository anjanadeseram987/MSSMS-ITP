using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Order
    {

        public string order_no { get; private set; }
        public Buyer buyer { get; private set; }
        public DateTime order_placement_date { get; private set; }
        public string order_status { get; private set; }

        public Order(string order_no, Buyer buyer, DateTime order_placement_date, string order_status)
        {
            this.order_no = order_no;
            this.buyer = buyer;
            this.order_placement_date = order_placement_date;
            this.order_status = order_status;
        }
    }
}
