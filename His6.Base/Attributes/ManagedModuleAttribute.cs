using System;
using System.ComponentModel;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：可管理的模块
    /// 功能描述：用于管理程序集模块信息
    ///           在AssemblyInfo.cs文件中设置。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public class ManagedModuleAttribute : Attribute
    {
        /// <summary>
        /// 模块代码
        /// </summary>
        [Browsable(false)]
        public string Code { get; private set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="code"></param>
        public ManagedModuleAttribute(string code)
        {
            Code = code;
        }
    }
}
