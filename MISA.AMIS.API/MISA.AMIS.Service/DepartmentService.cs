using System;
using System.Collections.Generic;
using System.Text;
using MISA.AMIS.Common;
using MISA.AMIS.DataLayer.Interfaces;
using MISA.AMIS.Service.Interfaces;

namespace MISA.AMIS.Service
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        #region Declare
        IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Method
        public override bool ValidateAddData(Department department, ErrorMsg errorMsg = null)
        {
            var isValid = true;

            //1.Check tên đơn vị để trống
            if (_departmentRepository.CheckDepartmentNameEmpty(department.DepartmentName) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Required_DepartmentName);
                isValid = false;
            }
            //2.Check tên đơn vị bị trùng
            if (_departmentRepository.CheckDepartmentNameExist(department.DepartmentName) == true)
            {
                errorMsg.UserMsg.Add(MISA.AMIS.Common.Properties.Resources.Erro_Duplicate_DepartmentName);
                isValid = false;
            }

            return isValid;
        }
        #endregion

    }
}
