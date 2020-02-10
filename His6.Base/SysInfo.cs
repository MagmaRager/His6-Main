using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace His6.Base
{
    /// <summary>
    ///  系统公用信息
    /// </summary>
    public static class SysInfo
    {
        #region 属性定义

        private static SysInfoOper _Oper;
        /// <summary>
        /// 人员基本信息
        /// </summary>
        public static SysInfoOper Oper
        {
            get
            {
                if (_Oper == null)
                {
                    _Oper = new SysInfoOper();
                }
                return _Oper;
            }
        }

        private static SysInfoEnv _Env;
        /// <summary>
        ///  运行环境相关信息
        /// </summary>
        public static SysInfoEnv Env
        {
            get
            {
                if (_Env == null)
                {
                    _Env = new SysInfoEnv();
                }
                return _Env;
            }
        }


        #endregion

        public static bool InitSysInfo()
        {
            /*TODO
                 * 获取配置文件信息
                 * 初始化操作系统信息
                 * 获取公共基本信息
                 */

            SysInfo.Oper.Id = -1;
            
            // 获取机器的基本信息

            // 运行目录(不要取运行时的环境参数中的路径,直接取自运行文件的所在目录)
            string file = Application.ExecutablePath;
            SysInfo.Env.RunPath = file.Substring(0, file.LastIndexOf('\\') + 1);

            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            if (ver != null)
            {
                SysInfo.Env.Ver = ver.FileVersion;
            }
            //  机器名
            SysInfo.Env.ComputerName = System.Windows.Forms.SystemInformation.ComputerName;
            //  CPU编号
            SysInfo.Env.ComputerCode = "";

            string mcode = string.Empty;

            //  先获取MAC地址
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        string mac = mo["MacAddress"].ToString();
                        mcode = mac.Substring(0, 2) + mac.Substring(3, 2) +
                                                              mac.Substring(6, 2) + mac.Substring(9, 2) +
                                                              mac.Substring(12, 2) + mac.Substring(15, 2);
                        break;
                    }
                }
            }
            catch (Exception err)
            {
                LogHelper.Write(ELogType.Error, "", "Program", "获取Mac地址出错(Win32_NetworkAdapterConfiguration)," + err.Message);
            }


            //  取不到MAC时取CPU号
            if (string.IsNullOrEmpty(mcode))
            {
                try
                {
                    ManagementClass mc = new ManagementClass("Win32_Processor");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        mcode = mo.Properties["ProcessorId"].Value.ToString();
                        break;
                    }
                }
                catch (Exception err)
                {
                    LogHelper.Write(ELogType.Error, "", "Program", "获取Mac地址出错(Win32_Processor)," + err.Message);
                }
            }


            if (!string.IsNullOrEmpty(mcode))
            {
                SysInfo.Env.ComputerCode = mcode.ToString();
            }

            if (string.IsNullOrEmpty(SysInfo.Env.ComputerCode))
            {
                throw new Exception("获取mac地址失败，可能window服务WMI没有启动!");
            }

            //  取得IP地址
            string host_name = Dns.GetHostName();             //得到本机的主机名
            IPAddress[] ip_addresses = Dns.GetHostAddresses(host_name);
            Regex ipMatch = new Regex(//验证IP的正则表达式
            @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

            foreach (var address in ip_addresses)
            {
                if (ipMatch.IsMatch(address.ToString()))
                {
                    SysInfo.Env.ComputerIp = address.ToString();
                    break;
                }
            }
            return true;
        }

        public static bool CheckLastDate()
        {
            string key = ConfigurationManager.AppSettings.Get("UserSerial");

            //  检查是否到期
            string lastdate = ConfigurationManager.AppSettings.Get("LastDate");
            lastdate = DataCryptoHelper.Decrypting(lastdate, key);
            SysInfo.Env.LastDate = Convert.ToDateTime(lastdate);

            if (DateTime.Now > SysInfo.Env.LastDate)
            {
                MessageBox.Show("系统已经过期, 请与供应商联系！");
                return false;
            }
            return true;
        }

        public static bool Login(int branchId, String operCode, String passwd, String workplace, String subSystem)
        {
            String loginUrl = HttpDataHelper.getUrl("SYS");
            if (loginUrl != null)
            {

                Dictionary<String, String> dic = HttpDataHelper.PathGet<Dictionary<String, String>>(loginUrl + "login", 
                    new String[] { branchId.ToString(), operCode, passwd });

                //workplace subSystem判断

            }
            return true;
        }

        public static bool IsLogin()
        {
            return _Oper.Id >= 0;
        }
    }

    /// <summary>
    ///  人员基本信息
    /// </summary>
    public class SysInfoOper
    {
        /// <summary>
        /// 操作员标识
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// 操作员CODE
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// 业务人员标识
        /// </summary>
        public int BizEmpId { get; internal set; }

        /// <summary>
        /// 业务人员姓名
        /// </summary>
        public string BizEmpName { get; internal set; }

        /// <summary>
        ///  隶属医疗机构标识
        /// </summary>
        public int BranchId { get; internal set; }

        /// <summary>
        ///  隶属组织机构代码
        /// </summary>
        public string BranchCode { get; internal set; }

        /// <summary>
        /// 隶属医疗机构名称
        /// </summary>
        public string BranchName { get; internal set; }

        /// <summary>
        /// 行政科室标识
        /// </summary>
        public int DeptId { get; internal set; }

        /// <summary>
        /// 行政科室名称
        /// </summary>
        public string DeptName { get; internal set; }

        /// <summary>
        /// 业务科室标识
        /// </summary>
        public int BizDeptId { get; internal set; }

        /// <summary>
        /// 业务科室名称
        /// </summary>
        public string BizDeptName { get; internal set; }

        /// <summary>
        /// 操作员分组标识
        /// </summary>
        public int GroupId { get; internal set; }

        /// <summary>
        /// 操作员分组名称
        /// </summary>        
        public string GroupName { get; internal set; }

        /// <summary>
        /// 职称Id
        /// </summary>
        public int TitleId { get; internal set; }

        /// <summary>
        /// 职称名称
        /// </summary>
        public string TitleName { get; internal set; }

        /// <summary>
        /// 职称等级
        /// </summary>
        public int TitleGrade { get; internal set; }

        /// <summary>
        /// 操作员角色列表
        /// </summary>
        public List<string> RoleList { get; internal set; }

        /// <summary>
        /// 操作员行为权限列表(包括被制授权列表)
        /// </summary>
        public List<ActionRight> ActionRightList { get; internal set; }

        #region 扩充的属性及方法

        /// <summary>
        ///  操作员角色字符串
        /// </summary>
        public string Roles
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (RoleList != null)
                {
                    for (int i = 0; i < RoleList.Count; i++)
                    {
                        if (i == RoleList.Count - 1)
                        {
                            sb.Append(RoleList[i]);
                        }
                        else
                        {
                            sb.Append(RoleList[i]);
                            sb.Append(" ");
                        }
                    }
                }
                return sb.ToString();
            }
        }

        /// <summary>
        ///  判别是否有对应的角色权限
        /// </summary>
        /// <param name="code">角色代码</param>
        /// <returns></returns>
        public bool HasRole(string code)
        {
            if (RoleList != null)
            {
                return RoleList.Contains(code);
            }
            return false;
        }

        /// <summary>
        ///  是否系统管理员
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                return HasActionRight("SYS_ADMIN");
            }
        }

        /// <summary>
        ///  是否有某行为权限
        /// </summary>
        /// <param name="code">行为权限代码</param>
        /// <returns></returns>
        public bool HasActionRight(string code)
        {
            if (ActionRightList != null)
            {
                return ActionRightList.FindIndex(o =>
                {
                    return o.Code == code && o.ExpiryTime > SysInfo.Env.ServerTime;
                }) >= 0;
            }
            return false;
        }

        /// <summary>
        ///  获取授权人员标识
        /// </summary>
        /// <param name="code">行为权限代码</param>
        /// <returns></returns>
        public int? GetActionRightEmpId(string code)
        {
            ActionRight ar = ActionRightList.Find(o => { return o.Code == code; });
            if (ar == null)
            {
                return null;
            }
            else
            {
                return ar.GrantEmpId;
            }
        }

        #endregion
    }

    /// <summary>
    ///  环境相关信息
    /// </summary>
    public class SysInfoEnv
    {
        /// <summary>
        /// 机器编号()
        /// </summary>
        public string ComputerCode { get; internal set; }

        /// <summary>
        /// 机器ＩＰ地址
        /// </summary>
        public string ComputerIp { get; internal set; }

        /// <summary>
        /// 计算机名称
        /// </summary>
        public string ComputerName { get; internal set; }

        /// <summary>
        /// 系统运行目录
        /// </summary>
        public string RunPath { get; internal set; }

        /// <summary>
        /// 子系统代码
        /// </summary>
        public string SysCode { get; internal set; }

        /// <summary>
        /// 子系统名称
        /// </summary>
        public string SysName { get; internal set; }

        /// <summary>
        /// 版本信息
        /// </summary>
        public string Ver { get; internal set; }

        /// <summary>
        /// 系统有效日期
        /// </summary>
        public DateTime LastDate { get; internal set; }

        /// <summary>
        /// 系统用户单位名称
        /// </summary>
        public string UserName { get; internal set; }

        /// <summary>
        /// 工作点ID
        /// </summary>
        public int WorkPlaceId { get; internal set; }

        /// <summary>
        /// 工作点名称
        /// </summary>
        public string WorkPlaceName { get; internal set; }

        /// <summary>
        /// 系统服务器时间
        /// </summary>
        public DateTime ServerTime { get; internal set; }

        /// <summary>
        /// 单点登录令牌
        /// </summary>
        public string Token { get; internal set; }

        /// <summary>
        /// 公共密钥
        /// </summary>
        public string PublicKey { get; internal set; }

    }

    /// <summary>
    /// 操作员对应的行为权限及授权信息
    /// </summary>
    public class ActionRight
    {
        /// <summary>
        /// 行为权限代码
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        /// 授权人员
        /// </summary>
        public int GrantEmpId { get; internal set; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime EffectiveTime { get; internal set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime ExpiryTime { get; internal set; }

    }


    
}
