using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using His6.Base;

namespace His6.Main
{
    /// <summary>
    /// 输入码选择窗口
    /// </summary>
    class FrmInputCode : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// 系统信息
        /// </summary>
        private SimpleButton button1;
        private SimpleButton button2;
        private RadioGroup rgInputCode;
        private IContainer components = null;

        /// <summary>
        ///  构造函数
        /// </summary>
        public FrmInputCode()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            if (EmpInfo.InputChoice == "1")
            {
                this.rgInputCode.SelectedIndex = 0;
            }
            else
            {
                this.rgInputCode.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.rgInputCode = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.rgInputCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消 ";
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 30);
            
            this.button1.TabIndex = 4;
            this.button1.Text = "确定 ";
            this.button1.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rgInputCode
            // 
            this.rgInputCode.Location = new System.Drawing.Point(59, 12);
            this.rgInputCode.Name = "rgInputCode";
            this.rgInputCode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgInputCode.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.rgInputCode.Properties.Appearance.Options.UseBackColor = true;
            this.rgInputCode.Properties.Appearance.Options.UseForeColor = true;
            this.rgInputCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgInputCode.Properties.Columns = 2;
            this.rgInputCode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "首拼"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "五笔")});
            this.rgInputCode.Size = new System.Drawing.Size(194, 46);
            this.rgInputCode.TabIndex = 6;
            // 
            // FrmInputCode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(273, 144);
            this.ControlBox = false;
            this.Controls.Add(this.rgInputCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入法选择";
            ((System.ComponentModel.ISupportInitialize)(this.rgInputCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            string input = "1";
            if (this.rgInputCode.SelectedIndex == 1) input = "2";

            if (input != EmpInfo.InputChoice)		//  改变了输入法
            {
                string message = "";
                //  TODO: 
                //using (ISysSupport service = ServiceFactory.CreateService<ISysSupport>(false))
                //{
                //   message = service.ChangeInputCode(SystemInfo.Oper.Id, input);
                //}

                if (string.IsNullOrEmpty(message))
                {
                    EmpInfo.InputChoice = input;
                    this.DialogResult = DialogResult.OK;
                    base.Close();
                }
                else
                {
                    MessageHelper.ShowError("保存数据出错！\r\n" + message);
                }
            }
        }
    }
}
