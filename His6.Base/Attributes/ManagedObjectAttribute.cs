using System;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：可管理的窗口
    /// 功能描述：用于管理窗体对象信息(包括窗体类名,对象代码,对象名称)
    ///           在AssemblyInfo.cs文件中设置，对应的窗口中获取对应信息。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class ManagedObjectAttribute : Attribute
    {
        /// <summary>
        /// 窗口类名
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// 对象代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 对象名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="objectName">对象名</param>
        /// <param name="code">对象代码</param>
        /// <param name="name">对象名称</param>
        public ManagedObjectAttribute(string objectName, string code, string name)
        {
            ObjectName = objectName;
            Code = code;
            Name = name;
        }
    }
}
