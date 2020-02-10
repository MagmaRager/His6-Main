using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using DevExpress.Utils.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using His6.Base.Helper;
using His6.Model;

namespace His6.Base
{
    public partial class UCLogin : UCLoginBase
    {
        private bool codeChanged = false;

        public UCLogin()
        {
            InitializeComponent();
            this.Title = "口令登录";
        }
   
        private void teEmpCode_Leave(object sender, System.EventArgs e)
        {
            if (FreshData())
            {
                codeChanged = true;
            }
            else codeChanged = false;
            this.LoginBtn.Enabled = codeChanged;
        }

        public void InitForRelogin()
        {
            this.teEmpCode.Text = EmpInfo.Code;
            this.teEmpCode.Enabled = false;

            FreshData();
            this.labelControl3.Visible = false;
            this.lueSystem.Visible = false;
        }

        private bool FreshData()
        {
            string empCode = teEmpCode.Text;

            string msg = EmpInfo.QueryEmpByCode(empCode);
            this.lueSystem.Properties.DisplayMember = "Name";
            this.lueSystem.Properties.ValueMember = "Code";
            this.labelControl4.Text = msg;

            if (!msg.IsNullOrEmpty())
            {
                //MessageHelper.ShowError(msg);                
                this.lueSystem.Properties.DataSource = null;
                return false;
            }
            else
            {
                this.lueSystem.Properties.DataSource = EmpInfo.CanUseSystemList;
                //  获取上一次登录的系统
                this.lueSystem.EditValue = EmpInfo.GetLastSystemCode();
                return true;
            }
        }

        public override bool Login()
        {
            string passwd = this.tePassword.Text;
            string system_code = this.lueSystem.EditValue.ToString();
            string ret = "";

            if (string.IsNullOrEmpty(passwd))
            {
                ret = "请输入密码";
            }
            else ret = EmpInfo.Login(EnvInfo.BranchId, system_code, passwd);

            if (ret.IsNullOrEmpty())
            {
                var parmList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString())
                };
                CustomException ce = null;
                BDictEmp empInfo = HttpDataHelper.GetWithInfo<BDictEmp>("BASE", "/sys/empinfo", out ce, parmList);                
                List<string> roleList = HttpDataHelper.GetWithInfo<List<string>>("BASE", "/sys/role", out ce, parmList);                
                List<CDictAction> actionList = HttpDataHelper.GetWithInfo<List<CDictAction>>("BASE", "/sys/action", out ce, parmList);

                EmpInfo.SetEmpInfo(empInfo, roleList, actionList);                
                return true;
            }
            else
            {
                MessageHelper.ShowError(ret);
                return false;
            }
        }

       
    }
}
