using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class ServiceResult
    {/// <summary>
    /// Trạng thái Service (true - thành công; fail - thất bại)
    /// </summary>
        public bool Success { get; set; }
        public object Data { get; set; }
        public string MISACode { get; set; }
    }
}
