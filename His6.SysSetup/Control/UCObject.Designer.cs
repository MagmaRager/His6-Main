namespace His6.SysSetup.Control
{
    partial class UCObject
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtObject = new DevExpress.XtraEditors.TextEdit();
            this.ckIsFP = new DevExpress.XtraEditors.CheckEdit();
            this.ckIsFunction = new DevExpress.XtraEditors.CheckEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.ckUsedFlag = new DevExpress.XtraEditors.CheckEdit();
            this.gcFp = new DevExpress.XtraGrid.GridControl();
            this.gvFp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclFpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclFpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclFpDescribe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControlBase = new DevExpress.XtraEditors.GroupControl();
            this.meDescribe = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControlFP = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsFP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsFunction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUsedFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).BeginInit();
            this.groupControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meDescribe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFP)).BeginInit();
            this.groupControlFP.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(106, 41);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(120, 20);
            this.txtCode.TabIndex = 0;
            // 
            // txtObject
            // 
            this.txtObject.EnterMoveNextControl = true;
            this.txtObject.Location = new System.Drawing.Point(106, 82);
            this.txtObject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtObject.Name = "txtObject";
            this.txtObject.Properties.ReadOnly = true;
            this.txtObject.Size = new System.Drawing.Size(355, 20);
            this.txtObject.TabIndex = 3;
            // 
            // ckIsFP
            // 
            this.ckIsFP.Location = new System.Drawing.Point(481, 128);
            this.ckIsFP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckIsFP.Name = "ckIsFP";
            this.ckIsFP.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsFP.Properties.Appearance.Options.UseFont = true;
            this.ckIsFP.Properties.Caption = "功能点";
            this.ckIsFP.Properties.ReadOnly = true;
            this.ckIsFP.Size = new System.Drawing.Size(74, 19);
            this.ckIsFP.TabIndex = 5;
            // 
            // ckIsFunction
            // 
            this.ckIsFunction.Location = new System.Drawing.Point(481, 85);
            this.ckIsFunction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckIsFunction.Name = "ckIsFunction";
            this.ckIsFunction.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIsFunction.Properties.Appearance.Options.UseFont = true;
            this.ckIsFunction.Properties.Caption = "菜单";
            this.ckIsFunction.Properties.ReadOnly = true;
            this.ckIsFunction.Size = new System.Drawing.Size(52, 19);
            this.ckIsFunction.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(283, 41);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 2;
            // 
            // ckUsedFlag
            // 
            this.ckUsedFlag.EditValue = 0;
            this.ckUsedFlag.Location = new System.Drawing.Point(481, 43);
            this.ckUsedFlag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckUsedFlag.Name = "ckUsedFlag";
            this.ckUsedFlag.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckUsedFlag.Properties.Appearance.Options.UseFont = true;
            this.ckUsedFlag.Properties.Caption = "在用";
            this.ckUsedFlag.Properties.ValueChecked = 1;
            this.ckUsedFlag.Properties.ValueUnchecked = 0;
            this.ckUsedFlag.Size = new System.Drawing.Size(52, 19);
            this.ckUsedFlag.TabIndex = 1;
            // 
            // gcFp
            // 
            this.gcFp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gcFp.Location = new System.Drawing.Point(2, 21);
            this.gcFp.MainView = this.gvFp;
            this.gcFp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gcFp.Name = "gcFp";
            this.gcFp.Size = new System.Drawing.Size(592, 286);
            this.gcFp.TabIndex = 53;
            this.gcFp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFp});
            // 
            // gvFp
            // 
            this.gvFp.ColumnPanelRowHeight = 0;
            this.gvFp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclFpCode,
            this.gclFpName,
            this.gclFpDescribe});
            this.gvFp.DetailHeight = 423;
            this.gvFp.FooterPanelHeight = 0;
            this.gvFp.GridControl = this.gcFp;
            this.gvFp.GroupRowHeight = 0;
            this.gvFp.Name = "gvFp";
            this.gvFp.OptionsView.EnableAppearanceEvenRow = true;
            this.gvFp.OptionsView.EnableAppearanceOddRow = true;
            this.gvFp.OptionsView.ShowGroupPanel = false;
            this.gvFp.OptionsView.ShowIndicator = false;
            this.gvFp.RowHeight = 0;
            this.gvFp.ViewCaptionHeight = 0;
            // 
            // gclFpCode
            // 
            this.gclFpCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclFpCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclFpCode.Caption = "代码";
            this.gclFpCode.FieldName = "Code";
            this.gclFpCode.MaxWidth = 130;
            this.gclFpCode.MinWidth = 108;
            this.gclFpCode.Name = "gclFpCode";
            this.gclFpCode.OptionsColumn.AllowEdit = false;
            this.gclFpCode.OptionsColumn.ReadOnly = true;
            this.gclFpCode.Visible = true;
            this.gclFpCode.VisibleIndex = 0;
            this.gclFpCode.Width = 108;
            // 
            // gclFpName
            // 
            this.gclFpName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclFpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclFpName.Caption = "名称";
            this.gclFpName.FieldName = "Name";
            this.gclFpName.MaxWidth = 216;
            this.gclFpName.MinWidth = 130;
            this.gclFpName.Name = "gclFpName";
            this.gclFpName.OptionsColumn.AllowEdit = false;
            this.gclFpName.OptionsColumn.ReadOnly = true;
            this.gclFpName.Visible = true;
            this.gclFpName.VisibleIndex = 1;
            this.gclFpName.Width = 163;
            // 
            // gclFpDescribe
            // 
            this.gclFpDescribe.AppearanceHeader.Options.UseTextOptions = true;
            this.gclFpDescribe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclFpDescribe.Caption = "备注";
            this.gclFpDescribe.FieldName = "Describe";
            this.gclFpDescribe.MinWidth = 22;
            this.gclFpDescribe.Name = "gclFpDescribe";
            this.gclFpDescribe.Visible = true;
            this.gclFpDescribe.VisibleIndex = 2;
            this.gclFpDescribe.Width = 216;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(47, 85);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 56;
            this.labelControl3.Text = "对象：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(241, 44);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 57;
            this.labelControl4.Text = "名称：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(47, 129);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 58;
            this.labelControl5.Text = "备注：";
            // 
            // groupControlBase
            // 
            this.groupControlBase.Controls.Add(this.meDescribe);
            this.groupControlBase.Controls.Add(this.labelControl1);
            this.groupControlBase.Controls.Add(this.labelControl5);
            this.groupControlBase.Controls.Add(this.txtCode);
            this.groupControlBase.Controls.Add(this.labelControl4);
            this.groupControlBase.Controls.Add(this.labelControl3);
            this.groupControlBase.Controls.Add(this.txtObject);
            this.groupControlBase.Controls.Add(this.ckUsedFlag);
            this.groupControlBase.Controls.Add(this.ckIsFunction);
            this.groupControlBase.Controls.Add(this.ckIsFP);
            this.groupControlBase.Controls.Add(this.txtName);
            this.groupControlBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlBase.Location = new System.Drawing.Point(0, 0);
            this.groupControlBase.Margin = new System.Windows.Forms.Padding(2);
            this.groupControlBase.Name = "groupControlBase";
            this.groupControlBase.Size = new System.Drawing.Size(596, 189);
            this.groupControlBase.TabIndex = 59;
            this.groupControlBase.Text = "对象信息";
            // 
            // meDescribe
            // 
            this.meDescribe.Location = new System.Drawing.Point(106, 120);
            this.meDescribe.Margin = new System.Windows.Forms.Padding(2);
            this.meDescribe.Name = "meDescribe";
            this.meDescribe.Properties.MaxLength = 128;
            this.meDescribe.Size = new System.Drawing.Size(355, 55);
            this.meDescribe.TabIndex = 59;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 44);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 54;
            this.labelControl1.Text = "代码：";
            // 
            // groupControlFP
            // 
            this.groupControlFP.Controls.Add(this.gcFp);
            this.groupControlFP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlFP.Location = new System.Drawing.Point(0, 189);
            this.groupControlFP.Margin = new System.Windows.Forms.Padding(2);
            this.groupControlFP.Name = "groupControlFP";
            this.groupControlFP.Size = new System.Drawing.Size(596, 309);
            this.groupControlFP.TabIndex = 60;
            this.groupControlFP.Text = "功能点信息";
            // 
            // UCObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlFP);
            this.Controls.Add(this.groupControlBase);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCObject";
            this.Size = new System.Drawing.Size(596, 498);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsFP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsFunction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUsedFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBase)).EndInit();
            this.groupControlBase.ResumeLayout(false);
            this.groupControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meDescribe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFP)).EndInit();
            this.groupControlFP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtObject;
        private DevExpress.XtraEditors.CheckEdit ckIsFP;
        private DevExpress.XtraEditors.CheckEdit ckIsFunction;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.CheckEdit ckUsedFlag;
        private DevExpress.XtraGrid.GridControl gcFp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFp;
        private DevExpress.XtraGrid.Columns.GridColumn gclFpCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclFpName;
        private DevExpress.XtraGrid.Columns.GridColumn gclFpDescribe;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControlBase;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit meDescribe;
        private DevExpress.XtraEditors.GroupControl groupControlFP;
    }
}
