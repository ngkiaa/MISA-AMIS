using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MISA.AMIS.Common;
using MISA.AMIS.Service.Interfaces;

namespace MISA.AMIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : BaseController<Employee>
    {
        #region Declare
        IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu nhân viên bằng filter tìm kiếm qua tên hoặc mã nv
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        /// CreatedBy: NVNghia (28/08/2021)
        [HttpGet("search")]
        public IActionResult GetByCodeAndName([FromQuery]string searchKey)
        {
            var res = _employeeService.GetEmployeeByCodeAndName(searchKey);
            var employees = res.Data as List<Employee>;
            if(employees.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }
        #endregion
    }
}
