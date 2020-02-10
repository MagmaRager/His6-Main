using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

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
using His6.Model;

namespace His6.Main
{
    public partial class FrmMenuDefault : XtraForm
    {
        public FrmMenuDefault()
        {
            InitializeComponent();
            // 设置默认菜单
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("systemId", EnvInfo.SystemId.ToString()),
                new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()),
                new KeyValuePair<string, string>("roles", EmpInfo.Roles),
            };
            CustomException ce = null;
            List<DataMenu> menulist = HttpDataHelper.GetWithInfo<List<DataMenu>>(
                "BASE", "/sys/menu", out ce, parmList);

            parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()),
                new KeyValuePair<string, string>("parmName", "DEF_MENU_" + EnvInfo.SystemCode)
            };
            String defmenu = HttpDataHelper.GetStringWithInfo("BASE", "/sys/parameteremp", out ce, parmList);            

            tlSysMenu.BeginUpdate();
            CreateTreeView(menulist, defmenu);
            tlSysMenu.EndUpdate();
        }

        private void CreateTreeView(List<DataMenu> mlist, String defmenu)
        {
            TreeListNode lnode = null;
            string lcode = string.Empty;
            for (int j = 0; j < mlist.Count; j++)
            {
                if (mlist[j].Code.Length == 1)
                {
                    lcode = mlist[j].Code;
                    lnode = tlSysMenu.Nodes.Add(new object[] { mlist[j].Code, mlist[j].Title });
                }
                else
                {
                    //  找上级菜单
                    bool ok = true;
                    TreeListNode bnode = lnode;    //  备份旧的节点，防止找不到上级时可以回到原节点
                    while (lcode != mlist[j].Code.Substring(0, mlist[j].Code.Length - 1))
                    {
                        lnode = lnode.ParentNode;
                        lcode = lnode.GetValue(tlcCode).ToString();
                        if (lnode.Level < 0)
                        {
                            lnode = bnode;
                            lcode = lnode.GetValue(tlcCode).ToString();
                            ok = false;
                            MessageHelper.ShowError("菜单号：" + mlist[j].Code + " 找不到上级菜单，请与管理员联系！");
                            break;
                        }
                    }
                    if (ok)
                    {
                        lcode = mlist[j].Code;
                        lnode = lnode.Nodes.Add(new object[] { mlist[j].Code, mlist[j].Title });
                    }
                }
            }
            TreeListNode tndf = tlSysMenu.FindNode(o => o.GetValue(tlcCode).ToString() == defmenu);
            tlSysMenu.FocusedNode = tndf;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TreeListNode tn = tlSysMenu.FocusedNode;
            if (tn != null && !tn.HasChildren)
            {
                String code = tn.GetValue(tlcCode).ToString();
                // 设置默认菜单code
                List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
                parms.Add(new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()));
                parms.Add(new KeyValuePair<string, string>("parmName", "DEF_MENU_" + EnvInfo.SystemCode));
                parms.Add(new KeyValuePair<string, string>("value", code));
                CustomException ce = null;
                HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/sys/parameteremp", out ce, parms);
                MessageBox.Show("默认菜单设置完成！");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
