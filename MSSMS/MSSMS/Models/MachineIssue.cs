using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class MachineIssue
    {
        public string issue_id { get; private set; }
        public string subject { get; private set; }
        public string machine_id { get; private set; }
        public string submitted_by { get; private set; }
        public DateTime submitted_date { get; private set; }
        public string description { get; private set; }
        public string priority_level { get; private set; }
        public string status { get; private set; }
        public Machine machine { get; set; }

        public MachineIssue(string issue_id, string subject, string machine_id, string submitted_by, DateTime submitted_date, string description, string priority_level, string status)
        {
            this.issue_id = issue_id;
            this.subject = subject;
            this.machine_id = machine_id;
            this.submitted_by = submitted_by;
            this.submitted_date = submitted_date;
            this.description = description;
            this.priority_level = priority_level;
            this.status = status;
        }
    }
}
