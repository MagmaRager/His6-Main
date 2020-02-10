namespace His6.Main
{
    partial class FrmSqlMonitor
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
            this.teSqlHeader = new DevExpress.XtraEditors.TextEdit();
            this.btnSwitch = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gcOutput = new DevExpress.XtraGrid.GridControl();
            this.gvOutput = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclSql = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclParams = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.teSqlHeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // teSqlHeader
            // 
            this.teSqlHeader.EditValue = "";
            this.teSqlHeader.Location = new System.Drawing.Point(109, 27);
            this.teSqlHeader.Name = "teSqlHeader";
            this.teSqlHeader.Properties.MaxLength = 20;
            this.teSqlHeader.Properties.NullText = "例如：DEBUG_SQL";
            this.teSqlHeader.Size = new System.Drawing.Size(237, 20);
            this.teSqlHeader.TabIndex = 1;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(416, 26);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(75, 23);
            this.btnSwitch.TabIndex = 2;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(533, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gcOutput
            // 
            this.gcOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOutput.Location = new System.Drawing.Point(0, 69);
            this.gcOutput.MainView = this.gvOutput;
            this.gcOutput.Name = "gcOutput";
            this.gcOutput.Size = new System.Drawing.Size(642, 287);
            this.gcOutput.TabIndex = 4;
            this.gcOutput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutput});
            // 
            // gvOutput
            // 
            this.gvOutput.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclTime,
            this.gclSql,
            this.gclParams,
            this.gclDuration});
            this.gvOutput.GridControl = this.gcOutput;
            this.gvOutput.Name = "gvOutput";
            this.gvOutput.OptionsView.ShowGroupPanel = false;
            // 
            // gclTime
            // 
            this.gclTime.Caption = "执行时间";
            this.gclTime.FieldName = "TimeStr";
            this.gclTime.Name = "gclTime";
            this.gclTime.OptionsColumn.AllowEdit = false;
            this.gclTime.OptionsColumn.ReadOnly = true;
            this.gclTime.Visible = true;
            this.gclTime.VisibleIndex = 0;
            // 
            // gclSql
            // 
            this.gclSql.Caption = "SQL语句";
            this.gclSql.FieldName = "ExecuteSql";
            this.gclSql.Name = "gclSql";
            this.gclSql.OptionsColumn.AllowEdit = false;
            this.gclSql.OptionsColumn.ReadOnly = true;
            this.gclSql.Visible = true;
            this.gclSql.VisibleIndex = 1;
            this.gclSql.Width = 347;
            // 
            // gclParams
            // 
            this.gclParams.Caption = "参数";
            this.gclParams.FieldName = "ParameterList";
            this.gclParams.Name = "gclParams";
            this.gclParams.OptionsColumn.AllowEdit = false;
            this.gclParams.OptionsColumn.ReadOnly = true;
            this.gclParams.Visible = true;
            this.gclParams.VisibleIndex = 2;
            this.gclParams.Width = 73;
            // 
            // gclDuration
            // 
            this.gclDuration.Caption = "运行时长（毫秒）";
            this.gclDuration.FieldName = "Duration";
            this.gclDuration.Name = "gclDuration";
            this.gclDuration.OptionsColumn.AllowEdit = false;
            this.gclDuration.OptionsColumn.ReadOnly = true;
            this.gclDuration.Visible = true;
            this.gclDuration.VisibleIndex = 3;
            this.gclDuration.Width = 129;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.teSqlHeader);
            this.panelControl1.Controls.Add(this.btnSwitch);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(642, 69);
            this.panelControl1.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "SQL请求头：";
            // 
            // FrmSqlMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 356);
            this.Controls.Add(this.gcOutput);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSqlMonitor";
            this.Text = "SQL监视";
            ((System.ComponentModel.ISupportInitialize)(this.teSqlHeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit teSqlHeader;
        private DevExpress.XtraEditors.SimpleButton btnSwitch;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcOutput;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutput;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gclTime;
        private DevExpress.XtraGrid.Columns.GridColumn gclSql;
        private DevExpress.XtraGrid.Columns.GridColumn gclParams;
        private DevExpress.XtraGrid.Columns.GridColumn gclDuration;
    }
}