using System;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：功能实体对象
    /// 功能描述：用于以下二处：菜单对应的功能、信息调用的打开功能。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class DataFunction 
    {
        #region Property

        /// <summary>
        /// 标题名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 对象名称
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        ///  窗口打开标志（0：弹窗 1：可新开 2：参数一致时激活否则新开 3：已存在激活否则新开）
        /// </summary>
        public int OpenFlag { get; set; }

        #endregion

        /// <summary>
        ///  构造函数
        /// </summary>
        public DataFunction()
        {
        }

        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="title">标题名称</param>
            /// <param name="module_name">模块</param>
            /// <param name="object_name">功能对象名</param>
            /// <param name="parameter">参数</param>
            /// <param name="open_flag">打开标志</param>
            public DataFunction(string title, string module_name, string object_name, string parameter, int open_flag)
                : this()
            {
                this.Title = title;
                this.ModuleName = module_name;
                this.ObjectName = object_name;
                this.Parameter = parameter;
                this.OpenFlag = open_flag;
            }

    }
}
