using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    [FormParmDesc("对象设置参数格式： 系统ID;员工ID", "10001,110009")]
    public partial class FrmObjectSetup : FrmBase
    {
        public FrmObjectSetup()
        {
            InitializeComponent();
        }

        public override bool Init()
        {
            if (EmpInfo.IsCenterAdmin)
            {
                this.FreshData();
                return base.Init();
            }
            else
            {
                MessageHelper.ShowError("没有中心管理员权限不能使用本系统！");
                return false;
            }
        }

        private void FreshData()
        {
            CustomException ce = null;
            // 获取模块列表、对象列表数据, 以下为测试数据
            List<CDictModule> modules = HttpDataHelper.GetWithInfo<List<CDictModule>>("BASE", "/setup/module", out ce);
            List<CDictObject> objects = HttpDataHelper.GetWithInfo<List<CDictObject>>("BASE", "/setup/object", out ce);

            this.tlSysObject.FocusedNodeChanged -= tlSysObject_FocusedNodeChanged;
            this.tlSysObject.BeginUpdate();    //  停止控件刷新
            this.tlSysObject.Nodes.Clear();
            int j = 0;
            foreach(CDictModule module in modules)
            {
                TreeListNode rnode = this.tlSysObject.Nodes.Add(new object[] { module.Code, module.Name, module.FileName, module.UsedFlag, "" });
                rnode.Tag = module;

                for (; j < objects.Count; j++)
                {
                    if (module.Code == objects[j].ModuleCode)
                    {
                        TreeListNode node =  rnode.Nodes.Add(new object[] { objects[j].Code, objects[j].Name, objects[j].Object, objects[j].UsedFlag, objects[j].ModuleCode });
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
            if (modules.Count > 0)
            {
                this.FreshModule(modules[0]);
            }
            else
            {
                this.ucSysModule1.Visible = false;
                this.ucSysObject1.Visible = false;
                this.bbiEditModule.Visibility = BarItemVisibility.Never;
                this.bbiEditObject.Visibility = BarItemVisibility.Never;
                this.bbiAddObject.Visibility = BarItemVisibility.Never;
            }
        }

        private void tlSysObject_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null)
            {
                this.ucSysModule1.Visible = false;
                this.ucSysObject1.Visible = false;
                this.bbiEditModule.Visibility = BarItemVisibility.Never;
                this.bbiEditObject.Visibility = BarItemVisibility.Never;
                this.bbiAddObject.Visibility = BarItemVisibility.Never;
                return;
            }

            string code = e.Node.GetValue(this.tlcCode).ToString();
            string moduleCode = e.Node.GetValue(tlcParentCode).ToString();
            if (string.IsNullOrEmpty(moduleCode))
            {
                CDictModule module = e.Node.Tag as CDictModule;
                this.FreshModule(module);
            }
            else
            {
                CDictObject obj = e.Node.Tag as CDictObject;
                string objectCode = obj.Code;
                var parmList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("objectCode", objectCode)
                };
                CustomException ce = null;
                //  获取功能对应的功能点
                List<CDictFunctionPoint> fps = HttpDataHelper.GetWithInfo<List<CDictFunctionPoint>>("BASE", "/setup/fplist", out ce, parmList);
                obj.FunctionPointList = fps;
                this.FreshObject(obj);
            }
        }

        private void FreshObject(CDictObject obj)
        {
            this.ucSysModule1.Visible = false;
            this.ucSysObject1.Visible = true;
            this.bbiAddObject.Visibility = BarItemVisibility.Always;
            this.bbiEditModule.Visibility = BarItemVisibility.Never;
            this.bbiEditObject.Visibility = BarItemVisibility.Always;
            this.ucSysObject1.Init(obj);
            this.ucSysObject1.SetStatus(false);
        }

        private void FreshModule(CDictModule module)
        {
            this.ucSysModule1.Visible = true;
            this.ucSysObject1.Visible = false;
            this.bbiAddObject.Visibility = BarItemVisibility.Always;
            this.bbiEditModule.Visibility = BarItemVisibility.Always;
            this.bbiEditObject.Visibility = BarItemVisibility.Never;
            this.ucSysModule1.Init(module);
            this.ucSysModule1.SetStatus(false);
        }


        private void bbiAddModule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //  TEST
            //LocalInfoHelper.SendOpenForm("TITLE", "His6.SysSetup", "FrmMenuSetup", "", 1);

            //  选择模块文件
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "选择模块文件";
            openFileDialog1.InitialDirectory = EnvInfo.RunPath;
            openFileDialog1.Filter = "动态文件 (*.dll)|*.dll";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                int pos = filename.LastIndexOf(@"\");
                string module_name = filename.Substring(pos + 1);
                module_name = module_name.Substring(0, module_name.Length - 4);

                //  判断模块文件是否已经加入
                bool found = false;
                TreeListNode node = this.tlSysObject.Nodes.FirstNode;
                while (node != null)
                {
                    if (node.GetValue(this.tlcObject).ToString() == module_name)
                    {
                        found = true;
                        break;
                    }
                    node = node.NextNode;
                }
                if (found)
                {
                    MessageHelper.ShowError("模块文件已经在数据中...");
                    return;
                }

                //  打开模块选择窗口
                FrmModuleAdd frm = new FrmModuleAdd();
                if (frm.ImpModule(filename))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        //  成功加入模块数据
                        CDictModule module = frm.DataModule;
                        List<CDictObject> objectList = frm.DataObjectList;

                        //  添加节点
                        this.tlSysObject.FocusedNodeChanged -= tlSysObject_FocusedNodeChanged;
                        this.tlSysObject.BeginUpdate();    //  停止控件刷新
                        TreeListNode rnode = this.tlSysObject.Nodes.Add(new object[] { module.Code, module.Name, module.FileName, module.UsedFlag, "" });
                        rnode.Tag = module;

                        foreach(CDictObject obj in objectList)
                        {
                            TreeListNode onode = rnode.Nodes.Add(new object[] { obj.Code, obj.Name, obj.Object, obj.UsedFlag, obj.ModuleCode });
                            onode.Tag = obj;
                        }
                        this.tlSysObject.FocusedNodeChanged += tlSysObject_FocusedNodeChanged;
                        this.tlSysObject.EndUpdate();       //  控件刷新从BeginUpdate开始的改变
                        this.tlSysObject.FocusedNode = rnode;
                        if (!this.ucSysModule1.Visible)     //  没有任何数据第一条加入时不会触发行更改事件
                        {
                            this.FreshModule(module);
                        }
                    }
                }
                frm.Dispose();
            }
        }

        private void bbiEditModule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode mnode = this.tlSysObject.FocusedNode;
            if (mnode != null)
            {
                CDictModule module = mnode.Tag as CDictModule;
                if(module != null)
                {
                    FrmModuleEdit frm = new FrmModuleEdit();
                    frm.Init(module);
                    if(frm.ShowDialog() == DialogResult.OK)
                    {
                        module = frm.DataModule;
                        mnode.SetValue(tlcName, module.Name);
                        mnode.SetValue(tlcUsedFlag, module.UsedFlag);
                        mnode.Tag = module;
                        this.ucSysModule1.Init(module);
                    }
                    frm.Dispose();
                }
            }
        }

        private void bbiAddObject_ItemClick(object sender, ItemClickEventArgs e)
        {
            //  获取模块名称
            TreeListNode rnode = this.tlSysObject.FocusedNode;
            if (rnode == null)
            {
                return;
            }
            if(rnode.ParentNode != null)
            {
                //  选择对象时获取其对应的模块节点
                rnode = rnode.ParentNode;
            }
            string module_obj = rnode.GetValue(this.tlcObject).ToString();
            string module_code = rnode.GetValue(this.tlcCode).ToString();
            string module_name = rnode.GetValue(this.tlcName).ToString();

            //  获取已经加入的功能
            List<string> existsObjectList = new List<string>();
            foreach(TreeListNode objnode in rnode.Nodes)
            {
                existsObjectList.Add(objnode.GetValue(this.tlcCode).ToString());
            }

            //  获取对应模块可用功能
            List<CDictObject> objectList = new List<CDictObject>();
            try
            {
                Assembly theDll = Assembly.LoadFrom(EnvInfo.RunPath + module_obj + ".dll");

                //  找出未加入的对象到noexistsObjectList
                List<string> noexistsObjectList = new List<string>();       //  未加入的对象列表
                object[] customs = theDll.GetCustomAttributes(false);
                foreach (var item in customs)
                {
                    if (item.GetType() == typeof(ManagedObjectAttribute))
                    {
                        ManagedObjectAttribute objAttr = item as ManagedObjectAttribute;

                        string code = objAttr.Code;
                        if (existsObjectList.Find(o => o == code) == null)
                        {
                            noexistsObjectList.Add(objAttr.ObjectName);
                        }
                    }
                }

                //  找出可用对象完整信息到listObject
                //  获取模块信息中全部可管理的对象attribute
                object[] attributes = theDll.GetCustomAttributes(typeof(ManagedObjectAttribute), false);
                for (int i = 0; i < attributes.Length; i++)
                {
                    ManagedObjectAttribute obj_attr = attributes[i] as ManagedObjectAttribute;
                    //  判断是否已经加入
                    if (noexistsObjectList.Find(o => o == obj_attr.ObjectName) != null)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(obj_attr.Code))
                            {
                                CDictObject obj = new CDictObject();
                                obj.Code = obj_attr.Code;
                                obj.Name = obj_attr.Name;
                                obj.Object = obj_attr.ObjectName;
                                obj.UsedFlag = 1;
                                obj.ModuleCode = module_code;

                                Type type = theDll.GetType(module_obj + "." + obj.Object);
                                obj.IsFunction = type.IsSubclassOf(typeof(FrmBase)) ? 1 : 0;
                                obj.HasFunctionPoint = typeof(IFunctionPoint).IsAssignableFrom(type) ? 1 : 0;

                                objectList.Add(obj);

                                //  有功能点时自动获取功能点信息
                                if (obj.HasFunctionPoint == 1)
                                {
                                    List<CDictFunctionPoint> listObjectFp = new List<CDictFunctionPoint>();
                                    foreach (Attribute attr in type.GetCustomAttributes(typeof(FunctionPointAttribute)))
                                    {
                                        FunctionPointAttribute fpattr = attr as FunctionPointAttribute;
                                        CDictFunctionPoint fp = new CDictFunctionPoint();
                                        fp.Code = obj.Code + "-" + fpattr.Code;
                                        fp.Name = fpattr.Name;
                                        fp.ObjectCode = obj.Code;
                                        fp.Describe = fpattr.Describe;

                                        listObjectFp.Add(fp);
                                    }
                                    if (listObjectFp.Count > 0)
                                    {
                                        obj.FunctionPointList = listObjectFp;
                                    }
                                    else
                                    {
                                        obj.HasFunctionPoint = 0;      //  没有设置具体功能点认为无功能点
                                    }
                                }
                            }
                            else continue;
                        }
                        catch (Exception ex)
                        {
                            MessageHelper.ShowWarning(ex.Message);
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowWarning(ex.Message);
            }
            finally
            {
                //  选择对象
                if(objectList.Count > 0)
                {
                    //  按代码排序
                    objectList.Sort((left, right) =>
                    {
                        int result = left.Code.CompareTo(right.Code);
                        if (result > 0) return 1;
                        else if (result < 0) return -1;
                        return 0;
                    });
                    FrmObjectAdd frm = new FrmObjectAdd();
                    frm.Init(objectList, module_name);
                    if(frm.ShowDialog() == DialogResult.OK)
                    {
                        //  添加节点
                        this.tlSysObject.FocusedNodeChanged -= tlSysObject_FocusedNodeChanged;
                        this.tlSysObject.BeginUpdate();    //  停止控件刷新

                        foreach (CDictObject obj in frm.DataObjectList)
                        {
                            TreeListNode onode = rnode.Nodes.Add(new object[] { obj.Code, obj.Name, obj.Object, obj.UsedFlag, obj.ModuleCode });
                            onode.Tag = obj;
                        }
                        this.tlSysObject.FocusedNodeChanged += tlSysObject_FocusedNodeChanged;
                        this.tlSysObject.EndUpdate();       //  控件刷新从BeginUpdate开始的改变
                    }
                    frm.Dispose();
                }
            }
        }

        private void bbiEditObject_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeListNode mnode = this.tlSysObject.FocusedNode;
            if (mnode != null)
            {
                CDictObject data = mnode.Tag as CDictObject;
                if (data != null)
                {
                    //  重新获取功能对象信息, 防止对象信息变更。
                    //  TODO：未验证？
                    string module_obj = this.tlSysObject.FocusedNode.ParentNode.GetValue(this.tlcObject).ToString();
                    Assembly theDll = Assembly.LoadFrom(EnvInfo.RunPath + module_obj + ".dll");
                    Type type = theDll.GetType(module_obj + "." + data.Object);
                    data.IsFunction = type.IsSubclassOf(typeof(FrmBase)) ? 1 : 0;
                    data.HasFunctionPoint = typeof(IFunctionPoint).IsAssignableFrom(type) ? 1 : 0;
                    if (data.HasFunctionPoint == 1)
                    {
                        List<CDictFunctionPoint> listObjectFp = new List<CDictFunctionPoint>();
                        foreach (Attribute attr in type.GetCustomAttributes(typeof(FunctionPointAttribute)))
                        {
                            FunctionPointAttribute fpattr = attr as FunctionPointAttribute;
                            CDictFunctionPoint fp = new CDictFunctionPoint();
                            fp.Code = data.Code + "-" + fpattr.Code;
                            fp.Name = fpattr.Name;
                            fp.ObjectCode = data.Code;
                            fp.Describe = fpattr.Describe;

                            listObjectFp.Add(fp);
                        }
                        if (listObjectFp.Count > 0)
                        {
                            data.FunctionPointList = listObjectFp;
                        }
                        else
                        {
                            data.HasFunctionPoint = 0;      //  没有设置具体功能点认为无功能点
                        }
                    }

                    FrmObjectEdit frm = new FrmObjectEdit();
                    frm.Init(data);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        data = frm.DataObject;
                        mnode.SetValue(tlcName, data.Name);
                        mnode.SetValue(tlcUsedFlag, data.UsedFlag);
                        mnode.Tag = data;
                        this.ucSysObject1.Init(data);
                    }
                    frm.Dispose();
                }
            }
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.FreshData();
        }

        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListHelper.ExportTo(this.tlSysObject, EnvInfo.RunPath);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

    }
}
