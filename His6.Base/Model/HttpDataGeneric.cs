using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class HttpDataGeneric<T>
    {
        public T DataEntity { get; set; }

        public CustomException ExceptionInfo { get; set; }        

    }
}
