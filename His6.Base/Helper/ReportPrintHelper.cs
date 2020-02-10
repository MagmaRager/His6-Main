
using DevExpress.XtraReports.UI;

using System;
using System.IO;

namespace His6.Base
{
        /// <summary>
        /// 报表处理类
        /// </summary>
        public static class ReportPrintHelper
        {
            #region 形成报表格式
            /// <summary>
            ///  产生Dev报表格式
            /// </summary>
            /// <param name="rpt_control">报表控件对象</param>
            /// <param name="script">格式脚本</param>
            /// <returns>是否成功</returns>
            public static bool CreateXtraReport(ref XtraReport rpt_control, byte[] script)
            {
                bool ok = false;

                try
                {
                    //  形成报表格式
                    MemoryStream ms = new MemoryStream(script);
                    rpt_control = XtraReport.FromStream(ms, true);
                    if (rpt_control != null)
                    {
                        rpt_control.ShowPrintMarginsWarning = false;
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
            /// 把report转为byte[]
            /// </summary>
            /// <param name="report">打开的报表</param>
            /// <returns>返回的byte[]</returns>
            public static byte[] GetBuffer(XtraReport report)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    report.SaveLayout(stream);
                    return stream.ToArray();
                }
            }

        /*
            /// <summary>
            /// 从机器参数表中获取打印机名称
            /// </summary>
            /// <param name="useCode"></param>
            /// <param name="computerCode"></param>
            /// <returns></returns>
            public static string GetPrinter(string useCode, string computerCode)
            {
                var printer = string.Empty;
                var printerXml = ServiceFactory.CreateService<ISysConfig>().
                    GetComputerParameterValue(computerCode, WinParameterHelper.SYS_REPORT_PRINTER);
                if (string.IsNullOrEmpty(printerXml) || printerXml == "[]")
                {
                    return string.Empty;
                }
                var dt = ToDataTable(printerXml);
                if (dt.Rows.Count > 0 && dt.Columns.Contains("REPORT_CLASS"))
                {
                    var drs = dt.Select(string.Format("REPORT_CLASS = '{0}'", useCode));
                    if (drs.Length > 0)
                    {
                        printer = Convert.ToString(drs[0]["PRINTER"]);
                    }
                }
                return printer;
            }

            /// <summary>
            /// 从报表格式使用表中获取打印机名称
            /// </summary>
            /// <param name="useCode"></param>
            /// <param name="computerCode"></param>
            /// <param name="sourceType"></param>
            /// <returns></returns>
            public static string GetPrinter(string useCode, int sourceType, string computerCode)
            {
                EntitySysReportUseComputer reportUseCom = ServiceFactory.CreateService<ISysReport>().
                    GetReporUseOfComputerItem(computerCode, useCode, sourceType);
                if (reportUseCom == null)
                {
                    return string.Empty;
                }
                return reportUseCom.PrinterName;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string ToJson(DataTable dt)
            {
                var javaScriptSerializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
                var arrayList = new ArrayList();
                foreach (var dictionary in from DataRow dataRow in dt.Rows
                                           select dt.Columns.Cast<DataColumn>()
                                                    .ToDictionary<DataColumn, string, object>(
                                                        dataColumn => dataColumn.ColumnName,
                                                        dataColumn => ToStr(dataRow[dataColumn.ColumnName])))
                {
                    arrayList.Add(dictionary); //ArrayList集合中添加键值
                }

                return javaScriptSerializer.Serialize(arrayList); //返回一个json字符串
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="s"></param>
            /// <param name="format"></param>
            /// <returns></returns>
            public static string ToStr(object s, string format = "")
            {
                string result;
                try
                {
                    result = format == "" ? s.ToString() : string.Format("{0:" + format + "}", s);
                }
                catch
                {
                    return string.Empty;
                }
                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="json"></param>
            /// <returns></returns>
            public static DataTable ToDataTable(string json)
            {
                var dataTable = new DataTable();  //实例化
                DataTable result;
                try
                {
                    var javaScriptSerializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
                    var arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                    if (arrayList.Count > 0)
                    {
                        foreach (Dictionary<string, object> dictionary in arrayList)
                        {
                            if (!dictionary.Keys.Any())
                            {
                                result = dataTable;
                                return result;
                            }
                            if (dataTable.Columns.Count == 0)
                            {
                                foreach (string current in dictionary.Keys)
                                {
                                    dataTable.Columns.Add(current, dictionary[current].GetType());
                                }
                            }
                            var dataRow = dataTable.NewRow();
                            foreach (var current in dictionary.Keys)
                            {
                                dataRow[current] = dictionary[current];
                            }

                            dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                        }
                    }
                }
                catch
                {
                    return new DataTable();
                }
                result = dataTable;
                return result;
            }
            */
            #endregion
        }
    }
