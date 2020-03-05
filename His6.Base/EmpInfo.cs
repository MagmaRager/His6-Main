using System;
using System.Collections.Generic;
using System.Text;

using His6.Model;

namespace His6.Base
{

    /// <summary>
    ///  人员基本信息
    /// </summary>
    public class EmpInfo
    {
        #region 属性

        /// <summary>
        /// 操作员标识
        /// </summary>
        public static int Id { get; private set; }

        /// <summary>
        /// 操作员CODE
        /// </summary>
        public static string Code { get; private set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        public static string Name { get; private set; }

        /// <summary>
        /// 中心人员标识
        /// </summary>
        public static int Ceid { get; private set; }

        /// <summary>
        /// 业务人员标识
        /// </summary>
        public static int BizEmpId { get; private set; }

        /// <summary>
        /// 业务人员姓名
        /// </summary>
        public static string BizEmpName { get; private set; }

        /// <summary>
        /// 行政科室标识
        /// </summary>
        public static int DeptId { get; private set; }

        /// <summary>
        /// 行政科室名称
        /// </summary>
        public static string DeptName { get; private set; }

        /// <summary>
        /// 业务科室标识
        /// </summary>
        public static int BizDeptId { get; private set; }

        /// <summary>
        /// 业务科室名称
        /// </summary>
        public static string BizDeptName { get; private set; }

        /// <summary>
        /// 操作员分组标识
        /// </summary>
        public static int? GroupId { get; private set; }

        /// <summary>
        /// 操作员分组名称
        /// </summary>        
        public static string GroupName { get; private set; }

        /// <summary>
        /// 操作员角色列表
        /// </summary>
        public static List<string> RoleList { get; private set; }

        /// <summary>
        /// 操作员行为角色列表(包括被制授权列表)
        /// </summary>
        public static List<CDictAction> ActionRoleList { get; private set; }

        /// <summary>
        /// 操作员对应的类型集合
        /// 1=行政/2=诊疗/3=护理/4=医技/5=手术/6=麻醉/7=药事/8=财务/9=后勤/10=护工/99=其它
        /// </summary>
        //public static List<int> KindList { get; private set; }

        /// <summary>
        /// 职称Id
        /// </summary>
        public static int? TitlesId { get; private set; }

        /// <summary>
        /// 职称名称
        /// </summary>
        public static string TitlesName { get; private set; }

        /// <summary>
        /// 操作员输入码类型(1=辅码1,2=辅码2)
        /// </summary>
        public static string InputChoice { get; set; }

        /// <summary>
        ///  员工可用子系统列表
        /// </summary>
        public static List<BDictSystem> CanUseSystemList { get; private set; }

        #endregion

        #region 扩充的属性及方法

        /// <summary>
        ///  操作员角色字符串，中间用空格间隔
        /// </summary>
        public static string Roles
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
        ///  是否系统管理员
        /// </summary>
        public static bool IsCenterAdmin
        {
            get
            {
                return HasActionRole("SYS_ADMIN");
            }
        }

        /// <summary>
        ///  是否机构管理员
        /// </summary>
        public static bool IsBranchAdmin
        {
            get  
            {
                return HasActionRole("BRANCH_ADMIN");
            }
        }

        /// <summary>
        ///  是否有某行为角色
        /// </summary>
        /// <param name="code">行为角色代码</param>
        /// <returns></returns>
        public static bool HasActionRole(string code)
        {
            if (ActionRoleList != null)
            {
                return ActionRoleList.FindIndex(o =>
                {
                    return o.Code == code && (o.GrantEmpId == null || 
                    (Convert.ToDateTime(o.EffectiveTime) < DateTime.Now && Convert.ToDateTime(o.ExpiryTime) > DateTime.Now));
                }) >= 0;
            }
            return false;
        }

        /// <summary>
        ///  获取授权人员标识
        /// </summary>
        /// <param name="code">行为权限代码</param>
        /// <returns></returns>
        public static int? GetActionRoleEmpId(string code)
        {
            CDictAction ar = ActionRoleList.Find(o => { return o.Code == code; });

            if (ar == null)
            {
                return null;
            }
            else
            {
                return ar.GrantEmpId;
            }
        }

        /// <summary>
        ///  判别是否有对应的角色权限
        /// </summary>
        /// <param name="code">角色代码</param>
        /// <returns></returns>
        public static bool HasRole(string code)
        {
            if (RoleList != null)
            {
                return RoleList.Contains(code);
            }
            return false;
        }

        /// <summary>
        ///  判别人员是否有职责性质
        /// </summary>
        /// <param name="kind">职责性质</param>
        /// <returns></returns>
        //public static bool HasKind(int kind)
        //{
        //    if (KindList != null)
        //    {
        //        return KindList.Contains(kind);
        //    }
        //    return false;
        //}

        #endregion

        #region 功能方法

        /// <summary>
        ///  通过代码获取员工ID及可用系统信息
        /// </summary>
        /// <param name="code">员工代码</param>
        /// <returns>返回错误信息，空为成功</returns>
        public static string QueryEmpByCode(string code)
        {
            //EmpInfo.CanUseSystemList = new List<BDicSystem>();
            if (code.IsNullOrEmpty())
            {
                EmpInfo.Id = 0;
                EmpInfo.Code = string.Empty;
                return "工号不可为空！";
            }

            //  依据员工代码获取员工ID，再获取可使用的子系统
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("empCode", code)
            };
            CustomException ce = null;
            int emp_id = HttpDataHelper.GetWithInfo<int>("BASE", "/sys/empid", out ce, parmList);
            if(emp_id < 0)
            {
                return "不存在工号为" + code + "的人员！";
            }

            parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("empId", emp_id.ToString())
            };
            List<BDictSystem> ls = HttpDataHelper.GetWithInfo<List<BDictSystem>>("BASE", "/sys/system", out ce, parmList);
            if(ls == null || ls.Count == 0)
            {
                return "工号" + code + "的人员没有可用的子系统！";
            }
            EmpInfo.CanUseSystemList = ls;          

            EmpInfo.Code = code;
            EmpInfo.Id = emp_id;       

            return string.Empty;
        }

        /// <summary>
        ///  获取上一次登录的系统代码
        /// </summary>
        /// <returns></returns>
        public static string GetLastSystemCode()
        {
            string code = string.Empty;
            if (EmpInfo.Id > 0)
            {
                var parmList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString())
                };
                CustomException ce = null;                
                // 获取上一次登录的系统代码
                code = HttpDataHelper.GetStringWithInfo("BASE", "/sys/systemdefault", out ce, parmList);
                if (ce != null)
                {
                    MessageHelper.ShowError("获取默认子系统失败！\r\n" + ce.Info + " " + ce.InnerMessage);
                    return null;
                }
            }

            return code;
        }

        public static void SetEmpInfo(BDictEmp emp, List<string> roleList, List<CDictAction> actionList)
        {
            EmpInfo.Name = emp.Name;
            EmpInfo.Ceid = emp.Ceid;
            EmpInfo.DeptId = emp.DeptId;
            EmpInfo.DeptName = emp.DeptName;
            EmpInfo.BizDeptId = emp.BizDeptId;
            EmpInfo.BizDeptName = emp.BizDeptName;
            EmpInfo.GroupId = emp.GroupId;
            EmpInfo.GroupName = emp.GroupName;
            EmpInfo.TitlesId = emp.TitlesId;
            EmpInfo.TitlesName = emp.TitlesName;

            EmpInfo.RoleList = roleList;
            EmpInfo.ActionRoleList = actionList;

            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()),
                new KeyValuePair<string, string>("parmName", "DEF_INPUT")
            };
            CustomException ce = null;
            String defInput = HttpDataHelper.GetStringWithInfo("BASE", "/sys/parameteremp", out ce, parmList);
            if (ce != null)
            {
                MessageHelper.ShowError("获取默认输入法失败！\r\n" + ce.Info + " " + ce.InnerMessage);
            }
            if (String.IsNullOrEmpty(defInput))
            {
                EmpInfo.InputChoice = "1";
            }
            else EmpInfo.InputChoice = defInput;

        }

        /// <summary>
        ///  系统登录
        /// </summary>
        /// <param name="branch_id">机构ID</param>
        /// <param name="system_code">子系统代码</param>
        /// <param name="password">口令</param>
        /// <returns>返回错误信息，空为成功</returns>
        public static string Login(int branch_id, string system_code, string password)
        {
            //  完成登录，获取员工相关信息
            //        1. 验证用户口令并获取员工信息记录中的基本内容。
            //        2. 判断子系统使用权限
            //        3. 获取普通角色、行为角色

            List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
            parms.Add(new KeyValuePair<string, string>("branchCode", EnvInfo.BranchCode));
            parms.Add(new KeyValuePair<string, string>("empCode", EmpInfo.Code));
            parms.Add(new KeyValuePair<string, string>("password", DataCryptoHelper.MD5EncryptString(password)));
            parms.Add(new KeyValuePair<string, string>("ip", EnvInfo.ComputerIp));
            CustomException ce = null;
            int loginRst = int.Parse(HttpDataHelper.HttpPostFormUrlWithInfo("BASE", "/sys/login", out ce, parms));

            switch(loginRst)
            {
                case -1:
                    return "人员不存在！";
                case -2:
                    return "密码错误！";
                case 1:
                    // 4. 设置环境信息对应的子系统代码、名称
                    SelectSystem(system_code,true);
                    return string.Empty;
                default:
                    return "服务异常";
            }
            
            /* TODO 参考
            EmpInfo.Name = EmpInfo.Id.ToString();            
            EmpInfo.BizEmpName = " 业务" + EmpInfo.Id.ToString();
            EmpInfo.InputCode = "1";
           
            String loginUrl = HttpDataHelper.getUrl("SYSTEM");
            if (loginUrl != null)
            {

                Dictionary<String, String> dic = HttpDataHelper.PathGet<Dictionary<String, String>>(loginUrl + "login",
                    new String[] { branch_id.ToString(), system_code, EmpInfo.Id.ToString(), password });

                //workplace subSystem判断

            }
            */
            
        }

        /// <summary>
        ///  切换子系统
        /// </summary>
        /// <param name="system_code">系统代码</param>
        public static void SelectSystem(string system_code, bool isLogin = false)
        {
            EnvInfo.SystemCode = system_code;
            EnvInfo.SystemId = CanUseSystemList.Find(o => o.Code == system_code).Id;
            EnvInfo.SystemName = CanUseSystemList.Find(o => o.Code == system_code).Name;

            // 将最新使用子系统更新至个人参数
            if (!GetLastSystemCode().Equals(system_code))
            {
                List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();                
                parms.Add(new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()));
                parms.Add(new KeyValuePair<string, string>("parmName", "DEF_SYSTEM"));
                parms.Add(new KeyValuePair<string, string>("value", EnvInfo.SystemCode));
                CustomException ce;
                HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/sys/parameteremp", out ce, parms);
                if (ce != null) throw ce;
            }
        }

        /// <summary>
        ///  Token登录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool LoginWithToken(string token)
        {
            bool ok = false;
            //  TODO: 利用token直接登录系统
            //      

            return ok;
        }

        public static void Logout()
        {
            EmpInfo.Id = 0;
            EmpInfo.Code = string.Empty;
            EmpInfo.Name = string.Empty;
        }

        #endregion

    }

    /// <summary>
    /// 员工行为角色及授权信息
    /// </summary>
    public class ActionRole
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="code"></param>
        /// <param name="grant_empid"></param>
        /// <param name="effective_time"></param>
        /// <param name="expiry_time"></param>
        public ActionRole(string code, int grant_empid, DateTime effective_time, DateTime expiry_time)
        {
            this.Code = code;
            this.GrantEmpId = grant_empid;
            this.EffectiveTime = effective_time;
            this.ExpiryTime = expiry_time;
        }

        /// <summary>
        /// 行为角色代码
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// 授权人员
        /// </summary>
        public int GrantEmpId { get; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime EffectiveTime { get; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime ExpiryTime { get; }

    }

}
