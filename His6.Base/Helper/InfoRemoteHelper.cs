using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：远程信息处理类
    /// 功能描述：通过ActiveMQ消息服务实现信息的传送，
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public static class InfoRemoteHelper
    {
        #region 变量

        private static String _BrokerUri;                                   //  代理Uri
        private static Double _TimeoutSeconds = 3;                          //  消息发送过期时间
        private static String _TopicName = "His6";                    //  主题名称                      

        private static IConnection _Connection;                             //  连接对象
        private static ISession _Session;                                   //  会话对象
        private static IMessageConsumer _Consumer;                          //  消息消费对象

        private static Dictionary<String, List<InfoRemoteAction>> _ActionDict;    //  信息代码及远程信息功能对象列表

        #endregion

        #region 属性

        /// <summary>
        ///  是否连接
        /// </summary>
        public static bool IsConnected
        {
            get
            {
                return _Session != null ;
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
        static InfoRemoteHelper()
        {
            _BrokerUri = "tcp://localhost:61616";                //??  
            _TimeoutSeconds = 5;            //??  
            _TopicName = "His6";      //??  
            _ActionDict = new Dictionary<string, List<InfoRemoteAction>>();
        }


        /// <summary>
        ///  连接服务
        /// </summary>
        /// <returns></returns>
        public static bool ConnectServer()
        {
            bool succeed = false;
            try
            {
                //  加工对象
                IConnectionFactory factory = new ConnectionFactory(_BrokerUri);

                // 产生连接  
                _Connection = factory.CreateConnection();
                //  使用 机器IP : 系统代码 ： 客户代码  代表客户标识
                _Connection.ClientId = EnvInfo.ComputerIp + ":" + EnvInfo.SystemCode + ":" + EmpInfo.Id.ToString() ;

                _Connection.ExceptionListener += new ExceptionListener(Connection_ExceptionListener);
                _Connection.Start();
                LogHelper.Info(typeof(InfoRemoteHelper).FullName, "消息服务连接成功... " + _BrokerUri);

                // 产生会话  
                _Session = _Connection.CreateSession();
                succeed = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(InfoRemoteHelper).FullName, "消息服务连接不成功..." + ex.Message);
                DisConnect();
            }
            return succeed;
        }

        /// <summary>
        ///  断开连接
        /// </summary>
        public static void DisConnect()
        {
            try
            {
                if (_Consumer != null)
                {
                    _Consumer.Close();
                    _Consumer.Dispose();
                }
                if (_Session != null)
                {
                    _Session.Close();
                    _Session.Dispose();
                }
                if (_Connection != null)
                {
                    _Connection.Close();
                    _Connection.Dispose();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        ///  连接异常
        /// </summary>
        /// <param name="ex"></param>
        private static void Connection_ExceptionListener(Exception ex)
        {
            LogHelper.Error(typeof(InfoRemoteHelper).FullName, "消息服务连接异常..." + ex.Message);
            DisConnect();
        }

        /// <summary>
        ///  异步消息获取
        /// </summary>
        /// <param name="message"></param>
        private static void consumer_Listener(IMessage message)
        {
            try
            {
                ITextMessage recieveMessage = (ITextMessage)message;
                String infoCode = recieveMessage.Properties.GetString("InfoCode");
                String infoBody = recieveMessage.Text;

                //  取发送者信息
                StringBuilder sb = new StringBuilder();
                sb.Append("接受到消息： \r\n    用户Id：");
                sb.Append(recieveMessage.Properties.GetString("SendClientId"));
                sb.Append("用户名：");
                sb.Append(recieveMessage.Properties.GetString("SendClientName"));
                sb.Append("系统代码：");
                sb.Append(recieveMessage.Properties.GetString("SendSysCode"));
                sb.Append("机器IP：");
                sb.AppendLine(recieveMessage.Properties.GetString("SendComputerIP"));
                sb.Append("    信息代码：");
                sb.AppendLine(infoCode);
                sb.Append("    信息内容：");
                sb.AppendLine(infoBody);

                LogHelper.Info(typeof(InfoRemoteHelper).FullName, sb.ToString());

                //  接受对应信息代码的功能执行回调
                List<InfoRemoteAction> actions = _ActionDict[infoCode];
                if(actions != null)
                {
                    foreach (InfoRemoteAction ac in actions)
                    {
                        ac.Callback(infoCode, infoBody);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(InfoRemoteHelper).FullName, "接受消息过程出错Message：" + ex.Message + "\r\nStackTrace:" + ex.StackTrace);
            }
        }

        /// <summary>
        ///  注册信息
        /// </summary>
        /// <param name="infoAction">带信息功能的对象</param>
        /// <param name="infoCodeList">需要注册的信息列表</param>
        /// <returns></returns>
        public static bool RegisterInfo(InfoRemoteAction infoAction, List<String> infoCodeList)
        {
            if (infoAction == null || infoCodeList.Count == 0)
            {
                LogHelper.Warn(typeof(InfoRemoteHelper).FullName, "注册时对象不能空或没有接受信息代码");
                return false;
            }

            bool reRegister = false;      //  标志是否需要重新注册
            foreach (String code in infoCodeList)
            {
                if ( !_ActionDict.ContainsKey(code))                //  信息代码不存在
                {
                    _ActionDict.Add(code, new List<InfoRemoteAction>());
                    reRegister = true;
                }

                //  是否已经存在，不存在新加入
                List<InfoRemoteAction> lst = _ActionDict[code];
                if (!lst.Exists(o => o == infoAction) ) 
                {
                    lst.Add(infoAction);
                };
            }
            LogHelper.Info(typeof(InfoRemoteHelper).FullName, infoAction.GetType().FullName + "注册远程信息,代码：" + string.Join(",", infoCodeList.ToArray()));

            if (reRegister)
            {
                return Subscribe();
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        ///  撤消信息
        /// </summary>
        /// <param name="infoAction">带信息功能的对象</param>
        /// <returns></returns>
        public static bool RevokeInfo(InfoRemoteAction infoAction)
        {
            if (infoAction == null)
            {
                return false;
            }

            bool reRegister = false;      //  标志是否需要重新注册
            
            //  清理字典
            List<String> keys =_ActionDict.Keys.ToList<String>();
            foreach (String key in keys)
            {
                var item = _ActionDict[key];
                if (item.Exists( o => o == infoAction))
                {
                    item.Remove(infoAction);
                }

                if(item.Count == 0)
                {
                    _ActionDict.Remove(key);
                    reRegister = true;
                }
            }
            LogHelper.Info(typeof(InfoRemoteHelper).FullName, infoAction.GetType().FullName + "撤消远程信息");


            if (reRegister)
            {
                return Subscribe();
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        ///  消息订阅(使用public目的是连接断了以后可以调用本函数重新订阅)
        /// </summary>
        /// <returns></returns>
        public static bool Subscribe()
        {
            bool succeed = false;
            if (!IsConnected)
            {
                ConnectServer();
            }
            if (IsConnected)
            {
                try
                {
                    if (_Consumer != null)
                    {
                        _Consumer.Close();
                    }

                    //  形成订阅消息，如: InfoCode = 'A1' OR InfoCode = 'B1' OR InfoCode = 'C2'  (空时为注销)
                    StringBuilder sb = new StringBuilder();
                    foreach (var key in _ActionDict.Keys)
                    {
                        sb.Append("OR InfoCode ='" + key + "' ");
                    }
                    String messageFilter = sb.ToString(3, sb.Length - 3);

                    if (messageFilter.Length > 0)
                    {
                        // 产生功能消费者
                        _Consumer = _Session.CreateConsumer(new ActiveMQTopic(_TopicName), messageFilter, false);
                        _Consumer.Listener += new MessageListener(consumer_Listener);
                    }
                    succeed = true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(typeof(InfoRemoteHelper).FullName, "消息服务订阅消息异常..." + ex.Message);
                    DisConnect();
                }
            }
            return succeed;
        }


        /// <summary>
        ///  发送信息
        /// </summary>
        /// <param name="infoCode">信息代码</param>
        /// <param name="info">内容</param>
        /// <returns></returns>
        public static bool SendInfo(string infoCode, string info)
        {
            bool succeed = false;
            IMessageProducer producer = null;
            if ( !IsConnected )
            {
                ConnectServer();
            }

            if (IsConnected)
            {
                try
                {
                    producer = _Session.CreateProducer(new ActiveMQTopic(_TopicName));
                    ITextMessage sendMessage = producer.CreateTextMessage();
                    sendMessage.Text = info;
                    sendMessage.Properties.SetString("InfoCode", infoCode);                        //  信息代码 

                    //  加入相关属性
                    sendMessage.Properties.SetString("SendClientCode", EmpInfo.Id.ToString());     //  发送客户号 
                    sendMessage.Properties.SetString("SendClientName", EmpInfo.Name);              //  发送客户名 
                    sendMessage.Properties.SetString("SendSystemCode", EnvInfo.SystemCode);        //  发送系统代码
                    sendMessage.Properties.SetString("SendComputerIP", EnvInfo.ComputerIp);        //  发送机器IP

                    producer.Send(sendMessage, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.FromSeconds(_TimeoutSeconds));
                    succeed = true;
                    LogHelper.Info(typeof(InfoRemoteHelper).FullName, "消息服务发送成功，信息代码：" + infoCode + " 信息内容：" + info);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(typeof(InfoRemoteHelper).FullName , "消息服务发送消息异常..." + ex.Message);
                    DisConnect();
                }
            }
            return succeed;
        }

        #endregion

    }
}
