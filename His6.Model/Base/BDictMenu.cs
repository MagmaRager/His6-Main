using System;
using System.Collections.Generic;

namespace His6.Model
{
    public class BDictMenu
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public int SystemId { get; set; }
        /// <summary>
        /// 菜单代码（按代码分层级）
        /// </summary>
        public String Code { get; set; }
        /// <summary>
        /// 菜单标题
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 对象代码
        /// </summary>
        public String ObjectCode { get; set; }
        /// <summary>
        /// 图标文件
        /// </summary>
        public String Ico { get; set; }
        /// <summary>
        /// 菜单提示信息
        /// </summary>
        public String Prompt { get; set; }
        /// <summary>
        /// 打开方式  0弹出 /1新开/2存在(且参数一致)激活，否则新开/3存在激活否则新开
        /// </summary>
        public int WinState { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public String Parameter { get; set; }
    }
}
