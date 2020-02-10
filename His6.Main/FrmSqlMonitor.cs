using System;
using System.Collections.Generic;

using His6.Base;

namespace His6.Main
{
    partial class FrmSqlMonitor : FrmBase
    {
        private bool activated; 

        public FrmSqlMonitor()
        {
            InitializeComponent();
            activated = false;
            btnSwitch.Text = "启用监视";
            if (!String.IsNullOrEmpty(EnvInfo.SqlHeader))
            {
                teSqlHeader.Text = EnvInfo.SqlHeader;
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (activated)  //停止监视
            {
                this.gcOutput.BeginUpdate();
                this.gcOutput.DataSource = null;
                this.gcOutput.EndUpdate();
                activated = false;
                btnSwitch.Text = "启用监视";
                btnSwitch.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                EnvInfo.SqlHeader = null;
            }
            else    //开始监视
            {
                if (String.IsNullOrEmpty(teSqlHeader.Text))
                {
                    MessageHelper.ShowInfo("请输入Header。");
                    return;
                }
                MonitorInfoShow();

                activated = true;
                btnSwitch.Text = "停止监视";
                btnSwitch.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;

                EnvInfo.SqlHeader = teSqlHeader.Text;
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MonitorInfoShow();
        }

        private void MonitorInfoShow()
        {
            List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
            parms.Add(new KeyValuePair<string, string>("header", teSqlHeader.Text));
            CustomException ce = null;
            List<SqlMonitorInfo> lm = HttpDataHelper.GetWithInfo<List<SqlMonitorInfo>>("BASE", "/mongo/sqlmonitor/get", out ce, parms);

            this.gcOutput.BeginUpdate();
            this.gcOutput.DataSource = lm;
            this.gcOutput.EndUpdate();
        }
    }
}
