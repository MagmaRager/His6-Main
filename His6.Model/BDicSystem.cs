using System;
using System.Collections.Generic;

namespace His6.Model
{
    public class BDicSystem
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public String Code { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public String Ico { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public String IcoText { get; set; }
        /// <summary>
        /// 主页菜单代码
        /// </summary>
        public string MenuCode { get; set; }
        /// <summary>
        /// 次序号
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// 人员权限列表
        /// </summary>
        public List<BDicFpEmp> EmpList { get; set; }
        /// <summary>
        /// 角色权限列表
        /// </summary>
        public List<BDicFpRole> RoleList { get; set; }
    }
}
