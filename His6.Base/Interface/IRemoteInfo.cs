using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public interface IRemoteInfo
    {

        bool Init(string url, Action<String> callback);

        /// <summary>
        ///  连接服务
        /// </summary>
        void Connection();

        /// <summary>
        ///  检测消息服务是否连接
        /// </summary>
        bool CheckConnect();

        /// <summary>
        /// 订阅
        /// </summary>
        bool Subscribe(string topic);

        /// <summary>
        /// 发布
        /// </summary>
        void Publish(string topic, string content);

        /// <summary>
        /// 取消订阅
        /// </summary>
        void Unsubscribe(string topic);

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();
    }
}
