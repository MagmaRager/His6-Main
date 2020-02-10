using System.Collections.Generic;

using His6.Base;
using His6.Model;

namespace His6.SysSetup
{
    public static class CommonDataHelper
    {
        /// <summary>
        ///  获取全部可用角色
        /// </summary>
        /// <returns></returns>
        public static List<BDictRole> GetRoleAll()
        {
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("branchId", EnvInfo.BranchId.ToString())
            };
            CustomException ce = null;
            // 查询获取全部可用角色列表（本机构及公共角色）
            // TODO 中心角色？
            List<BDictRole> roles = HttpDataHelper.GetWithInfo<List<BDictRole>>("BASE", "/setup/role", out ce, parmList);

            return roles;
        }

        /// <summary>
        ///  获取全部可用员工
        /// </summary>
        /// <returns></returns>
        public static List<DataEmpDir> GetEmpAll()
        {
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("branchId", EnvInfo.BranchId.ToString())
            };
            CustomException ce = null;
            // 获取全部可用员工(本机构在用员工)
            // TODO 中心人员？
            List<DataEmpDir> emps = HttpDataHelper.GetWithInfo<List<DataEmpDir>>("BASE", "/setup/emp", out ce, parmList);

            return emps;
        }

    }
}
