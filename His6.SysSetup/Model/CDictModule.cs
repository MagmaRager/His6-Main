using System;

namespace His6.SysSetup
{
    /// <summary>
    /// 系统模块名称
    /// </summary>
    public class CDictModule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CDictModule()
        { }

        /// <summary>
        /// 带主键的构造函数
        /// </summary>
        public CDictModule(String code)
        {
            this.Code = code;
        }

        #region 属性

        /// <summary>
        /// 模块代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 模块名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 模块程序文件名
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public String Version { get; set; }

        // <summary>
        // 更新人员
        // </summary>
        public int? UpdateEmpid { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        //public String UpdateTime { get; set; }

        /// <summary>
        /// 文件时间
        /// </summary>
        public String FileTime { get; set; }

        /// <summary>
        /// 是否有效（1是/0否）
        /// </summary>
        public int UsedFlag { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Describe { get; set; }

        #endregion
    }
}
