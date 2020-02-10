using System;

namespace His6.Base
{
    /// <summary>
    /// 窗体参数说明
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class FormParmDescAttribute : Attribute
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public FormParmDescAttribute(string description , string example) : base()
        {
            Description = description;
            Example = example;
        }

        /// <summary>
        /// 参数说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 示例
        /// </summary>
        public string Example { get; set; }

    }

}