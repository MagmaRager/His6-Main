using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Main
{
    public class SqlMonitorInfo
    {
        public String Header { get; set; }

        public long Time { get; set; }

        public string TimeStr
        {
            get
            {
                var date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                date = date.AddMilliseconds(Time);
                return date.ToString();
            }
        }

        public String ExecuteSql { get; set; }

        public List<String> Parameters { get; set; }

        public string ParameterList
        {
            get
            {
                if (Parameters.Count == 0) return "无";
                String ps = "";
                foreach(String p in Parameters)
                {
                    ps += p + " ※ ";                    
                }
                return ps;
            }
        }

        public long Duration { get; set; }
    }
}
