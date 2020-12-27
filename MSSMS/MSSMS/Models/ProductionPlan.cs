using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class ProductionPlan
    {
        public string productionplan_id { get; set; }
        public string productionplan_name { get; private set; }
        public DateTime start_date { get; private set; }
        public DateTime end_date { get; private set; }
        public string added_by { get; private set; }
        public DateTime added_date { get; private set; }
        public string approved_by { get; private set; }
        public DateTime approved_date { get; private set; }
        public string remarks { get; private set; }
        public string status { get; private set; }
        public int oi_count { get; set; }

        public ProductionPlan(string productionplan_id, string productionplan_name, DateTime start_date, DateTime end_date, string added_by, DateTime added_date, string approved_by, DateTime approved_date, string remarks, string status)
        {
            this.productionplan_id = productionplan_id;
            this.productionplan_name = productionplan_name;
            this.start_date = start_date;
            this.end_date = end_date;
            this.added_by = added_by;
            this.added_date = added_date;
            this.approved_by = approved_by;
            this.approved_date = approved_date;
            this.remarks = remarks;
            this.status = status;
        }
    }
}
