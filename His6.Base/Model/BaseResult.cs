using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
   public class BaseResult
    {
        /// <summary>
        ///返回信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 0: 成功
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string Type { get; set; }
    }
}
