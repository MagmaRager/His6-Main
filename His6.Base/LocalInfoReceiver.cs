using System;
using System.Collections.Generic;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：本地信息接受对象
    /// 功能描述：实现可接受本地信息功能,接受的信息代码设置在infoCodeList, 销毁时调用Close()用于回收注册的信息。
    ///         
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class LocalInfoReceiver : IDisposable
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
        public LocalInfoReceiver(List<String> codes, OnCallbackInfo callback)
        {
            infoCodeList = codes;
            callbackInfo = callback;

            //  注册信息码
            if (infoCodeList.Count > 0)
            {
                LocalInfoHelper.RegisterInfo(this, infoCodeList);
            }
        }

         /// <summary>
        ///  信息功能关闭
        /// </summary>
        public void Close()
        {
            if (infoCodeList != null && infoCodeList.Count > 0)
            {
                LocalInfoHelper.RevokeInfo(this);
                infoCodeList = null;
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

        /// <summary>
        ///  实现销毁接口，防止没有调用Close方法
        /// </summary>
        public void Dispose()
        {
            if (infoCodeList != null && infoCodeList.Count > 0)
            {
                LocalInfoHelper.RevokeInfo(this);
            }
        }
    }

}
