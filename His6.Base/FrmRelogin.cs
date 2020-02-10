using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace His6.Base
{
    public partial class FrmRelogin : XtraForm
    {
        private int _LoginNum;                      //登录次数
        public FrmRelogin()
        {
            InitializeComponent();

            this.ucLogin1.InitForRelogin();
        }
        
        private void btnRelogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ucLogin1.Login())//验证
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
                LogHelper.Info(this, ex.Message + "\r\n重新登录不成功！\r\n" + ex.StackTrace);                
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
    }
}
