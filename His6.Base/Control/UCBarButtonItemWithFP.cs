using System.ComponentModel;
using DevExpress.XtraBars;

namespace His6.Base
{
    /// <summary>
    /// 带功能点的BarButtonItem
    /// </summary>
    /// 
    public partial class UCBarButtonItemWithFP : BarButtonItem
    {

        public UCBarButtonItemWithFP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// .net标准使用IContainer接口的容器，Dev18.1.7组件使用BarManager为容器。
        /// </summary>
        /// <param name="container"></param>
        public UCBarButtonItemWithFP(BarManager container)
        {
            InitializeComponent();
            this.Manager = container;
        }

        #region 权限控制

        private bool _ControlAuthority = false;

        /// <summary>
        /// 权限控制属性(枚举)
        /// </summary>
        [Browsable(false)]
        public bool ControlAuthority
        {
            get { return this._ControlAuthority; }
            set { this._ControlAuthority = value; }
        }

        /// <summary>
        ///  重载Enabled属性
        /// </summary>
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                if (!this.ControlAuthority && base.Enabled)
                {
                    base.Enabled = false;
                }
            }
        }
        #endregion 

    }
}
