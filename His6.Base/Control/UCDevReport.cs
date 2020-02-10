using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace His6.Base
{
    /// <summary>
    ///  Dev报表展示对象
    /// </summary>
    public partial class UCDevReport : XtraUserControl
    {
        /// <summary>
        ///  报表显示对象
        /// </summary>
        protected XtraReport _Report = new XtraReport();

        /// <summary>
        ///  构造函数
        /// </summary>
        public UCDevReport()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  产生报表
        /// </summary>
        /// <param name="script">报表格式脚本</param>
        /// <returns></returns>
        public bool CreateReport(byte[] script)
        {
            bool ok = true;
            try
            {
                //  形成报表格式
                MemoryStream ms = new MemoryStream(script);
                this._Report = XtraReport.FromStream(ms, true);
                if (this._Report != null)
                {
                    this._Report.ShowPrintMarginsWarning = false;
                }
                ok = true;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("格式脚本不正确！\r\n" + ex.Message);
            }
            return ok;

        }

        /// <summary>
        ///  数据绑定
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="parameters">参数值</param>
        /// <returns></returns>
        public bool BindData(DataSet ds, Dictionary<string, object> parameters)
        {
            if (_Report == null)
            {
                return false;
            }
            bool ok = false;
            try
            {
                if (ds != null)
                {
                    this._Report.DataSource = ds;
                }
                this.printControl1.PrintingSystem = this._Report.PrintingSystem;

                if (parameters != null && parameters.Count > 0)
                {
                    for (int i = 0; i < this._Report.Parameters.Count; i++)
                    {
                        if (parameters.ContainsKey(_Report.Parameters[i].Name))
                        {
                            this._Report.Parameters[i].Value = parameters[_Report.Parameters[i].Name];
                            this._Report.Parameters[i].Visible = false;
                        }
                    }
                }

                this._Report.CreateDocument(true);

                ok = true;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("绑定数据出错!\r\n" + ex.Message);
                ok = false;
            }
            return ok;
        }

        /// <summary>
        ///  打印（有打印选择）
        /// </summary>
        public void Print()
        {
            this.printControl1.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Print);
        }

        /// <summary>
        ///  直接打印
        /// </summary>
        public void PrintDirect()
        {
            this.printControl1.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
        }
    }
}
