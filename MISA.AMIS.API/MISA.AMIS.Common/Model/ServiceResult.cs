using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Common.Model
{
    public class ServiceResult
    {
        /// <summary>
        /// Trạng thái Service (true: thành công; false: thất bại)
        /// </summary>
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
