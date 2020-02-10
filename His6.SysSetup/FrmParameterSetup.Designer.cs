namespace His6.SysSetup
{
    partial class FrmParameterSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParameterSetup));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiEdit = new His6.Base.UCBarButtonItemWithFP();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCancel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcParameterList = new DevExpress.XtraGrid.GridControl();
            this.gvParameterList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNameChn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclModifyType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riiModifyType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gclDescribe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.meObjectList = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.icbeModifyType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.meDescribe = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.teNameChn = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.teValue = new DevExpress.XtraEditors.TextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParameterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riiModifyType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meObjectList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbeModifyType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescribe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNameChn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
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
            this.bbiSave,
            this.bbiRefresh,
            this.bbiClose,
            this.bbiExport,
            this.bbiEdit,
            this.bbiCancel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose, true)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "主菜单";
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "修改";
            this.bbiEdit.ControlAuthority = false;
            this.bbiEdit.Id = 8;
            this.bbiEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEdit.ImageOptions.Image")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "保存";
            this.bbiSave.Enabled = false;
            this.bbiSave.Id = 0;
            this.bbiSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.Image")));
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiCancel
            // 
            this.bbiCancel.Caption = "取消";
            this.bbiCancel.Enabled = false;
            this.bbiCancel.Id = 9;
            this.bbiCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCancel.ImageOptions.Image")));
            this.bbiCancel.Name = "bbiCancel";
            this.bbiCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCancel_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1376, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 756);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1376, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 716);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1376, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 716);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "刷新";
            this.bbiRefresh.Id = 5;
            this.bbiRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.Image")));
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gcParameterList
            // 
            this.gcParameterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcParameterList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gcParameterList.Location = new System.Drawing.Point(0, 0);
            this.gcParameterList.MainView = this.gvParameterList;
            this.gcParameterList.Margin = new System.Windows.Forms.Padding(6);
            this.gcParameterList.MenuManager = this.barManager1;
            this.gcParameterList.Name = "gcParameterList";
            this.gcParameterList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riiModifyType});
            this.gcParameterList.Size = new System.Drawing.Size(671, 716);
            this.gcParameterList.TabIndex = 4;
            this.gcParameterList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvParameterList});
            // 
            // gvParameterList
            // 
            this.gvParameterList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclName,
            this.gclValue,
            this.gclNameChn,
            this.gclModifyType,
            this.gclDescribe});
            this.gvParameterList.DetailHeight = 725;
            this.gvParameterList.FixedLineWidth = 4;
            this.gvParameterList.GridControl = this.gcParameterList;
            this.gvParameterList.Name = "gvParameterList";
            this.gvParameterList.OptionsBehavior.Editable = false;
            this.gvParameterList.OptionsView.ColumnAutoWidth = false;
            this.gvParameterList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvParameterList.OptionsView.ShowGroupPanel = false;
            this.gvParameterList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvParameterList_FocusedRowChanged);
            // 
            // gclName
            // 
            this.gclName.Caption = "名称";
            this.gclName.FieldName = "Name";
            this.gclName.MaxWidth = 279;
            this.gclName.MinWidth = 100;
            this.gclName.Name = "gclName";
            this.gclName.Visible = true;
            this.gclName.VisibleIndex = 0;
            this.gclName.Width = 159;
            // 
            // gclValue
            // 
            this.gclValue.Caption = "值";
            this.gclValue.FieldName = "Value";
            this.gclValue.MaxWidth = 371;
            this.gclValue.MinWidth = 100;
            this.gclValue.Name = "gclValue";
            this.gclValue.Visible = true;
            this.gclValue.VisibleIndex = 2;
            this.gclValue.Width = 240;
            // 
            // gclNameChn
            // 
            this.gclNameChn.Caption = "中文名称";
            this.gclNameChn.FieldName = "NameChn";
            this.gclNameChn.MaxWidth = 223;
            this.gclNameChn.MinWidth = 100;
            this.gclNameChn.Name = "gclNameChn";
            this.gclNameChn.Visible = true;
            this.gclNameChn.VisibleIndex = 1;
            this.gclNameChn.Width = 223;
            // 
            // gclModifyType
            // 
            this.gclModifyType.Caption = "修改";
            this.gclModifyType.ColumnEdit = this.riiModifyType;
            this.gclModifyType.FieldName = "ModifyType";
            this.gclModifyType.MaxWidth = 111;
            this.gclModifyType.MinWidth = 80;
            this.gclModifyType.Name = "gclModifyType";
            this.gclModifyType.Visible = true;
            this.gclModifyType.VisibleIndex = 3;
            this.gclModifyType.Width = 99;
            // 
            // riiModifyType
            // 
            this.riiModifyType.AutoHeight = false;
            this.riiModifyType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riiModifyType.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.riiModifyType.Name = "riiModifyType";
            // 
            // gclDescribe
            // 
            this.gclDescribe.Caption = "描述";
            this.gclDescribe.FieldName = "Describe";
            this.gclDescribe.MaxWidth = 300;
            this.gclDescribe.MinWidth = 37;
            this.gclDescribe.Name = "gclDescribe";
            this.gclDescribe.Visible = true;
            this.gclDescribe.VisibleIndex = 4;
            this.gclDescribe.Width = 300;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(700, 716);
            this.panelControl1.TabIndex = 5;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.meObjectList);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 478);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(696, 236);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "使用对象";
            // 
            // meObjectList
            // 
            this.meObjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meObjectList.Location = new System.Drawing.Point(2, 21);
            this.meObjectList.Margin = new System.Windows.Forms.Padding(6);
            this.meObjectList.MenuManager = this.barManager1;
            this.meObjectList.Name = "meObjectList";
            this.meObjectList.Properties.ReadOnly = true;
            this.meObjectList.Size = new System.Drawing.Size(692, 213);
            this.meObjectList.TabIndex = 24;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.icbeModifyType);
            this.groupControl1.Controls.Add(this.meDescribe);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.teName);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.teNameChn);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.teValue);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(696, 476);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "参数信息";
            // 
            // icbeModifyType
            // 
            this.icbeModifyType.Location = new System.Drawing.Point(164, 249);
            this.icbeModifyType.Name = "icbeModifyType";
            this.icbeModifyType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbeModifyType.Properties.ReadOnly = true;
            this.icbeModifyType.Size = new System.Drawing.Size(165, 20);
            this.icbeModifyType.TabIndex = 26;
            // 
            // meDescribe
            // 
            this.meDescribe.Location = new System.Drawing.Point(164, 310);
            this.meDescribe.Margin = new System.Windows.Forms.Padding(6);
            this.meDescribe.MenuManager = this.barManager1;
            this.meDescribe.Name = "meDescribe";
            this.meDescribe.Size = new System.Drawing.Size(447, 148);
            this.meDescribe.TabIndex = 23;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(80, 72);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "名称：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(80, 312);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 22;
            this.labelControl6.Text = "描述：";
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(164, 66);
            this.teName.Margin = new System.Windows.Forms.Padding(6);
            this.teName.Name = "teName";
            this.teName.Properties.ReadOnly = true;
            this.teName.Size = new System.Drawing.Size(447, 20);
            this.teName.TabIndex = 15;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Location = new System.Drawing.Point(80, 255);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "类型：";
            // 
            // teNameChn
            // 
            this.teNameChn.Location = new System.Drawing.Point(164, 127);
            this.teNameChn.Margin = new System.Windows.Forms.Padding(6);
            this.teNameChn.MenuManager = this.barManager1;
            this.teNameChn.Name = "teNameChn";
            this.teNameChn.Size = new System.Drawing.Size(447, 20);
            this.teNameChn.TabIndex = 20;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 192);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "数据值：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(56, 132);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "中文名：";
            // 
            // teValue
            // 
            this.teValue.Location = new System.Drawing.Point(164, 188);
            this.teValue.Margin = new System.Windows.Forms.Padding(6);
            this.teValue.MenuManager = this.barManager1;
            this.teValue.Name = "teValue";
            this.teValue.Size = new System.Drawing.Size(447, 20);
            this.teValue.TabIndex = 18;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 40);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcParameterList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.MinSize = 700;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1376, 716);
            this.splitContainerControl1.SplitterPosition = 1140;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // FrmParameterSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 756);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmParameterSetup";
            this.Text = "系统参数设置";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParameterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riiModifyType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meObjectList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbeModifyType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescribe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNameChn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        protected DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.GridControl gcParameterList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvParameterList;
        private DevExpress.XtraGrid.Columns.GridColumn gclName;
        private DevExpress.XtraGrid.Columns.GridColumn gclValue;
        private DevExpress.XtraGrid.Columns.GridColumn gclNameChn;
        private DevExpress.XtraGrid.Columns.GridColumn gclModifyType;
        private DevExpress.XtraGrid.Columns.GridColumn gclDescribe;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit meDescribe;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit teNameChn;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit teValue;
        private Base.UCBarButtonItemWithFP bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiCancel;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riiModifyType;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbeModifyType;
        private DevExpress.XtraEditors.MemoEdit meObjectList;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}