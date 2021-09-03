using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Common
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string IdDepartment
        {
            get
            {
                return DepartmentId.ToString();
            }
        }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}
