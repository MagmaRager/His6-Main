using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using EasyNetQ;

namespace His6.Base
{
    /// <summary>
    /// MQ信息处理
    /// RabbitMQ信息处理
    /// </summary>

    public class RemoteInfoMQ : IRemoteInfo
    {
        #region 变量

        private bool _Cancel = false;                        //  是否取消连接消息服务
        private bool _SubscribeFlag = false;                 //  是否已经订阅
        private string _ConnString = string.Empty;           //  消息服务连接串
        private IBus _Bus = null;                            //  消息服务对象
        private string _SubscribeId = EnvInfo.ComputerIp + " ||" + EnvInfo.SystemCode;    //  订阅ID

        public Dictionary<string, List<RemoteInfoReceiver>> _ActionDict
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        } //  信息代码及远程信息功能对象列表

        #endregion

        /*
        #region 属性

        /// <summary>
        ///  是否连接
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return _Bus.IsConnected;
            }
        }

        /// <summary>
        ///  是否有订阅的信息
        /// </summary>
        /// <returns></returns>
        public bool HaveInfo
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
    */
        #region 函数

        /// <summary>
        ///  初始化函数
        /// </summary>
        public RemoteInfoMQ()
        {
            _ActionDict = new Dictionary<string, List<RemoteInfoReceiver>>();
            // TODO： 获取信息服务URI
            _ConnString = "";//"host=192.168.0.109:5672;username=h13584;password=123456";

            if (_ConnString == null || _ConnString == string.Empty)
            {
                LogHelper.Error(typeof(RemoteInfoMQ).FullName, "RabbitMQ 服务地址没有配置");
                _Cancel = true;
                return;
            }

            //  初始化对象
            _Bus = RabbitHutch.CreateBus(_ConnString);
            _Bus.Dispose();
            
        }

        /// <summary>
        ///  连接服务
        /// </summary>
        public void Connection()
        {
            if (_Cancel)
            {
                return;
            }
            try
            {
                _Bus = RabbitHutch.CreateBus(_ConnString);
            }
            catch (Exception ex)
            {
                string msg = "RabbitMQ 服务连接出错：" + ex.Message;
                msg += "\r\n异常跟踪:" + ex.StackTrace;
                if (ex.InnerException != null)
                {
                    msg += "\r\n异常消息：" + ex.InnerException.Message + "\r\n异常错误:" + ex.InnerException.StackTrace;
                }
                LogHelper.Error(typeof(RemoteInfoMQ).FullName, msg);
            }
        }

        /// <summary>
        ///  检测消息服务是否连接
        /// </summary>
        /// <returns></returns>
        public bool CheckConnect()
        {
            if (!_Bus.IsConnected)
            {
                if (_Cancel)
                {
                    return false;
                }
                else
                {
                    Connection();
                }
            }

            if (!_Bus.IsConnected)
            {
                if(MessageHelper.ShowYesNoAndQuestion("消息服务连接不成功，是否关闭？") == System.Windows.Forms.DialogResult.Yes)
                {
                    _Cancel = true;
                }
            }

            return _Bus.IsConnected;
        }

        /// <summary>
        ///  注册信息
        /// </summary>
        /// <param name="infoAction">带信息功能的对象</param>
        /// <param name="infoCodeList">需要注册的信息列表</param>
        /// <returns></returns>
        public bool RegisterInfo(RemoteInfoReceiver infoAction, List<String> infoCodeList)
        {
            if (infoAction == null || infoCodeList.Count == 0)
            {
                LogHelper.Warn(typeof(RemoteInfoMQ).FullName, "注册时对象不能空或没有接受信息代码");
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
                };
            }
            LogHelper.Info(typeof(RemoteInfoMQ).FullName, infoAction.GetType().FullName + "注册远程信息,代码：" + string.Join(",", infoCodeList.ToArray()));

            if (!_SubscribeFlag)        //  没有订阅开启订阅
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
        public void RevokeInfo(RemoteInfoReceiver infoAction)
        {
            if (infoAction == null)
            {
                return ;
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
            LogHelper.Info(typeof(RemoteInfoMQ).FullName, infoAction.GetType().FullName + "撤消远程信息");


            if (_ActionDict.Count == 0 && _Bus != null)     //  没有订阅的消息自动关闭
            {
                _Bus.Dispose();
                _SubscribeFlag = false;
            }
            return ;
        }

        /// <summary>
        ///  消息接收后处理
        /// </summary>
        /// <param name="md"></param>
        private void CallBack(MessageData md)
        {
            //  取发送者信息
            StringBuilder sb = new StringBuilder();
            sb.Append("接受到消息： \r\n    用户Id：");
            sb.Append(md.SendEmpId);
            sb.Append("系统代码：");
            sb.Append(md.SendSystemCode);
            sb.Append("对象名称：");
            sb.Append(md.SendObject);
            sb.Append("IP：");
            sb.Append(md.SendIP);
            sb.Append("\r\n    信息代码：");
            sb.AppendLine(md.Code);
            sb.Append("    信息内容：");
            sb.AppendLine(md.Info);

            LogHelper.Info(typeof(RemoteInfoMQ).FullName, sb.ToString());
            
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
        public bool Subscribe()
        {
            bool succeed = false;
            try
            {
                if (CheckConnect())
                {
                    _Bus.Subscribe<MessageData>(_SubscribeId, msg => CallBack(msg as MessageData));
                    _SubscribeFlag = true;
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoMQ).FullName, "消息服务订阅消息异常..." + ex.Message);
            }
            return succeed;
        }

        public void Publish(string topic, string info)
        {
            try
            {
                if (CheckConnect())
                {
                    MessageData md = new MessageData();
                    md.Code = topic;
                    md.Info = info;
                    md.SendIP = EnvInfo.ComputerIp;
                    md.SendSystemCode = EnvInfo.SystemCode;
                    md.SendEmpId = EmpInfo.Id;
                    _Bus.Publish<MessageData>(md);                    
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoMQ).FullName, "消息服务发布异常..." + ex.Message);
            }
        }


        /// <summary>
        ///  发送信息
        /// </summary>
        /// <param name="infoCode">信息代码</param>
        /// <param name="info">内容</param>
        /// <param name="sendObject">发送对象</param>
        /// <returns></returns>
        public bool SendInfo(string infoCode, string info, string sendObject = "" )
        {
            bool succeed = false;
            try
            {
                MessageData md = new MessageData();
                md.Code = infoCode;
                md.Info = info;
                md.SendIP = EnvInfo.ComputerIp;
                md.SendSystemCode = EnvInfo.SystemCode;
                md.SendEmpId = EmpInfo.Id;
                md.SendObject = sendObject;

                if (CheckConnect())
                {
                    _Bus.Publish<MessageData>(md);
                    if (!_SubscribeFlag)
                    {
                        _Bus.Dispose();
                    }
                }
                succeed = true;
                LogHelper.Info(typeof(RemoteInfoMQ).FullName, "消息服务发送成功，信息代码：" + infoCode + " 信息内容：" + info);
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoMQ).FullName, "消息服务发送消息异常..." + ex.Message);
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

            //  发送者IP
            public string SendIP { set; get; }

            //  发送者系统代码
            public string SendSystemCode { set; get; }

            //  发送者对象名称
            public string SendObject { set; get; }

            //  发送者员工ID
            public int SendEmpId { set; get; }
        }
    }
}
