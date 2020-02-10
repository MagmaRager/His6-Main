namespace His6.SysSetup
{
    partial class FrmSelectRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectRole));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcFrom = new DevExpress.XtraGrid.GridControl();
            this.gvFrom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode_From = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName_From = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInputcode1_From = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInputcode2_From = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTo = new DevExpress.XtraGrid.GridControl();
            this.gvTo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode_To = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName_To = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInputcode1_To = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInputcode2_To = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnOk.Appearance.Options.UseBorderColor = true;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(833, 27);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(180, 70);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnDel);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(111, 796);
            this.panelControl2.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.ImageOptions.Image")));
            this.btnDel.Location = new System.Drawing.Point(27, 444);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(51, 46);
            this.btnDel.TabIndex = 1;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(27, 201);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 46);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcFrom);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcTo);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1395, 796);
            this.splitContainerControl1.SplitterPosition = 629;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcFrom
            // 
            this.gcFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFrom.Location = new System.Drawing.Point(0, 0);
            this.gcFrom.MainView = this.gvFrom;
            this.gcFrom.Name = "gcFrom";
            this.gcFrom.Size = new System.Drawing.Size(629, 796);
            this.gcFrom.TabIndex = 19;
            this.gcFrom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFrom});
            // 
            // gvFrom
            // 
            this.gvFrom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode_From,
            this.gcName_From,
            this.gcInputcode1_From,
            this.gcInputcode2_From});
            this.gvFrom.GridControl = this.gcFrom;
            this.gvFrom.GroupPanelText = "可选择的角色";
            this.gvFrom.Name = "gvFrom";
            this.gvFrom.OptionsBehavior.Editable = false;
            this.gvFrom.OptionsCustomization.AllowGroup = false;
            this.gvFrom.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvFrom.OptionsSelection.MultiSelect = true;
            this.gvFrom.OptionsView.ColumnAutoWidth = false;
            this.gvFrom.OptionsView.EnableAppearanceEvenRow = true;
            this.gvFrom.OptionsView.EnableAppearanceOddRow = true;
            this.gvFrom.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvFrom.OptionsView.ShowIndicator = false;
            this.gvFrom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvFrom_MouseDown);
            // 
            // gcCode_From
            // 
            this.gcCode_From.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCode_From.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCode_From.Caption = "代码";
            this.gcCode_From.FieldName = "Code";
            this.gcCode_From.Name = "gcCode_From";
            this.gcCode_From.Visible = true;
            this.gcCode_From.VisibleIndex = 0;
            this.gcCode_From.Width = 103;
            // 
            // gcName_From
            // 
            this.gcName_From.AppearanceHeader.Options.UseTextOptions = true;
            this.gcName_From.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName_From.Caption = "角色名称";
            this.gcName_From.FieldName = "Name";
            this.gcName_From.Name = "gcName_From";
            this.gcName_From.Visible = true;
            this.gcName_From.VisibleIndex = 1;
            this.gcName_From.Width = 287;
            // 
            // gcInputcode1_From
            // 
            this.gcInputcode1_From.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInputcode1_From.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInputcode1_From.Caption = "辅码1";
            this.gcInputcode1_From.FieldName = "Inputcode1";
            this.gcInputcode1_From.Name = "gcInputcode1_From";
            this.gcInputcode1_From.Visible = true;
            this.gcInputcode1_From.VisibleIndex = 2;
            this.gcInputcode1_From.Width = 85;
            // 
            // gcInputcode2_From
            // 
            this.gcInputcode2_From.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInputcode2_From.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInputcode2_From.Caption = "辅码2";
            this.gcInputcode2_From.FieldName = "Inputcode2";
            this.gcInputcode2_From.Name = "gcInputcode2_From";
            this.gcInputcode2_From.Visible = true;
            this.gcInputcode2_From.VisibleIndex = 3;
            this.gcInputcode2_From.Width = 96;
            // 
            // gcTo
            // 
            this.gcTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTo.Location = new System.Drawing.Point(111, 0);
            this.gcTo.MainView = this.gvTo;
            this.gcTo.Name = "gcTo";
            this.gcTo.Size = new System.Drawing.Size(645, 796);
            this.gcTo.TabIndex = 19;
            this.gcTo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTo});
            // 
            // gvTo
            // 
            this.gvTo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode_To,
            this.gcName_To,
            this.gcInputcode1_To,
            this.gcInputcode2_To});
            this.gvTo.GridControl = this.gcTo;
            this.gvTo.GroupPanelText = "已选择的角色";
            this.gvTo.Name = "gvTo";
            this.gvTo.OptionsBehavior.Editable = false;
            this.gvTo.OptionsCustomization.AllowGroup = false;
            this.gvTo.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvTo.OptionsSelection.MultiSelect = true;
            this.gvTo.OptionsView.ColumnAutoWidth = false;
            this.gvTo.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTo.OptionsView.EnableAppearanceOddRow = true;
            this.gvTo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvTo.OptionsView.ShowIndicator = false;
            this.gvTo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvTo_MouseDown);
            // 
            // gcCode_To
            // 
            this.gcCode_To.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCode_To.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCode_To.Caption = "代码";
            this.gcCode_To.FieldName = "Code";
            this.gcCode_To.Name = "gcCode_To";
            this.gcCode_To.Visible = true;
            this.gcCode_To.VisibleIndex = 0;
            this.gcCode_To.Width = 123;
            // 
            // gcName_To
            // 
            this.gcName_To.AppearanceHeader.Options.UseTextOptions = true;
            this.gcName_To.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName_To.Caption = "角色名称";
            this.gcName_To.FieldName = "Name";
            this.gcName_To.Name = "gcName_To";
            this.gcName_To.Visible = true;
            this.gcName_To.VisibleIndex = 1;
            this.gcName_To.Width = 236;
            // 
            // gcInputcode1_To
            // 
            this.gcInputcode1_To.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInputcode1_To.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInputcode1_To.Caption = "辅码1";
            this.gcInputcode1_To.FieldName = "Inputcode1";
            this.gcInputcode1_To.Name = "gcInputcode1_To";
            this.gcInputcode1_To.Visible = true;
            this.gcInputcode1_To.VisibleIndex = 2;
            this.gcInputcode1_To.Width = 102;
            // 
            // gcInputcode2_To
            // 
            this.gcInputcode2_To.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInputcode2_To.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInputcode2_To.Caption = "辅码2";
            this.gcInputcode2_To.FieldName = "Inputcode2";
            this.gcInputcode2_To.Name = "gcInputcode2_To";
            this.gcInputcode2_To.Visible = true;
            this.gcInputcode2_To.VisibleIndex = 3;
            this.gcInputcode2_To.Width = 93;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 796);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1395, 129);
            this.panelControl1.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1119, 27);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 70);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "取消";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmSelectRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 925);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSelectRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色选择";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraGrid.GridControl gcFrom;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode_From;
        private DevExpress.XtraGrid.Columns.GridColumn gcName_From;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputcode1_From;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputcode2_From;
        private DevExpress.XtraGrid.GridControl gcTo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTo;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode_To;
        private DevExpress.XtraGrid.Columns.GridColumn gcName_To;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputcode1_To;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputcode2_To;
    }
}