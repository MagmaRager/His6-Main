using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using His6.Model;

namespace His6.SysSetup
{
    public class SystemWithRight
    {
        public BDictSystem SystemInfo { get; set; }

        public List<BDictRole> RoleList { get; set; }

        public List<DataEmpDir> EmpList { get; set; }
        
    }
}
