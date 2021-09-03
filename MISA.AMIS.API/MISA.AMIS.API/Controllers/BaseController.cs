using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Service.Interfaces;

namespace MISA.AMIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T>:ControllerBase
    {
        #region Declare
        IBaseService<T> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>204: NoContent; 200: Success</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var res = _baseService.GetData();
            var objects = res.Data as List<T>;
            if (objects.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        /// <summary>
        /// Lấy dữ liệu qua Id
        /// </summary>
        /// <returns>204: NoContent; 200: Success</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var res = _baseService.GetDataById(id);
            var objects = res.Data as List<T>;
            if (objects.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns>400: BadRequest; 201: Thêm thành công</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var res = _baseService.Insert(entity);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(201, res.Data);
            }
        }

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">object đã sửa</param>
        /// <returns>400: BadRequest; 201: Sửa thành công</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            var res = _baseService.Update(entity);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(201, res.Data);
            }
        }

        /// <summary>
        /// Xóa thông tin
        /// </summary>
        /// <param name="id">id của object cần xóa</param>
        /// <returns>400: BadRequest; 200: Success</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = _baseService.Delete(id);
            switch (res.Success)
            {
                case false:
                    return StatusCode(400, res.Data);
                case true:
                    return StatusCode(200, res.Data);
            }
        }
        #endregion
    }
}
