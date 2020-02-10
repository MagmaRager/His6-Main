using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class CustomExceptionInfo
    {
        public String Info { get; set; }

        public String InnerMessage { get; set; }

        public String Stacktrace { get; set; }

        public CustomExceptionInfo()
        { }
        

        public CustomExceptionInfo(String info, String message, String stacktrace)
        {
            this.Info = info;
            this.InnerMessage = message;
            this.Stacktrace = stacktrace;
        }


    }
}
