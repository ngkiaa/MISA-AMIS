using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.AMIS.DataLayer.Interfaces;

namespace MISA.AMIS.DataLayer
{
    public class DbContext<T>:IDbContext<T>
    {
        #region Declare
        protected string _connectionString = "User Id=dev; Host=47.241.69.179; Database=MF722_NNSON_AMIS; port=3306; password=12345678; Character Set=utf8;";
        protected IDbConnection dbConnection;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: NVNghia (28/08/2021)
        public DbContext()
        {
            dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ sữ liệu
        /// </summary>
        /// <returns>Collection object</returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public virtual IEnumerable<T> GetData()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            // Thực hiện truy vấn lấy dữ liệu
            var entity = dbConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);

            // Trả về kết quả cho client
            return entity;
        }

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí khác nhau
        /// </summary>
        /// <param name="sqlCommand">Tên StoreProcedure</param>
        /// <param name="parameters">Đối tượng chứa thông tin của tham số của Store</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public IEnumerable<T> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            //Thực thi truy vấn lấy dữ liệu
            var entity = dbConnection.Query<T>(sqlCommand, param: parameters, commandType: commandType);

            // Trả về kết quả cho client
            return entity;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns></returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public int Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";

            var affectRows = dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns></returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public int Update(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";

            var affectRows = dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">id của object cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: NVNghia (28/08/2021)
        public int Delete(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            var affectRows = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        #endregion
    }
}
