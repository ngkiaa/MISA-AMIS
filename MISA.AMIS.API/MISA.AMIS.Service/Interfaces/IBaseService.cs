using System;
using System.Collections.Generic;
using System.Text;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Model;

namespace MISA.AMIS.Service.Interfaces
{
    public interface IBaseService<T>
    {
        ServiceResult GetData();
        ServiceResult GetDataById(string id);
        ServiceResult Insert(T entity);
        ServiceResult Update(T entity);
        ServiceResult Delete(string id);
        bool ValidateAddData(T entity, ErrorMsg errorMsg = null);
        bool ValidateUpdateData(T entity, ErrorMsg errorMsg = null);
    }
}
