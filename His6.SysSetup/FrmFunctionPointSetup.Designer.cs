namespace His6.SysSetup
{
    partial class FrmFunctionPointSetup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFunctionPointSetup));
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiSetup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRole = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEmp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCancel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tlSysObject = new DevExpress.XtraTreeList.TreeList();
            this.tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcRole = new DevExpress.XtraGrid.GridControl();
            this.gvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclRoleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmp = new DevExpress.XtraGrid.GridControl();
            this.gvEmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.teDescribe = new DevExpress.XtraEditors.TextEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.teCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlSysObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDescribe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "1";
            this.repositoryItemCheckEdit1.ValueUnchecked = "0";
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.HideBarsWhenMerging = false;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiClose,
            this.bbiExport,
            this.bbiEmp,
            this.bbiRole,
            this.bbiSave,
            this.bbiCancel,
            this.bbiSetup});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 32;
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSetup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiRole, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEmp),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "工具菜单";
            // 
            // bbiSetup
            // 
            this.bbiSetup.Caption = "权限设置";
            this.bbiSetup.Id = 31;
            this.bbiSetup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSetup.ImageOptions.Image")));
            this.bbiSetup.Name = "bbiSetup";
            this.bbiSetup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetup_ItemClick);
            // 
            // bbiRole
            // 
            this.bbiRole.Caption = "角色";
            this.bbiRole.Id = 28;
            this.bbiRole.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRole.ImageOptions.Image")));
            this.bbiRole.Name = "bbiRole";
            this.bbiRole.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRole_ItemClick);
            // 
            // bbiEmp
            // 
            this.bbiEmp.Caption = "人员";
            this.bbiEmp.Id = 27;
            this.bbiEmp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEmp.ImageOptions.Image")));
            this.bbiEmp.Name = "bbiEmp";
            this.bbiEmp.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiEmp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEmp_ItemClick);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "保存";
            this.bbiSave.Id = 29;
            this.bbiSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.Image")));
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiCancel
            // 
            this.bbiCancel.Caption = "取消";
            this.bbiCancel.Id = 30;
            this.bbiCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCancel.ImageOptions.Image")));
            this.bbiCancel.Name = "bbiCancel";
            this.bbiCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCancel_ItemClick);
            // 
            // bbiExport
            // 
            this.bbiExport.Caption = "导出";
            this.bbiExport.Id = 19;
            this.bbiExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExport.ImageOptions.Image")));
            this.bbiExport.Name = "bbiExport";
            this.bbiExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExport_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "退出";
            this.bbiClose.Id = 5;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.ImageIndex = 9;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlTop.Size = new System.Drawing.Size(1899, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 998);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlBottom.Size = new System.Drawing.Size(1899, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 958);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1899, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 958);
            // 
            // tlSysObject
            // 
            this.tlSysObject.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcCode,
            this.tlcName});
            this.tlSysObject.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlSysObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlSysObject.FixedLineWidth = 4;
            this.tlSysObject.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Silver;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "0";
            this.tlSysObject.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.tlSysObject.KeyFieldName = "Code";
            this.tlSysObject.Location = new System.Drawing.Point(0, 0);
            this.tlSysObject.Margin = new System.Windows.Forms.Padding(6);
            this.tlSysObject.MinWidth = 37;
            this.tlSysObject.Name = "tlSysObject";
            this.tlSysObject.BeginUnboundLoad();
            this.tlSysObject.AppendNode(new object[] {
            "SYS",
            "系统基础模块"}, -1);
            this.tlSysObject.AppendNode(new object[] {
            "SYS-W01",
            "系统对象设置"}, 0);
            this.tlSysObject.AppendNode(new object[] {
            "SYS-W02",
            "系统功能点权限设置"}, 0);
            this.tlSysObject.EndUnboundLoad();
            this.tlSysObject.OptionsBehavior.Editable = false;
            this.tlSysObject.OptionsBehavior.PopulateServiceColumns = true;
            this.tlSysObject.OptionsNavigation.EnterMovesNextColumn = true;
            this.tlSysObject.OptionsView.EnableAppearanceEvenRow = true;
            this.tlSysObject.OptionsView.EnableAppearanceOddRow = true;
            this.tlSysObject.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.tlSysObject.OptionsView.ShowIndicator = false;
            this.tlSysObject.ParentFieldName = "";
            this.tlSysObject.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.tlSysObject.RootValue = "";
            this.tlSysObject.Size = new System.Drawing.Size(1018, 958);
            this.tlSysObject.TabIndex = 4;
            this.tlSysObject.TreeLevelWidth = 33;
            this.tlSysObject.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.tlSysObject_AfterExpand);
            this.tlSysObject.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlSysObject_FocusedNodeChanged);
            // 
            // tlcCode
            // 
            this.tlcCode.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcCode.Caption = "代码";
            this.tlcCode.FieldName = "Code";
            this.tlcCode.MinWidth = 93;
            this.tlcCode.Name = "tlcCode";
            this.tlcCode.Visible = true;
            this.tlcCode.VisibleIndex = 0;
            this.tlcCode.Width = 716;
            // 
            // tlcName
            // 
            this.tlcName.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcName.Caption = "名称";
            this.tlcName.FieldName = "Name";
            this.tlcName.MinWidth = 149;
            this.tlcName.Name = "tlcName";
            this.tlcName.Visible = true;
            this.tlcName.VisibleIndex = 1;
            this.tlcName.Width = 1723;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 40);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlSysObject);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1899, 958);
            this.splitContainerControl1.SplitterPosition = 876;
            this.splitContainerControl1.TabIndex = 9;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 233);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.gcRole);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gcEmp);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(876, 725);
            this.splitContainerControl2.SplitterPosition = 423;
            this.splitContainerControl2.TabIndex = 63;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // gcRole
            // 
            this.gcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRole.Location = new System.Drawing.Point(0, 0);
            this.gcRole.MainView = this.gvRole;
            this.gcRole.Name = "gcRole";
            this.gcRole.Size = new System.Drawing.Size(423, 725);
            this.gcRole.TabIndex = 20;
            this.gcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRole});
            // 
            // gvRole
            // 
            this.gvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclRoleCode,
            this.gclRoleName});
            this.gvRole.GridControl = this.gcRole;
            this.gvRole.GroupPanelText = "可使用的角色";
            this.gvRole.Name = "gvRole";
            this.gvRole.OptionsBehavior.Editable = false;
            this.gvRole.OptionsCustomization.AllowGroup = false;
            this.gvRole.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvRole.OptionsSelection.MultiSelect = true;
            this.gvRole.OptionsView.EnableAppearanceEvenRow = true;
            this.gvRole.OptionsView.EnableAppearanceOddRow = true;
            this.gvRole.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvRole.OptionsView.ShowGroupPanel = false;
            this.gvRole.OptionsView.ShowGroupPanelColumnsAsSingleRow = true;
            this.gvRole.OptionsView.ShowIndicator = false;
            this.gvRole.DoubleClick += new System.EventHandler(this.gvRole_DoubleClick);
            // 
            // gclRoleCode
            // 
            this.gclRoleCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclRoleCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclRoleCode.Caption = "代码";
            this.gclRoleCode.FieldName = "Code";
            this.gclRoleCode.Name = "gclRoleCode";
            this.gclRoleCode.Visible = true;
            this.gclRoleCode.VisibleIndex = 0;
            this.gclRoleCode.Width = 417;
            // 
            // gclRoleName
            // 
            this.gclRoleName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclRoleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclRoleName.Caption = "角色名称";
            this.gclRoleName.FieldName = "Name";
            this.gclRoleName.Name = "gclRoleName";
            this.gclRoleName.Visible = true;
            this.gclRoleName.VisibleIndex = 1;
            this.gclRoleName.Width = 1085;
            // 
            // gcEmp
            // 
            this.gcEmp.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEmp.Location = new System.Drawing.Point(0, 0);
            this.gcEmp.MainView = this.gvEmp;
            this.gcEmp.Name = "gcEmp";
            this.gcEmp.Size = new System.Drawing.Size(448, 725);
            this.gcEmp.TabIndex = 19;
            this.gcEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmp});
            // 
            // gvEmp
            // 
            this.gvEmp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclEmpCode,
            this.gclEmpName});
            this.gvEmp.GridControl = this.gcEmp;
            this.gvEmp.GroupPanelText = "可使用的职工";
            this.gvEmp.Name = "gvEmp";
            this.gvEmp.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gvEmp.OptionsBehavior.Editable = false;
            this.gvEmp.OptionsCustomization.AllowGroup = false;
            this.gvEmp.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvEmp.OptionsSelection.MultiSelect = true;
            this.gvEmp.OptionsView.EnableAppearanceEvenRow = true;
            this.gvEmp.OptionsView.EnableAppearanceOddRow = true;
            this.gvEmp.OptionsView.ShowGroupedColumns = true;
            this.gvEmp.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvEmp.OptionsView.ShowGroupPanel = false;
            this.gvEmp.OptionsView.ShowIndicator = false;
            this.gvEmp.DoubleClick += new System.EventHandler(this.gvEmp_DoubleClick);
            // 
            // gclEmpCode
            // 
            this.gclEmpCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclEmpCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclEmpCode.Caption = "工号";
            this.gclEmpCode.FieldName = "Code";
            this.gclEmpCode.Name = "gclEmpCode";
            this.gclEmpCode.Visible = true;
            this.gclEmpCode.VisibleIndex = 0;
            this.gclEmpCode.Width = 115;
            // 
            // gclEmpName
            // 
            this.gclEmpName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclEmpName.Caption = "姓名";
            this.gclEmpName.FieldName = "Name";
            this.gclEmpName.Name = "gclEmpName";
            this.gclEmpName.Visible = true;
            this.gclEmpName.VisibleIndex = 1;
            this.gclEmpName.Width = 207;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.teDescribe);
            this.groupControl1.Controls.Add(this.teName);
            this.groupControl1.Controls.Add(this.teCode);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(876, 233);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "功能点信息";
            // 
            // teDescribe
            // 
            this.teDescribe.Location = new System.Drawing.Point(127, 175);
            this.teDescribe.MenuManager = this.barManager1;
            this.teDescribe.Name = "teDescribe";
            this.teDescribe.Properties.ReadOnly = true;
            this.teDescribe.Size = new System.Drawing.Size(698, 20);
            this.teDescribe.TabIndex = 6;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(127, 117);
            this.teName.MenuManager = this.barManager1;
            this.teName.Name = "teName";
            this.teName.Properties.ReadOnly = true;
            this.teName.Size = new System.Drawing.Size(456, 20);
            this.teName.TabIndex = 5;
            // 
            // teCode
            // 
            this.teCode.Location = new System.Drawing.Point(127, 59);
            this.teCode.MenuManager = this.barManager1;
            this.teCode.Name = "teCode";
            this.teCode.Properties.ReadOnly = true;
            this.teCode.Size = new System.Drawing.Size(141, 20);
            this.teCode.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(49, 179);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "备注：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 122);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "名称：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(49, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "代码：";
            // 
            // FrmFunctionPointSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1899, 998);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmFunctionPointSetup";
            this.Text = "功能点权限设置";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlSysObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDescribe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiEmp;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTreeList.TreeList tlSysObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl gcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRole;
        private DevExpress.XtraGrid.Columns.GridColumn gclRoleCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclRoleName;
        private DevExpress.XtraGrid.GridControl gcEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmp;
        private DevExpress.XtraGrid.Columns.GridColumn gclEmpCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclEmpName;
        private DevExpress.XtraBars.BarButtonItem bbiSetup;
        private DevExpress.XtraBars.BarButtonItem bbiRole;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiCancel;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.TextEdit teCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit teDescribe;
    }
}