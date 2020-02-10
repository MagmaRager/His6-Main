using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace His6.SysSetup
{
    public partial class FrmTestNotice : His6.Base.FrmNoticeBase
    {
        public FrmTestNotice()
        {
            InitializeComponent();
        }

        public override void Init(string code)
        {
            this.timer_interval = 10000;
            this.IcoImage = His6.Base.BmpHelper.GetIco("L_Message.png");
            this.AutoOpen = true;
            this.IcoHint = "危机值通知...";

            base.Init(code);
        }

        protected override void QueryInfo()
        {
            base.QueryInfo();
            this.NoticeCount++;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
