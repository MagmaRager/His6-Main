using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    [FunctionPointAttribute("01", "修改", "系统参数修改")]
    public partial class FrmParameterSetup : FrmWithFPBase
    {
        public FrmParameterSetup()
        {
            InitializeComponent();

            // 注册功能点
            _FunctionPointHelper.RegisterFunctionPoints(this, this.bbiEdit);
        }

        public override bool Init()
        {
            this.BindTypeData();

            CustomException ce = null;
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("branchId", EnvInfo.BranchId.ToString())
            };
            // 根据机构ID查询出全部参数
            List<BDictParameter> parameterList = HttpDataHelper.GetWithInfo<List<BDictParameter>>(
                "BASE", "/setup/paramsget", out ce, parmList);
            
            this.gcParameterList.DataSource = parameterList;
            this.SetStatus(false);

            return base.Init();
        }

        private void BindTypeData()
        {
            this.riiModifyType.Items.AddRange(new ImageComboBoxItem[] {
                new ImageComboBoxItem("允许", "Y", -1),
                new ImageComboBoxItem("不可", "N", -1),
                new ImageComboBoxItem("警告", "W", -1)});

            this.icbeModifyType.Properties.Items.AddRange(new ImageComboBoxItem[] {
                new ImageComboBoxItem("允许", "Y", -1),
                new ImageComboBoxItem("不可", "N", -1),
                new ImageComboBoxItem("警告", "W", -1)});
        }

        /// <summary>
        ///  设置状态
        /// </summary>
        /// <param name="is_edit">是否编辑</param>
        private void SetStatus(bool is_edit)
        {
            this.teNameChn.Properties.ReadOnly = !is_edit;
            this.teValue.Properties.ReadOnly = !is_edit;
            this.meDescribe.Properties.ReadOnly = !is_edit;

            this.bbiEdit.Enabled = !is_edit;
            this.bbiSave.Enabled = is_edit;
            this.bbiCancel.Enabled = is_edit;

            this.gcParameterList.Enabled = !is_edit;
        }

        private void gvParameterList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.FreshRow();
        }

        private void FreshRow()
        {
            BDictParameter para = this.gvParameterList.GetFocusedRow() as BDictParameter;
            if (para == null)
            {
                return;
            }

            this.teName.Text = para.Name;
            this.teNameChn.Text = para.NameChn;
            this.teValue.Text = para.Value;
            this.icbeModifyType.EditValue = para.ModifyType;
            this.meDescribe.Text = para.Describe;

            //  TODO: 参数对象显示处理（待对象参数表完善）

            meObjectList.Text = "His6.Base.GridHelper\r\nHis6.Base.TreeListHelper";
        }

        #region 功能按钮事件

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string modify_type = this.icbeModifyType.EditValue.ToString();
            if (modify_type == "N")
            {
                return;
            }
            if(modify_type == "W")
            {
                if(MessageHelper.ShowYesNoAndQuestion("是否真的修改参数？") != DialogResult.Yes)
                {
                    return;
                }
            }
            this.SetStatus(true);
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 保存修改数据
            BDictParameter para = this.gvParameterList.GetFocusedRow() as BDictParameter;
            if (string.IsNullOrEmpty(this.teValue.Text)) {
                MessageHelper.ShowWarning("参数值不可为空！");
                return;
            }
            para.Value = this.teValue.Text;
            para.NameChn = string.IsNullOrEmpty(this.teNameChn.Text) ? "" : this.teNameChn.Text;
            para.Describe = string.IsNullOrEmpty(this.meDescribe.Text) ? "" : this.meDescribe.Text;

            string json = StringHelper.SerializeObject<BDictParameter>(para);
            CustomException ce = null;
            HttpDataHelper.HttpPostWithInfo("BASE", "/setup/paramset", out ce, json);
            if (ce == null)
            {
                this.gvParameterList.SetFocusedRowCellValue("Value", this.teValue.Text);
                this.gvParameterList.SetFocusedRowCellValue("NameChn", this.teNameChn.Text);
                this.gvParameterList.SetFocusedRowCellValue("Describe", this.meDescribe.Text);
                this.SetStatus(false);
            }
            else
            {
                MessageHelper.ShowError("保存参数失败！\r\n" + ce.Info);
            }
        }

        private void bbiCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.FreshRow();
            this.SetStatus(false);
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
    }
}
