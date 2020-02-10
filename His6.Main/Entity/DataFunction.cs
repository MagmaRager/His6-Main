namespace His6.Main
{
    public class DataFunction
    {
        #region Property

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
        public bool OpenFlag { get; set; }

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
        /// <param name="function_name">功能名</param>
        /// <param name="module_name">模块</param>
        /// <param name="parameter">参数</param>
        /// <param name="open_flag">多次打开</param>
        /// <param name="is_popup">是否弹出显示</param>
        public DataFunction(string module_name, string object_name, string parameter, bool open_flag)
            : this()
        {
            this.ModuleName = module_name;
            this.ObjectName = object_name;
            this.Parameter = parameter;
            this.OpenFlag = open_flag;
        }

    }
}
