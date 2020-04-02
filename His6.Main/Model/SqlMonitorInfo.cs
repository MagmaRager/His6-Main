using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Main
{
    public class SqlMonitorInfo
    {
        public String Node { get; set; }

        public String Time { get; set; }
        
        public String ExecuteSql { get; set; }

        public List<String> Parameters { get; set; }        

        public long Duration { get; set; }
    }
}
