using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    /// <summary>
    ///  模块显示对象
    /// </summary>
    public partial class UCModule : XtraUserControl
    { 
        /// <summary>
        ///  构造函数
        /// </summary>
        public UCModule()
        {
            InitializeComponent();

            //  不允许选择文件
            this.txtFilename.Properties.Buttons[0].Visible = false;
        }

        /// <summary>
        ///  数据初始化
        /// </summary>
        /// <param name="data"></param>
        public void Init(CDictModule data)
        {
            this.txtCode.Text = data.Code;
            this.txtName.Text = data.Name;
            this.txtFilename.Text = data.FileName;
            this.txtVersion.Text = data.Version;
            if (!String.IsNullOrEmpty(data.FileTime))
            {
                this.deFileTime.DateTime = DateTime.Parse(data.FileTime);
            }
            this.meDescribe.Text = data.Describe;

            this.ckUsedFlag.Checked = (data.UsedFlag == 1);
        }

        /// <summary>
        /// 可编辑设置
        /// </summary>
        /// <param name="isEdit"></param>
        public void SetStatus(bool isEdit)
        {
            this.txtName.Properties.ReadOnly = !isEdit;
            this.meDescribe.Properties.ReadOnly = !isEdit;
            this.ckUsedFlag.Properties.ReadOnly = !isEdit;
        }

        /// <summary>
        ///  获取数据
        /// </summary>
        /// <param name="data">实体</param>
        public CDictModule GetData()
        {
            txtName.ErrorText = null;
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                txtName.ErrorText = "模块名称不可为空！";
                txtName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                txtName.Focus();
                return null ;
            }

            CDictModule data = new CDictModule();
            data.Code = this.txtCode.Text;
            data.Name = this.txtName.Text;
            data.FileName = this.txtFilename.Text;
            data.Version = this.txtVersion.Text;
            data.FileTime = this.deFileTime.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            data.Describe = this.meDescribe.Text;
            data.UpdateEmpid = EmpInfo.Id;

            data.UsedFlag = this.ckUsedFlag.Checked ? 1 : 0;
            return data;
        }

    }
}
