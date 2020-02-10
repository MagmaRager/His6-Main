using System.Collections.Generic;

namespace His6.Model
{
    public class BDicFunctionPoint
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 对象代码
        /// </summary>
        public string ObjectCode { get; set; }
        /// <summary>
        /// 默认属性（H/R/W不可视/只读/读写）
        /// </summary>
        public string DefaultProperty { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 功能点人员权限列表
        /// </summary>
        public List<BDicFpEmp> EmpList { get; set; }
        /// <summary>
        /// 功能点角色权限列表
        /// </summary>
        public List<BDicFpRole> RoleList { get; set; }

    }
}
