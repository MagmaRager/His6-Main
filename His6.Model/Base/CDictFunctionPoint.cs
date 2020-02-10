namespace His6.Model
{
    /// <summary>
    /// 功能点
    /// </summary>
    public class CDictFunctionPoint
    {
        public CDictFunctionPoint() { }

        /// <summary>
        /// 初始化
        /// </summary>
        public CDictFunctionPoint(string code, string name, string objectCode, string describe)
        {
            this.Code = code;
            this.Name = name;
            this.ObjectCode = objectCode;
            this.Describe = describe;
        }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 对象代码
        /// </summary>
        public string ObjectCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
    }
}
