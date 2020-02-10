
using DevExpress.Utils;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：显示信息处理类
    /// 功能描述：用于只显示，不需要点击的提示信息
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public static class DisplayHelper
    {
        private static WaitDialogForm _WaitFrm;

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="caption">提示信息</param>
        /// <param name="title">标题</param>
        public static void Show(string caption, string title)
        {
            if (_WaitFrm == null || _WaitFrm.IsDisposed)
            {
                _WaitFrm = new WaitDialogForm(caption, title);
                _WaitFrm.TopMost = true;
            }
            else
            {
                _WaitFrm.SetCaption(caption);
                _WaitFrm.Show();
            }
        }

        /// <summary>
        ///  显示提示信息并记录日志
        /// </summary>
        /// <param name="log">日志名</param>
        /// <param name="caption">提示信息</param>
        /// <param name="title">标题</param>
        public static void ShowWithLog(string log, string caption, string title)
        {
            DisplayHelper.Show(caption, title);
            LogHelper.Info(log, caption);
        }

        /// <summary>
        ///  显示提示信息并记录日志
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="caption">提示信息</param>
        /// <param name="title">标题</param>
        public static void ShowWithLog(object obj, string caption, string title)
        {
            DisplayHelper.Show(caption, title);
            LogHelper.Info(obj, caption);
        }

        /// <summary>
        ///  关闭
        /// </summary>
        public static void Close()
        {
            if (_WaitFrm != null)
            {
                _WaitFrm.Close();
                _WaitFrm = null;
            }
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        public static void Hide()
        {
            if (_WaitFrm != null)
            {
                _WaitFrm.Hide();
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        public static void Show()
        {
            if (_WaitFrm != null)
            {
                _WaitFrm.Show();
            }
        }

        /// <summary>
        /// 改变提示信息
        /// </summary>
        /// <param name="newCaption">提示内容</param>
        public static void SetCaption(string newCaption)
        {
            if (_WaitFrm != null)
            {
                _WaitFrm.SetCaption(newCaption);
            }
        }

        /// <summary>
        ///  改变提示信息并记录日志
        /// </summary>
        /// <param name="log">日志名</param>
        /// <param name="newCaption">提示内容</param>
        public static void SetCaptionWithLog(string log, string newCaption)
        {
            DisplayHelper.SetCaption(newCaption);
            LogHelper.Info(log, newCaption);
        }

        /// <summary>
        ///  改变提示信息并记录日志
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="newCaption">提示内容</param>
        public static void SetCaptionWithLog(object obj, string newCaption)
        {
            DisplayHelper.SetCaption(newCaption);
            LogHelper.Info(obj, newCaption);
        }

    }

}
