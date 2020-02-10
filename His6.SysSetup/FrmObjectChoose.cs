using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using His6.Base;
using His6.Model;

namespace His6.SysSetup
{
    public partial class FrmObjectChoose : XtraForm
    {
        private string objectCode = "";
        private List<CDictObject> objectList = new List<CDictObject>();
        public FrmObjectChoose()
        {
            InitializeComponent();
        }

        public void Init(List<CDictModule> module_list, List<CDictObject> object_list, string object_code)
        {
            this.objectList = object_list;
            this.gcModule.DataSource = module_list;
            CDictObject obj = object_list.Find(o => { return o.Code == object_code; });
            if (obj != null)
            {
                this.objectCode = object_code;
                int idx = module_list.FindIndex(o => { return o.Code == obj.ModuleCode; });
                this.gvModule.FocusedRowHandle = idx;
            }
        }

        /// <summary>
        ///  当前确认选择的值
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            return this.objectCode;
        }

        /// <summary>
        /// 第一次加载显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmObjectChoice_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.objectCode))
            {
                int idx = ((List<CDictObject>)this.gvFunction.DataSource).FindIndex(o => { return o.Code == this.objectCode; });
                this.gvFunction.FocusedRowHandle = idx;
            }
        }

        /// <summary>
        /// 数据行改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvModule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                string code = this.gvModule.GetFocusedRowCellValue(this.gclModuleCode).ToString();

                List<CDictObject> list = this.objectList.FindAll(o => { return o.ModuleCode == code; });

                this.gcObject.DataSource = list;
            }
        }


        /// <summary>
        /// 选择功能窗体
        /// </summary>
        private void SelectFunction()
        {
            if (this.gvFunction.FocusedRowHandle < 0)
            {
                MessageHelper.ShowError("请先选择一个窗体功能信息！");
                return;
            }
            this.objectCode = this.gvFunction.GetFocusedRowCellValue(gclFunctionCode).ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectFunction();
        }

        private void gvFunction_DoubleClick(object sender, EventArgs e)
        {
            SelectFunction();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
