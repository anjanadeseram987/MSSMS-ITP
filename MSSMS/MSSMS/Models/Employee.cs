using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Employee
    {
        public string employeeId { get; private set; }
        public string fullName { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public DateTime birthday { get; private set; }
        public string gender { get; private set; }
        public string designationId { get; private set; }
        public string designationName { get; private set; }
        public DateTime dateRecruited { get; private set; }
        public string primaryEmail { get; private set; }
        public string primaryPhone { get; private set; }

        public Employee()
        {

        }

        public Employee(string fullName, string firstName, string lastName, DateTime birthday, string gender, string designationId, DateTime dateRecruited, string primaryEmail, string primaryPhone)
        {
            this.fullName = fullName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.gender = gender;
            this.designationId = designationId;
            this.dateRecruited = dateRecruited;
            this.primaryEmail = primaryEmail;
            this.primaryPhone = primaryPhone;
        }

        public Employee(string employeeId, string fullName, string firstName, string lastName, DateTime birthday, string gender, string designationId, DateTime dateRecruited, string primaryEmail, string primaryPhone)
        {
            this.employeeId = employeeId;
            this.fullName = fullName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.gender = gender;
            this.designationId = designationId;
            this.dateRecruited = dateRecruited;
            this.primaryEmail = primaryEmail;
            this.primaryPhone = primaryPhone;
        }

        public Employee(string employee_id, string full_name, string first_name, string last_name, string gender, DateTime birthday, string designationId, string designationName, DateTime date_recruited, string email, string phone)
        {
            this.employeeId = employee_id;
            this.fullName = full_name;
            this.firstName = first_name;
            this.lastName = last_name;
            this.gender = gender;
            this.birthday = birthday;
            this.designationId = designationId;
            this.designationName = designationName;
            this.dateRecruited = date_recruited;
            this.primaryEmail = email;
            this.primaryPhone = phone;
        }


    }
}
