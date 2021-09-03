using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.DataLayer.Interfaces;

namespace MISA.AMIS.DataLayer
{
    public class DepartmentRepository : DbContext<Department>, IDepartmentRepository
    {
        /// <summary>
        /// Kiểm tra tên đơn vị phòng ban có tồn tại không
        /// </summary>
        /// <param name="name">tên đơn vị cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public bool CheckDepartmentNameExist(string name)
        {
            var departments = dbConnection.Query($"SELECT * FROM Department WHERE DepartmentName = '{name}'");
            if (departments != null)
            {
                foreach (var department in departments)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường tên đơn vị có để trống không
        /// </summary>
        /// <param name="name">giá trị của trường tên đơn vị</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public bool CheckDepartmentNameEmpty(string name)
        {
            if (name == String.Empty || name == null)
            {
                return true;
            }
            return false;
        }
    }
}
