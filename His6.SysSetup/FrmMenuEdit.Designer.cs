namespace His6.SysSetup
{
    partial class FrmMenuEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuEdit));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEmp = new DevExpress.XtraEditors.SimpleButton();
            this.btnRole = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucMenu1 = new His6.SysSetup.UCMenu();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnEmp);
            this.panelControl1.Controls.Add(this.btnRole);
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(179, 508);
            this.panelControl1.TabIndex = 5;
            // 
            // btnEmp
            // 
            this.btnEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmp.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnEmp.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEmp.Appearance.Options.UseBorderColor = true;
            this.btnEmp.Appearance.Options.UseFont = true;
            this.btnEmp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmp.ImageOptions.Image")));
            this.btnEmp.Location = new System.Drawing.Point(18, 298);
            this.btnEmp.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(143, 32);
            this.btnEmp.TabIndex = 12;
            this.btnEmp.Text = "人员选择";
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
            // 
            // btnRole
            // 
            this.btnRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRole.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnRole.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRole.Appearance.Options.UseBorderColor = true;
            this.btnRole.Appearance.Options.UseFont = true;
            this.btnRole.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRole.ImageOptions.Image")));
            this.btnRole.Location = new System.Drawing.Point(18, 237);
            this.btnRole.Margin = new System.Windows.Forms.Padding(2);
            this.btnRole.Name = "btnRole";
            this.btnRole.Size = new System.Drawing.Size(143, 32);
            this.btnRole.TabIndex = 11;
            this.btnRole.Text = "角色选择";
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnExit.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Appearance.Options.UseBorderColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.Location = new System.Drawing.Point(18, 138);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(143, 32);
            this.btnExit.TabIndex = 10;
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
            this.btnOk.Location = new System.Drawing.Point(18, 78);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(143, 32);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucMenu1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(826, 508);
            this.splitContainerControl1.SplitterPosition = 642;
            this.splitContainerControl1.TabIndex = 7;
            // 
            // ucMenu1
            // 
            this.ucMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMenu1.EmpList = null;
            this.ucMenu1.Location = new System.Drawing.Point(0, 0);
            this.ucMenu1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucMenu1.ModuleList = null;
            this.ucMenu1.Name = "ucMenu1";
            this.ucMenu1.ObjectList = null;
            this.ucMenu1.RoleList = null;
            this.ucMenu1.Size = new System.Drawing.Size(642, 508);
            this.ucMenu1.TabIndex = 6;
            // 
            // FrmMenuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 508);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMenuEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单修改";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private UCMenu ucMenu1;
        private DevExpress.XtraEditors.SimpleButton btnEmp;
        private DevExpress.XtraEditors.SimpleButton btnRole;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}