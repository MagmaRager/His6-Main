using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using NATS.Client;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：远程信息处理类
    /// 功能描述：通过RabbitMQ消息服务实现信息的传送，
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class RemoteInfoNATS : IRemoteInfo
    {
        #region 变量

        private Dictionary<String, IAsyncSubscription> sAsyncList = new Dictionary<string, IAsyncSubscription>();                  // 订阅异步消息对象
        private bool _Cancel = false;                        //  是否取消连接消息服务
        //private bool _SubscribeFlag = false;                 //  是否已经订阅
        private string _ConnString = string.Empty;           //  消息服务连接串
        private IConnection _conn = null;                     //  消息服务对象
        //private string _SubscribeId = EnvInfo.ComputerIp + " ||" + EnvInfo.SystemCode;   //  订阅ID
        private Action<string> _Callback;            //回调函数

        #endregion

        #region 函数

        /// <summary>
        ///  初始化函数
        /// </summary>
        //public RemoteInfoNATS()
        //{
           
        //    //_ActionDict = new Dictionary<string, List<RemoteInfoReceiver>>();

        //    // Create a new connection factory to create
        //    // a connection.
        //    ConnectionFactory cf = new ConnectionFactory();

        //    _ConnString = "nats://192.168.207.213:4222";
        //    // Creates a live connection to the default
        //    // NATS Server running locally
        //    _conn = cf.CreateConnection(_ConnString);

            
        //    // Setup an event handler to process incoming messages.
        //    // An anonymous delegate function is used for brevity.
        //    EventHandler<MsgHandlerEventArgs> h = (sender, args) =>
        //    {
        //        // print the message
        //        Console.WriteLine(args.Message);

        //        // Here are some of the accessible properties from
        //        // the message:
        //        // args.Message.Data;
        //        // args.Message.Reply;
        //        // args.Message.Subject;
        //        // args.Message.ArrivalSubcription.Subject;
        //        // args.Message.ArrivalSubcription.QueuedMessageCount;
        //        // args.Message.ArrivalSubcription.Queue;

        //        // Unsubscribing from within the delegate function is supported.
        //        //args.Message.ArrivalSubcription.Unsubscribe();
        //    };            

        //    // The simple way to create an asynchronous subscriber
        //    // is to simply pass the event in.  Messages will start
        //    // arriving immediately.
        //    IAsyncSubscription sAsync = c.SubscribeAsync("foo", h);

        //    // Alternatively, create an asynchronous subscriber on subject foo,
        //    // assign a message handler, then start the subscriber.   When
        //    // multicasting delegates, this allows all message handlers
        //    // to be setup before messages start arriving.
        //    sAsync = _conn.SubscribeAsync("foo");
        //    sAsync.MessageHandler += h;
        //    sAsync.Start();

            
        //    // Simple synchronous subscriber
        //    ISyncSubscription sSync = _conn.SubscribeSync("foo");
            
        //    _conn.Publish("foo", Encoding.UTF8.GetBytes("hello world"));

        //    _conn.Publish("foo", Encoding.UTF8.GetBytes("我"));
        //    // Publish requests to the given reply subject:
        //    _conn.Publish("foo", "bar", Encoding.UTF8.GetBytes("help!"));

        //    // Using a synchronous subscriber, gets the first message available,
        //    // waiting up to 1000 milliseconds (1 second)
        //    Msg m1 = sSync.NextMessage(1000);

        //    Msg m2 = sSync.NextMessage(1000);

        //    Msg m3 = sSync.NextMessage(1000);

            

        //    // Draining and closing a connection
        //    _conn.Drain();

        //    // Closing a connection
        //    _conn.Close();
            
        //}

        public bool Init(string url, Action<string> callback)
        {
            _ConnString = url;
            _Callback = callback;

            ConnectionFactory cf = new ConnectionFactory();
            try { _conn = cf.CreateConnection(_ConnString); }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoNATS).FullName, "NATS连接失败：" + ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /////  连接服务
        ///// </summary>
        public void Connection()
        {
            if (_Cancel)
            {
                return;
            }
            try
            {
                ConnectionFactory cf = new ConnectionFactory();
                
                _conn = cf.CreateConnection(_ConnString);
            }
            catch (Exception ex)
            {
                string msg = "NATS 服务连接出错：" + ex.Message;
                msg += "\r\n异常跟踪:" + ex.StackTrace;
                if (ex.InnerException != null)
                {
                    msg += "\r\n异常消息：" + ex.InnerException.Message + "\r\n异常错误:" + ex.InnerException.StackTrace;
                }
                LogHelper.Error(typeof(RemoteInfoNATS).FullName, msg);
            }
        }

        /// <summary>
        ///  检测消息服务是否连接
        /// </summary>
        /// <returns></returns>
        public bool CheckConnect()
        {
            if (_conn.State != ConnState.CONNECTED)
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

            if (_conn.State != ConnState.CONNECTED)
            {
                if (MessageHelper.ShowYesNoAndQuestion("消息服务连接不成功，是否关闭？") == System.Windows.Forms.DialogResult.Yes)
                {
                    _Cancel = true;
                }
            }

            return _conn.State == ConnState.CONNECTED;
        }

        /// <summary>
        ///  消息订阅
        /// </summary>
        /// <returns></returns>
        public bool Subscribe(string topic)
        {
            bool succeed = false;
            try
            {
                if (CheckConnect())
                {
                    EventHandler<MsgHandlerEventArgs> h = (sender, args) =>
                    {
                        byte[] data = args.Message.Data;
                        string msg = Encoding.UTF8.GetString(data);
                        _Callback(msg);
                        // print the message
                        //Console.WriteLine(args.Message);
                    };

                    IAsyncSubscription sAsync = _conn.SubscribeAsync(topic);
                    sAsync.MessageHandler += h;
                    sAsync.Start();
                    sAsyncList.Add(topic, sAsync);
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(RemoteInfoHelper).FullName, "消息服务订阅消息异常..." + ex.Message);
            }
            return succeed;
        }

        /// <summary>
        ///  检测消息服务是否连接
        /// </summary>
        /// <returns></returns>
        public void Publish(string topic, string content)
        {
            _conn.Publish(topic, Encoding.UTF8.GetBytes(content));
        }

        /// <summary>
        ///  消息退订
        /// </summary>
        /// <returns></returns>
        public void Unsubscribe(string topic)
        {
            if (CheckConnect()) {
                sAsyncList[topic].Unsubscribe();
            }
            
        }
        public void Close()
        {
            _conn.Drain();
            _conn.Close();
        }


        #endregion


    }
}
