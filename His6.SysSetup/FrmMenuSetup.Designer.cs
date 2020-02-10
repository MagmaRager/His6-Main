namespace His6.SysSetup
{
    partial class FrmMenuSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuSetup));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiAddSystem = new His6.Base.UCBarButtonItemWithFP();
            this.bbiAddMenu = new His6.Base.UCBarButtonItemWithFP();
            this.bbiEdit = new His6.Base.UCBarButtonItemWithFP();
            this.bbiDelete = new His6.Base.UCBarButtonItemWithFP();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tlSysMenu = new DevExpress.XtraTreeList.TreeList();
            this.tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ucMenu1 = new His6.SysSetup.UCMenu();
            this.ucSystem1 = new His6.SysSetup.UCSystem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlSysMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.HideBarsWhenMerging = false;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiEdit,
            this.bbiDelete,
            this.bbiClose,
            this.bbiExport,
            this.bbiRefresh,
            this.bbiAddSystem,
            this.bbiAddMenu,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 26;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(275, 169);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddSystem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddMenu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "工具条";
            // 
            // bbiAddSystem
            // 
            this.bbiAddSystem.Caption = "加系统";
            this.bbiAddSystem.ControlAuthority = false;
            this.bbiAddSystem.Id = 23;
            this.bbiAddSystem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAddSystem.ImageOptions.Image")));
            this.bbiAddSystem.Name = "bbiAddSystem";
            this.bbiAddSystem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddSystem_ItemClick);
            // 
            // bbiAddMenu
            // 
            this.bbiAddMenu.Caption = "加菜单";
            this.bbiAddMenu.ControlAuthority = false;
            this.bbiAddMenu.Id = 24;
            this.bbiAddMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAddMenu.ImageOptions.Image")));
            this.bbiAddMenu.Name = "bbiAddMenu";
            this.bbiAddMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddMenu_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "修改";
            this.bbiEdit.ControlAuthority = false;
            this.bbiEdit.Id = 3;
            this.bbiEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEdit.ImageOptions.Image")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "删除";
            this.bbiDelete.ControlAuthority = false;
            this.bbiDelete.Id = 4;
            this.bbiDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDelete.ImageOptions.Image")));
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "刷新";
            this.bbiRefresh.Id = 22;
            this.bbiRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.Image")));
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // bbiExport
            // 
            this.bbiExport.Caption = "导出";
            this.bbiExport.Id = 20;
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
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "权限";
            this.barButtonItem1.Id = 25;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(1586, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 670);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1586, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 623);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1586, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 623);
            // 
            // tlSysMenu
            // 
            this.tlSysMenu.AllowDrop = true;
            this.tlSysMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcCode,
            this.tlcName});
            this.tlSysMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlSysMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlSysMenu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlSysMenu.KeyFieldName = "";
            this.tlSysMenu.Location = new System.Drawing.Point(0, 47);
            this.tlSysMenu.MinWidth = 18;
            this.tlSysMenu.Name = "tlSysMenu";
            this.tlSysMenu.OptionsBehavior.Editable = false;
            this.tlSysMenu.OptionsBehavior.PopulateServiceColumns = true;
            this.tlSysMenu.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.tlSysMenu.OptionsView.EnableAppearanceEvenRow = true;
            this.tlSysMenu.OptionsView.EnableAppearanceOddRow = true;
            this.tlSysMenu.OptionsView.ShowIndicator = false;
            this.tlSysMenu.ParentFieldName = "";
            this.tlSysMenu.RootValue = "";
            this.tlSysMenu.SelectImageList = this.imageCollection1;
            this.tlSysMenu.Size = new System.Drawing.Size(419, 623);
            this.tlSysMenu.TabIndex = 4;
            this.tlSysMenu.TreeLevelWidth = 16;
            this.tlSysMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.tlSysMenu_DragDrop);
            // 
            // tlcCode
            // 
            this.tlcCode.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcCode.Caption = "代码";
            this.tlcCode.FieldName = "Code";
            this.tlcCode.MinWidth = 40;
            this.tlcCode.Name = "tlcCode";
            this.tlcCode.Visible = true;
            this.tlcCode.VisibleIndex = 0;
            this.tlcCode.Width = 417;
            // 
            // tlcName
            // 
            this.tlcName.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcName.Caption = "名称";
            this.tlcName.FieldName = "Name";
            this.tlcName.MinWidth = 74;
            this.tlcName.Name = "tlcName";
            this.tlcName.Visible = true;
            this.tlcName.VisibleIndex = 1;
            this.tlcName.Width = 802;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "forward_32x32.png");
            this.imageCollection1.Images.SetKeyName(1, "fontcolor_32x32.png");
            this.imageCollection1.Images.SetKeyName(2, "bold_32x32.png");
            this.imageCollection1.Images.SetKeyName(3, "group_32x32.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ucMenu1);
            this.panelControl1.Controls.Add(this.ucSystem1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(419, 47);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1167, 623);
            this.panelControl1.TabIndex = 9;
            // 
            // ucMenu1
            // 
            this.ucMenu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucMenu1.EmpList = null;
            this.ucMenu1.Location = new System.Drawing.Point(577, 2);
            this.ucMenu1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucMenu1.ModuleList = null;
            this.ucMenu1.Name = "ucMenu1";
            this.ucMenu1.ObjectList = null;
            this.ucMenu1.RoleList = null;
            this.ucMenu1.Size = new System.Drawing.Size(575, 619);
            this.ucMenu1.TabIndex = 1;
            // 
            // ucSystem1
            // 
            this.ucSystem1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSystem1.EmpList = null;
            this.ucSystem1.Location = new System.Drawing.Point(2, 2);
            this.ucSystem1.Margin = new System.Windows.Forms.Padding(2);
            this.ucSystem1.Name = "ucSystem1";
            this.ucSystem1.RoleList = null;
            this.ucSystem1.Size = new System.Drawing.Size(575, 619);
            this.ucSystem1.TabIndex = 0;
            // 
            // FrmMenuSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(1586, 670);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.tlSysMenu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMenuSetup";
            this.Text = "系统菜单设置";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlSysMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private His6.Base.UCBarButtonItemWithFP bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private His6.Base.UCBarButtonItemWithFP bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private His6.Base.UCBarButtonItemWithFP bbiAddSystem;
        private His6.Base.UCBarButtonItemWithFP bbiAddMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTreeList.TreeList tlSysMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private UCSystem ucSystem1;
        private UCMenu ucMenu1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
