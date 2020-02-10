using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using His6.Base;
using His6.Model;

namespace His6.SysSetup
{
    public partial class FrmFunctionPointSetup : FrmBase
    {
        List<BDictRole> roleList = null;
        List<DataEmpDir> empList = null;

        public FrmFunctionPointSetup()
        {
            InitializeComponent();
        }

        #region 函数方法

        public override bool Init()
        {
            if(EmpInfo.IsCenterAdmin){
                this.freshData();
                return base.Init();
            }
            else
            {
                MessageHelper.ShowError("没有中心管理员权限不能使用本系统！");
                return false;
            }
        }

        private void freshData()
        {
            CustomException ce = null;
            // 获取模块列表、有功能点的对象列表数据, 以下为测试数据
            List<CDictModule> modules = HttpDataHelper.GetWithInfo<List<CDictModule>>("BASE", "/setup/module", out ce);
          
            List<CDictObject> objects = HttpDataHelper.GetWithInfo<List<CDictObject>>("BASE", "/setup/object", out ce);
                   
            this.tlSysObject.FocusedNodeChanged -= tlSysObject_FocusedNodeChanged;
            this.tlSysObject.BeginUpdate();    //  停止控件刷新
            this.tlSysObject.Nodes.Clear();
            int j = 0;
            foreach (CDictModule module in modules)
            {
                TreeListNode rnode = this.tlSysObject.Nodes.Add(new object[] { module.Code, module.Name});
                rnode.Tag = module;

                for (; j < objects.Count; j++)
                {
                    if (module.Code == objects[j].ModuleCode)
                    {
                        TreeListNode node = rnode.Nodes.Add(new object[] { objects[j].Code, objects[j].Name});
                        node.Tag = objects[j];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            this.tlSysObject.FocusedNodeChanged += tlSysObject_FocusedNodeChanged;
            this.tlSysObject.EndUpdate();       //  控件刷新从BeginUpdate开始的改变
            this.groupControl1.Visible = false;
            this.gcEmp.Visible = false;
            this.gcRole.Visible = false;
            
            this.setStatus(false);
        }

        private void freshFP(TreeListNode node)
        {
            CDictFunctionPoint fp = node.Tag as CDictFunctionPoint;
            this.teCode.Text = fp.Code;            
            this.teName.Text = fp.Name;
            this.teDescribe.Text = fp.Describe;

            //  获取功能点角色及人员数据
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("fpCode", fp.Code)
            };
            CustomException ce = null;
            List<BDictRole> roles = HttpDataHelper.GetWithInfo<List<BDictRole>>("BASE", "/setup/fprole", out ce, parmList);
            List<DataEmpDir> emps = HttpDataHelper.GetWithInfo<List<DataEmpDir>>("BASE", "/setup/fpemp", out ce, parmList);
            
            this.gcEmp.DataSource = emps;
            this.gcRole.DataSource = roles;
            this.bbiSetup.Enabled = true;
        }

        private void setStatus(bool isEdit)
        {
            this.tlSysObject.Enabled = !isEdit;
            this.gvEmp.OptionsBehavior.ReadOnly = !isEdit;
            this.gvRole.OptionsBehavior.ReadOnly = !isEdit;

            this.bbiSetup.Enabled = !isEdit && (this.tlSysObject.FocusedNode != null && this.tlSysObject.FocusedNode.Level == 2);
            this.bbiSave.Enabled = isEdit;
            this.bbiCancel.Enabled = isEdit;
            this.bbiRole.Enabled = isEdit;
            this.bbiEmp.Enabled = isEdit;
            this.bbiExport.Enabled = !isEdit;
        }

        private void selectRole()
        {
            if(this.roleList == null)
            {
                this.roleList = CommonDataHelper.GetRoleAll();
            }

            FrmSelectRole frm = new FrmSelectRole();
            frm.SetDataSource(this.roleList, this.gcRole.DataSource as List<BDictRole>);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                List<BDictRole> new_selected = frm.RoleSelected;
                gcRole.DataSource = new_selected;
            }
            frm.Dispose();
        }

        private void selectEmp()
        {
            if (this.empList == null)
            {
                this.empList = CommonDataHelper.GetEmpAll();
            }

            FrmSelectEmp frm = new FrmSelectEmp();
            frm.SetDataSource(this.empList, this.gcEmp.DataSource as List<DataEmpDir>);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                List<DataEmpDir> new_selected = frm.EmpSelected;
                gcEmp.DataSource = new_selected;
            }
            frm.Dispose();
        }

         #endregion

        #region 事件

        private void tlSysObject_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                this.groupControl1.Visible = true;
                this.gcEmp.Visible = true;
                this.gcRole.Visible = true;
                this.freshFP(e.Node);
            }
            else
            {
                this.groupControl1.Visible = false;
                this.gcEmp.Visible = false;
                this.gcRole.Visible = false;
                this.bbiSetup.Enabled = false;
            }
        }

        private void tlSysObject_AfterExpand(object sender, NodeEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                this.tlSysObject.FocusedNodeChanged -= tlSysObject_FocusedNodeChanged;
                this.tlSysObject.BeginUpdate();    //  停止控件刷新

                //  在模块展开时再检查功能的对应的功能点是否加载

                foreach (TreeListNode node in e.Node.Nodes)
                {
                    if (!node.HasChildren)
                    {
                        string objectCode = node.GetValue(this.tlcCode).ToString();
                        var parmList = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("objectCode", objectCode)
                        };
                        CustomException ce = null;
                        //  获取功能对应的功能点
                        List<CDictFunctionPoint> fps = HttpDataHelper.GetWithInfo<List<CDictFunctionPoint>>("BASE", "/setup/fplist", out ce, parmList);
                        
                        foreach (CDictFunctionPoint fp in fps)
                        {
                            TreeListNode cnode = node.Nodes.Add(new object[] { fp.Code, fp.Name });
                            cnode.Tag = fp;
                        }
                    }
                }
                this.tlSysObject.FocusedNodeChanged += tlSysObject_FocusedNodeChanged;
                this.tlSysObject.EndUpdate();       //  控件刷新从BeginUpdate开始的改变
            }
        }


        private void gvRole_DoubleClick(object sender, EventArgs e)
        {
            if (bbiRole.Enabled)
            {
                this.selectRole();
            }
        }

        private void gvEmp_DoubleClick(object sender, EventArgs e)
        {
            if (bbiEmp.Enabled)
            {
                this.selectEmp();
            }
        }


        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeListHelper.ExportTo(this.tlSysObject, EnvInfo.RunPath);
        }

        private void bbiSetup_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.setStatus(true);
        }

        private void bbiRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.selectRole();
        }

        private void bbiEmp_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.selectEmp();
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<DataEmpDir> emps = this.gcEmp.DataSource as List<DataEmpDir>;
            List<BDictRole> roles = this.gcRole.DataSource as List<BDictRole>;
            string fpCode = this.teCode.Text;
            //  保存数据处理, 1.清除本机构该功能点人员、角色， 2. 加入功能点人员、角色
            FunctionPointWithRight fpr = new FunctionPointWithRight();
            fpr.FpCode = this.teCode.Text;
            fpr.EmpList = emps;
            fpr.RoleList = roles;
            String json = StringHelper.SerializeObject<FunctionPointWithRight>(fpr);
            CustomException ce;
            HttpDataHelper.HttpPostWithInfo("BASE", "/setup/fprightset", out ce, json);
            if (ce != null) throw ce;

            this.setStatus(false);
        }

        private void bbiCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.setStatus(false);
            this.freshFP(this.tlSysObject.FocusedNode);
        }

        #endregion
    }
}
