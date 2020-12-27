using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class FinishedGood
    {
        public string fg_orderitem_no { get; private set; }
        public string fg_mc_no { get; private set; }
        public string fg_location_id { get; private set; }
        public string fg_added_by { get; private set; }
        public DateTime fg_added_date { get; private set; }
        public Decimal fg_mc_weight { get; private set; }
        public DateTime fg_exp_date { get; private set; }
        public string fg_status { get; private set; }
        public string fg_remarks { get; private set; }
        public OrderItem orderItem { get; set; }
        public String orderNo { get; set; }
        public int totalMCQuantity { get; set; }
        public String productionPlanId { get; set; }

        public FinishedGood(string fg_orderitem_no, string fg_mc_no, string fg_location_id, string fg_added_by, DateTime fg_added_date, decimal fg_mc_weight, DateTime fg_exp_date, string fg_status, string fg_remarks)
        {
            this.fg_orderitem_no = fg_orderitem_no;
            this.fg_mc_no = fg_mc_no;
            this.fg_location_id = fg_location_id;
            this.fg_added_by = fg_added_by;
            this.fg_added_date = fg_added_date;
            this.fg_mc_weight = fg_mc_weight;
            this.fg_exp_date = fg_exp_date;
            this.fg_status = fg_status;
            this.fg_remarks = fg_remarks;
        }
    }
}
