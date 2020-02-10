using System;
using System.Collections.Generic;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：本地信息功能
    /// 功能描述：实现可接受信息功能,接受的信息代码设置在infoCodeList, 销毁时调用Close()用于回收注册的信息。
    ///         
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class InfoLocalAction : IDisposable
    {
        #region 常用信息代码定义

        //  要求主窗口打开新窗口
        public const string OpenForm = "OpenForm";

        #endregion

        //  回调函数
        private OnCallbackInfo callbackInfo ;
        //  接受的信息代码列表
        private List<String> infoCodeList ;

        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="codes">接受的信息列表</param>
        /// <param name="callback">回调函数</param>
        public InfoLocalAction(List<String> codes, OnCallbackInfo callback)
        {
            infoCodeList = codes;
            callbackInfo = callback;

            //  注册信息码
            if (infoCodeList.Count > 0)
            {
                InfoLocalHelper.RegisterInfo(this, infoCodeList);
            }
        }


        /// <summary>
        ///  信息功能关闭
        /// </summary>
        public void Close()
        {
            if (infoCodeList.Count > 0)
            {
                InfoLocalHelper.RevokeInfo(this);
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
                InfoLocalHelper.RevokeInfo(this);
            }
        }
    }

}
