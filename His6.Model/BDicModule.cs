using System;
using System.Collections.Generic;

namespace His6.Model
{
    public class BDicModule
    {
        /// <summary>
        /// 模块代码
        /// </summary>
        public String Code { get; set; }
        /// <summary>
        /// 模块名
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 模块程序文件
        /// </summary>
        public String Filename { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public String Version { get; set; }
        /// <summary>
        /// 是否有效（1是/0否）
        /// </summary>
        public String UsedFlag { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Describe { get; set; }
        /// <summary>
        /// 文件时间
        /// </summary>
        public String FileTime { get; set; }
        /// <summary>
        /// 模块对象列表
        /// </summary>
        public List<BDicObject> ObjectList { get; set; }

        /// <summary>
        /// 复制模块信息至当前实体
        /// </summary>
        /// <param name="smcp"></param>
        public void CopyInfo(BDicModule smcp)
        {
            this.Code = smcp.Code;
            this.Name = smcp.Name;
            this.Filename = smcp.Filename;
            this.FileTime = smcp.FileTime;
            this.Version = smcp.Version;
            this.UsedFlag = smcp.UsedFlag;
            this.Describe = smcp.Describe;
        }
    }
}
