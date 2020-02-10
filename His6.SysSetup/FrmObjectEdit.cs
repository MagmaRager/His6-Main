using DevExpress.XtraEditors;

using System;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    /// <summary>
    ///  对象修改
    /// </summary>
    public partial class FrmObjectEdit : XtraForm
    {
        public CDictObject DataObject
        {
            get; private set;
        }

        public FrmObjectEdit()
        {
            InitializeComponent();
        }

        public void Init(CDictObject obj)
        {
            this.ucSysObject1.Init(obj);
            this.ucSysObject1.SetStatus(true);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //  保存数据
            this.DataObject = this.ucSysObject1.GetData();
            if (this.DataObject != null)
            {
                String str = StringHelper.SerializeObject<CDictObject>(this.DataObject);
                CustomException ce = null;
                String result = HttpDataHelper.HttpPostWithInfo("BASE", "/setup/objectset", out ce, str);
                if (result == "1")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else MessageHelper.ShowError("保存失败");
            }
        }

    }
}
