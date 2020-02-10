using DevExpress.XtraEditors;

using System.Collections.Generic;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup.Control
{
    public partial class UCObject : XtraUserControl
    {
        public UCObject()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  数据初始化
        /// </summary>
        /// <param name="data">对象实体</param>
        /// <param name="fpList">功能点列表</param>
        public void Init(CDictObject data)
        {
            this.txtCode.Text = data.Code;
            this.txtName.Text = data.Name;
            this.txtObject.Text = data.Object;
            //this.btnIco.Text = data.Ico;
            this.meDescribe.Text = data.Describe;

            this.ckUsedFlag.Checked = (data.UsedFlag == 1);
            this.ckIsFunction.Checked = (data.IsFunction == 1);
            this.ckIsFP.Checked = (data.HasFunctionPoint == 1);
            
            if(data.HasFunctionPoint == 1 && data.FunctionPointList != null && data.FunctionPointList.Count > 0)
            {
                this.gcFp.BeginUpdate();
                this.gcFp.DataSource = data.FunctionPointList;
                this.gcFp.EndUpdate();
                this.groupControlFP.Visible = true;
            }
            else
            {
                this.groupControlFP.Visible = false;
            }
        }


        /// <summary>
        ///  状态设置
        /// </summary>
        /// <param name="isEdit"></param>
        public void SetStatus(bool isEdit)
        {
            this.txtName.Properties.ReadOnly = !isEdit;
            this.meDescribe.Properties.ReadOnly = !isEdit;

            this.ckUsedFlag.Properties.ReadOnly = !isEdit;

            this.gclFpDescribe.OptionsColumn.AllowEdit = isEdit;
        }

        /// <summary>
        ///  取对象基本信息
        /// </summary>
        /// <returns></returns>
        public CDictObject GetData()
        {
            CDictObject data = new CDictObject(this.txtCode.Text);

            data.Name = this.txtName.Text ;
            data.Object = this.txtObject.Text ;
            //data.Ico = this.btnIco.Text ;
            data.Describe = this.meDescribe.Text ;

            data.UsedFlag = this.ckUsedFlag.Checked ? 1 : 0;
            data.IsFunction = this.ckIsFunction.Checked ? 1 : 0;
            data.HasFunctionPoint = this.ckIsFP.Checked ? 1 : 0;

            if (this.ckIsFP.Checked)
            {
                data.FunctionPointList = this.gcFp.DataSource as List<CDictFunctionPoint>;
            }
            return data;
        }

    }
}
