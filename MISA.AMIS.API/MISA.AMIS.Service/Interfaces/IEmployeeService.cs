using System;
using System.Collections.Generic;
using System.Text;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Model;

namespace MISA.AMIS.Service.Interfaces
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        ServiceResult GetEmployeeByCodeAndName(string searchKey); 
    }
}
