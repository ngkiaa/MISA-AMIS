using System;

namespace MISA.AMIS.Common
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string IdEmployee
        {
            get
            {
                return EmployeeId.ToString();
            }
        }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public Guid? DepartmentId { get; set; }
        public string IdDepartment
        {
            get
            {
                return DepartmentId.ToString();
            }
        }
        public string Position { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankPlace { get; set; }
        public string DepartmentName { get; set; }
    }
}
