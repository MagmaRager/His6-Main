namespace His6.Base
{
    /// <summary>
    ///  功能点信息数据
    /// </summary>
    public class EntityFunctionPoint
    {
        private string _Code;
        private string _Name;
        private EControlProperty _Property;
        private object _Target;

        /// <summary>
        /// 初始化
        /// </summary>
        public EntityFunctionPoint(string code, string name, EControlProperty Property, object target)
        {
            this._Code = code;
            this._Name = name;
            this._Property = Property;
            this._Target = target;
        }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code
        {
            get { return this._Code; }
            set { this._Code = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }

        /// <summary>
        /// 控件属性
        /// </summary>
        public EControlProperty Property
        {
            get { return this._Property; }
            set { this._Property = value; }
        }

        /// <summary>
        /// 当前对象
        /// </summary>
        public object Target
        {
            get { return this._Target; }
            set { this._Target = value; }
        }
    }


}
