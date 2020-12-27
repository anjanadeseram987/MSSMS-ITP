using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Department
    {
        public string dept_id { get; private set; }
        public string dept_name { get; private set; }
        public string description { get; private set; }
        public string contact_no { get; private set; }
        public string email { get; private set; }
        public int tot_emp { get; set; }
        public int tot_nemp { get; set; }        

        public Department ()
        {

        }

        public Department(string dept_id, string dept_name)
        {
            this.dept_id = dept_id;
            this.dept_name = dept_name;
        }

        public Department( string dept_id, string dept_name, string description, string contact_no, string email)
        {
            this.dept_name = dept_name;
            this.dept_id = dept_id;
            this.description = description;
            this.contact_no = contact_no;
            this.email = email;
        }

        public Department(string dept_name, string description, string contact_no, string email)
        {
            this.dept_name = dept_name;
            this.description = description;
            this.contact_no = contact_no;
            this.email = email;
        }


    }
}
