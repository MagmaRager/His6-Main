using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Model
{
    public class BDicFpEmp
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
        /// 默认属性
        /// </summary>
        public string DefaultProperty { get; set; }

        public BDicFpEmp(String code, String name, int id, string defaultProperty)
        {
            this.Code = code;
            this.Name = name;
            this.Id = id;
            this.DefaultProperty = defaultProperty;
        }
    }
}
