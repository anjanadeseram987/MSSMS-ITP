using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class OrderItemStatusCount
    {
        public string order_no { get; private set; }
        public int orderitem_other_count { get; set; }
        public int orderitem_pending_count { get; set; }

        public OrderItemStatusCount(string order_no)
        {
            this.order_no = order_no;
        }
    }
}
