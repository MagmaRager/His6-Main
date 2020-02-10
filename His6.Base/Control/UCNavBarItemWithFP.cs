using DevExpress.XtraNavBar;
using System.ComponentModel;

namespace His6.Base
{
    /// <summary>
    ///  带功能点的NavBarItem
    /// </summary>

    public partial class UCNavBarItemWithFP : NavBarItem
    {
        public UCNavBarItemWithFP()
        {
            InitializeComponent();
        }

        public UCNavBarItemWithFP(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        #region 权限控制

        private bool _ControlAuthority = false;

        /// <summary>
        /// 权限控制属性(枚举)
        /// </summary>
        [Browsable(false)]
        public bool ControlAuthority
        {
            get { return _ControlAuthority; }
            set { this._ControlAuthority = value; }
        }

        /// <summary>
        ///  重载Enabled事件
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
