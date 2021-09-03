using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.DataLayer.Interfaces;

namespace MISA.AMIS.DataLayer
{
    public class EmployeeRepository: DbContext<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Kiểm tra id nhân viên có tồn tại không
        /// </summary>
        /// <param name="id">id cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public bool CheckEmployeeIdExist(string id)
        {
            var employees = dbConnection.Query($"SELECT * FROM Employee WHERE EmployeeId = '{id}'");
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay không
        /// </summary>
        /// <param name="code">mã nhân viên cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public bool CheckEmployeeCodeExist(string code)
        {
            var employees = dbConnection.Query($"SELECT * FROM Employee WHERE EmployeeCode = '{code}'");
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra số CMTND/CCCD có tồn tại không
        /// </summary>
        /// <param name="identityNumber">số CMTND/CCCD cần kiểm tra</param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public bool CheckIdentityNumberExist(string identityNumber)
        {
            if (identityNumber == null)
            {
                return false;
            }
            var employees = dbConnection.Query($"SELECT * FROM Employee WHERE IdentityNumber = '{identityNumber}'");
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường họ và tên có để trống không
        /// </summary>
        /// <param name="fullName">giá trị của trường họ và tên</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public bool CheckEmptyFullName(string fullName)
        {
            if (fullName == string.Empty || fullName == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra trường mã nhân viên có để trống không
        /// </summary>
        /// <param name="code">giá trị trường mã nhân viên</param>
        /// <returns>true: để trống; false: đã có giá trị</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public bool CheckEmptyEmployeeCode(string code)
        {
            if (code == string.Empty || code == null)
            {
                return true;
            }
            return false;
        }
    }
}
