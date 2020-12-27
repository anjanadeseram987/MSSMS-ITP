using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class StoredGood
    {
        public string sg_orderitem_no { get; private set; }
        public string sg_mc_no { get; private set; }
        public string sg_location_id { get; private set; }
        public string sg_stored_by { get; private set; }
        public DateTime sg_stored_date { get; private set; }
        public string sg_issued_by { get; private set; }
        public DateTime sg_issued_date { get; private set; }
        public string sg_status { get; private set; }
        public string sg_remarks { get; private set; }
        public FinishedGood finishedGood { get; set; }

        public StoredGood(string sg_orderitem_no, string sg_mc_no, string sg_location_id, string sg_stored_by, DateTime sg_stored_date, string sg_issued_by, DateTime sg_issued_date, string sg_status, string sg_remarks)
        {
            this.sg_orderitem_no = sg_orderitem_no;
            this.sg_mc_no = sg_mc_no;
            this.sg_location_id = sg_location_id;
            this.sg_stored_by = sg_stored_by;
            this.sg_stored_date = sg_stored_date;
            this.sg_issued_by = sg_issued_by;
            this.sg_issued_date = sg_issued_date;
            this.sg_status = sg_status;
            this.sg_remarks = sg_remarks;
        }
    }
}
