using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base.Model
{
    /// <summary>
    /// 本机的IP信息
    /// </summary>
   public class ComputerMacIpVo
    {
        /// <summary>
        /// mac地址
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }
    }
}
