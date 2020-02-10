using System;
using System.Collections.Generic;

namespace His6.Base
{
    /// <summary>
    /// 
    /// 文 件 名：带接收信息基类窗口
    /// 功能描述：属性： 接收信息代码列表 _infoCodeList，用于记录本窗口的接收的信息。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：

    public partial class FrmBaseWithRecieveInfo : FrmBase
    {
        protected RemoteInfoReceiver _InfoAction ;

        // 窗口接收信息码
        protected List<string> _InfoCodeList = new List<string>();

        public FrmBaseWithRecieveInfo()
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
            _InfoAction = new RemoteInfoReceiver(_InfoCodeList, SynCallbackInfo);

            return base.Init();
        }

        /// <summary>
        ///  异步远程信息回调函数，用于实现在主线程调用CallbackInfo函数。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        protected virtual void SynCallbackInfo(string infoCode, string infoBody)
        {
            if (this.InvokeRequired)
            {
                OnCallbackInfo m = new OnCallbackInfo(CallbackInfo);
                this.Invoke(m, new object[] { infoCode, infoBody });
            }
            else
            {
                CallbackInfo(infoCode, infoBody);
            }
        }

        /// <summary>
        ///  远程信息回调函数，实现接收信息后的相关处理。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        protected virtual void CallbackInfo(string infoCode, string infoBody)
        { }

    }
}
