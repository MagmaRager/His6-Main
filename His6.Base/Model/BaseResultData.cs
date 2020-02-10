using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class BaseResultData<T>:BaseResult
    {
        /// <summary>
        /// 业务数据
        /// </summary>
        public T Data { get; set; }
    }
}
