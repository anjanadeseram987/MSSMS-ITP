using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class DeptDesig
    {
        public string deptId { get; private set; }
        public string desigId { get; private set; }
        public string deptName { get; private set; }
        public string desigName { get; private set; }

        //or as two grouped-by lists
        public List<Department> departments { get; private set; }
        public List<Designation> designations { get; private set; }

        public DeptDesig(string deptId, string desigId, string deptName, string desigName)
        {
            this.deptId = deptId;
            this.desigId = desigId;
            this.deptName = deptName;
            this.desigName = desigName;
        }

        public DeptDesig(List<Department> departments, List<Designation> designations)
        {
            this.departments = departments;
            this.designations = designations;
        }
    }
}
