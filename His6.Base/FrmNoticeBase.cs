using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：通知对象基类窗口
    /// 功能描述：用于通知类提示有关的基窗口，可实现危机值、关注项等提示
    ///     子类实现时
    ///         1. 需要重载方法：
    ///               CallbackInfo(..) 用于接收到消息服务器消息时的处理；
    ///               QueryInfo() 用于定时查询通知信息（防止消息服务器未接收到）
    ///         2. 初始化数据
    ///               timer_interval 定时时长，默认5分钟
    ///               IcoImage 在主窗口显示的通知图标图案
    ///               IcoColor 在主窗口显示的通知图标文本颜色，默认black
    ///               IcoHint  在主窗口显示的通知提示
    ///               AutoOpen 通知窗口接收到通知时是否自动打开，默认false
    ///         注：通知窗口必须有隐藏按钮或控件。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    ///  
    /// </summary>
    public partial class FrmNoticeBase : XtraForm
    {

        //  定义一个通知数量改变的委托函数
        public delegate void NoticeCountChanged(object sender, EventArgs e);
        //  定义通知数量改变事件
        public event NoticeCountChanged OnNoticeCountChanged;

        public FrmNoticeBase()
        {
            this.IcoColor = Color.Black;
            InitializeComponent();
        }

        #region 基础属性与方法
        
        //  是否自动弹出
        public bool AutoOpen
        {
            get;
            set;
        }

        //  通知数量
        int m_notice_count = 0;
        public int NoticeCount
        {
            get { return this.m_notice_count; }
            set
            {
                this.m_notice_count++;

                if (OnNoticeCountChanged != null)
                {
                    OnNoticeCountChanged(this, null);
                }
            }
        }

        //  提示图标
        public Image IcoImage
        {
            get;
            set;
        }

        //  提示颜色
        public Color IcoColor
        {
            get;
            set;
        }

        //  提示图标Hint
        public string IcoHint
        {
            get;
            set;
        }

        //  外部信息接口对象,用于从消息服务器获取信息
        protected RemoteInfoReceiver infoRemoteAction;

        //  定时器时间间隔默认5分钟
        protected int timer_interval = 5*60000; 
        protected Timer timer1;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="code"></param>
        public virtual void Init(string code)
        {
            //  加入远程信息接收处理
            List<string> infoRemoteCodeList = new List<string>();
            infoRemoteCodeList.Add(code);
            infoRemoteAction = new RemoteInfoReceiver(infoRemoteCodeList, SynCallbackInfo);

            //  加入定时信息获取
            if(timer_interval > 0)
            {
                timer1 = new Timer();
                timer1.Interval = timer_interval;
                this.timer1.Tick += (ts, te) =>
                {
                    this.QueryInfo();
                };
                this.timer1.Start();
            }
        }


        public virtual void Stop()
        {
            timer1.Stop();
        }

        /// <summary>
        ///  异步信息回调函数，用于实现在主线程调用CallbackInfo函数。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        private void SynCallbackInfo(string infoCode, string infoBody)
        {
            if (this.InvokeRequired)
            {
                OnCallbackInfo m = new OnCallbackInfo(CallbackInfo);
                this.Invoke(m, new object[] { infoCode, infoBody });
            }
            else
            {
                this.timer1.Stop();
                CallbackInfo(infoCode, infoBody);
                this.timer1.Start();
            }
        }

        /// <summary>
        ///  信息回调函数，实现接收信息后的相关处理,子类必须实现（包括加入通知列表同时通知数量+1）。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        protected virtual void CallbackInfo(string infoCode, string infoBody)
        {
        }

        /// <summary>
        ///  定时查询接收通知，如果查询到新的通知，加入通知列表同时通知数量+1
        /// </summary>
        protected virtual void QueryInfo()
        {
        }

        #endregion

    }
}
