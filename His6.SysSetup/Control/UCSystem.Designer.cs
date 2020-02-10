namespace His6.SysSetup
{
    partial class UCSystem
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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtIco = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcRole = new DevExpress.XtraGrid.GridControl();
            this.gvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclRoleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmp = new DevExpress.XtraGrid.GridControl();
            this.gvEmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilueDeptFrom = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueDeptFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(86, 29);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.NullValuePrompt = "<不可为空>";
            this.txtCode.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtCode.Size = new System.Drawing.Size(138, 20);
            this.txtCode.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 61);
            this.txtName.Name = "txtName";
            this.txtName.Properties.NullValuePrompt = "<不可为空>";
            this.txtName.Size = new System.Drawing.Size(328, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtIco
            // 
            this.txtIco.Location = new System.Drawing.Point(86, 98);
            this.txtIco.Name = "txtIco";
            this.txtIco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIco.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtIco_Properties_ButtonClick);
            this.txtIco.Size = new System.Drawing.Size(211, 20);
            this.txtIco.TabIndex = 21;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(43, 32);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 56;
            this.labelControl1.Text = "代码：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(43, 64);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 57;
            this.labelControl2.Text = "名称：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(43, 101);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 61;
            this.labelControl3.Text = "图标：";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtCode);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtIco);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(538, 127);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "系统信息";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 127);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcRole);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcEmp);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(538, 287);
            this.splitContainerControl1.SplitterPosition = 274;
            this.splitContainerControl1.TabIndex = 62;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcRole
            // 
            this.gcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRole.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcRole.Location = new System.Drawing.Point(0, 0);
            this.gcRole.MainView = this.gvRole;
            this.gcRole.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcRole.Name = "gcRole";
            this.gcRole.Size = new System.Drawing.Size(274, 287);
            this.gcRole.TabIndex = 20;
            this.gcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRole});
            // 
            // gvRole
            // 
            this.gvRole.ColumnPanelRowHeight = 0;
            this.gvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclRoleCode,
            this.gclRoleName});
            this.gvRole.DetailHeight = 169;
            this.gvRole.FixedLineWidth = 1;
            this.gvRole.FooterPanelHeight = 0;
            this.gvRole.GridControl = this.gcRole;
            this.gvRole.GroupPanelText = "可使用的角色";
            this.gvRole.GroupRowHeight = 0;
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
            this.gvRole.RowHeight = 0;
            this.gvRole.ViewCaptionHeight = 0;
            this.gvRole.DoubleClick += new System.EventHandler(this.gvRole_DoubleClick);
            // 
            // gclRoleCode
            // 
            this.gclRoleCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclRoleCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclRoleCode.Caption = "代码";
            this.gclRoleCode.FieldName = "Code";
            this.gclRoleCode.MinWidth = 11;
            this.gclRoleCode.Name = "gclRoleCode";
            this.gclRoleCode.Visible = true;
            this.gclRoleCode.VisibleIndex = 0;
            this.gclRoleCode.Width = 67;
            // 
            // gclRoleName
            // 
            this.gclRoleName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclRoleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclRoleName.Caption = "角色名称";
            this.gclRoleName.FieldName = "Name";
            this.gclRoleName.MinWidth = 11;
            this.gclRoleName.Name = "gclRoleName";
            this.gclRoleName.Visible = true;
            this.gclRoleName.VisibleIndex = 1;
            this.gclRoleName.Width = 134;
            // 
            // gcEmp
            // 
            this.gcEmp.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEmp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcEmp.Location = new System.Drawing.Point(0, 0);
            this.gcEmp.MainView = this.gvEmp;
            this.gcEmp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gcEmp.Name = "gcEmp";
            this.gcEmp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rilueDeptFrom});
            this.gcEmp.Size = new System.Drawing.Size(259, 287);
            this.gcEmp.TabIndex = 19;
            this.gcEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmp});
            // 
            // gvEmp
            // 
            this.gvEmp.ColumnPanelRowHeight = 0;
            this.gvEmp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclEmpCode,
            this.gclEmpName});
            this.gvEmp.DetailHeight = 169;
            this.gvEmp.FixedLineWidth = 1;
            this.gvEmp.FooterPanelHeight = 0;
            this.gvEmp.GridControl = this.gcEmp;
            this.gvEmp.GroupPanelText = "可使用的职工";
            this.gvEmp.GroupRowHeight = 0;
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
            this.gvEmp.RowHeight = 0;
            this.gvEmp.ViewCaptionHeight = 0;
            this.gvEmp.DoubleClick += new System.EventHandler(this.gvEmp_DoubleClick);
            // 
            // gclEmpCode
            // 
            this.gclEmpCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gclEmpCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclEmpCode.Caption = "工号";
            this.gclEmpCode.FieldName = "Code";
            this.gclEmpCode.MinWidth = 11;
            this.gclEmpCode.Name = "gclEmpCode";
            this.gclEmpCode.Visible = true;
            this.gclEmpCode.VisibleIndex = 0;
            this.gclEmpCode.Width = 62;
            // 
            // gclEmpName
            // 
            this.gclEmpName.AppearanceHeader.Options.UseTextOptions = true;
            this.gclEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gclEmpName.Caption = "姓名";
            this.gclEmpName.FieldName = "Name";
            this.gclEmpName.MinWidth = 11;
            this.gclEmpName.Name = "gclEmpName";
            this.gclEmpName.Visible = true;
            this.gclEmpName.VisibleIndex = 1;
            this.gclEmpName.Width = 111;
            // 
            // rilueDeptFrom
            // 
            this.rilueDeptFrom.AutoHeight = false;
            this.rilueDeptFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rilueDeptFrom.DisplayMember = "NAME";
            this.rilueDeptFrom.Name = "rilueDeptFrom";
            this.rilueDeptFrom.ValueMember = "ID";
            // 
            // UCSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCSystem";
            this.Size = new System.Drawing.Size(538, 414);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilueDeptFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ButtonEdit txtIco;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmp;
        private DevExpress.XtraGrid.Columns.GridColumn gclEmpCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclEmpName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rilueDeptFrom;
        private DevExpress.XtraGrid.GridControl gcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRole;
        private DevExpress.XtraGrid.Columns.GridColumn gclRoleCode;
        private DevExpress.XtraGrid.Columns.GridColumn gclRoleName;
    }
}
