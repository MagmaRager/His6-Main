using System;
using System.Reflection;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraTab;

using His6.Base;
using His6.Resource;

namespace His6.Main
{
    public partial class FrmLogin : XtraForm
    {
        #region 内部变量定义
        private int _LoginNum;                      //登录次数
        #endregion

        //构造方法
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this._LoginNum = 0;
            // 1.获取参数
            //  TODO: 通过机构代码获取登录方式, 没有取到时使用默认登录方式

            string loginbases = string.Empty;
            // SysParamBranch branch = HttpDataHelper.PathGetWithInfo<SysParamBranch>("BASE", "/getbranch", EnvInfo.BranchCode);
            //? EurekaHelper.PathGetString("PROVIDER", "/sys/getparambranchvalue", branchCode, "LOGIN_BASE");
            if (loginbases.IsNullOrEmpty())            
            {
                loginbases = "His6.Base.UCLogin";
                //SysParamBranch pb = new SysParamBranch();
                //pb.BranchCode = EnvInfo.BranchCode;
                //pb.Name = "LOGIN_BASE";
                //pb.NameChn = "登录控件";
                //pb.Value = loginbases;
                //pb.Type = "C";
                //pb.ModifyType = "N";
                //pb.Describe = "系统登录控件集合";

                //? EurekaHelper.Post("PROVIDER", "/sys/addparambranch", pb.Json());
            }

            String[] lgb = loginbases.Split(';');

            // 2.提取UCLoginBase内容，并创建其子类
            UCLoginBase[] ucLogins = new UCLoginBase[lgb.Length];

            for (int i = 0; i < lgb.Length; i++)
            {
                int idx = lgb[i].LastIndexOf('.');
                String file = lgb[i].Substring(0, idx);
                String obj = lgb[i].Substring(idx + 1);

                // 3.反射创建UCLoginBase子类对象
                if (file.Equals("His6.Main"))
                {
                    file += ".exe";
                }
                else 
                {
                    file += ".dll";
                }

                Assembly theDll = Assembly.LoadFile(EnvInfo.RunPath + file);

                UCLoginBase ucb = theDll.CreateInstance(lgb[i]) as UCLoginBase;
                ucb.SetParent(this,this.btnLogin);

                // 4.加入TabControl
                XtraTabPage tpg = new XtraTabPage();
                tpg.Text = ucb.Title;        
                ucb.Dock = System.Windows.Forms.DockStyle.Fill;
                tpg.Controls.Add(ucb);
                this.tabControl.TabPages.Add(tpg);
            }

            this.pictureBox1.Image = ResourceHelper.GetFromResource("Login");
            this.Text = "登录---" + EnvInfo.BranchName;
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            //  让第一个登录控件获取焦点
            SendKeys.SendWait("{TAB}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Submit();
        }
       

        #region 自定义方法
        /// <summary>
        /// 登录方法
        /// </summary>
        private void Submit()
        {
            try
            {
                if ((this.tabControl.SelectedTabPage.Controls[0] as UCLoginBase).Login())
                {
                    this.DialogResult = DialogResult.OK;
                    base.Close();
                }
                else
                {
                    this._LoginNum++;
                }
            }
            catch (Exception ex)
            {
                this._LoginNum++;
                LogHelper.Info(this, ex.Message + "\r\n登录不成功！\r\n" + ex.StackTrace);
            }
            finally
            {
                if (this._LoginNum >= 3)
                {
                    LogHelper.Warn(this, "由于登录错误次数过多，为了您的安全系统将暂时关闭！");
                    MessageBox.Show("由于登录错误次数过多，为了您的安全系统将暂时关闭！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    base.Close();
                }
            }
        }
        #endregion
    }
}
