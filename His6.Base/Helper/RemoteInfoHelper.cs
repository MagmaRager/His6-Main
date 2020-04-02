﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：远程信息处理类
    /// 功能描述：通过消息服务实现信息的传送，
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public static class RemoteInfoHelper
    {
        #region 变量

        private static bool _Connected = false;                        //  是否连接消息服务
        //private static bool _SubscribeFlag = false;                 //  是否已经订阅
        //private static string _ConnString = string.Empty;           //  消息服务连接串
        //private static IBus _Bus = null;                            //  消息服务对象
        //private static string _SubscribeId = EnvInfo.ComputerIp + " ||" + EnvInfo.SystemCode;    //  订阅ID
        
        private static IRemoteInfo remoteInfo;
        private static Dictionary<String, List<RemoteInfoReceiver>> _ActionDict;    //  信息代码及远程信息功能对象列表

        #endregion

        #region 属性

        /// <summary>
        ///  是否连接
        /// </summary>
        public static bool IsConnected
        {
            get
            {
                return _Connected;
            }
        }

        /// <summary>
        ///  是否有订阅的信息
        /// </summary>
        /// <returns></returns>
        public static bool HaveInfo
        {
            get
            {
                if (_ActionDict.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (var item in _ActionDict)
                    {
                        if (item.Value.Count > 0)
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
        static RemoteInfoHelper()
        {
            String mqUrl = System.Configuration.ConfigurationManager.AppSettings.Get("MQUrl");
            _ActionDict = new Dictionary<string, List<RemoteInfoReceiver>>();

            if (mqUrl.Substring(0, 4).ToUpper().Equals("NATS"))
            {
                remoteInfo = new RemoteInfoNATS { };
            }
            else
            {
                //remoteInfo = new RemoteInfoMQ { };
            }
            if(remoteInfo.Init(mqUrl, CallBack))
            {
                _Connected = true;
            }
        }

        /// <summary>
        ///  注册信息
        /// </summary>
        /// <param name="infoAction">带信息功能的对象</param>
        /// <param name="infoCodeList">需要注册的信息列表</param>
        /// <returns></returns>
        public static bool RegisterInfo(RemoteInfoReceiver infoAction, List<String> infoCodeList)
        {           
            if (infoAction == null || infoCodeList.Count == 0)
            {
                LogHelper.Warn(typeof(RemoteInfoHelper).FullName, "注册时对象不能空或没有接受信息代码");
                return false;
            }

            foreach (String code in infoCodeList)
            {
                if (!_ActionDict.ContainsKey(code))                //  信息代码不存在
                {
                    _ActionDict.Add(code, new List<RemoteInfoReceiver>());
                }

                //  是否已经存在，不存在新加入
                List<RemoteInfoReceiver> lst = _ActionDict[code];
                if (!lst.Exists(o => o == infoAction))
                {
                    lst.Add(infoAction);
                    if (_Connected)
                    {
                        remoteInfo.Subscribe(code);
                    }
                };
            }
            LogHelper.Info(typeof(RemoteInfoHelper).FullName, infoAction.GetType().FullName + "注册远程信息,代码：" + string.Join(",", infoCodeList.ToArray()));
            
            return true;
        }

        /// <summary>
        ///  撤消信息
        /// </summary>
        /// <param name="infoAction">带信息功能的对象</param>
        /// <returns></returns>
        public static void RevokeInfo(RemoteInfoReceiver infoAction)
        {
            if (infoAction == null)
            {
                return;
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
                    if (_Connected)     // 重新订阅
                    {
                        remoteInfo.Unsubscribe(key);
                    }
                }
            }
            LogHelper.Info(typeof(RemoteInfoHelper).FullName, infoAction.GetType().FullName + "撤消远程信息");
            
            
            return;
        }

        /// <summary>
        ///  消息接收后处理
        /// </summary>
        /// <param name="md"></param>
        private static void CallBack(string msg)
        {
            MessageData md = new MessageData();
            LogHelper.Info(typeof(RemoteInfoHelper).FullName, "接收消息：" + msg);
            try
            {
                md = StringHelper.DeserializeObject<MessageData>(msg);
            }
            catch(Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoHelper).FullName, ex.Message);
            }            
                       
            //  接受对应信息代码的功能执行回调
            List<RemoteInfoReceiver> actions = _ActionDict[md.Code];
            if (actions != null)
            {
                foreach (RemoteInfoReceiver ac in actions)
                {
                    ac.Callback(md.Code, md.Info);
                }
            }
        }


        /// <summary>
        ///  消息订阅
        /// </summary>
        /// <returns></returns>
        public static bool Subscribe(string topic)
        {
            bool succeed = false;
            try
            {
                if (remoteInfo.CheckConnect())
                {
                    remoteInfo.Subscribe(topic);
                    //_Bus.Subscribe<MessageData>(_SubscribeId, msg => CallBack(msg as MessageData));
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoHelper).FullName, "消息服务订阅消息异常..." + ex.Message);
            }
            return succeed;
        }

        public static void Close()
        {
            if (_Connected)
            {
                remoteInfo.Close();
            }
        }

        /// <summary>
        ///  发送信息
        /// </summary>
        /// <param name="infoCode">信息代码</param>
        /// <param name="info">内容</param>
        /// <param name="sendObject">发送对象</param>
        /// <returns></returns>
        public static bool SendInfo(string infoCode, string info)
        {
            bool succeed = false;
            try
            {
                MessageData md = new MessageData();
                md.Code = infoCode;
                md.Info = info;
                md.SendIP = EnvInfo.ComputerIp;
                md.SendEmpId = EmpInfo.Id;

                if (remoteInfo.CheckConnect())
                {
                    String infoStr = StringHelper.SerializeObject<MessageData>(md);
                    remoteInfo.Publish(infoCode, infoStr);
                    
                }
                succeed = true;
                LogHelper.Info(typeof(RemoteInfoHelper).FullName, "消息服务发送成功，信息代码：" + infoCode + " 信息内容：" + info);
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoHelper).FullName, "消息服务发送消息异常..." + ex.Message);
            }
            return succeed;
        }

        #endregion




        internal class MessageData
        {
            //  消息代码
            public string Code { set; get; }

            //  信息内容
            public string Info { set; get; }

            //  发送者ip
            public string SendIP { set; get; }            

            //  发送者员工id
            public int SendEmpId { set; get; }
        }
    }
}