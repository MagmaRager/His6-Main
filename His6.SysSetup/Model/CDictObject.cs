using System;
using System.Collections.Generic;

namespace His6.SysSetup
{
    /// <summary>
    /// 系统对象表
    /// </summary>
    public class CDictObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CDictObject()
        { }

        /// <summary>
        /// 带主键的构造函数
        /// </summary>
        public CDictObject(String code)
        {
            this.Code = code;
        }

        #region 属性

        /// <summary>
        /// 默认图标
        /// </summary>
        //public String Ico { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 对象名称
        /// </summary>
        public String Object { get; set; }

        /// <summary>
        /// 模块代码
        /// </summary>
        public String ModuleCode { get; set; }

        /// <summary>
        /// 是否有效（1是/0否）
        /// </summary>
        public int UsedFlag { get; set; }

        /// <summary>
        /// 是否功能菜单(1是/0否)
        /// </summary>
        public int IsFunction { get; set; }

        /// <summary>
        /// 是否有功能点(1是/0否)
        /// </summary>
        public int HasFunctionPoint { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Describe { get; set; }

        /// <summary>
        /// 对象功能点列表
        /// </summary>
        public List<CDictFunctionPoint> FunctionPointList { get; set; }


        #endregion
    }
}
