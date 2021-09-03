using System;
using System.Collections.Generic;
using System.Text;
using MISA.AMIS.Common;

namespace MISA.AMIS.DataLayer.Interfaces
{
    public interface IDepartmentRepository:IDbContext<Department>
    {
        bool CheckDepartmentNameExist(string name);
        bool CheckDepartmentNameEmpty(string name);
    }
}
