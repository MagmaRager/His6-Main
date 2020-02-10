using System.Runtime.Serialization;

namespace His6.Model
{
	/// <summary>
	///  员工信息简单列表
	/// </summary>
	public class DataEmpDir
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public DataEmpDir()
		{
		}

		/// <summary>
		/// 标识
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 代码
		/// </summary>
		public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 输入码1
        /// </summary>
        public string Inputcode1 { get; set; }

        /// <summary>
        /// 输入码2
        /// </summary>
        public string Inputcode2 { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public int? DeptId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
    }
}
