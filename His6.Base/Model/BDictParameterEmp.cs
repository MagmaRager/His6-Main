using System;

namespace His6.Base
{
    public class BDictParameterEmp
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
        /// 描述
        /// </summary>
        public String Describe { get; set; }
    }
}
