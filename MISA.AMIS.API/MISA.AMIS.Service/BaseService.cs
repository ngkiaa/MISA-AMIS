using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Model;
using MISA.AMIS.DataLayer.Interfaces;
using MISA.AMIS.Service.Interfaces;

namespace MISA.AMIS.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Declare
        IDbContext<T> _dbContext;
        #endregion

        #region Constructor
        public BaseService(IDbContext<T> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public virtual ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();

            serviceResult.Data = _dbContext.GetData();
            serviceResult.Success = true;

            return serviceResult;
        }

        /// <summary>
        /// Lấy dữ liệu qua Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public virtual ServiceResult GetDataById(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ById";
            var serviceResult = new ServiceResult();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"{tableName}Id", id);

            serviceResult.Data = _dbContext.GetData(storeName, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            serviceResult.Success = true;

            return serviceResult;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns></returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public virtual ServiceResult Insert(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var isValid = ValidateAddData(entity, errorMsg);

            if (isValid == true)
            {
                serviceResult.Success = true;
                _dbContext.Insert(entity);
                serviceResult.Data = MISA.AMIS.Common.Properties.Resources.Add_Success_Msg;
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        /// <summary>
        /// Sửa thông tin dữ liệu
        /// </summary>
        /// <param name="entity">object đã sửa</param>
        /// <returns></returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public virtual ServiceResult Update(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var isValid = ValidateUpdateData(entity, errorMsg);

            if (isValid == true)
            {
                serviceResult.Success = true;
                _dbContext.Update(entity);
                serviceResult.Data = MISA.AMIS.Common.Properties.Resources.Update_Success_Msg;
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">id của object cần xóa</param>
        /// <returns></returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public virtual ServiceResult Delete(string id)
        {
            var serviceResult = new ServiceResult();
            _dbContext.Delete(id);
            serviceResult.Data = MISA.AMIS.Common.Properties.Resources.Delete_Success_Msg;
            serviceResult.Success = true;
            return serviceResult;
        }

        /// <summary>
        /// Xác thực dữ liệu thêm
        /// </summary>
        /// <param name="entity">object cần kiểm tra</param>
        /// <param name="errorMsg">thông tin lỗi nếu có</param>
        /// <returns></returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public virtual bool ValidateAddData(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }

        /// <summary>
        /// Xác thực dữ liệu sửa
        /// </summary>
        /// <param name="entity">object cần kiểm tra</param>
        /// <param name="errorMsg">thông tin lỗi nếu có</param>
        /// <returns></returns>
        /// CreatdBy: NVNghia (28/08/2021)
        public virtual bool ValidateUpdateData(T entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
        #endregion
    }
}
