using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Contract
    {
        public string contract_no { get; private set; }
        public DateTime contract_placement_date { get; private set; }
        public string contract_status { get; private set; }

        public Contract(DateTime contract_placement_date, string contract_status)
        {
            this.contract_placement_date = contract_placement_date;
            this.contract_status = contract_status;
        }

        public Contract(string contract_no, DateTime contract_placement_date, string contract_status)
        {
            this.contract_no = contract_no;
            this.contract_placement_date = contract_placement_date;
            this.contract_status = contract_status;
        }
    }
}
