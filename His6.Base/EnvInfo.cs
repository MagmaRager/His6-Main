using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using His6.Base.Helper;
using His6.Base.Model;

namespace His6.Base
{

    /// <summary>
    ///  环境相关信息
    /// </summary>
    public static class EnvInfo
    {
        static EnvInfo()
        {
            //  设置程序相关信息
            SetProgramInfo();

            //  设置机器信息
            SetComputerInfo();

            //  设置机构信息
            SetBranchInfo();
        }

        #region 属性

        /// <summary>
        /// 机器编号 Mac地址
        /// </summary>
        public static string ComputerCode { get; private set; }

        /// <summary>
        /// 机器ＩＰ地址
        /// </summary>
        public static string ComputerIp { get; private set; }

        /// <summary>
        /// 计算机名称
        /// </summary>
        public static string ComputerName { get; private set; }

        /// <summary>
        /// 服务器与本地时间差（毫秒）
        /// </summary>
        public static long ServerTimeDelta { get; set; }

        /// <summary>
        /// 系统运行目录
        /// </summary>
        public static string RunPath { get; private set; }

        /// <summary>
        /// 运行程序文件名
        /// </summary>
        public static string RunFile { get; private set; }

        /// <summary>
        /// 版本信息
        /// </summary>
        public static string Version { get; private set; }

        /// <summary>
        ///  医疗机构ID
        /// </summary>
        public static int BranchId { get; private set; }

        /// <summary>
        ///  隶属医疗机构代码
        /// </summary>
        public static string BranchCode { get; private set; }

        /// <summary>
        /// 隶属医疗机构名称
        /// </summary>
        public static string BranchName { get; private set; }

        /// <summary>
        /// 系统用户单位名称
        /// </summary>
        public static string UserName { get; private set; }

        /// <summary>
        /// 子系统ID
        /// </summary>
        public static int SystemId { get; internal set; }

        /// <summary>
        /// 子系统代码
        /// </summary>
        public static string SystemCode { get; internal set; }

        /// <summary>
        /// 子系统名称
        /// </summary>
        public static string SystemName { get; internal set; }

        /// <summary>
        /// SQL调试请求头
        /// </summary>
        public static string SqlHeader { get; set; }

        /// <summary>
        /// SQL调试请求头
        /// </summary>
        public static string JwtToken { get; set; }
        /// <summary>
        /// 用户登录初始化数据生成的唯一标识符  Token`
        /// </summary>
        public static string Access_Token { get; set; }
        /// <summary>
        /// 本机的所有ip+mac
        /// </summary>
        public static List<ComputerMacIpVo> ComputerMacIpList { get; set; }
        /// <summary>
        /// 药事系统代码
        /// </summary>
        public static  string[] DrugSystem = { "DRUG_MANAGE", "DRUG_STO_MANAGE", "DRUG_STORE_MANE_IN" };


        #endregion


        #region 方法

        /// <summary>
        ///  设置程序相关信息
        /// </summary>
        private static void SetProgramInfo()
        {
            //设置 对象序列化时 datetime类型 的格式
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };
            // 运行目录(不要取运行时的环境参数中的路径,直接取自运行文件的所在目录)
            string file = Application.ExecutablePath;
            EnvInfo.RunFile = file.Substring(file.LastIndexOf('\\') + 1);
            EnvInfo.RunPath = file.Substring(0, file.LastIndexOf('\\') + 1);

            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(file);
            if (ver != null)
            {
                EnvInfo.Version = ver.FileVersion;
            }
            //日志等级，默认为Error(错误级)
            string logLevel = ConfigurationManager.AppSettings.Get("LogLevel");
            if (!string.IsNullOrEmpty(logLevel))
            {
                LogHelper._logLevel = Convert.ToInt32(logLevel);
            }
            else LogHelper._logLevel = 1;            
        }

        /// <summary>
        ///  设置机器信息
        /// </summary>
        private static void SetComputerInfo()
        {
            var kk = netAddress.Value;
            GetMacAddress();
            ComputerMacIpList = new List<ComputerMacIpVo>();
            //  IP
            EnvInfo.ComputerIp = String.Empty;
            //ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //ManagementObjectCollection instances = managementClass.GetInstances();
            //foreach (ManagementBaseObject managementBaseObject in instances)
            //{
            //    ManagementObject managementObject = (ManagementObject)managementBaseObject;
            //    if ((bool)managementObject["IPEnabled"])
            //    {
            //        Array array = (Array)managementObject.Properties["IpAddress"].Value;
            //        EnvInfo.ComputerIp = array.GetValue(0).ToString();
            //        break;
            //    }
            //}

            //  机器名
            EnvInfo.ComputerName = SystemInformation.ComputerName;
            //  MAC地址
            EnvInfo.ComputerCode = string.Empty;
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        Array array = (Array) mo.Properties["IpAddress"].Value;
                        ComputerMacIpList.Add(new ComputerMacIpVo
                        {
                            Ip = array.GetValue(0).ToString(),
                            Mac = mo["MacAddress"].ToString()
                        });
                        //string mac = mo["MacAddress"].ToString();
                        //EnvInfo.ComputerCode = mac.Substring(0, 2) + mac.Substring(3, 2) +
                        //                                      mac.Substring(6, 2) + mac.Substring(9, 2) +
                        //                                      mac.Substring(12, 2) + mac.Substring(15, 2);
                        //break;
                    }
                }
                var result = ComputerMacIpList.FirstOrDefault();
                EnvInfo.ComputerIp = result?.Ip;
                EnvInfo.ComputerCode = result?.Mac.Replace(":", "");
                //result?.Mac.Substring(0, 2) + result?.Mac.Substring(3, 2) +
                //                   result?.Mac.Substring(6, 2) + result?.Mac.Substring(9, 2) +
                //                   result?.Mac.Substring(12, 2) + result?.Mac.Substring(15, 2);

            }
            catch (Exception err)
            {
                //  TODO 在message中加入环境和人员信息
                LogHelper.Error(typeof(EnvInfo).FullName, "获取Mac地址出错(Win32_NetworkAdapterConfiguration)," + err.Message);
            }
        }
        public static string GetMacAddress()
        {
            var kk = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()).ToList();
            var mm= (from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up&& nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                    select nic.GetPhysicalAddress().ToString()).ToList();
            return null;
            //string _mac = string.Empty;
            //NetworkInterface[] _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            //foreach (NetworkInterface adapter in _networkInterfaces)
            //{
            //    if (adapter.NetworkInterfaceType == networkType)
            //    {
            //        if (adapter.OperationalStatus != status) continue;
            //        _mac = adapter.GetPhysicalAddress().ToString();
            //        if (!String.IsNullOrEmpty(_mac)) break;
            //    }
            //}
            //if (macAddressFormatHanlder != null)
            //    _mac = macAddressFormatHanlder(_mac);
            //return _mac;
        }
        //本机的网卡地址
        public static Lazy<string> netAddress = new Lazy<string>(() =>
        {
            string result = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(new SelectQuery("Win32_NetworkAdapterConfiguration"));
            foreach (ManagementObject mo in searcher.Get())
            {
                if ((bool) mo["IPEnabled"])
                {
                    result = mo.Properties["MacAddress"].Value.ToString();
                    result = result.Replace(":", "");
                }
            }

            return result;
        });


        /// <summary>
        /// 通过配置文件设置机构信息
        /// </summary>
        private static void SetBranchInfo()
        {
            //  获取机构ID，默认为1.
            string sid = ConfigurationManager.AppSettings.Get("BranchId");
            if (!sid.IsNullOrEmpty() && sid.IsInt())
            {
                EnvInfo.BranchId = int.Parse(sid);
            }
            else
            {
                EnvInfo.BranchId = 1;
            }

            string key = ConfigurationManager.AppSettings.Get("UserSerial").Reversal();
            // 获取用户名称
            string rets = ConfigurationManager.AppSettings.Get("UserName");
            if (!string.IsNullOrEmpty(rets))
            {
                rets = DataCryptoHelper.Decrypting(rets, "Wonder.His" + key);
                EnvInfo.UserName = rets;
            }
            else
            {
                throw new Exception("配置文件中用户名称有误！");
            }

            //try
            //{
            // 系统时间与数据库时间同步
            DateTime d = DateTime.Now;
            //int timezone = int.Parse(DateTime.Now.ToString("%z").Substring(1));
            
            CustomException ex = null;
            String systime = HttpDataHelper.GetStringWithInfo("BASE", "/sys/date", out ex);
            if(ex != null) { throw ex; }
            char[] spp = new char[] { '-', ':', ' ', '+' };
            string[] tp = systime.Split(spp, StringSplitOptions.RemoveEmptyEntries);
            int[] itp = new int[7];
            for(int i = 0; i < 7; i++)
            {
                itp[i] = int.Parse(tp[i]);
            }
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(itp[0], itp[1], itp[2], itp[3], itp[4], itp[5]));
            
            long delta = GetTimeStamp(startTime) - GetTimeStamp(d) - itp[6] * 36000; //时区处理
            if (Math.Abs(delta) < 60000)
            {
                SYSTEMTIME st = new SYSTEMTIME();
                st.FromDateTime(DateTime.Now.AddMilliseconds(delta));
                bool syn = Win32API.SetLocalTime(ref st);
                if (!syn)
                {
                    EnvInfo.ServerTimeDelta = delta;
                }
            }

            //  通过BranchId 查询 名称及代码
            List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
            parms.Add(new KeyValuePair<string, string>("branchId", EnvInfo.BranchId.ToString()));
            CustomException ce = null;
            CDictBranch branch = HttpDataHelper.GetWithInfo<CDictBranch>("BASE", "/sys/branch", out ce, parms);
            EnvInfo.BranchCode = branch.Code;// "101";
            EnvInfo.BranchName = branch.Name;// EnvInfo.UserName;

            #region MONGODB 测试
            //ErrorLogInfo eli = new ErrorLogInfo();
            //eli.BranchId = EnvInfo.BranchId;
            //eli.EmpId = EmpInfo.Id;
            //eli.ComputerIp = EnvInfo.ComputerIp;
            //eli.Info = "Try";
            //eli.Message = "Demo message";

            //String json = StringHelper.SerializeObject<ErrorLogInfo>(eli);
            //HttpDataHelper.HttpPostWithInfo"BASE", "/mongo/errorlog/save", json);

            #endregion

            //}
            //catch (Exception ex)
            //{
            //    MessageHelper.ShowError(ex.Message);
            //}
        }

        private static DateTime GetDateTime(long timestamp)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区            
            return startTime.AddTicks(timestamp * 10000);
        }

        private  static long GetTimeStamp(DateTime d)
        {
            return (d.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }

        #endregion
    }

    public class Win32API
    {
        //设定，获取系统时间,SetSystemTime()默认设置的为UTC时间，比北京时间少了8个小时。  
        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref SYSTEMTIME time);
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME time);
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref SYSTEMTIME time);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SYSTEMTIME time);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;


        /// <summary>
        /// 从System.DateTime转换。
        /// </summary>
        /// <param name="time">System.DateTime类型的时间。</param>
        public void FromDateTime(DateTime time)
        {
            wYear = (ushort)time.Year;
            wMonth = (ushort)time.Month;
            wDayOfWeek = (ushort)time.DayOfWeek;
            wDay = (ushort)time.Day;
            wHour = (ushort)time.Hour;
            wMinute = (ushort)time.Minute;
            wSecond = (ushort)time.Second;
            wMilliseconds = (ushort)time.Millisecond;
        }
        /// <summary>
        /// 转换为System.DateTime类型。
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
        }
        /// <summary>
        /// 静态方法。转换为System.DateTime类型。
        /// </summary>
        /// <param name="time">SYSTEMTIME类型的时间。</param>
        /// <returns></returns>
        public static DateTime ToDateTime(SYSTEMTIME time)
        {
            return time.ToDateTime();
        }

    }

}
