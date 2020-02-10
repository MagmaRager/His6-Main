using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Model
{
    public class CDictAction
    {
        /// <summary>
        /// 代码
        /// </summary>
        public String Code { get; set; }
        /// <summary>
        /// 授权人员
        /// </summary>
        public int? GrantEmpId { get; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public String EffectiveTime { get; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public String ExpiryTime { get; }
    }
}
