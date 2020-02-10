using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using His6.Base;
using His6.Model;
using His6.Resource;

namespace His6.SysSetup
{
    public partial class UCSystem : XtraUserControl
    {
        private int m_id = 0;
        private bool editStatus = false;

        #region 增加修改需要的选择数据

        /// <summary>
        ///  角色列表
        /// </summary>
        public List<BDictRole> RoleList
        {
            get;
            set;
        }

        /// <summary>
        ///  员工列表
        /// </summary>
        public List<DataEmpDir> EmpList
        {
            get;
            set;
        }

        #endregion

        public UCSystem()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  数据初始化
        /// </summary>
        /// <param name="data">系统信息</param>
        public void Init(BDictSystem data, List<BDictRole> roleList, List<DataEmpDir> empList)
        {
            m_id = data.Id;
            this.txtCode.Text = data.Code;
            this.txtName.Text = data.Name;
            this.txtIco.Text = data.Ico;
            this.gcRole.DataSource = roleList;
            this.gcEmp.DataSource = empList;

            //按钮不可见
            //if (editStatus == true)
            //{
            //    gcRole.Visible = false;
            //    gcEmp.Visible = false;
            //}
        }

        private void txtIco_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = this.txtIco.Text;
            openFileDialog.InitialDirectory = EnvInfo.RunPath + "ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtIco.Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf(@"\") + 1);
            }

        }
        /// <summary>
        /// 可编辑设置
        /// </summary>
        /// <param name="isEdit"></param>
        public void SetStatus(bool isEdit, bool isNew)
        {
            this.txtCode.Properties.ReadOnly = !isEdit || !isNew;
            this.txtName.Properties.ReadOnly = !isEdit;
            this.txtIco.Properties.ReadOnly = !isEdit;
            this.txtIco.Properties.Buttons[0].Visible = isEdit;

            editStatus = isEdit;
        }


        public BDictSystem GetData()
        {
            BDictSystem data = new BDictSystem();
            data.Id = m_id;
            data.Code = this.txtCode.Text;
            data.Name = this.txtName.Text;
            data.Ico = this.txtIco.Text;

            return data;
        }

        /// <summary>
        ///  获取角色
        /// </summary>
        /// <returns></returns>
        public List<BDictRole> GetRoles()
        {
            return this.gcRole.DataSource as List<BDictRole>;
        }

        /// <summary>
        ///  获取人员
        /// </summary>
        /// <returns></returns>
        public List<DataEmpDir> GetEmps()
        {
            return this.gcEmp.DataSource as List<DataEmpDir>;
        }

        public void SelectRole()
        {
            if (editStatus)
            {
                FrmSelectRole frm = new FrmSelectRole();
                frm.SetDataSource(this.RoleList, this.gcRole.DataSource as List<BDictRole>);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<BDictRole> new_selected = frm.RoleSelected;
                    gcRole.DataSource = new_selected;
                }
                frm.Dispose();
            }
        }

        public void SelectEmp()
        {
            if (editStatus)
            {
                FrmSelectEmp frm = new FrmSelectEmp();
                frm.SetDataSource(this.EmpList, this.gcEmp.DataSource as List<DataEmpDir>);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<DataEmpDir> new_selected = frm.EmpSelected;
                    gcEmp.DataSource = new_selected;
                }
                frm.Dispose();
            }
        }

        private void gvRole_DoubleClick(object sender, EventArgs e)
        {
            this.SelectRole();
        }

        private void gvEmp_DoubleClick(object sender, EventArgs e)
        {
            this.SelectEmp();
        }

    }
}
