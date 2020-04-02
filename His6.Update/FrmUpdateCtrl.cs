using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;
using System.Diagnostics;

namespace His6.Update
{
    public partial class FrmUpdateCtrl : Form
    {
        private string Ip;
        private string Mac;
        private string ComputerName;

        private string Path;

        private bool stayFinish;

        public FrmUpdateCtrl()
        {
            InitializeComponent();
            this.btnExit.Enabled = false;
        }

        private void FrmUpdateCtrl_Shown(object sender, EventArgs e)
        {
            stayFinish = ConfigurationManager.AppSettings.Get("AutoExit") == "0";

            this.lbInfo.Items.Add("正在获取机器信息......");
            GetMacAddress();
            string nodeSuffix = ConfigurationManager.AppSettings.Get("NodeSuffix");
            if(!String.IsNullOrEmpty(nodeSuffix))
            {
                Mac += "-" + nodeSuffix;
            }            

            this.lbInfo.Items.Add("正在获取本地文件信息......");
            Path = ConfigurationManager.AppSettings.Get("Path");
            this.Text += "——" + Path;
            List<FInfo> lf = GetFilesFromPath(Path, Path.Length);

            GetFile(lf);
        }
        

        private void GetMacAddress()
        {
            ComputerName = SystemInformation.ComputerName;
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        Array array = (Array)mo.Properties["IpAddress"].Value;
                        Ip = array.GetValue(0).ToString();
                        Mac = mo["MacAddress"].ToString();
                        Mac = Mac.Substring(0, 2) + Mac.Substring(3, 2) + Mac.Substring(6, 2) +
                            Mac.Substring(9, 2) + Mac.Substring(12, 2) + Mac.Substring(15, 2);
                        break;
                    }
                }
            }
            catch
            {

            }
        }

        private byte[] TcpGetFile(string node, string fpath, string filename)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            using (System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient())
            {
                string addr = ConfigurationManager.AppSettings.Get("TcpFileAddr");
                int port = int.Parse(ConfigurationManager.AppSettings.Get("TcpFilePort"));
                client.Connect(addr, port);
                System.Net.Sockets.NetworkStream stream = client.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(node + "\\\\\\" + filename);
                stream.Write(data, 0, data.Length);
                // 补全路径
                string[] fpathl = filename.Split(new String[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                string fp = fpath;
                bool nopath = false;
                for (int i = 0; i < fpathl.Length - 1; i++)
                {
                    fp = fp + "\\" + fpathl[i];
                    if (nopath || !System.IO.Directory.Exists(fp))
                    {
                        System.IO.Directory.CreateDirectory(fp);
                        nopath = true;
                    }
                }

                var bw = new System.IO.BinaryWriter(new System.IO.FileStream(fpath + "\\" + filename, System.IO.FileMode.Create));
                byte[] recByte = new byte[40960000];
                while (true)
                {
                    var bytes = stream.Read(recByte, 0, recByte.Length);
                    if (bytes == 0) break;
                    bw.Write(recByte, 0, bytes);
                }
                bw.Close();

                //文件修改时间更新
                sw.Stop();
                return recByte;
            }

        }

        private List<FInfo> GetFilesFromPath(string srcPath, int plen)
        {
            List<FInfo> fileInfo = new List<FInfo>();
            try
            {
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就重新调用GetFileNum(string srcPath)
                    if (System.IO.Directory.Exists(file))
                    {
                        fileInfo.AddRange(GetFilesFromPath(file, plen));
                    }
                    else
                    {
                        FInfo f = new FInfo();
                        f.Name = file.Substring(plen + 1);
                        System.IO.FileInfo fif = new System.IO.FileInfo(file);
                        f.Time = fif.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

                        fileInfo.Add(f);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return fileInfo;
        }


        private void GetFile(List<FInfo> lf)
        {
            String result = String.Empty;
            String json = SerializeObject<List<FInfo>>(lf);
            var content = new StringContent(json, Encoding.UTF8, "application/json"); //Content-Type设置

            this.lbInfo.Items.Add("正在获取更新文件信息......");
            try
            {
                string url = ConfigurationManager.AppSettings.Get("HttpFileUrl");
                HttpClient _HttpClient = new HttpClient();
                HttpResponseMessage response = _HttpClient.PostAsync(url + "files/" + Mac + "/" + Ip + "/" + ComputerName, content).Result;
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;

                string[] files = result.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd hh:mm:ss";
                string node = files[0];
                for (int i = 1; i < files.Length; i += 2)
                {
                    string file = files[i];
                    string fileTime = files[i + 1];
                    this.lbInfo.Items.Add("[" + (i / 2 + 1) + "/" + files.Length / 2 + "]" + "正在更新文件：" + file);
                    this.lbInfo.SelectedIndex = this.lbInfo.Items.Count - 1;
                    this.lbInfo.Update();
                    this.progressBar.Value = 100 * (i + 2)/ files.Length;
                    this.progressBar.Update();
                    byte[] fb = TcpGetFile(node, Path, file);
                    System.IO.FileInfo fif = new System.IO.FileInfo(Path + "\\" + file);
                    fif.LastWriteTime = Convert.ToDateTime(files[i + 1], dtFormat);

                    //   上传记录更新信息
                    string branchId = ConfigurationManager.AppSettings.Get("BranchId");
                    if (String.IsNullOrEmpty(branchId))
                    {
                        branchId = "1";
                    }
                    NodeFile nf = new NodeFile();
                    nf.BranchId = int.Parse(branchId);
                    nf.Mac = Mac;
                    nf.Ip = Ip;
                    nf.CompName = ComputerName;
                    nf.FileWp = Path + "\\" + file;
                    nf.Version = FileVersionInfo.GetVersionInfo(nf.FileWp).FileVersion;
                    nf.FileTime = files[i + 1];
                    UpdateNodeFile(nf);
                }
                
                this.lbInfo.Items.Add("更新文件完成！");
                if (stayFinish) this.btnExit.Enabled = true; 
                else this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void UpdateNodeFile(NodeFile nf)
        {
            String result = String.Empty;
            String json = SerializeObject<NodeFile>(nf);
            var content = new StringContent(json, Encoding.UTF8, "application/json"); //Content-Type设置
            try
            {
                string url = ConfigurationManager.AppSettings.Get("HttpFileUrl");
                HttpClient _HttpClient = new HttpClient();
                HttpResponseMessage response = _HttpClient.PostAsync(url + "filenoderec", content).Result;
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        ///  对象序列化为字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns></returns>
        private string SerializeObject<T>(T t)
        {
            JsonSerializerSettings js = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,//忽略循环引用，如果设置为Error，则遇到循环引用的时候报错（建议设置为Error，这样更规范）
                DateFormatString = "yyyy-MM-dd HH:mm:ss",//日期格式化，默认的格式也不好看
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()//json中属性开头字母小写的驼峰命名
            };

            return JsonConvert.SerializeObject(t, js);
        }

        internal class PathInfo
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public List<FInfo> Files { get; set; }
            public bool ReadToMem { get; set; }
        }

        internal class FInfo
        {
            public string Name { get; set; }
            public byte[] Content { get; set; }
            public string Time { get; set; }
        }

        internal class NodeFile
        {
            public int BranchId { get; set; }
            public string Mac { get; set; }
            public string Ip { get; set; }
            public string CompName { get; set; }
            public string FileWp { get; set; }
            public string Version { get; set; }
            public string FileTime { get; set; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
