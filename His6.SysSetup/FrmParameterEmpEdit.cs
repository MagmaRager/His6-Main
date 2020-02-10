using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using His6.Model;
using His6.Base;

namespace His6
{
    public partial class FrmParameterEmpEdit : Form
    {
        private int m_EmpId = 0; 
        public FrmParameterEmpEdit()
        {
            InitializeComponent();
        }

        public void Init(BDictParameterEmp parm)
        {
            m_EmpId = parm.EmpId;
            this.teName.Text = parm.Name;
            this.teNameChn.Text = parm.NameChn;
            this.teValue.Text = parm.Value;
            this.meDescribe.Text = parm.Describe;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // 保存修改数据
            BDictParameterEmp para = new BDictParameterEmp();
            if (string.IsNullOrEmpty(this.teValue.Text))
            {
                MessageHelper.ShowWarning("参数值不可为空！");
                return;
            }
            para.EmpId = m_EmpId;
            para.Name = this.teName.Text;
            para.Value = this.teValue.Text;
            para.NameChn = string.IsNullOrEmpty(this.teNameChn.Text) ? "" : this.teNameChn.Text;
            para.Describe = string.IsNullOrEmpty(this.meDescribe.Text) ? "" : this.meDescribe.Text;

            string json = StringHelper.SerializeObject<BDictParameterEmp>(para);
            CustomException ce = null;
            HttpDataHelper.HttpPostWithInfo("BASE", "/setup/paramempset", out ce, json);
            if (ce == null)
            {
                MessageHelper.ShowInfo("人员参数设置完成！");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageHelper.ShowWarning("人员参数设置不成功！\r\n" + ce.InnerMessage);
                return;
            }
        }

        public BDictParameterEmp GetData()
        {
            BDictParameterEmp parm = new BDictParameterEmp();
            parm.EmpId = m_EmpId;
            parm.Name = this.teName.Text;
            parm.NameChn = this.teNameChn.Text;
            parm.Value = this.teValue.Text;
            parm.Describe = this.meDescribe.Text;

            return parm;
        }

    }
}
