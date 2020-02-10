using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using His6.Model;

namespace His6.SysSetup
{
    /// <summary>
    /// 文 件 名：员工选择窗口（鼠标双击或选中加入）
    /// 使用示例： 
    ///      FrmSelectEmp frm = new FrmSelectEmp();
    ///      frm.SetDataSource(all, selected);
    ///      if（frm.ShowDialog() == DialogResult.OK)
    ///      {
    ///          List<DataEmpDir> new_selected = frm.EmpSelected;
    ///          。。。
    ///       }
    /// 
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public partial class FrmSelectEmp : XtraForm
    {

        /// <summary>
        ///  选择的人员属性，用于返回选择结果
        /// </summary>
        public List<DataEmpDir> EmpSelected
        {
            get
            {
                return gcTo.DataSource as List<DataEmpDir>;
            }
        }

        private List<DataEmpDir> empList;

        public FrmSelectEmp()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  设置数据源
        /// </summary>
        /// <param name="emp_all">所有可选的人员</param>
        /// <param name="emp_selected">已经选择的人员</param>
        public void SetDataSource(List<DataEmpDir> emp_all, List<DataEmpDir> emp_selected)
        {
            this.empList = emp_all;
            List<DataEmpDir>  empAll = new List<DataEmpDir>();
            if (emp_all != null)
            {
                empAll.AddRange(emp_all);
            }

            List < DataEmpDir > empSelected = new List<DataEmpDir>();
            if (emp_selected != null)
            {
                empSelected.AddRange(emp_selected);
            }

            //  清除已选人员
            foreach (DataEmpDir emp in empSelected)
            {
                DataEmpDir emp1 = empAll.Find(o => { return o.Id == emp.Id; });
                if (emp1 != null)
                {
                    emp.Code = emp1.Code;
                    //  防止被选人员中没有输入码
                    emp.Inputcode1 = emp1.Inputcode1;
                    emp.Inputcode2 = emp1.Inputcode2;

                    empAll.Remove(emp1);
                }
            }

            this.gcFrom.DataSource = empAll;
            this.gcTo.DataSource = empSelected;

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int[] dataRowIndexs = gvFrom.GetSelectedRows();
            if (dataRowIndexs == null)
            {
                return;
            }

            //在已分配中添加新的数据
            foreach (int rowIndex in dataRowIndexs)
            {
                DataEmpDir emp = gvFrom.GetRow(rowIndex) as DataEmpDir;
                (gcTo.DataSource as List<DataEmpDir>).Add(emp);
            }
            gcTo.RefreshDataSource();
            gvFrom.DeleteSelectedRows();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int[] dataRowIndexs = gvTo.GetSelectedRows();
            if (dataRowIndexs == null)
            {
                return;
            }

            //在可分配中添加对应记录
            foreach (int rowIndex in dataRowIndexs)
            {
                DataEmpDir emp = gvTo.GetRow(rowIndex) as DataEmpDir;

                DataEmpDir emp1 = this.empList.Find(o => o.Id == emp.Id);
                if(emp1 != null)
                {
                    emp.DeptId = emp1.DeptId;
                    emp.DeptName = emp1.DeptName;
                }
                (gcFrom.DataSource as List<DataEmpDir>).Add(emp);
            }
            gcFrom.RefreshDataSource();
            gvTo.DeleteSelectedRows();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gvFrom_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo hInfo = gvFrom.CalcHitInfo(new Point(e.X, e.Y));
                if (e.Button == MouseButtons.Left && e.Clicks == 2)     //  判断是否左键双击
                {
                    //判断光标是否在行范围内 
                    if (hInfo.InRow)
                    {
                        int idx = gvFrom.FocusedRowHandle;
                        if (idx >= 0)
                        {
                            DataEmpDir emp = gvFrom.GetRow(idx) as DataEmpDir;
                            (gcTo.DataSource as List<DataEmpDir>).Add(emp);
                            gcTo.RefreshDataSource();
                            gvFrom.DeleteRow(idx);
                        }
                    }
                }
            }
            catch {}
        }

        private void gvTo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo hInfo = gvTo.CalcHitInfo(new Point(e.X, e.Y));
                if (e.Button == MouseButtons.Left && e.Clicks == 2)     //  判断是否左键双击
                {
                    //判断光标是否在行范围内 
                    if (hInfo.InRow)
                    {
                        int idx = gvTo.FocusedRowHandle;
                        if (idx >= 0)
                        {
                            DataEmpDir emp = gvTo.GetRow(idx) as DataEmpDir;
                            DataEmpDir emp1 = this.empList.Find(o => o.Id == emp.Id);
                            if (emp1 != null)
                            {
                                emp.DeptId = emp1.DeptId;
                                emp.DeptName = emp1.DeptName;
                            }
                            (gcFrom.DataSource as List<DataEmpDir>).Add(emp);
                            gcFrom.RefreshDataSource();
                            gvTo.DeleteRow(idx);
                        }
                    }
                }
            }
            catch { }
        }
    }
}
