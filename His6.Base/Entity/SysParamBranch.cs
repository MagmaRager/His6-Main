using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace His6.Base
{
    public class SysParamBranch
    {
        /// <summary>
        /// 机构代码
        /// </summary>
        public String BranchCode { get; set; }
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
        /// 修改类型
        /// </summary>
        public String ModifyType { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Describe { get; set; }

        public String Json()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
