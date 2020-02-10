using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
  public  class BaseResultPageInfo<T>: BaseResultData<T>
    {
        public PageInfo PageInfo { get; set; }
    }
}
