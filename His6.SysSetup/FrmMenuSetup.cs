using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using His6.Base;
using His6.Model;

namespace His6.SysSetup
{
    [FunctionPoint("01", "系统新增", "子系统新增")]
    [FunctionPoint("02", "菜单新增", "菜单新增")]
    [FunctionPoint("03", "修改", "修改子系统或菜单")]
    [FunctionPoint("04", "删除", "删除子系统或菜单")]
    public partial class FrmMenuSetup : FrmWithFPBase
    {
        //  用于子窗口的选择数据
        List<CDictModule> moduleList = new List<CDictModule>();
        List<CDictObject> objectList = new List<CDictObject>();
        List<DataEmpDir> empList = null;
        List<BDictRole> roleList = null;

        public FrmMenuSetup()
        {
            InitializeComponent();           
        }

        public override bool Init()
        {
            //功能点设置
            this._FunctionPointHelper.RegisterFunctionPoints(this,
                this.bbiAddSystem, this.bbiAddMenu, this.bbiEdit, this.bbiDelete);
            
            //  获取模块信息
            this.moduleList = getModuleAll();

            //  获取对象信息
            this.objectList = getObjectAll();

            this.ucMenu1.ModuleList = this.moduleList;
            this.ucMenu1.ObjectList = this.objectList;

            this.RefreshList();
            if (tlSysMenu.Nodes.Count >= 0)
            {
                this.FreshSystem(tlSysMenu.Nodes[0].Tag as BDictSystem);
            }

            return base.Init();
        }

        #region 数据获取方法

        /// <summary>
        ///  获取全部模块信息
        /// </summary>
        /// <returns></returns>
        private List<CDictModule> getModuleAll()
        {
            CustomException ce = null;
            // 获取模块信息
            List<CDictModule> modules = HttpDataHelper.GetWithInfo<List<CDictModule>>("BASE", "/setup/module", out ce);

            return modules;
        }

        /// <summary>
        ///  获取全部对象信息
        /// </summary>
        /// <returns></returns>
        private List<CDictObject> getObjectAll()
        {
            CustomException ce = null;
            // 获取对象信息
            List<CDictObject> objects = HttpDataHelper.GetWithInfo<List<CDictObject>>("BASE", "/setup/object", out ce);

            return objects;
        }

        /// <summary>
        ///  获取系统选择的角色
        /// </summary>
        /// <param name="system"></param>
        /// <returns></returns>
        private List<BDictRole> getSystemRole(BDictSystem system)
        {
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("systemId", system.Id.ToString())
            };
            CustomException ce = null;
            //  TODO: 获取系统选择的角色
            List<BDictRole> roles = HttpDataHelper.GetWithInfo<List<BDictRole>>("BASE", "/setup/sysrole",out ce, parmList);

            return roles;
        }

        /// <summary>
        ///  获取系统选择的人员
        /// </summary>
        /// <param name="system"></param>
        /// <returns></returns>
        private List<DataEmpDir> getSystemEmp(BDictSystem system)
        {
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("systemId", system.Id.ToString())
            };
            CustomException ce = null;
            //  获取系统选择的人员
            List<DataEmpDir> emps = HttpDataHelper.GetWithInfo<List<DataEmpDir>>("BASE", "/setup/sysemp", out ce, parmList);

            return emps;
        }

        /// <summary>
        ///  获取菜单选择的角色
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private List<BDictRole> getMenuRole(BDictMenu menu)
        {
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("menuCode", menu.Code)
            };
            CustomException ce = null;
            //  获取菜单选择的角色
            List<BDictRole> roles = HttpDataHelper.GetWithInfo<List<BDictRole>>("BASE", "/setup/menurole", out ce, parmList);

            return roles;
        }

        /// <summary>
        ///  获取菜单选择的人员
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private List<DataEmpDir> getMenuEmp(BDictMenu menu)
        {
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("menuCode", menu.Code)
            };
            CustomException ce = null;
            //  获取菜单选择的人员
            List<DataEmpDir> emps = HttpDataHelper.GetWithInfo<List<DataEmpDir>>("BASE", "/setup/menuemp", out ce, parmList);

            return emps;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private void RefreshList()
        {
            tlSysMenu.FocusedNodeChanged -= tvFunction_FocusedNodeChanged;
            tlSysMenu.BeginUpdate();
            tlSysMenu.Nodes.Clear();

            CustomException ce = null;
            // 获取系统信息
            List<BDictSystem> systemList = HttpDataHelper.GetWithInfo<List<BDictSystem>>("BASE", "/setup/systemget", out ce);

            // 获取菜单信息
            List<BDictMenu> menuList = HttpDataHelper.GetWithInfo<List<BDictMenu>>("BASE", "/setup/menuget", out ce);

            foreach (BDictSystem dataSystem in systemList)
            {
                TreeListNode rnode = tlSysMenu.Nodes.Add(new object[] { dataSystem.Code, dataSystem.Name });
                rnode.Tag = dataSystem;
                if(dataSystem.Id > 1000)
                {
                    rnode.ImageIndex = 2;
                }
                else
                {
                    rnode.ImageIndex = 1;//设置节点的图标
                }

                TreeListNode lnode = null;
                string lcode = string.Empty;
                for (var j=0; j < menuList.Count; j++)
                {
                    if (dataSystem.Id == menuList[j].SystemId)
                    {
                        if(menuList[j].Code.Length == 1)
                        {
                            lcode = menuList[j].Code;
                            lnode = rnode.Nodes.Add(new object[] { menuList[j].Code, menuList[j].Title });
                            lnode.Tag = menuList[j];
                            lnode.ImageIndex = 3;
                        }
                        else
                        {
                            //  找上级菜单
                            bool ok = true;
                            TreeListNode bnode = lnode;    //  备份旧的节点，防止找不到上级时可以回到原节点
                            while(lcode != menuList[j].Code.Substring(0, menuList[j].Code.Length - 1))
                            {
                                lnode = lnode.ParentNode;
                                lcode = lnode.GetValue(tlcCode).ToString();
                                if(lnode.Level == 0)
                                {
                                    lnode = bnode;
                                    lcode = lnode.GetValue(tlcCode).ToString();
                                    ok = false;
                                    MessageHelper.ShowError("菜单号：" + menuList[j].Code + " 找不到上级菜单，请与管理员联系！");
                                    break;

                                }
                            }
                            if (ok)
                            {
                                lcode = menuList[j].Code;
                                lnode = lnode.Nodes.Add(new object[] { menuList[j].Code, menuList[j].Title });
                                lnode.Tag = menuList[j];
                                lnode.ImageIndex = 3;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            this.ucSystem1.SetStatus(false, false);
            this.ucMenu1.SetStatus(false);
            tlSysMenu.CollapseAll();
            tlSysMenu.EndUpdate();
            tlSysMenu.FocusedNodeChanged += tvFunction_FocusedNodeChanged;
        }

        private void tvFunction_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {            
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    BDictSystem system = e.Node.Tag as BDictSystem;
                    this.FreshSystem(system);
                }
                else
                {
                    BDictMenu menu = e.Node.Tag as BDictMenu;
                    this.FreshMenu(menu);
                }
            }
        }

        /// <summary>
        /// 刷新系统
        /// </summary>
        /// <param name="system"></param>
        private void FreshSystem(BDictSystem system)
        {
            if (system != null)
            {
                //  获取系统选择的角色与人员
                List<BDictRole> roles = getSystemRole(system);
                List<DataEmpDir> emps = getSystemEmp(system);

                this.ucSystem1.Init(system, roles, emps);
                this.ucSystem1.Visible = true;
                this.ucMenu1.Visible = false;
            }
        }

        /// <summary>
        /// 
        /// 刷新菜单
        /// </summary>
        /// <param name="menu"></param>
        private void FreshMenu(BDictMenu menu)
        {
            if (menu != null)
            {
                //  获取菜单选择的角色与人员
                List<BDictRole> roles = getMenuRole(menu);
                List<DataEmpDir> emps = getMenuEmp(menu);

                this.ucMenu1.Init(menu, roles, emps);
                this.ucSystem1.Visible = false;
                this.ucMenu1.Visible = true;
            }
        }


        #region 功能按钮事件

        private void bbiAddSystem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BDictSystem system = new BDictSystem();
            FrmSystemEdit frm = new FrmSystemEdit();
            if (this.roleList == null)
            {
                //  获取全部可用角色列表
                this.roleList = CommonDataHelper.GetRoleAll();
            }
            if (this.empList == null)
            {
                //  获取全部可用员工列表
                this.empList = CommonDataHelper.GetEmpAll();
            }

            frm.SetRefData(this.roleList, this.empList);
            frm.Init(true, system, new List<BDictRole>(), new List<DataEmpDir>());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                system = frm.GetData();

                TreeListNode rnode = this.tlSysMenu.Nodes.Add(new object[] { system.Code, system.Name });
                rnode.Tag = system;
                rnode.ImageIndex = system.Id > 10000 ? 1 : 2;
                tlSysMenu.FocusedNode = rnode;
            }
            frm.Dispose();
        }

        private void bbiAddMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlSysMenu.FocusedNode == null)
            {
                return;
            }
            if ((tlSysMenu.FocusedNode.Tag as BDictMenu).ObjectCode != null)
            {
                MessageHelper.ShowWarning("该节点有对象，不能下挂菜单！");
                return;
            }
            if (tlSysMenu.FocusedNode.Level == 4)
            {
                MessageHelper.ShowWarning("菜单的层级目前至多为4级！");
                return;
            }

            //  计算下一个代码编号
            string code = string.Empty;
            if (tlSysMenu.FocusedNode.Nodes.Count > 0)
            {
                //  已经有节点，在最后节点编号基础上加1
                code = getNextMenuCode(tlSysMenu.FocusedNode.Nodes[tlSysMenu.FocusedNode.Nodes.Count - 1].GetValue(this.tlcCode).ToString());
            }
            else
            {
                if (tlSysMenu.FocusedNode.Level == 0)
                {
                    code = "1";
                }
                else
                {
                    code = tlSysMenu.FocusedNode.GetValue(this.tlcCode).ToString() + "1";
                }
            }

            //  获取系统ID
            int systemId = 0;
            if (tlSysMenu.FocusedNode.Level == 0)
            {
                systemId = (tlSysMenu.FocusedNode.Tag as BDictSystem).Id;
            }
            else
            {
                systemId = (tlSysMenu.FocusedNode.Tag as BDictMenu).SystemId;
            }

            BDictMenu menu = new BDictMenu();
            menu.Code = code;
            menu.SystemId = systemId;
            menu.WinState = 1;

            FrmMenuEdit frm = new FrmMenuEdit();
            if (this.roleList == null)
            {
                //  获取全部可用角色列表
                this.roleList = CommonDataHelper.GetRoleAll();
            }
            if (this.empList == null)
            {
                //  获取全部可用员工列表
                this.empList = CommonDataHelper.GetEmpAll();
            }

            frm.SetRefData(this.moduleList, this.objectList, this.roleList, this.empList);
            frm.Init(true, menu, new List<BDictRole>(), new List<DataEmpDir>());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                menu = frm.GetData();

                TreeListNode cnode = this.tlSysMenu.FocusedNode.Nodes.Add(new object[] { menu.Code, menu.Title });
                cnode.Tag = menu;
                tlSysMenu.FocusedNode = cnode;
            }
            frm.Dispose();
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlSysMenu.FocusedNode != null)
            {
                if (tlSysMenu.FocusedNode.Level == 0)
                {
                    //  系统修改
                    BDictSystem system = tlSysMenu.FocusedNode.Tag as BDictSystem;
                    FrmSystemEdit frm = new FrmSystemEdit();
                    if (this.roleList == null)
                    {
                        //  获取全部可用角色列表
                        this.roleList = CommonDataHelper.GetRoleAll();
                    }
                    if (this.empList == null)
                    {
                        //  获取全部可用员工列表
                        this.empList = CommonDataHelper.GetEmpAll();
                    }

                    frm.SetRefData(this.roleList, this.empList);
                    frm.Init(false, system, this.ucSystem1.GetRoles(), this.ucSystem1.GetEmps());
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        system = frm.GetData();
                        this.tlSysMenu.FocusedNode.SetValue(this.tlcCode, system.Code);
                        this.tlSysMenu.FocusedNode.SetValue(this.tlcName, system.Name);
                        this.tlSysMenu.FocusedNode.Tag = system;
                        this.ucSystem1.Init(system, frm.GetRoles(), frm.GetEmps());
                        
                    }
                    frm.Dispose();
                }
                else
                {
                    //  菜单修改
                    BDictMenu menu = tlSysMenu.FocusedNode.Tag as BDictMenu;
                    FrmMenuEdit frm = new FrmMenuEdit();
                    if (this.roleList == null)
                    {
                        //  获取全部可用角色列表
                        this.roleList = CommonDataHelper.GetRoleAll();
                    }
                    if (this.empList == null)
                    {
                        //  获取全部可用员工列表
                        this.empList = CommonDataHelper.GetEmpAll();
                    }

                    frm.SetRefData(this.moduleList, this.objectList, this.roleList, this.empList);
                    frm.Init(false, menu, this.ucMenu1.GetRoles(), this.ucMenu1.GetEmps());
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        menu = frm.GetData();
                        this.tlSysMenu.FocusedNode.SetValue(this.tlcName, menu.Title);
                        this.tlSysMenu.FocusedNode.Tag = menu;
                        this.ucMenu1.Init(menu, frm.GetRoles(), frm.GetEmps());
                    }
                    frm.Dispose();
                }
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlSysMenu.FocusedNode != null)
            {
                if (tlSysMenu.FocusedNode.HasChildren)
                {
                    MessageHelper.ShowWarning("还有子项不能删除！");
                    return;
                }

                string mess = (tlSysMenu.FocusedNode.Level == 0) ? "系统:" : "菜单:";
                mess = mess + "(" + tlSysMenu.FocusedNode.GetDisplayText(tlcCode) + ")" + tlSysMenu.FocusedNode.GetDisplayText(tlcName);

                if (MessageHelper.ShowYesNoAndInfo("是否真的删除 " + mess + "?") == DialogResult.Yes)
                {                    
                    CustomException ce = null;
                    
                    if (tlSysMenu.FocusedNode.Level == 0)
                    {
                        BDictSystem system = tlSysMenu.FocusedNode.Tag as BDictSystem;
                        var parmList = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("systemId", system.Id.ToString())
                        };
                        //  删除子系统
                        HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/setup/systemdelete", out ce, parmList);
                    }
                    else
                    {
                        BDictMenu menu = tlSysMenu.FocusedNode.Tag as BDictMenu;
                        var parmList = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("systemId", menu.SystemId.ToString()),
                            new KeyValuePair<string, string>("menuCode", menu.Code),
                        };
                        //  删除菜单
                        HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/setup/menudelete", out ce, parmList);
                    }
                    // 处理异常ce
                    if (ce != null)
                    {
                        MessageHelper.ShowError("删除操作失败！\r\n" + ce.Info);
                    }
                    tlSysMenu.FocusedNode.Remove();
                }
            }
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.tlSysMenu.BeginUpdate();
            RefreshList();
            if (tlSysMenu.Nodes.Count > 0)
            {
                tlSysMenu.FocusedNode = tlSysMenu.Nodes[0];
            }
            tlSysMenu.EndUpdate();
        }

        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListHelper.ExportTo(this.tlSysMenu, EnvInfo.RunPath);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private string getNextMenuCode(string last_code)
        {
            string code = last_code.Substring(0, last_code.Length - 1);
            char no = last_code[last_code.Length - 1];

            if (no == '9')
            {
                no = 'A';
            }
            else
            {
                no ++ ;
            }

            return code + no;
        }

        #endregion

        private void tlSysMenu_DragDrop(object sender, DragEventArgs e)
        {
            
            e.Effect = DragDropEffects.None;
            TreeListNode snode = GetDragNode(e.Data);
            BDictMenu menu = snode.Tag as BDictMenu;
            string old_code = menu.Code;
            int old_systemId = menu.SystemId;

            if (snode == null)
            {
                return;
            }
            TreeListHitInfo info = tlSysMenu.CalcHitInfo(tlSysMenu.PointToClient(new System.Drawing.Point(e.X, e.Y)));
            if (info == null)
            {
                return;
            }
            TreeListNode tnode = info.Node;
            if (snode.ParentNode == tnode)    //  还是同一父节点下
            {
                return;
            }
            if (snode.Level == 0 || tnode.Level == 4)    //  系统不能拖到其他节点下，4级菜单下不能再有子节点
            {
                return;
            }

            if (snode.HasChildren)
            {
                MessageHelper.ShowWarning("有子节点的不能被拖到其他菜单下!");
                return;
            }

            int new_systemId = 0;
            string new_code = string.Empty;
            if (tnode.Level > 0)
            {
                if (!string.IsNullOrEmpty((tnode.Tag as BDictMenu).ObjectCode))
                {
                    MessageHelper.ShowWarning("节点有功能不能挂其他菜单!");
                    return;
                }
                new_systemId = (tnode.Tag as BDictMenu).SystemId;
                new_code = tnode.GetValue(tlcCode).ToString() + "1";
            }
            else
            {
                new_systemId = (tnode.Tag as BDictSystem).Id;
                new_code = "1";
            }
            
            //  计算新的代码
            if (tnode.HasChildren)
            {
                new_code = getNextMenuCode(tnode.Nodes[tnode.Nodes.Count - 1].GetValue(this.tlcCode).ToString());
            }
            menu.Code = new_code;
            menu.SystemId = new_systemId;

            // 拖拽修修改
            List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
            parms.Add(new KeyValuePair<string, string>("oldSystem", old_systemId.ToString()));
            parms.Add(new KeyValuePair<string, string>("oldMenu", old_code));
            parms.Add(new KeyValuePair<string, string>("newSystem", new_systemId.ToString()));
            parms.Add(new KeyValuePair<string, string>("newMenu", new_code));
            CustomException ce = null;
            HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/setup/menumove", out ce, parms);            
            if (ce == null)
            {
                snode.Remove();
                TreeListNode cnode = tnode.Nodes.Add(new object[] { menu.Code, menu.Title });
                cnode.Tag = menu;
                tlSysMenu.FocusedNode = cnode;
            }
            else
            {
                MessageHelper.ShowError("菜单移动调用服务失败！\r\n" + ce.Info);
            }
        }

        private TreeListNode GetDragNode(IDataObject data)
        {
            return (TreeListNode)data.GetData(typeof(TreeListNode));
        }
    }
}
