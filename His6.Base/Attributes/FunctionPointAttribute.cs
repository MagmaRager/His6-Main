using System;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：功能点特性类
    /// 功能描述：标记功能点信息
    ///      功能点使用：
    ///         1. 在窗口类上定义Attribute，如： 
    ///            [FunctionPoint("SYS-W02-01", "子系统新增", EControlProperty.Hide, "子系统新增")]
    ///            [FunctionPoint("SYS-W02-02", "菜单新增", EControlProperty.Hide, "菜单新增")]
    ///         2. 在窗口构造函数中注册功能点， 如：
    ///            this._FunctionPointHelper.RegisterFunctionPoints(this, this.tsbSystemAdd, this.tsbMenuAdd, ...);
    ///         3. 使用时可通过功能点权限管理设置权限。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class FunctionPointAttribute : Attribute, IComparable
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public FunctionPointAttribute(string code, string name, string desc)
        {
            Code = code;
            Name = name;
            Describe = desc;
        }

        /// <summary>
        /// 功能点列表排序方法
        /// </summary>
        /// <param name="obj">功能点</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is FunctionPointAttribute)
            {
                return Code.CompareTo(((FunctionPointAttribute)obj).Code);
            }

            return 1;
        }

        /// <summary>
        /// 功能点代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 功能点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
    }
}
