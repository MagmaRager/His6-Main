using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    public partial class FrmTest : FrmBase
    {

        RemoteInfoReceiver rir ;
        public FrmTest()
        {
            InitializeComponent();
        }

        public override bool Init()
        {
            List<string>  lst = new List<string>();
            lst.Add("A");
            lst.Add("C");

            rir = new RemoteInfoReceiver(lst, SynCallbackInfo);
            return base.Init();
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
                CallbackInfo(infoCode, infoBody);
            }
        }

        /// <summary>
        ///  信息回调函数，实现接收信息后的相关处理。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        private void CallbackInfo(string infoCode, string infoBody)
        {
            MessageHelper.ShowInfo(infoCode + " || " + infoBody);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string code = textEdit1.Text;
            string info = textEdit2.Text;

            RemoteInfoHelper.SendInfo(code, info, this.GetType().FullName);
        }

        private void FrmTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.rir != null)
            {
                rir.Close();
            }
        }
    }
}
