using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public class ErrorLogInfo
    {
        public int BranchId { get; set; }

        public int EmpId { get; set; }

        public String ComputerIp { get; set; }

        public String Info { get; set; }

        public String Message { get; set; }

        public String Stacktrace { get; set; }
    }
}
