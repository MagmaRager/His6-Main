using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using His6.Model;

namespace His6.Base
{
    public partial class UCLoginBase : XtraUserControl
    {
        /// <summary>
        ///  Tab页标题
        /// </summary>
        public String Title { get; protected set; }

        /// <summary>
        ///  登录窗口
        /// </summary>
        protected Form LoginForm ;

        /// <summary>
        ///  登录按钮
        /// </summary>
        protected Button LoginBtn;

        public UCLoginBase()
        {
            InitializeComponent();
        }

        public void SetParent(Form parent, Button btn)
        {
            LoginForm = parent;
            LoginBtn = btn;
        }

        public virtual bool Login()
        {
            return true;
        }

    }
}
