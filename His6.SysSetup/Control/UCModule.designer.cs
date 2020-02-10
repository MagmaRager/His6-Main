namespace His6.SysSetup
{
    partial class UCModule
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.meDescribe = new DevExpress.XtraEditors.MemoEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.ckUsedFlag = new DevExpress.XtraEditors.CheckEdit();
            this.txtVersion = new DevExpress.XtraEditors.TextEdit();
            this.txtFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.deFileTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescribe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUsedFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFileTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFileTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(75, 39);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.MaxLength = 8;
            this.txtCode.Properties.NullValuePrompt = "<不可为空>";
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(123, 30);
            this.txtCode.TabIndex = 0;
            // 
            // meDescribe
            // 
            this.meDescribe.Location = new System.Drawing.Point(75, 152);
            this.meDescribe.Name = "meDescribe";
            this.meDescribe.Properties.MaxLength = 128;
            this.meDescribe.Size = new System.Drawing.Size(409, 59);
            this.meDescribe.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 78);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 20;
            this.txtName.Properties.NullValuePrompt = "<不可为空>";
            this.txtName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtName.Size = new System.Drawing.Size(184, 30);
            this.txtName.TabIndex = 2;
            // 
            // ckUsedFlag
            // 
            this.ckUsedFlag.Location = new System.Drawing.Point(429, 42);
            this.ckUsedFlag.Name = "ckUsedFlag";
            this.ckUsedFlag.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckUsedFlag.Properties.Appearance.Options.UseFont = true;
            this.ckUsedFlag.Properties.Caption = "在用";
            this.ckUsedFlag.Size = new System.Drawing.Size(76, 24);
            this.ckUsedFlag.TabIndex = 1;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(274, 40);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Properties.MaxLength = 10;
            this.txtVersion.Properties.NullValuePrompt = "<不可为空>";
            this.txtVersion.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtVersion.Properties.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(123, 30);
            this.txtVersion.TabIndex = 3;
            // 
            // txtFilename
            // 
            this.txtFilename.EditValue = "";
            this.txtFilename.Location = new System.Drawing.Point(75, 115);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFilename.Properties.MaxLength = 50;
            this.txtFilename.Properties.NullValuePrompt = "<不可为空>";
            this.txtFilename.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtFilename.Properties.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(409, 30);
            this.txtFilename.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.deFileTime);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtCode);
            this.groupControl1.Controls.Add(this.meDescribe);
            this.groupControl1.Controls.Add(this.txtFilename);
            this.groupControl1.Controls.Add(this.ckUsedFlag);
            this.groupControl1.Controls.Add(this.txtVersion);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(632, 241);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "模块信息";
            // 
            // deFileTime
            // 
            this.deFileTime.EditValue = null;
            this.deFileTime.Location = new System.Drawing.Point(337, 78);
            this.deFileTime.Margin = new System.Windows.Forms.Padding(6);
            this.deFileTime.Name = "deFileTime";
            this.deFileTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFileTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFileTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.deFileTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFileTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.deFileTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFileTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.deFileTime.Properties.ReadOnly = true;
            this.deFileTime.Size = new System.Drawing.Size(168, 30);
            this.deFileTime.TabIndex = 16;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(274, 81);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 22);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "时间：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(214, 42);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(54, 22);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "版本：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 156);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 22);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "说明：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 120);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 22);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "文件：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 84);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 22);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "名称：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 22);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "代码：";
            // 
            // UCModule
            // 
            this.Controls.Add(this.groupControl1);
            this.Name = "UCModule";
            this.Size = new System.Drawing.Size(632, 241);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescribe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUsedFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFileTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFileTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtVersion;
        private DevExpress.XtraEditors.CheckEdit ckUsedFlag;
        private DevExpress.XtraEditors.MemoEdit meDescribe;
        private DevExpress.XtraEditors.ButtonEdit txtFilename;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFileTime;
    }
}
