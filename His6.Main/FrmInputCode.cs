using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using His6.Base;

namespace His6.Main
{
    /// <summary>
    /// ������ѡ�񴰿�
    /// </summary>
    class FrmInputCode : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// ϵͳ��Ϣ
        /// </summary>
        private SimpleButton button1;
        private SimpleButton button2;
        private RadioGroup rgInputCode;
        private IContainer components = null;

        /// <summary>
        ///  ���캯��
        /// </summary>
        public FrmInputCode()
        {
            //
            // Windows ���������֧���������
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
        /// ������������ʹ�õ���Դ��
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

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
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
            this.button2.Text = "ȡ�� ";
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 30);
            
            this.button1.TabIndex = 4;
            this.button1.Text = "ȷ�� ";
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
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "��ƴ"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "���")});
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
            this.Text = "���뷨ѡ��";
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

            if (input != EmpInfo.InputChoice)		//  �ı������뷨
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
                    MessageHelper.ShowError("�������ݳ���\r\n" + message);
                }
            }
        }
    }
}
