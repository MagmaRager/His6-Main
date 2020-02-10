using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：各类消息显示处理类
    /// 功能描述：
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class MessageHelper
    {
        public static DialogResult ShowInfo(string message)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static DialogResult ShowWarning(string message)
        {
            return XtraMessageBox.Show(message, "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowError(string message)
        {
            return XtraMessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static DialogResult ShowYesNoAndError(string message)
        {
            return XtraMessageBox.Show(message, "错误信息", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
        }

        public static DialogResult ShowYesNoAndError(string message, MessageBoxDefaultButton defaultButton)
        {
            return XtraMessageBox.Show(message, "错误信息", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, defaultButton);
        }

        public static DialogResult ShowYesNoAndInfo(string message)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        public static DialogResult ShowYesNoAndInfo(string message, MessageBoxDefaultButton defaultButton)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, defaultButton);
        }

        public static DialogResult ShowYesNoAndWarning(string message)
        {
            return XtraMessageBox.Show(message, "警告信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowYesNoAndWarning(string message, MessageBoxDefaultButton defaultButton)
        {
            return XtraMessageBox.Show(message, "警告信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, defaultButton);
        }

        public static DialogResult ShowYesNoAndQuestion(string message)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowYesNoAndQuestion(string message, MessageBoxDefaultButton defaultButton)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, defaultButton);
        }

        public static DialogResult ShowYesNoCancelAndInfo(string message)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }

        public static DialogResult ShowYesNoCancelAndInfo(string message, MessageBoxDefaultButton defaultButton)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, defaultButton);
        }

    }
}
