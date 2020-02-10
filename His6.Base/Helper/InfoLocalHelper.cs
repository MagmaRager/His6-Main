using System;
using System.Collections.Generic;
using System.Linq;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：本地信息处理类
    /// 功能描述：通过本处理类实现对象之间的信息传送，
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public static class InfoLocalHelper
    {
        #region 变量

        private static Dictionary<String, List<InfoLocalAction>> _ActionDict;    //  信息代码及本地信息功能对象列表

        #endregion

        #region 属性

        /// <summary>
        ///  是否有订阅的信息
        /// </summary>
        /// <returns></returns>
        public static bool HaveInfo
        {
            get
            {
                if(_ActionDict.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (var item in _ActionDict)
                    {
                        if(item.Value.Count > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }

        #endregion

        #region 函数

        /// <summary>
        ///  初始化函数
        /// </summary>
        static InfoLocalHelper()
        {
            _ActionDict = new Dictionary<string, List<InfoLocalAction>>();
        }

        /// <summary>
        ///  注册信息
        /// </summary>
        /// <param name="infoAction">带信息功能的对象</param>
        /// <param name="infoCodeList">需要注册的信息列表</param>
        /// <returns></returns>
        public static bool RegisterInfo(InfoLocalAction infoAction, List<String> infoCodeList)
        {
            if (infoAction == null || infoCodeList.Count == 0)
            {
                LogHelper.Warn(typeof(InfoLocalHelper).FullName, "注册时对象不能空或没有接受信息代码");
                return false;
            }

            foreach (String code in infoCodeList)
            {
                if (!_ActionDict.ContainsKey(code))                //  信息代码不存在
                {
                    _ActionDict.Add(code, new List<InfoLocalAction>());
                }

                //  是否已经存在，不存在新加入
                List<InfoLocalAction> lst = _ActionDict[code];
                if (!lst.Exists(o => o == infoAction))
                {
                    lst.Add(infoAction);
                }
            }
            LogHelper.Info(typeof(InfoLocalHelper).FullName, infoAction.GetType().FullName + "注册本地信息,代码：" + string.Join(",", infoCodeList.ToArray()));

            return true;
        }

        /// <summary>
        ///  撤消信息
        /// </summary>
        /// <param name="infoAction">带信息功能的对象</param>
        /// <returns></returns>
        public static bool RevokeInfo(InfoLocalAction infoAction)
        {
            if (infoAction == null)
            {
                return false;
            }

            //  清理字典
            List<String> keys = _ActionDict.Keys.ToList<String>();
            foreach (String key in keys)
            {
                var item = _ActionDict[key];
                if (item.Exists(o => o == infoAction))
                {
                    item.Remove(infoAction);
                }

                if (item.Count == 0)
                {
                    _ActionDict.Remove(key);
                }
            }
            LogHelper.Info(typeof(InfoLocalHelper).FullName, infoAction.GetType().FullName + "撤消本地信息");

            return true;
        }


        /// <summary>
        ///  发送信息
        /// </summary>
        /// <param name="infoCode">信息代码</param>
        /// <param name="info">内容</param>
        /// <returns></returns>
        public static bool SendInfo(string infoCode, string info)
        {
            bool succeed = true;
            //  接受对应信息代码的功能执行回调
            List<InfoLocalAction> actions = _ActionDict[infoCode];
            LogHelper.Info(typeof(InfoLocalHelper).FullName, "开始发送本地信息，代码："+ infoCode + " 内容：" + info);
            if (actions != null)
            {
                foreach (InfoLocalAction ac in actions)
                {
                    try
                    {
                        LogHelper.Info(typeof(InfoLocalHelper).FullName, ac.GetType().FullName + "开始回调");
                        ac.Callback(infoCode, info);
                    }
                    catch (Exception ex)
                    {
                        succeed = false;
                        LogHelper.Error(typeof(InfoLocalHelper).FullName, "本地信息互相调用异常..." + ex.Message);
                    }
                }
            }

            return succeed;
        }

        #endregion

    }
}
