using System;

namespace His6.Base
{
    public class BDictParameter
    {
        /// <summary>
        /// 机构代码
        /// </summary>
        public int BranchId { get; set; }
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
        /// 修改类型
        /// </summary>
        public String ModifyType { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Describe { get; set; }

    }
}
