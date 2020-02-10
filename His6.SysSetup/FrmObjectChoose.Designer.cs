namespace His6.SysSetup
{
    partial class FrmObjectChoose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcModule = new DevExpress.XtraGrid.GridControl();
            this.gvModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclModuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclModuleFilename = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclFileTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcObject = new DevExpress.XtraGrid.GridControl();
            this.gvFunction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclFunctionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcModule
            // 
            this.gcModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcModule.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcModule.Location = new System.Drawing.Point(0, 0);
            this.gcModule.MainView = this.gvModule;
            this.gcModule.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcModule.Name = "gcModule";
            this.gcModule.Size = new System.Drawing.Size(546, 230);
            this.gcModule.TabIndex = 6;
            this.gcModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvModule});
            // 
            // gvModule
            // 
            this.gvModule.ColumnPanelRowHeight = 0;
            this.gvModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclModuleCode,
            this.gclModuleName,
            this.gclModuleFilename,
            this.gclFileTime});
            this.gvModule.DetailHeight = 169;
            this.gvModule.FixedLineWidth = 1;
            this.gvModule.FooterPanelHeight = 0;
            this.gvModule.GridControl = this.gcModule;
            this.gvModule.GroupRowHeight = 0;
            this.gvModule.Name = "gvModule";
            this.gvModule.OptionsBehavior.Editable = false;
            this.gvModule.OptionsView.EnableAppearanceEvenRow = true;
            this.gvModule.OptionsView.EnableAppearanceOddRow = true;
            this.gvModule.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvModule.OptionsView.ShowGroupPanel = false;
            this.gvModule.OptionsView.ShowIndicator = false;
            this.gvModule.RowHeight = 0;
            this.gvModule.ViewCaptionHeight = 0;
            this.gvModule.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvModule_FocusedRowChanged);
            // 
            // gclModuleCode
            // 
            this.gclModuleCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclModuleCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclModuleCode.Caption = "代码";
            this.gclModuleCode.FieldName = "Code";
            this.gclModuleCode.MaxWidth = 54;
            this.gclModuleCode.MinWidth = 54;
            this.gclModuleCode.Name = "gclModuleCode";
            this.gclModuleCode.Visible = true;
            this.gclModuleCode.VisibleIndex = 0;
            this.gclModuleCode.Width = 54;
            // 
            // gclModuleName
            // 
            this.gclModuleName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclModuleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclModuleName.Caption = "模块名称";
            this.gclModuleName.FieldName = "Name";
            this.gclModuleName.MinWidth = 11;
            this.gclModuleName.Name = "gclModuleName";
            this.gclModuleName.OptionsColumn.AllowFocus = false;
            this.gclModuleName.Visible = true;
            this.gclModuleName.VisibleIndex = 1;
            this.gclModuleName.Width = 254;
            // 
            // gclModuleFilename
            // 
            this.gclModuleFilename.AppearanceHeader.Options.UseTextOptions = true;
            this.gclModuleFilename.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclModuleFilename.Caption = "文件名";
            this.gclModuleFilename.FieldName = "Filename";
            this.gclModuleFilename.MinWidth = 11;
            this.gclModuleFilename.Name = "gclModuleFilename";
            this.gclModuleFilename.OptionsColumn.AllowFocus = false;
            this.gclModuleFilename.Visible = true;
            this.gclModuleFilename.VisibleIndex = 2;
            this.gclModuleFilename.Width = 472;
            // 
            // gclFileTime
            // 
            this.gclFileTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gclFileTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclFileTime.Caption = "文件时间";
            this.gclFileTime.FieldName = "FileTime";
            this.gclFileTime.MaxWidth = 65;
            this.gclFileTime.MinWidth = 65;
            this.gclFileTime.Name = "gclFileTime";
            this.gclFileTime.OptionsColumn.AllowFocus = false;
            this.gclFileTime.UnboundExpression = "yyyy-MM-dd HH:mm";
            this.gclFileTime.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gclFileTime.Visible = true;
            this.gclFileTime.VisibleIndex = 3;
            this.gclFileTime.Width = 65;
            // 
            // gcObject
            // 
            this.gcObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcObject.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcObject.Location = new System.Drawing.Point(2, 2);
            this.gcObject.MainView = this.gvFunction;
            this.gcObject.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcObject.Name = "gcObject";
            this.gcObject.Size = new System.Drawing.Size(542, 300);
            this.gcObject.TabIndex = 7;
            this.gcObject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFunction});
            // 
            // gvFunction
            // 
            this.gvFunction.ColumnPanelRowHeight = 0;
            this.gvFunction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclFunctionCode,
            this.gclFunctionName,
            this.gclObjectName});
            this.gvFunction.DetailHeight = 169;
            this.gvFunction.FixedLineWidth = 1;
            this.gvFunction.FooterPanelHeight = 0;
            this.gvFunction.GridControl = this.gcObject;
            this.gvFunction.GroupRowHeight = 0;
            this.gvFunction.Name = "gvFunction";
            this.gvFunction.OptionsBehavior.Editable = false;
            this.gvFunction.OptionsView.EnableAppearanceEvenRow = true;
            this.gvFunction.OptionsView.EnableAppearanceOddRow = true;
            this.gvFunction.OptionsView.ShowGroupPanel = false;
            this.gvFunction.OptionsView.ShowIndicator = false;
            this.gvFunction.RowHeight = 0;
            this.gvFunction.ViewCaptionHeight = 0;
            this.gvFunction.DoubleClick += new System.EventHandler(this.gvFunction_DoubleClick);
            // 
            // gclFunctionCode
            // 
            this.gclFunctionCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclFunctionCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclFunctionCode.Caption = "功能码";
            this.gclFunctionCode.FieldName = "Code";
            this.gclFunctionCode.MinWidth = 11;
            this.gclFunctionCode.Name = "gclFunctionCode";
            this.gclFunctionCode.OptionsColumn.AllowFocus = false;
            this.gclFunctionCode.Visible = true;
            this.gclFunctionCode.VisibleIndex = 0;
            this.gclFunctionCode.Width = 42;
            // 
            // gclFunctionName
            // 
            this.gclFunctionName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclFunctionName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclFunctionName.Caption = "功能名称";
            this.gclFunctionName.FieldName = "Name";
            this.gclFunctionName.MinWidth = 11;
            this.gclFunctionName.Name = "gclFunctionName";
            this.gclFunctionName.OptionsColumn.AllowFocus = false;
            this.gclFunctionName.Visible = true;
            this.gclFunctionName.VisibleIndex = 1;
            this.gclFunctionName.Width = 132;
            // 
            // gclObjectName
            // 
            this.gclObjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclObjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclObjectName.Caption = "目标名";
            this.gclObjectName.FieldName = "Object";
            this.gclObjectName.MinWidth = 11;
            this.gclObjectName.Name = "gclObjectName";
            this.gclObjectName.OptionsColumn.AllowFocus = false;
            this.gclObjectName.Visible = true;
            this.gclObjectName.VisibleIndex = 2;
            this.gclObjectName.Width = 134;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcModule);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(546, 539);
            this.splitContainerControl1.SplitterPosition = 230;
            this.splitContainerControl1.TabIndex = 12;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcObject);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(546, 304);
            this.panelControl2.TabIndex = 8;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.splitContainerControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(550, 543);
            this.panelControl3.TabIndex = 14;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 545);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(550, 53);
            this.panelControl1.TabIndex = 13;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnExit.Appearance.Options.UseBorderColor = true;
            this.btnExit.Location = new System.Drawing.Point(397, 13);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 32);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "取消(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnOk.Appearance.Options.UseBorderColor = true;
            this.btnOk.Location = new System.Drawing.Point(256, 13);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.panelControl3);
            this.panelControl4.Controls.Add(this.panelControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(554, 600);
            this.panelControl4.TabIndex = 15;
            // 
            // FrmObjectChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 600);
            this.Controls.Add(this.panelControl4);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmObjectChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择对象(双击)";
            this.Shown += new System.EventHandler(this.FrmObjectChoice_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcModule;
        private DevExpress.XtraGrid.Views.Grid.GridView gvModule;
        private DevExpress.XtraGrid.Columns.GridColumn gclModuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclModuleName;
        private DevExpress.XtraGrid.Columns.GridColumn gclModuleFilename;
        private DevExpress.XtraGrid.Columns.GridColumn gclFileTime;
        private DevExpress.XtraGrid.GridControl gcObject;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFunction;
        private DevExpress.XtraGrid.Columns.GridColumn gclFunctionCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclFunctionName;
        private DevExpress.XtraGrid.Columns.GridColumn gclObjectName;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.PanelControl panelControl4;
    }
}