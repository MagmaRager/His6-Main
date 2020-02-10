using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    /// <summary>
    ///  导入模块
    /// </summary>
    public partial class FrmObjectAdd : XtraForm
    {
    
        public List<CDictObject> DataObjectList
        {
            get; private set;
        }


        public FrmObjectAdd()
        {
            InitializeComponent();
        }

        public void Init(List<CDictObject> object_list, string module_name)
        {
            this.gcObject.DataSource = object_list;
            this.Text = module_name + " --- 对象加入";
            this.gvObject.MasterRowExpanded += GvObject_MasterRowExpanded;
        }

        private void GvObject_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView fpView = gvObject.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;

            fpView.BeginUpdate();
            fpView.Columns["Code"].Caption = "代码";
            fpView.Columns["Name"].Caption = "名称";
            fpView.Columns["Describe"].Caption = "说明";

            fpView.Columns["ObjectCode"].Visible = false;
            fpView.Columns["Code"].OptionsColumn.ReadOnly = true;
            fpView.Columns["Name"].OptionsColumn.ReadOnly = true;

            fpView.EndUpdate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DataObjectList = gcObject.DataSource as List<CDictObject>;
            if(this.DataObjectList != null || this.DataObjectList.Count > 0)
            {
                CustomException ce = null;
                // 加入数据处理
                String json = StringHelper.SerializeObject<List<CDictObject>>(this.DataObjectList);
                HttpDataHelper.HttpPostWithInfo("BASE", "/setup/objectadd", out ce, json);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
