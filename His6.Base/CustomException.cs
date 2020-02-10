using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class CustomException : Exception
    {
        public String Info { get; set; }

        public String InnerMessage { get; set; }

        public String Stacktrace { get; set; }

        public CustomException() { }

        public CustomException(String errorMsg)
            : base(errorMsg) 
        {
        }

        public CustomException(CustomExceptionInfo ei)
        {
            this.Info = ei.Info;
            this.InnerMessage = ei.InnerMessage;
            this.Stacktrace = ei.Stacktrace;
        }

        public CustomException(String info, String message, String stacktrace)
        {
            this.Info = info;
            this.InnerMessage = message;
            this.Stacktrace = stacktrace;
        }


    }
}
