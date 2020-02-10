using System;
using System.Collections.Generic;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：远程信息接受对象
    /// 功能描述：实现可接受信息功能,接受的信息代码设置在infoCodeList, 销毁时调用Close()用于回收注册的信息。
    ///           注意回调函数是可视控件（如：窗口）的方法且改动可视对象时需要回调主线程的方法，如：
    ///   
    ///     public virtual void SynCallbackInfo(string infoBody)
    ///     {
    ///         if (this.InvokeRequired)
    ///         {
    ///             OnCallbackInfo m = new OnCallbackInfo(CallbackInfo);
    ///             this.Invoke(m, new object[] { infoBody });
    ///         }
    ///         else
    ///         {
    ///             InfoRecieved(infoBody);    //  主线程方法, 
    ///         }
    ///     }
    ///         
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class RemoteInfoReceiver : IDisposable
    {

        //  回调函数
        private OnCallbackInfo callbackInfo ;
        //  接受的信息代码列表
        private List<String> infoCodeList ;

        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="codes">接受的信息列表</param>
        /// <param name="callback">回调函数</param>
        public RemoteInfoReceiver(List<String> codes, OnCallbackInfo callback)
        {
            infoCodeList = codes;
            callbackInfo = callback;

            //  注册信息码
            if (infoCodeList.Count > 0)
            {
                RemoteInfoHelper.RegisterInfo(this, infoCodeList);
            }
        }


        /// <summary>
        ///  信息功能关闭
        /// </summary>
        public void Close()
        {
            if (infoCodeList != null && infoCodeList.Count > 0)
            {
                RemoteInfoHelper.RevokeInfo(this);
                infoCodeList = null;
            }

        }

        /// <summary>
        ///  防止没有主动调用Close
        /// </summary>
        public void Dispose()
        {
            if (infoCodeList != null && infoCodeList.Count > 0)
            {
                RemoteInfoHelper.RevokeInfo(this);
            }
        }

        /// <summary>
        ///  接受信息后回调函数
        /// </summary>
        /// <param name="infoBody"></param>
        public void Callback(String infoCode, String infoBody)
        {
            callbackInfo(infoCode, infoBody);
        }

    }

    /// <summary>
    ///  接受到信息后的回调函数委托
    /// </summary>
    /// <param name="functionInfo"></param>
    public delegate void OnCallbackInfo(string infoCode, string functionInfo);

}
