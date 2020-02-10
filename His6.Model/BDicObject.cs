using System;
using System.Collections.Generic;

namespace His6.Model
{
    public class BDicObject
    {
        /// <summary>
        /// 代码
        /// </summary>
        public String Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 对象名称
        /// </summary>
        public String Object { get; set; }
        /// <summary>
        /// 模块代码
        /// </summary>
        public String ModuleCode { get; set; }
        /// <summary>
        /// 是否有效（1是/0否）
        /// </summary>
        public String UsedFlag { get; set; }
        /// <summary>
        /// 是否功能菜单(1是/0否)
        /// </summary>
        public String IsFunction { get; set; }
        /// <summary>
        /// 是否有功能点(1是/0否)
        /// </summary>
        public String IsFunctionPoint { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Describe { get; set; }
        /// <summary>
        /// 默认图标
        /// </summary>
        public String Ico { get; set; }
        /// <summary>
        /// 对象功能点列表
        /// </summary>
        public List<BDicFunctionPoint> FpList { get; set; }

        /// <summary>
        /// 复制对象信息至当前实体
        /// </summary>
        /// <param name="socp"></param>
        public void CopyInfo(BDicObject socp)
        {
            this.Code = socp.Code;
            this.Name = socp.Name;
            this.Object = socp.Object;
            this.ModuleCode = socp.ModuleCode;            
            this.UsedFlag = socp.UsedFlag;
            this.IsFunction = socp.IsFunction;
            this.IsFunctionPoint = socp.IsFunctionPoint;
            this.Describe = socp.Describe;
            this.Ico = socp.Ico;
        }
    }
}
