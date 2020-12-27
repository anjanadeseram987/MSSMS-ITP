using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class ShippingSchedule
    {
        public string shippingschedule_id { get; set; }
        public DateTime loading_date { get; private set; }
        public DateTime shipping_date { get; private set; }
        public string destination { get; private set; }
        public string address { get; private set; }
        public string added_by { get; private set; }
        public DateTime added_date { get; private set; }
        public string approved_by { get; private set; }
        public DateTime approved_date { get; private set; }
        public string remarks { get; private set; }
        public string status { get; private set; }
        public int oi_per_ss_count { get; set; }
        public string contract_no { get; set; }
        public int total_mc_count { get; set; }
        public int manufact_mc_count { get; set; }
        public int stored_mc_count { get; set; }
        public int loaded_mc_count { get; set; }


        public ShippingSchedule(string shippingschedule_id, DateTime loading_date, DateTime shipping_date)
        {
            this.shippingschedule_id = shippingschedule_id;
            this.loading_date = loading_date;
            this.shipping_date = shipping_date;
        }

        public ShippingSchedule(string shippingschedule_id, DateTime loading_date, DateTime shipping_date, string destination, string address, string added_by, DateTime added_date, string approved_by, DateTime approved_date, string remarks, string status) : this(shippingschedule_id, loading_date, shipping_date)
        {
            this.destination = destination;
            this.address = address;
            this.added_by = added_by;
            this.added_date = added_date;
            this.approved_by = approved_by;
            this.approved_date = approved_date;
            this.remarks = remarks;
            this.status = status;
        }
    }
}
