namespace His6.Main
{
    partial class FrmMenuDefault
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlSysMenu = new DevExpress.XtraTreeList.TreeList();
            this.tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tlSysMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlSysMenu
            // 
            this.tlSysMenu.AllowDrop = true;
            this.tlSysMenu.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue;
            this.tlSysMenu.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.tlSysMenu.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tlSysMenu.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tlSysMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcCode,
            this.tlcName});
            this.tlSysMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlSysMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlSysMenu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlSysMenu.KeyFieldName = "";
            this.tlSysMenu.Location = new System.Drawing.Point(0, 0);
            this.tlSysMenu.MinWidth = 18;
            this.tlSysMenu.Name = "tlSysMenu";
            this.tlSysMenu.OptionsBehavior.Editable = false;
            this.tlSysMenu.OptionsBehavior.PopulateServiceColumns = true;
            this.tlSysMenu.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.tlSysMenu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tlSysMenu.OptionsView.EnableAppearanceEvenRow = true;
            this.tlSysMenu.OptionsView.EnableAppearanceOddRow = true;
            this.tlSysMenu.OptionsView.ShowIndicator = false;
            this.tlSysMenu.ParentFieldName = "";
            this.tlSysMenu.RootValue = "";
            this.tlSysMenu.Size = new System.Drawing.Size(344, 338);
            this.tlSysMenu.TabIndex = 0;
            this.tlSysMenu.TreeLevelWidth = 16;
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
            // FrmMenuDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 412);
            this.ControlBox = false;
            this.Controls.Add(this.tlSysMenu);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMenuDefault";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统默认菜单设置";
            ((System.ComponentModel.ISupportInitialize)(this.tlSysMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraTreeList.TreeList tlSysMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
    }
}