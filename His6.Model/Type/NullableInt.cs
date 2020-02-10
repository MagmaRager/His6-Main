using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Model
{
    public class NullableInt
    {
        /// <summary>
        /// 数值
        /// </summary>
        public string Int64 { get; set; }
        /// <summary>
        /// 若为false则视作NULL
        /// </summary>
        public bool Valid { get; set; }
    }
}
