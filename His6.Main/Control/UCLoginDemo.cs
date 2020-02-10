using System;
using System.Windows.Forms;

using His6.Base;

namespace His6.Main
{
    public partial class UCLoginDemo : UCLoginBase
    {
        public UCLoginDemo()
        {
            InitializeComponent();
            Title = "某种登录";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LoginForm.DialogResult = DialogResult.OK;
        }
    }
}
