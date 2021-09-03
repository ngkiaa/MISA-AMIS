using System;
using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Model;
using MISA.AMIS.DataLayer.Interfaces;
using MISA.AMIS.Service.Interfaces;

namespace MISA.AMIS.Service
{
    public class EmployeeService:BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu nhân viên bằng filter tìm kiếm qua tên hoặc mã nv
        /// </summary>
        /// <param name="searchKey">từ khóa cần tìm kiếm</param>
        /// <returns></returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public ServiceResult GetEmployeeByCodeAndName(string searchKey)
        {
            var serviceResult = new ServiceResult();
            var storeName = $"Proc_GetEmployeeByCodeAndName";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"SearchKey", searchKey);

            serviceResult.Data = _employeeRepository.GetData(storeName, dynamicParameters, System.Data.CommandType.StoredProcedure);
            serviceResult.Success = true;

            return serviceResult;
        }

        /// <summary>
        /// Xác thực dữ liệu nhân viên được thêm
        /// </summary>
        /// <param name="employee">object nhân viên cần kiểm tra</param>
        /// <param name="errorMsg">thông tin lỗi nếu có</param>
        /// <returns>true: dữ liệu xác thực đúng; false: sữ liệu xác thực sai</returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public override bool ValidateAddData(Employee employee, ErrorMsg errorMsg = null)
        {
            var isValid = true;
            // 1. check trùng mã nhân viên: 
            if (_employeeRepository.CheckEmployeeCodeExist(employee.EmployeeCode) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Duplicate_EmployeeCode);
                isValid = false;
            }
            // 2. check mã nhân viên trống:
            if (_employeeRepository.CheckEmptyEmployeeCode(employee.EmployeeCode) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Required_EmployeeCode);
                isValid = false;
            }
            // 3. check họ và tên trống:
            if (_employeeRepository.CheckEmptyFullName(employee.FullName) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Required_FullName);
                isValid = false;
            }
            // 4. check số CMND/CCCD trùng:
            if (_employeeRepository.CheckIdentityNumberExist(employee.IdentityNumber) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Duplicate_IdentityNumber);
                isValid = false;
            }    

            return isValid;

        }

        /// <summary>
        /// Xác thực dữ liệu nhân viên được sửa
        /// </summary>
        /// <param name="employee">object nhân viên cần kiểm tra</param>
        /// <param name="errorMsg">thông tin lỗi nếu có</param>
        /// <returns>true: dữ liệu xác thực đúng; false: sữ liệu xác thực sai</returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public override bool ValidateUpdateData(Employee employee, ErrorMsg errorMsg = null)
        {
            var isValid = true;
            // 1. check mã nhân viên trống:
            if (_employeeRepository.CheckEmptyEmployeeCode(employee.EmployeeCode) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Required_EmployeeCode);
                isValid = false;
            }
            // 2. check họ và tên trống:
            if (_employeeRepository.CheckEmptyFullName(employee.FullName) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Required_FullName);
                isValid = false;
            }

            return isValid;

        }
        #endregion
    }
}
