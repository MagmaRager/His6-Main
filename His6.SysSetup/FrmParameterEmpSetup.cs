using DevExpress.XtraBars;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using His6.Base;
using His6.Model;

namespace His6.SysSetup
{
    [FunctionPointAttribute("01", "修改", "个人参数修改按钮")]
    [FunctionPointAttribute("02", "人员选择", "个人参数人员选择按钮")]
    public partial class FrmParameterEmpSetup : FrmWithFPBase
    {
        private int m_EmpId = 0;
        public FrmParameterEmpSetup()
        {
            InitializeComponent();

            // 注册功能点
            _FunctionPointHelper.RegisterFunctionPoints(this, this.bbiEdit, this.beiEmp);
        }

        public override bool Init()
        {
            //  默认是操作员自己
            m_EmpId = EmpInfo.Id;
            if (this.beiEmp.ControlAuthority)
            {
                //  TODO: 查询员工信息列表
                List<DataEmpDir> emps = CommonDataHelper.GetEmpAll();
                
                this.rileEmp.DisplayMember = "Name";
                this.rileEmp.ValueMember = "Id";
                this.rileEmp.DataSource = emps;
                beiEmp.EditValue = m_EmpId;

            }
            else
            {
                this.bsiEmpChoice.Visibility =  BarItemVisibility.Never; 
            }
            this.Fresh();

            return base.Init();
        }


        #region 功能按钮事件

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BDictParameterEmp parm = this.gvParameterList.GetFocusedRow() as BDictParameterEmp;
            if (parm == null)
            {
                return;
            }
            FrmParameterEmpEdit frm = new FrmParameterEmpEdit();
            frm.Init(parm);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                parm = frm.GetData();
                this.gvParameterList.SetFocusedRowCellValue(this.gclNameChn, parm.NameChn);
                this.gvParameterList.SetFocusedRowCellValue(this.gclValue, parm.Value);
                this.gvParameterList.SetFocusedRowCellValue(this.gclDescribe, parm.Describe);
            }
        }

        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridHelper.ExportTo(this.gvParameterList, EnvInfo.RunPath);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             this.Close();
        }

        #endregion

        private void beiEmp_EditValueChanged(object sender, EventArgs e)
        {
            if(this.beiEmp.EditValue == null)
            {
                return;
            }
            int new_id = int.Parse(this.beiEmp.EditValue.ToString());
            if (m_EmpId != new_id)
            {
                m_EmpId = new_id;
                this.Fresh();
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void Fresh()
        {
            try
            {
                //  TODO: 获取员工参数列表
                var parmList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("empId", m_EmpId.ToString())
                };
                CustomException ce = null;
                List<BDictParameterEmp> parms = HttpDataHelper.GetWithInfo<List<BDictParameterEmp>>(
                    "BASE", "/setup/paramsemp", out ce, parmList);

                this.gcParameterList.DataSource = parms;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
        }

    }
}
