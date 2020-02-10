using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Model
{
    public class BDictEmp
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
        /// 中心库ID
        /// </summary>
        public int Ceid { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary> 
        public int DeptId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public String DeptName { get; set; }
        /// <summary>
        /// 业务科室ID
        /// </summary> 
        public int BizDeptId { get; set; }
        /// <summary>
        /// 业务科室名称
        /// </summary>
        public String BizDeptName { get; set; }
        /// <summary>
        /// 业务科室ID
        /// </summary> 
        public int? GroupId { get; set; }
        /// <summary>
        /// 业务科室名称
        /// </summary>
        public String GroupName { get; set; }
        /// <summary>
        /// 业务科室ID
        /// </summary> 
        public int? TitlesId { get; set; }
        /// <summary>
        /// 业务科室名称
        /// </summary>
        public String TitlesName { get; set; }
        /// <summary>
        /// 带教人员
        /// </summary>
        public int? TakeEmpid { get; set; }
    }
}
