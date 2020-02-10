using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace His6.Base
{
    public class MessageUtil
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

        public static DialogResult ShowYesNoAndInfo(string message)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        public static DialogResult ShowYesNoAndWarning(string message)
        {
            return XtraMessageBox.Show(message, "警告信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowYesNoCancelAndInfo(string message)
        {
            return XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }

    }
}
