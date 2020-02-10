using System;
using System.Windows.Forms;
using System.Collections.Generic;

using His6.Base;

namespace His6.Main
{
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtOld.Text.Length * txtNew1.Text.Length * txtNew2.Text.Length == 0)
            {
                MessageHelper.ShowWarning("口令不得为空！");
                return;
            }
            if (!txtNew1.Text.Equals(txtNew2.Text))
            {
                MessageHelper.ShowWarning("新密码与确认密码不一致！");
                return;
            }
            int branchid = EnvInfo.BranchId;
            int empid = EmpInfo.Id;

            //  修改密码
            List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
            parms.Add(new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()));
            parms.Add(new KeyValuePair<string, string>("opsw", DataCryptoHelper.MD5EncryptString(txtOld.Text)));
            parms.Add(new KeyValuePair<string, string>("npsw", DataCryptoHelper.MD5EncryptString(txtNew1.Text)));
            CustomException ce = null;
            if (Convert.ToInt32(HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/setup/newpsw", out ce, parms)) == 1)//CloudServiceHelper.PathGetString("PROVIDER", "/sys/getemppasswd", branchid.ToString(), empid.ToString()).Equals(txtOld.Text)
            {
                //CloudServiceHelper.PathGetString("PROVIDER", "/sys/setemppasswd", branchid.ToString(), empid.ToString(), txtNew1.Text);
                MessageHelper.ShowInfo("密码设置完成！");
            }
            else
            {
                MessageHelper.ShowWarning("密码验证失败！");
                return;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    string val = (sender as DevExpress.XtraEditors.TextEdit).Text;
        //    if (val.IsNullOrEmpty())
        //    {
        //        MessageHelper.ShowWarning("口令不得为空！");
        //        e.Cancel = true;
        //    }
        //}
    }
}
