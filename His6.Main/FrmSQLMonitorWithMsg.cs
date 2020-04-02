using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using His6.Base;
using System.IO;

namespace His6.Main
{
    public partial class FrmSQLMonitorWithMsg : FrmWithRemoteInfoBase
    {
        const string _MonitorString = "SQLMON";

        public FrmSQLMonitorWithMsg()
        {
            InitializeComponent();
            dgvMonitor.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvMonitor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        }

        public override bool Init()
        {
            String header = _MonitorString + ":" + EnvInfo.ComputerCode;
            this._InfoCodeList.Add(header);
            HttpDataHelper.SetMonitorNode(header);
            return base.Init();
        }

        private void FrmSQLMonitorWithMsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            HttpDataHelper.SetMonitorNode("");
        }


        protected override void CallbackInfo(string infoCode, string infoBody)
        {
            SqlMonitorInfo mi = StringHelper.DeserializeObject<SqlMonitorInfo>(infoBody);

            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell tc1 = new DataGridViewTextBoxCell();
            tc1.Value = mi.Time;
            row.Cells.Add(tc1);
            DataGridViewTextBoxCell tc2 = new DataGridViewTextBoxCell();
            tc2.Value = mi.ExecuteSql;
            row.Cells.Add(tc2);
            DataGridViewTextBoxCell tc3 = new DataGridViewTextBoxCell();
            tc3.Value = mi.ExecuteSql;
            string ps = "";
            if (mi.Parameters != null && mi.Parameters.Count > 0)
            {
                int i = 1;
                foreach (string s in mi.Parameters)
                {
                    ps += ":" + i + "=" + s;
                    if (i != mi.Parameters.Count)
                    {
                        ps += "\r\n";
                    }
                    i++;
                }
            }
            else
            {
                ps = "(空)";
            }
            tc3.Value = ps;
            row.Cells.Add(tc3);
            DataGridViewTextBoxCell tc4 = new DataGridViewTextBoxCell();
            tc4.Value = mi.Duration;
            row.Cells.Add(tc4);

            dgvMonitor.Rows.Add(row);
            dgvMonitor.AutoResizeColumns();
            //加到显示列表
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvMonitor.Rows.Clear();
        }

        private void ExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文本文件(*.TXT)|*.txt";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;            
            saveFileDialog.Title = "导出SQL监视";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName == "")
                {
                    return;
                }

                Stream myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string[] str = new string[] { "时间：", "SQL语句：", "参数：", "耗时（毫秒）："};
                try
                {
                    //for (int i = 0; i < dgvMonitor.ColumnCount; i++)
                    //{
                    //    str += dgvMonitor.Columns[i].HeaderText;
                    //    str += "\t";
                    //}
                    //sw.WriteLine(str);
                    for (int j = 0; j < dgvMonitor.Rows.Count - 1; j++)
                    {
                        string strTemp = "";                        
                        for (int k = 0; k < dgvMonitor.Columns.Count; k++)
                        {
                            strTemp += str[k];
                            if(k % 3 != 0) strTemp += "\r\n";
                            object obj = dgvMonitor.Rows[j].Cells[k].Value;
                            if (obj != null)
                            {
                                strTemp += dgvMonitor.Rows[j].Cells[k].Value.ToString();
                            }
                            strTemp += "\r\n";
                        }                        
                        sw.WriteLine(strTemp);
                    }
                    sw.Close();
                    myStream.Close();
                    MessageBox.Show("成功导出文件：\n" + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
            
            
        }

    }
}
