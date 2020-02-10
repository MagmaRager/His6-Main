using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Model.Base
{
    [Serializable]
    public class BaseEntity
    {
        /// <summary>
        /// 1:新增，2:修改
        /// </summary>
        [JsonIgnore]
        public int EditState { get; set; }
    }
}
