using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class SysEmp
    {
        /// <summary>
        /// 代码
        /// </summary>
        public String Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public String Inputcode { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }
        /// <summary>
        /// 分支机构ID
        /// </summary>
        public int BranchId { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary> 
        public int DeptId { get; set; }
        /// <summary>
        /// 公共库人员ID
        /// </summary>
        public int OperId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

    }
}
