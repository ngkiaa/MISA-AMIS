using System;
using System.Collections.Generic;
using System.Text;
using MISA.AMIS.Common;

namespace MISA.AMIS.DataLayer.Interfaces
{
    public interface IEmployeeRepository:IDbContext<Employee>
    {
        bool CheckEmployeeIdExist(string id);
        bool CheckEmployeeCodeExist(string code);
        bool CheckIdentityNumberExist(string identityNumber);
        bool CheckEmptyFullName(string fullName);
        bool CheckEmptyEmployeeCode(string code);
    }
}
