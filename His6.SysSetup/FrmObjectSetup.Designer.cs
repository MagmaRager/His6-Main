namespace His6.SysSetup
{
    partial class FrmObjectSetup
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObjectSetup));
            this.tlcUsedFlag = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlSysObject = new DevExpress.XtraTreeList.TreeList();
            this.tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcObject = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcParentCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ucSysModule1 = new His6.SysSetup.UCModule();
            this.ucSysObject1 = new His6.SysSetup.Control.UCObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiAddModule = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditModule = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAddObject = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditObject = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlSysObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlcUsedFlag
            // 
            this.tlcUsedFlag.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcUsedFlag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcUsedFlag.Caption = "使用";
            this.tlcUsedFlag.ColumnEdit = this.repositoryItemCheckEdit1;
            this.tlcUsedFlag.FieldName = "UsedFlag";
            this.tlcUsedFlag.MinWidth = 42;
            this.tlcUsedFlag.Name = "tlcUsedFlag";
            this.tlcUsedFlag.Visible = true;
            this.tlcUsedFlag.VisibleIndex = 3;
            this.tlcUsedFlag.Width = 190;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "1";
            this.repositoryItemCheckEdit1.ValueUnchecked = "0";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 58);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlSysObject);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucSysModule1);
            this.splitContainerControl1.Panel2.Controls.Add(this.ucSysObject1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1936, 900);
            this.splitContainerControl1.SplitterPosition = 691;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlSysObject
            // 
            this.tlSysObject.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcCode,
            this.tlcName,
            this.tlcObject,
            this.tlcUsedFlag,
            this.tlcParentCode});
            this.tlSysObject.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlSysObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlSysObject.FixedLineWidth = 3;
            this.tlSysObject.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Silver;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.tlcUsedFlag;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "0";
            this.tlSysObject.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.tlSysObject.KeyFieldName = "Code";
            this.tlSysObject.Location = new System.Drawing.Point(0, 0);
            this.tlSysObject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlSysObject.MinWidth = 27;
            this.tlSysObject.Name = "tlSysObject";
            this.tlSysObject.BeginUnboundLoad();
            this.tlSysObject.AppendNode(new object[] {
            "SYS",
            "系统基础模块",
            "His6.SysSetup",
            "1",
            ""}, -1);
            this.tlSysObject.AppendNode(new object[] {
            "SYS-W01",
            "系统对象设置",
            "FrmObjectSetup",
            "1",
            "SYS"}, 0);
            this.tlSysObject.AppendNode(new object[] {
            "SYS-W02",
            "系统功能点权限设置",
            "FrmFpSetup",
            "1",
            "SYS"}, 0);
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
            this.tlSysObject.Size = new System.Drawing.Size(691, 900);
            this.tlSysObject.TabIndex = 2;
            this.tlSysObject.TreeLevelWidth = 24;
            this.tlSysObject.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlSysObject_FocusedNodeChanged);
            // 
            // tlcCode
            // 
            this.tlcCode.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcCode.Caption = "代码";
            this.tlcCode.FieldName = "Code";
            this.tlcCode.MinWidth = 69;
            this.tlcCode.Name = "tlcCode";
            this.tlcCode.Visible = true;
            this.tlcCode.VisibleIndex = 0;
            this.tlcCode.Width = 471;
            // 
            // tlcName
            // 
            this.tlcName.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcName.Caption = "名称";
            this.tlcName.FieldName = "Name";
            this.tlcName.MinWidth = 111;
            this.tlcName.Name = "tlcName";
            this.tlcName.Visible = true;
            this.tlcName.VisibleIndex = 1;
            this.tlcName.Width = 631;
            // 
            // tlcObject
            // 
            this.tlcObject.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcObject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcObject.Caption = "对象名";
            this.tlcObject.FieldName = "ObjectName";
            this.tlcObject.MinWidth = 166;
            this.tlcObject.Name = "tlcObject";
            this.tlcObject.Visible = true;
            this.tlcObject.VisibleIndex = 2;
            this.tlcObject.Width = 535;
            // 
            // tlcParentCode
            // 
            this.tlcParentCode.Caption = "treeListColumn1";
            this.tlcParentCode.FieldName = "ModuleCode";
            this.tlcParentCode.MinWidth = 27;
            this.tlcParentCode.Name = "tlcParentCode";
            this.tlcParentCode.OptionsColumn.AllowEdit = false;
            this.tlcParentCode.OptionsColumn.ReadOnly = true;
            this.tlcParentCode.Width = 103;
            // 
            // ucSysModule1
            // 
            this.ucSysModule1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucSysModule1.Location = new System.Drawing.Point(0, 0);
            this.ucSysModule1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucSysModule1.Name = "ucSysModule1";
            this.ucSysModule1.Size = new System.Drawing.Size(1238, 556);
            this.ucSysModule1.TabIndex = 4;
            // 
            // ucSysObject1
            // 
            this.ucSysObject1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSysObject1.Location = new System.Drawing.Point(0, 0);
            this.ucSysObject1.Name = "ucSysObject1";
            this.ucSysObject1.Size = new System.Drawing.Size(1238, 900);
            this.ucSysObject1.TabIndex = 3;
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
            this.bbiEditModule,
            this.bbiAddModule,
            this.bbiAddObject,
            this.bbiRefresh,
            this.bbiEditObject});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 28;
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddModule, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEditModule, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddObject, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditObject),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "工具菜单";
            // 
            // bbiAddModule
            // 
            this.bbiAddModule.Caption = "增加模块";
            this.bbiAddModule.Id = 24;
            this.bbiAddModule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAddModule.ImageOptions.Image")));
            this.bbiAddModule.Name = "bbiAddModule";
            this.bbiAddModule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddModule_ItemClick);
            // 
            // bbiEditModule
            // 
            this.bbiEditModule.Caption = "修改模块";
            this.bbiEditModule.Id = 23;
            this.bbiEditModule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEditModule.ImageOptions.Image")));
            this.bbiEditModule.Name = "bbiEditModule";
            this.bbiEditModule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditModule_ItemClick);
            // 
            // bbiAddObject
            // 
            this.bbiAddObject.Caption = "增加对象";
            this.bbiAddObject.Id = 25;
            this.bbiAddObject.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAddObject.ImageOptions.Image")));
            this.bbiAddObject.Name = "bbiAddObject";
            this.bbiAddObject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddObject_ItemClick);
            // 
            // bbiEditObject
            // 
            this.bbiEditObject.Caption = "修改对象";
            this.bbiEditObject.Id = 27;
            this.bbiEditObject.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEditObject.ImageOptions.Image")));
            this.bbiEditObject.Name = "bbiEditObject";
            this.bbiEditObject.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiEditObject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditObject_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "刷新(&R)";
            this.bbiRefresh.Id = 26;
            this.bbiRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.Image")));
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1936, 58);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 958);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1936, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 58);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 900);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1936, 58);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 900);
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(130, 195);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAddModule),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditModule),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAddObject),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditObject, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "工具条";
            // 
            // FrmObjectSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.ClientSize = new System.Drawing.Size(1936, 958);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmObjectSetup";
            this.Text = "系统对象设置";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlSysObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbiEditObject;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiEditModule;
        private DevExpress.XtraBars.BarButtonItem bbiAddModule;
        private DevExpress.XtraBars.BarButtonItem bbiAddObject;
        private DevExpress.XtraTreeList.TreeList tlSysObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcObject;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcUsedFlag;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcParentCode;
        private DevExpress.XtraBars.Bar bar2;
        private UCModule ucSysModule1;
        private Control.UCObject ucSysObject1;
    }
}
