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
    /// 文 件 名：角色选择窗口（鼠标双击或选中加入）
    /// 使用示例： 
    ///      FrmSelectRole frm = new FrmSelectRole();
    ///      frm.SetDataSource(all, selected);
    ///      if（frm.ShowDialog() == DialogResult.OK)
    ///      {
    ///          List<BDictRole> new_selected = frm.RoleSelected;
    ///          。。。
    ///       }
    /// 
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public partial class FrmSelectRole : XtraForm
    {

        //  是否包含中心角色
        private bool includeCenter = true;

        /// <summary>
        ///  选择的角色属性，用于返回选择结果
        /// </summary>
        public List<BDictRole> RoleSelected
        {
            get
            {
                return gcTo.DataSource as List<BDictRole>;
            }
        }

        public FrmSelectRole()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  设置数据源
        /// </summary>
        /// <param name="role_all">所有可选的角色</param>
        /// <param name="role_selected">已经选择的角色</param>
        /// <param name="include_center">是否包含中心角色</param>
        public void SetDataSource(List<BDictRole> role_all, List<BDictRole> role_selected, bool include_center = true)
        {
            this.includeCenter = include_center;
            List<BDictRole> roleSelected = new List<BDictRole>();    //  选择的角色
            List<BDictRole> roleAll = new List<BDictRole>();         //  所有的角色

            if (role_all != null)
            {
                if (includeCenter)
                {
                    roleAll.AddRange(role_all);
                }
                else
                {
                    roleAll.AddRange(role_all.FindAll(o => o.Id > 100000));    //  100000以内的代表中心定义的角色
                }
            }
            if (role_selected != null)
            {
                roleSelected.AddRange(role_selected);
            }

            //  清除已选角色
            foreach (BDictRole role in roleSelected)
            {
                BDictRole role1 = roleAll.Find(o => { return o.Code == role.Code; });
                if (role1 != null)
                {
                    role.Code = role1.Code;
                    //  防止被选角色中没有输入码
                    role.Inputcode1 = role1.Inputcode1;
                    role.Inputcode2 = role1.Inputcode2;

                    roleAll.Remove(role1);
                }
            }

            this.gcFrom.DataSource = roleAll;
            this.gcTo.DataSource = roleSelected;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int[] dataRowIndexs = gvFrom.GetSelectedRows();
            if (dataRowIndexs == null)
            {
                return;
            }

            //在分配中添加新的数据
            foreach (int rowIndex in dataRowIndexs)
            {
                BDictRole role = gvFrom.GetRow(rowIndex) as BDictRole;
                (gcTo.DataSource as List<BDictRole>).Add(role);
            }
            gcTo.RefreshDataSource();
            //在可分配中删除对应的记录
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
                BDictRole role = gvTo.GetRow(rowIndex) as BDictRole;
                (gcFrom.DataSource as List<BDictRole>).Add(role);
            }
            gcFrom.RefreshDataSource();
            //在已分配中删除对应记录
            gvTo.DeleteSelectedRows();
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
                            BDictRole role = gvFrom.GetRow(idx) as BDictRole;
                            (gcTo.DataSource as List<BDictRole>).Add(role);
                            gcTo.RefreshDataSource();
                            gvFrom.DeleteRow(idx);
                        }
                    }
                }
            }
            catch { }
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
                            BDictRole role = gvTo.GetRow(idx) as BDictRole;
                            (gcFrom.DataSource as List<BDictRole>).Add(role);
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
