using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    /// <summary>
    ///  模块修改
    /// </summary>
    public partial class FrmModuleEdit : XtraForm
    {
        public CDictModule DataModule
        {
            get; private set;
        }

        public FrmModuleEdit()
        {
            InitializeComponent();
        }

        public void Init(CDictModule module)
        {
            this.ucSysModule1.Init(module);
            this.ucSysModule1.SetStatus(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //  保存数据
            this.DataModule = this.ucSysModule1.GetData();
            if (this.DataModule != null)
            {
                String str = StringHelper.SerializeObject<CDictModule>(this.DataModule);
                CustomException ce = null;
                HttpDataHelper.HttpPostWithInfo("BASE", "/setup/moduleset", out ce, str);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
