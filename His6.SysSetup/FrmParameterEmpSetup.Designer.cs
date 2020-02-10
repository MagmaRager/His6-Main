namespace His6.SysSetup
{
    partial class FrmParameterEmpSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParameterEmpSetup));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bsiEmpChoice = new DevExpress.XtraBars.BarStaticItem();
            this.beiEmp = new His6.Base.UCBarEditItemWithFP();
            this.rileEmp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bbiEdit = new Base.UCBarButtonItemWithFP();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.gcParameterList = new DevExpress.XtraGrid.GridControl();
            this.gvParameterList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNameChn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDescribe = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rileEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParameterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameterList)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiEmpChoice),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beiEmp, "", false, true, true, 423),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose, true)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "主菜单";
            // 
            // bsiEmpChoice
            // 
            this.bsiEmpChoice.Caption = "请选择：";
            this.bsiEmpChoice.Id = 11;
            this.bsiEmpChoice.Name = "bsiEmpChoice";
            // 
            // beiEmp
            // 
            this.beiEmp.Caption = "员工选择：";
            this.beiEmp.Edit = this.rileEmp;
            this.beiEmp.Id = 10;
            this.beiEmp.Name = "beiEmp";
            this.beiEmp.EditValueChanged += new System.EventHandler(this.beiEmp_EditValueChanged);
            // 
            // rileEmp
            // 
            this.rileEmp.AutoHeight = false;
            this.rileEmp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rileEmp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "工号", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "姓名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Inputcode1", "辅码1", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Inputcode2", "辅码2", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeptName", "科室", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "标识", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeptId", "科室ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rileEmp.DropDownRows = 17;
            this.rileEmp.Name = "rileEmp";
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "修改";
            this.bbiEdit.Id = 8;
            this.bbiEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEdit.ImageOptions.Image")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiExport
            // 
            this.bbiExport.Caption = "导出";
            this.bbiExport.Id = 7;
            this.bbiExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExport.ImageOptions.Image")));
            this.bbiExport.Name = "bbiExport";
            this.bbiExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExport_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "退出";
            this.bbiClose.Id = 6;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bbiCancel
            // 
            this.bbiCancel.Caption = "取消";
            this.bbiCancel.Enabled = false;
            this.bbiCancel.Id = 9;
            this.bbiCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCancel.ImageOptions.Image")));
            this.bbiCancel.Name = "bbiCancel";
            this.bbiCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiRefresh,
            this.bbiClose,
            this.bbiExport,
            this.bbiEdit,
            this.bbiCancel,
            this.beiEmp,
            this.bsiEmpChoice});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rileEmp});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1711, 78);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 998);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1711, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 78);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 920);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1711, 78);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 920);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "刷新";
            this.bbiRefresh.Id = 5;
            this.bbiRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.Image")));
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gcParameterList
            // 
            this.gcParameterList.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gcParameterList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcParameterList.Location = new System.Drawing.Point(0, 78);
            this.gcParameterList.MainView = this.gvParameterList;
            this.gcParameterList.Name = "gcParameterList";
            this.gcParameterList.Size = new System.Drawing.Size(1711, 920);
            this.gcParameterList.TabIndex = 9;
            this.gcParameterList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvParameterList});
            // 
            // gvParameterList
            // 
            this.gvParameterList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclName,
            this.gclNameChn,
            this.gclValue,
            this.gclDescribe});
            this.gvParameterList.GridControl = this.gcParameterList;
            this.gvParameterList.Name = "gvParameterList";
            this.gvParameterList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvParameterList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvParameterList.OptionsView.ShowGroupPanel = false;
            // 
            // gclName
            // 
            this.gclName.Caption = "名称";
            this.gclName.FieldName = "Name";
            this.gclName.Name = "gclName";
            this.gclName.OptionsColumn.ReadOnly = true;
            this.gclName.Visible = true;
            this.gclName.VisibleIndex = 0;
            this.gclName.Width = 140;
            // 
            // gclNameChn
            // 
            this.gclNameChn.Caption = "中文名称";
            this.gclNameChn.FieldName = "NameChn";
            this.gclNameChn.Name = "gclNameChn";
            this.gclNameChn.OptionsColumn.ReadOnly = true;
            this.gclNameChn.Visible = true;
            this.gclNameChn.VisibleIndex = 1;
            this.gclNameChn.Width = 197;
            // 
            // gclValue
            // 
            this.gclValue.Caption = "值";
            this.gclValue.FieldName = "Value";
            this.gclValue.Name = "gclValue";
            this.gclValue.OptionsColumn.ReadOnly = true;
            this.gclValue.Visible = true;
            this.gclValue.VisibleIndex = 2;
            this.gclValue.Width = 161;
            // 
            // gclDescribe
            // 
            this.gclDescribe.Caption = "描述";
            this.gclDescribe.FieldName = "Describe";
            this.gclDescribe.Name = "gclDescribe";
            this.gclDescribe.OptionsColumn.ReadOnly = true;
            this.gclDescribe.Visible = true;
            this.gclDescribe.VisibleIndex = 3;
            this.gclDescribe.Width = 177;
            // 
            // FrmParameterEmpSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 998);
            this.Controls.Add(this.gcParameterList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmParameterEmpSetup";
            this.Text = "个人参数设置";
            ((System.ComponentModel.ISupportInitialize)(this.rileEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParameterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar2;
        private His6.Base.UCBarButtonItemWithFP bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiCancel;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraGrid.GridControl gcParameterList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvParameterList;
        private DevExpress.XtraGrid.Columns.GridColumn gclName;
        private DevExpress.XtraGrid.Columns.GridColumn gclNameChn;
        private DevExpress.XtraGrid.Columns.GridColumn gclValue;
        private DevExpress.XtraGrid.Columns.GridColumn gclDescribe;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private His6.Base.UCBarEditItemWithFP beiEmp;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rileEmp;
        private DevExpress.XtraBars.BarStaticItem bsiEmpChoice;
    }
}