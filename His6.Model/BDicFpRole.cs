using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Model
{
    public class BDicFpRole
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
        /// 默认属性（H/R/W不可视/只读/读写）
        /// </summary>
        public string DefaultProperty { get; set; }

        public BDicFpRole(String code, String name, string defaultProperty)
        {
            this.Code = code;
            this.Name = name;
            this.DefaultProperty = defaultProperty;
        }
    }
}
