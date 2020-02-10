namespace His6.Base
{
    /// <summary>
    /// 文 件 名：远程信息实体对象
    /// 功能描述：用于远程信息接收时的信息，信息内容由各对应信息自己定义。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class DataRemoteInfo
    {
        #region 属性

        /// <summary>
        /// 信息代码
        /// </summary>
        public string InfoCode
        {
            get;
            set;
        }

        /// <summary>
        /// 发送者员工ID
        /// </summary>
        public int EmpId
        {
            get;
            set;
        }

        /// <summary>
        /// 机器IP
        /// </summary>
        public string ComputerIP
        {
            get ; 
            set ; 
        }

        /// <summary>
        /// 机器名称
        /// </summary>
        public string ComputerName
        {
            get ; 
            set ;
        }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string InfoBody
        {
            get ;
            set ;
        }

        #endregion

        /// <summary>
        ///  初始化
        /// </summary>
        public DataRemoteInfo()
        {
        }

        /// <summary>
        ///  初始化
        /// </summary>
        /// <param name="info_code">信息代码</param>
        /// <param name="emp_id">员工ID</param>
        /// <param name="ip">机器IP</param>
        /// <param name="computer_name">机器名称</param>
        /// <param name="info_body">信息内容</param>
        public DataRemoteInfo(string info_code, int emp_id, string ip, string computer_name, string info_body)
        {
            this.InfoCode = info_code;
            this.EmpId = emp_id;
            this.ComputerIP = ip;
            this.ComputerName = computer_name;
            this.InfoBody = info_body;
        }

    }
}
