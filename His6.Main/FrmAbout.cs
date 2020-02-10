using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using His6.Base;
using His6.Resource;

namespace His6.Main
{
    /// <summary>
    /// 版本说明
    /// </summary>
    class FrmAbout : XtraForm
    {
        private LabelControl lblSystemName;
        private LabelControl label1;
        private PictureBox pictureBox1;
        private MemoEdit txtInfo;
        private List<string> FileList = new List<string>();
        private DevExpress.XtraTreeList.TreeList tlDllFile;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private PanelControl panelControl1;
        private PanelControl panelControl3;
        private LabelControl labelControl1;
        private SplitContainerControl splitContainerControl1;
        private PanelControl panelControl5;
        private PanelControl panelControl4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private IContainer components = null;

        public FrmAbout()
        {
            //
            // Windows 窗体设计器支持所必需的
            //

            //  TODO: 因为现在文件放在同一级目录下， tlDllFile 控件可改为 Grid

            InitializeComponent();            
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlDllFile = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txtInfo = new DevExpress.XtraEditors.MemoEdit();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tlDllFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlDllFile
            // 
            this.tlDllFile.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.tlDllFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlDllFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDllFile.ImageIndexFieldName = "IS_LEAF";
            this.tlDllFile.KeyFieldName = "CODE";
            this.tlDllFile.Location = new System.Drawing.Point(2, 2);
            this.tlDllFile.Name = "tlDllFile";
            this.tlDllFile.OptionsBehavior.Editable = false;
            this.tlDllFile.OptionsView.ShowIndicator = false;
            this.tlDllFile.ParentFieldName = "PARENT_CODE";
            this.tlDllFile.Size = new System.Drawing.Size(612, 466);
            this.tlDllFile.TabIndex = 26;
            this.tlDllFile.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlDllFile_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "程序集名称";
            this.treeListColumn1.FieldName = "NAME";
            this.treeListColumn1.MinWidth = 33;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 439;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "版本号";
            this.treeListColumn2.FieldName = "VERSION";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 175;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "更新时间";
            this.treeListColumn3.FieldName = "TIME";
            this.treeListColumn3.Format.FormatString = "yyyy-MM-dd HH:mm";
            this.treeListColumn3.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 229;
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(3, 3);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInfo.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Properties.Appearance.Options.UseBackColor = true;
            this.txtInfo.Properties.Appearance.Options.UseFont = true;
            this.txtInfo.Properties.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(294, 433);
            this.txtInfo.TabIndex = 23;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblSystemName.Appearance.Options.UseBackColor = true;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(386, 74);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(182, 14);
            this.lblSystemName.TabIndex = 0;
            this.lblSystemName.Text = "系统名称：万达HIS系统 V1.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(25, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("楷体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Appearance.Options.UseForeColor = true;
            this.label1.Location = new System.Drawing.Point(330, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "万达信息股份有限公司";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainerControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 127);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(937, 474);
            this.panelControl1.TabIndex = 27;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl5);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl4);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(933, 470);
            this.splitContainerControl1.SplitterPosition = 616;
            this.splitContainerControl1.TabIndex = 28;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.tlDllFile);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(616, 470);
            this.panelControl5.TabIndex = 27;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.tabControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(312, 470);
            this.panelControl4.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(308, 466);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(300, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "产品信息：";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.lblSystemName);
            this.panelControl3.Controls.Add(this.pictureBox1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(937, 127);
            this.panelControl3.TabIndex = 29;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(140, 102);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "已安装产品";
            // 
            // FrmAbout
            // 
            this.ClientSize = new System.Drawing.Size(937, 601);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "版本说明";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlDllFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        /// <summary>
        /// 封装文件信息表结构
        /// </summary>
        /// <returns></returns>
        private DataTable GetFileInfo()
        {
            DataTable dt = new DataTable("FileInfo");
            dt.Columns.Add("NAME");
            dt.Columns.Add("TIME", typeof(DateTime));
            dt.Columns.Add("VERSION");

            return dt;
        }

        /// <summary>
        /// 获取当前路径下面文件和文件夹信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        private void GetDirectoryFiles(DataTable dt)
        {
            string path = EnvInfo.RunPath;
            DirectoryInfo direInfo = new DirectoryInfo(path);
            foreach (FileInfo file in direInfo.GetFiles())
            {
                if (file.Name.StartsWith("Wonder."))
                {
                    if (file.Name.ToUpper().EndsWith(".EXE") || file.Name.ToUpper().EndsWith(".DLL"))
                    {
                        DataRow dr = dt.NewRow();
                        dr["NAME"] = file.Name;
                        Assembly asb = Assembly.LoadFile(path + "\\" + file.Name);
                        dr["TIME"] = File.GetLastWriteTime(path + "\\" + file.Name);
                        FileVersionInfo ver = FileVersionInfo.GetVersionInfo(path + "\\" + file.Name);
                        dr["VERSION"] = ver.FileVersion;
                        dt.Rows.Add(dr);
                    }
                }
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAbout_Load(object sender, System.EventArgs e)
        {
            try
            {
                //pictureBox1.Image = Properties.Resources.Wonders;
                this.pictureBox1.Image = ResourceHelper.GetFromResource("ICON64");
                this.Text = "关于";
                this.lblSystemName.Text = "万达HIS系统 版本：" + EnvInfo.Version;
                //  TODO: 

                //using (ISysConfig configService = ServiceFactory.CreateService<ISysConfig>(false))
                //{
                //    this.lblServiceTel.Text = configService.GetParameterValueWithAdd
                //        (SystemInfo.Environment.BranchCode, "SYS_KINGT_TELEPHONE", "400-658-2800", "服务电话", "C", "Y", "服务电话");
                //    this.lblServiceEmail.Text = configService.GetParameterValueWithAdd
                //        (SystemInfo.Environment.BranchCode, "SYS_KINGT_EMAIL", "kingtsoft@126.com", "公司Email", "C", "Y", "公司电子邮箱");
                //    this.llblLink.Text = configService.GetParameterValueWithAdd
                //        (SystemInfo.Environment.BranchCode, "SYS_KINGT_URL", "www.tomtawsoft.com", "公司网站", "C", "Y", "公司网站");
                //}
                DataTable dt = GetFileInfo();
                GetDirectoryFiles(dt);
                tlDllFile.DataSource = dt;
                tlDllFile.CollapseAll();
            }
            catch { }
        }

        /// <summary>
        /// 导出产口列表清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            tlDllFile.ExpandAll();
            TreeListHelper.ExportTo(tlDllFile, EnvInfo.RunPath);
            tlDllFile.CollapseAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// dll文件选择改变事件
        /// </summary>
        private void tlDllFile_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                var drv = tlDllFile.GetDataRecordByNode(tlDllFile.FocusedNode) as DataRowView;
                if (drv == null)
                {
                    this.txtInfo.Text = null;
                    return;
                }
                string file = EnvInfo.RunPath + Convert.ToString(drv["NAME"]);
                Assembly dll = Assembly.LoadFrom(file);
                object[] attributes = dll.GetCustomAttributes(false);
                string fileversion = "";
                string product = "";
                string copywrite = "";
                string title = "";
                foreach (object attribute in attributes)
                {
                    if (attribute.GetType().FullName == "System.Reflection.AssemblyFileVersionAttribute")
                    {
                        fileversion = ((System.Reflection.AssemblyFileVersionAttribute)attribute).Version;
                    }

                    if (attribute.GetType().FullName == "System.Reflection.AssemblyProductAttribute")
                    {
                        product = ((System.Reflection.AssemblyProductAttribute)attribute).Product;
                    }

                    if (attribute.GetType().FullName == "System.Reflection.AssemblyCopyrightAttribute")
                    {
                        copywrite = ((System.Reflection.AssemblyCopyrightAttribute)attribute).Copyright;
                    }

                    if (attribute.GetType().FullName == "System.Reflection.AssemblyTitleAttribute")
                    {
                        title = ((System.Reflection.AssemblyTitleAttribute)attribute).Title;
                    }
                }

                this.txtInfo.Text = "产品标题：" + title + "\r\n产品名称：" + product + "\r\n版 本 号：" + fileversion + "\r\n版权所有：" + copywrite;
            }
            catch
            {
                this.txtInfo.Text = null;
            }
        }

    }
}
