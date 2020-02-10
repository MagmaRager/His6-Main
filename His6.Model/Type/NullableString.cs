using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Model
{
    public class NullableString
    {
        /// <summary>
        /// 字符串内容
        /// </summary>
        public string String { get; set; }
        /// <summary>
        /// 若为false则视作NULL
        /// </summary>
        public bool Valid { get; set; }
    }
}
