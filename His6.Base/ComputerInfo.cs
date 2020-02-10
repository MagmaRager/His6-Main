using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace His6.Base
{
    /// <summary>
    /// 计算机基础信息
    /// </summary>
    public static class ComputerInfo
    {
        private static string UnKnow = "未识别";

        /// <summary>
        /// CPU信息
        /// </summary>
        private static Lazy<Dictionary<string, object>> cpu = new Lazy<Dictionary<string, object>>(() =>
        {
            var result = new Dictionary<string, object>();
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_Processor"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            foreach (PropertyData property in mo.Properties)
                            {
                                result.Add(property.Name, property.Value);
                            }
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }

            return result;
        });

        /// <summary>
        /// 输入法列表
        /// </summary>
        private static Lazy<List<string>> ime = new Lazy<List<string>>(() =>
        {
            List<string> result = new List<string>();
            foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
            {
                result.Add(language.LayoutName);
            }

            return result;
        });

        /// <summary>
        /// 本机的网卡地址
        /// </summary>
        private static Lazy<List<string>> netAddress = new Lazy<List<string>>(() =>
        {
            var result = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(new SelectQuery("Win32_NetworkAdapterConfiguration"));
            foreach (ManagementObject mo in searcher.Get())
            {
                if ((bool) mo["IPEnabled"])
                {
                    result.Add(mo.Properties["MacAddress"].Value.ToString().Replace(":", ""));
                }
            }

            return result;
        });

        /// <summary>
        /// 本机的IP地址
        /// </summary>
        private static Lazy<string> ipAddress = new Lazy<string>(() =>
        {
            System.Net.IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            string result = null;
            if (addresses.Length > 0)
            {
                //取IPv4地址
                System.Net.IPAddress ipAddress = addresses.FirstOrDefault(p => p.AddressFamily == AddressFamily.InterNetwork);
                if (ipAddress != null)
                {
                    result = ipAddress.ToString();
                }
            }

            return result;
        });

        /// <summary>
        /// 本机计算机名
        /// </summary>
        private static Lazy<string> computerName = new Lazy<string>(Dns.GetHostName);

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        private static Lazy<string> diskId = new Lazy<string>(() =>
        {
            string result = null;

            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_DiskDrive"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            result = (string) mo.Properties["Model"].Value;
                        }
                    }
                }
            }
            catch
            {
                result = UnKnow;
            }

            return result;
        });

        /// <summary>
        /// 物理内存数量
        /// </summary>
        private static Lazy<string> totalPhysicalMemory = new Lazy<string>(() =>
        {
            string result = null;
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            result = mo["TotalPhysicalMemory"].ToString();
                        }
                    }
                }
            }
            catch
            {
                result = UnKnow;
            }

            return result;
        });

        /// <summary>
        /// 计算机类型
        /// </summary>
        private static Lazy<string> systemType = new Lazy<string>(() =>
        {
            string result = null;
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            result = mo["SystemType"].ToString();
                        }
                    }
                }
            }
            catch
            {
                result = "unknow";
            }

            return result;
        });
        private  static Lazy<List<string>> printerInfo=new Lazy<List<string>>(() =>
        {
            var list=new List<string>();
            var kkk = PrinterSettings.InstalledPrinters;
            foreach (string item in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                list.Add(item);
            }

            return list;
        });
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        public static string CpuId => cpu.Value.ContainsKey("ProcessorId") ? cpu.Value["ProcessorId"].ToString() : UnKnow;

        /// <summary>
        /// 获取CPU名称
        /// </summary>
        public static string CpuName => cpu.Value.ContainsKey("Name") ? cpu.Value["Name"].ToString() : UnKnow;

        /// <summary>
        /// 获取CPU核心数量
        /// </summary>
        public static int CpuNumberOfCores => cpu.Value.ContainsKey("NumberOfCores") ? (cpu.Value["NumberOfCores"] == null ? 0 : Convert.ToInt32(cpu.Value["NumberOfCores"])) : 0;

        /// <summary>
        /// 获取CPU可用核心数量
        /// </summary>
        public static int CpuNumberOfEnabledCore =>
            cpu.Value.ContainsKey("NumberOfEnabledCore") ? (cpu.Value["NumberOfEnabledCore"] == null ? 0 : Convert.ToInt32(cpu.Value["NumberOfEnabledCore"])) : 0;

        /// <summary>
        /// 获取CPU逻辑处理器数量
        /// </summary>
        public static int CpuNumberOfLogicalProcessors =>
            cpu.Value.ContainsKey("NumberOfLogicalProcessors") ? (cpu.Value["NumberOfLogicalProcessors"] == null ? 0 : Convert.ToInt32(cpu.Value["NumberOfLogicalProcessors"])) : 0;

        /// <summary>
        /// 获取操作系统版本
        /// </summary>
        public static string OSVersion => Environment.OSVersion.ToString();

        /// <summary>
        /// 获取输入法列表
        /// </summary>
        public static List<string> Ime => ime.Value;

        /// <summary>
        /// 获取本机的网卡地址
        /// </summary>
        public static List<string> NetAddress => netAddress.Value;

        /// <summary>
        /// 获取本机的IP地址
        /// </summary>
        public static string IpAddress => ipAddress.Value;

        /// <summary>
        /// 获取本机计算机名
        /// </summary>
        public static string ComputerName => computerName.Value;

        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        public static string DiskId => diskId.Value;

        /// <summary>
        /// 获取物理内存数量
        /// </summary>
        public static string TotalPhysicalMemory => totalPhysicalMemory.Value;

        /// <summary>
        /// 获取计算机类型
        /// </summary>
        public static string SystemType => systemType.Value;
        /// <summary>
        /// 获取本机打印机信息
        /// </summary>
        public static List<string> PrinterInfo => printerInfo.Value;
    }
}
