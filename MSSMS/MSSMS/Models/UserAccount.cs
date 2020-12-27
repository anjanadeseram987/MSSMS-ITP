using System;

namespace MSSMS.Models
{
    public class UserAccount
    {
        //for all details including employee details
        public string employeeId { get; private set; }
        public string fullName { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public DateTime birthday { get; private set; }
        public string gender { get; private set; }
        public string designationName { get; private set; }
        public DateTime dateRecruited { get; private set; }
        public string primaryEmail { get; private set; }
        public string primaryPhone { get; private set; }
        //public string address { get; private set; }

        //for user accounts
        public string username { get; private set; }
        public string newPassword { get; private set; }
        public string secondaryEmail { get; private set; }
        public byte[] profilePicture { get; private set; }
        //public int profilePictureSize { get; private set; }
        public string authorizationStatus { get; private set; }
        public string authorizedBy { get; private set; }
        public string role { get; private set; }
        public string departmentId { get; private set; }
        public string designationId { get; private set; }
        public string departmentName { get; private set; }

        public UserAccount()
        {

        }

        public UserAccount(string employeeId, string username, string newPassword, string secondaryEmail, byte[] profilePicture, string authorizationStatus, string authorizedBy, string role)
        {
            this.employeeId = employeeId;
            this.username = username;
            this.newPassword = newPassword;
            this.secondaryEmail = secondaryEmail;
            this.profilePicture = profilePicture;
            this.authorizationStatus = authorizationStatus;
            this.authorizedBy = authorizedBy;
            this.role = role;
        }
        public UserAccount(string employeeId, string firstName, string lastName, string fullName, string gender, DateTime birthday, string primaryEmail, string primaryPhone, byte[] profilePicture)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = fullName;
            this.gender = gender;
            this.birthday = birthday;
            this.primaryEmail = primaryEmail;
            this.primaryPhone = primaryPhone;
            this.profilePicture = profilePicture;
        }

        public UserAccount(string employeeId, string firstName, string lastName, string fullName, string gender, DateTime birthday, string primaryEmail, string secondaryEmail, string primaryPhone, string username, string role, string authorizationStatus, string authorizedBy, byte[] profilePicture, string departmentName, string designationName, string departmentId, string designationId)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = fullName;
            this.gender = gender;
            this.birthday = birthday;
            this.primaryEmail = primaryEmail;
            this.secondaryEmail = secondaryEmail;
            this.primaryPhone = primaryPhone;
            this.username = username;
            this.role = role;
            this.authorizationStatus = authorizationStatus;
            this.profilePicture = profilePicture;
            this.departmentName = departmentName;
            this.designationName = designationName;
            this.departmentId = departmentId;
            this.designationId = designationId;
            this.authorizedBy = authorizedBy;
        }

        public UserAccount(string employeeId, string firstName, string lastName, string fullName, string gender, DateTime birthday, string primaryEmail, string secondaryEmail, string primaryPhone, string username, string role, string authorizationStatus, string authorizedBy, byte[] profilePicture, string departmentName, string designationName, string departmentId, string designationId, string newPassword)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = fullName;
            this.gender = gender;
            this.birthday = birthday;
            this.primaryEmail = primaryEmail;
            this.secondaryEmail = secondaryEmail;
            this.primaryPhone = primaryPhone;
            this.username = username;
            this.role = role;
            this.authorizationStatus = authorizationStatus;
            this.profilePicture = profilePicture;
            this.departmentName = departmentName;
            this.designationName = designationName;
            this.departmentId = departmentId;
            this.designationId = designationId;
            this.authorizedBy = authorizedBy;
            this.newPassword = newPassword;
        }
    }
}
