namespace His6.SysSetup
{
    partial class FrmObjectAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObjectAdd));
            this.gcObject = new DevExpress.XtraGrid.GridControl();
            this.gvObject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclUsedFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riFlag = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gclCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclIsFunction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclIsFP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDescribe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcObject
            // 
            this.gcObject.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.gcObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcObject.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gcObject.Location = new System.Drawing.Point(0, 0);
            this.gcObject.MainView = this.gvObject;
            this.gcObject.Margin = new System.Windows.Forms.Padding(2);
            this.gcObject.Name = "gcObject";
            this.gcObject.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riFlag});
            this.gcObject.Size = new System.Drawing.Size(865, 350);
            this.gcObject.TabIndex = 6;
            this.gcObject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvObject});
            // 
            // gvObject
            // 
            this.gvObject.ColumnPanelRowHeight = 0;
            this.gvObject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclUsedFlag,
            this.gclCode,
            this.gclName,
            this.gclObject,
            this.gclIsFunction,
            this.gclIsFP,
            this.gclDescribe});
            this.gvObject.DetailHeight = 204;
            this.gvObject.FixedLineWidth = 1;
            this.gvObject.FooterPanelHeight = 0;
            this.gvObject.GridControl = this.gcObject;
            this.gvObject.GroupRowHeight = 0;
            this.gvObject.Name = "gvObject";
            this.gvObject.OptionsDetail.AllowZoomDetail = false;
            this.gvObject.OptionsDetail.ShowDetailTabs = false;
            this.gvObject.OptionsDetail.SmartDetailExpand = false;
            this.gvObject.OptionsView.EnableAppearanceEvenRow = true;
            this.gvObject.OptionsView.EnableAppearanceOddRow = true;
            this.gvObject.OptionsView.ShowGroupPanel = false;
            this.gvObject.OptionsView.ShowIndicator = false;
            this.gvObject.RowHeight = 0;
            this.gvObject.ViewCaptionHeight = 0;
            // 
            // gclUsedFlag
            // 
            this.gclUsedFlag.AppearanceHeader.Options.UseTextOptions = true;
            this.gclUsedFlag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclUsedFlag.Caption = "启用";
            this.gclUsedFlag.ColumnEdit = this.riFlag;
            this.gclUsedFlag.FieldName = "UsedFlag";
            this.gclUsedFlag.MaxWidth = 47;
            this.gclUsedFlag.MinWidth = 29;
            this.gclUsedFlag.Name = "gclUsedFlag";
            this.gclUsedFlag.Visible = true;
            this.gclUsedFlag.VisibleIndex = 0;
            this.gclUsedFlag.Width = 41;
            // 
            // riFlag
            // 
            this.riFlag.AutoHeight = false;
            this.riFlag.Name = "riFlag";
            this.riFlag.ValueChecked = "1";
            this.riFlag.ValueUnchecked = "0";
            // 
            // gclCode
            // 
            this.gclCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclCode.Caption = "代码";
            this.gclCode.FieldName = "Code";
            this.gclCode.MinWidth = 12;
            this.gclCode.Name = "gclCode";
            this.gclCode.OptionsColumn.AllowEdit = false;
            this.gclCode.Visible = true;
            this.gclCode.VisibleIndex = 1;
            this.gclCode.Width = 108;
            // 
            // gclName
            // 
            this.gclName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclName.Caption = "功能名称";
            this.gclName.FieldName = "Name";
            this.gclName.MinWidth = 12;
            this.gclName.Name = "gclName";
            this.gclName.Visible = true;
            this.gclName.VisibleIndex = 2;
            this.gclName.Width = 158;
            // 
            // gclObject
            // 
            this.gclObject.AppearanceHeader.Options.UseTextOptions = true;
            this.gclObject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclObject.Caption = "目标名称";
            this.gclObject.FieldName = "Object";
            this.gclObject.MinWidth = 12;
            this.gclObject.Name = "gclObject";
            this.gclObject.OptionsColumn.AllowEdit = false;
            this.gclObject.Visible = true;
            this.gclObject.VisibleIndex = 3;
            this.gclObject.Width = 226;
            // 
            // gclIsFunction
            // 
            this.gclIsFunction.AppearanceHeader.Options.UseTextOptions = true;
            this.gclIsFunction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclIsFunction.Caption = "功能";
            this.gclIsFunction.ColumnEdit = this.riFlag;
            this.gclIsFunction.FieldName = "IsFunction";
            this.gclIsFunction.MaxWidth = 47;
            this.gclIsFunction.MinWidth = 29;
            this.gclIsFunction.Name = "gclIsFunction";
            this.gclIsFunction.OptionsColumn.ReadOnly = true;
            this.gclIsFunction.Visible = true;
            this.gclIsFunction.VisibleIndex = 4;
            this.gclIsFunction.Width = 36;
            // 
            // gclIsFP
            // 
            this.gclIsFP.Caption = "功能点";
            this.gclIsFP.ColumnEdit = this.riFlag;
            this.gclIsFP.FieldName = "IsFunctionPoint";
            this.gclIsFP.MaxWidth = 58;
            this.gclIsFP.MinWidth = 29;
            this.gclIsFP.Name = "gclIsFP";
            this.gclIsFP.OptionsColumn.ReadOnly = true;
            this.gclIsFP.Visible = true;
            this.gclIsFP.VisibleIndex = 5;
            this.gclIsFP.Width = 47;
            // 
            // gclDescribe
            // 
            this.gclDescribe.AppearanceHeader.Options.UseTextOptions = true;
            this.gclDescribe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclDescribe.Caption = "备注";
            this.gclDescribe.FieldName = "Describe";
            this.gclDescribe.MinWidth = 12;
            this.gclDescribe.Name = "gclDescribe";
            this.gclDescribe.Visible = true;
            this.gclDescribe.VisibleIndex = 6;
            this.gclDescribe.Width = 289;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnExit.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Appearance.Options.UseBorderColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.Location = new System.Drawing.Point(631, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 39);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "取消(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnOk.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Appearance.Options.UseBorderColor = true;
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(504, 8);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 39);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 292);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(865, 58);
            this.panelControl1.TabIndex = 9;
            // 
            // FrmObjectAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 350);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcObject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmObjectAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "对象加入";
            ((System.ComponentModel.ISupportInitialize)(this.gcObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcObject;
        private DevExpress.XtraGrid.Columns.GridColumn gclUsedFlag;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riFlag;
        private DevExpress.XtraGrid.Columns.GridColumn gclCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclName;
        private DevExpress.XtraGrid.Columns.GridColumn gclObject;
        private DevExpress.XtraGrid.Columns.GridColumn gclIsFunction;
        private DevExpress.XtraGrid.Columns.GridColumn gclDescribe;
        private DevExpress.XtraGrid.Columns.GridColumn gclIsFP;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvObject;
    }
}