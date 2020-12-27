using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Designation
    {
        public string desig_id { get; private set; }
        public string desig_name { get; private set; }
        public string description { get; private set; }
        public string dept_id { get; private set; }
        public string dept_name { get; private set; }

        public Designation()
        {

        }

        public Designation(string desig_name, string description, string dept_id)
        {
            this.desig_name = desig_name;
            this.description = description;
            this.dept_id = dept_id;
        }


        public Designation(string desig_name, string description, string dept_id, string dept_name)
        {
            this.desig_name = desig_name;
            this.description = description;
            this.dept_id = dept_id;
            this.dept_name = dept_name;
        }


        public Designation(string desig_id, string desig_name, string description, string dept_id, int dummyValue)
        {
            this.desig_id = desig_id;
            this.desig_name = desig_name;
            this.description = description;
            this.dept_id = dept_id;
        }


        public Designation(string desig_id, string desig_name, string description, string dept_id, string dept_name)
        {
            this.desig_id = desig_id;
            this.desig_name = desig_name;
            this.description = description;
            this.dept_id = dept_id;
            this.dept_name = dept_name;
        }
    }
}
