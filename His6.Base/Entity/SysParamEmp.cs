using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class SysParamEmp
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public String Value { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public String NameChn { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Describe { get; set; }
    }
}
