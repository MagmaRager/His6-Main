using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class EntityInfoClient
    {
        #region 变量

        private string _Code;           //  客户代码
        private string _Name;           //  客户名
        private string _BranchId;       //  机构标识

        private string _ComputerIP;     //  机器IP
        private string _ComputerName;   //  机器名


        #endregion

        #region 属性

        /// <summary>
        /// 客户代码
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        /// <summary>
        /// 客户名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// 机器IP
        /// </summary>
        public string ComputerIP
        {
            get { return _ComputerIP; }
            set { _ComputerIP = value; }
        }

        /// <summary>
        /// 机器名称
        /// </summary>
        public string ComputerName
        {
            get { return _ComputerName; }
            set { _ComputerName = value; }
        }



        /// <summary>
        /// 医疗机构
        /// </summary>
        public string BranchId
        {
            get { return _BranchId; }
            set { _BranchId = value; }
        }

        #endregion

        /// <summary>
        ///  初始化
        /// </summary>
        public EntityInfoClient()
        {
        }

        /// <summary>
        ///  字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Code + "|" + this.Name + "|" + 
                this.ComputerIP + "|" + this.ComputerName;
        }

    }
}
