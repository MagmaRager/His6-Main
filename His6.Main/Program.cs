using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;

using His6.Base;
using His6.Base.Helper;

namespace His6.Main
{
    static class Program
    {
        private static Mutex running = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-Hans");
            //换肤
            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!DevExpress.Skins.SkinManager.AllowFormSkins)
            {
                DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                DevExpress.Skins.SkinManager.EnableFormSkins();
            }

            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new ThreadExceptionEventHandler(AppThreadException);

            DisplayHelper.ShowWithLog(typeof(Program).FullName, "初始化", "正在初始化系统，请稍后...");

            //  判断系统是否已经运行, 
            CheckRunning();

            try
            {
                string title = "Wonder医院信息管理系统V1.0";
                //获取分支机构
                if (EnvInfo.BranchId <= 0)
                {
                    MessageHelper.ShowError("分支机构ID未能获取，无法进入系统！");
                    Application.Exit();
                    return;
                }

                // 获取命令行信息
                string[] cmdline = Environment.GetCommandLineArgs();
                Dictionary<String, String> cmdInfos = new Dictionary<string, string>();
                if (cmdline.Length > 1)
                {
                    string cmdInfo = cmdline[1];
                    cmdInfos = GetInfos(cmdInfo);
                }

                bool login = false;
                String token = string.Empty;
                cmdInfos.TryGetValue("Token", out token);
                if (!token.IsNullOrEmpty())
                {
                    //  token登录
                    login = EmpInfo.LoginWithToken(token);
                }

                if (!login)
                {
                    DisplayHelper.Hide();

                    //登录
                    FrmLogin frm_login = new FrmLogin();
                    frm_login.Text = title;

                    login = (frm_login.ShowDialog() == DialogResult.OK);
                }

                if (login)
                {
                    //if(EmpInfo.GetLastSystemCode() == "OPC")
                    //{
                    //    WindowsFormsSettings.DefaultFont = new Font(SystemFonts.DefaultFont.Name, 10);
                    //}
                    //else
                    //{
                    WindowsFormsSettings.DefaultFont = new Font(SystemFonts.DefaultFont.Name, SystemFonts.DefaultFont.Size);
                    //}

                    DisplayHelper.ShowWithLog(typeof(Program).FullName, "初始化", "正在创建主窗口...");

                    FrmMainRibbon frm = new FrmMainRibbon();
                    frm.Title = title;
                    frm.Init();

                    DisplayHelper.Close();
                    Application.Run(frm);
                }
            }
            catch (Exception ex)
            {
                DisplayHelper.Close();
                MessageHelper.ShowError(ex.Message + "\r\n" + ex.InnerException.Message);
                LogHelper.Error(typeof(Program).FullName, ex.Message + "\r\n" + ex.InnerException.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        ///  未知异常的捕获
        /// </summary>
        private static void AppThreadException(object source, ThreadExceptionEventArgs e)
        {
            try
            {
                string msg = "FrmMain异常消息: " + e.Exception.Message;
                MessageBox.Show(msg);

                msg += "\r\n异常跟踪:" + e.Exception.StackTrace;
                if (e.Exception.InnerException != null)
                {
                    msg += "\r\n异常内部消息：" + e.Exception.InnerException.Message +
                        "\r\n异常内部跟踪:" + e.Exception.InnerException.StackTrace;
                }

                LogHelper.Error(typeof(Program).FullName, msg);

            }
            catch (Exception ex)
            {
                MessageBox.Show("FrmMain异常消息: " + ex.Message);
                LogHelper.Error(typeof(Program).FullName, "FrmMain异常错误:" + ex.Message + "\r\n异常跟踪:" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 检查系统是否已经运行
        /// </summary>
        private static void CheckRunning()
        {
            bool flag = false;
            string name = "WondersHis";
            try
            {
                LogHelper.Info("His6.Main", "判断系统是否已经运行");
                running = new Mutex(false, name, out flag);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
            if (flag)
            {
                return;
            }
            else
            {
                String canMultiRunning = System.Configuration.ConfigurationManager.AppSettings.Get("CanMultiRunning");
                if (canMultiRunning != null && canMultiRunning == "1")
                {
                    if (MessageHelper.ShowYesNoAndInfo("另一个窗口已在运行，是否重复运行？") == DialogResult.Yes)
                    {
                        return;
                    }
                }
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// 命令行获取参数
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        private static Dictionary<String, String> GetInfos(String infos)
        {
            Dictionary<String, String> dict = new Dictionary<String, String>();
            String[] segs = infos.Split('&');
            foreach (String s in segs)
            {
                String[] pars = s.Split('=');
                dict.Add(pars[0], pars[1]);
            }
            return dict;
        }



    }


}
