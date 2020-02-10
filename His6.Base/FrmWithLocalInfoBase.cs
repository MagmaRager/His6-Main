using System;
using System.Collections.Generic;

namespace His6.Base
{
    /// <summary>
    /// 
    /// 文 件 名：带接收远程信息的基类窗口
    /// 功能描述：属性： 接收信息代码列表 _infoCodeList，用于记录本窗口的接收的信息。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：

    public partial class FrmWithLocalInfoBase : FrmBase
    {
        protected LocalInfoReceiver _InfoAction ;

        // 窗口接收信息码
        protected List<string> _InfoCodeList = new List<string>();

        public FrmWithLocalInfoBase()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            _InfoAction.Close();
            base.OnClosed(e);
        }

        /// <summary>
        ///  注意：调用前子类必须设置好_infoCodeList。
        /// </summary>
        /// <returns></returns>
        public override bool Init()
        {
            _InfoAction = new LocalInfoReceiver(_InfoCodeList, CallbackInfo);

            return base.Init();
        }

        /// <summary>
        ///  信息回调函数，实现接收信息后的相关处理。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        protected virtual void CallbackInfo(string infoCode, string infoBody)
        { }

    }
}
