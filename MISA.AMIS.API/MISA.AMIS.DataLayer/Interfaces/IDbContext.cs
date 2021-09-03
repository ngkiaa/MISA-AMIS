using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.AMIS.DataLayer.Interfaces
{
    public interface IDbContext<T>
    {
        IEnumerable<T> GetData();
        IEnumerable<T> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);
        int Insert(T entity);
        int Update(T entity);
        int Delete(string id);
    }
}
