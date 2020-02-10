using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

using His6.Base;

namespace His6.SysSetup
{
    /// <summary>
    ///  导入模块
    /// </summary>
    public partial class FrmModuleAdd : XtraForm
    {
        //  数据
        public CDictModule DataModule
        {
            get;  private set;
        }
    
        public List<CDictObject> DataObjectList
        {
            get; private set;
        }


        public FrmModuleAdd()
        {
            InitializeComponent();
        }

        private List<CDictObject> getModuleObjectList(Assembly theDll, String moduleCode)
        {
            Type[] types = theDll.GetTypes();
            List<CDictObject> listObject = new List<CDictObject>();
            foreach (Type type in types)
            {
                if (type.GetInterface("IManagedControl") != null)
                {
                    try
                    {
                        IManagedControl mc = (IManagedControl)theDll.CreateInstance(type.FullName);
                        string _name = mc.ControlName;
                        string _code = mc.ControlCode;

                        if (!string.IsNullOrEmpty(_code))
                        {
                            CDictObject obj = new CDictObject();
                            obj.Code = _code;
                            obj.Name = _name;
                            obj.Object = type.Name;
                            obj.UsedFlag = 1;
                            obj.ModuleCode = moduleCode;
                            obj.IsFunction = (mc is FrmBase) ? 1 : 0;
                            obj.HasFunctionPoint = (mc is IFunctionPoint) ? 1 : 0;

                            listObject.Add(obj);

                            //  有功能点时自动获取功能点信息
                            if (obj.HasFunctionPoint == 1)
                            {
                                List<CDictFunctionPoint> listObjectFp = new List<CDictFunctionPoint>();
                                foreach (DataFunctionPoint fpi in ((IFunctionPoint)mc).FunctionPointList)
                                {
                                    CDictFunctionPoint fp = new CDictFunctionPoint();
                                    fp.Code = fpi.Code;
                                    fp.Name = fpi.Name;
                                    fp.ObjectCode = obj.Code;
                                    fp.Describe = fpi.Target.ToString();

                                    listObjectFp.Add(fp);
                                }
                                if(listObjectFp.Count > 0)
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
            return listObject;
        }

        private List<CDictObject> getModuleObjectListNew(Assembly theDll, String moduleCode, string moduleObject)
        {
            List<CDictObject> listObject = new List<CDictObject>();
            //  获取模块信息中全部可管理的对象attribute
            object[] attributes = theDll.GetCustomAttributes(typeof(ManagedObjectAttribute), false);
            for(int i = 0; i < attributes.Length; i++)
            {
                ManagedObjectAttribute obj_attr = attributes[i] as ManagedObjectAttribute;

                CDictObject obj = new CDictObject();
                obj.Code = obj_attr.Code;
                obj.Name = obj_attr.Name;
                obj.Object = obj_attr.ObjectName;
                obj.UsedFlag = 1;
                obj.ModuleCode = moduleCode;

                try
                {
                    Type type = theDll.GetType(moduleObject + "." + obj.Object);
                    obj.IsFunction = type.IsSubclassOf(typeof(FrmBase)) ? 1 : 0;
                    obj.HasFunctionPoint = typeof(IFunctionPoint).IsAssignableFrom(type) ? 1 : 0;

                    listObject.Add(obj);

                    //  有功能点时自动获取功能点信息
                    if (obj.HasFunctionPoint == 1)
                    {
                        List<CDictFunctionPoint> listObjectFp = new List<CDictFunctionPoint>();
                        try
                        {
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
                        }
                        catch (Exception ex)
                        {
                            MessageHelper.ShowWarning(moduleObject + "." + obj.Object + "功能点分析出现问题。\r\n" + ex.Message);
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
                catch (Exception ex)
                {
                    MessageHelper.ShowWarning( moduleObject + "." + obj.Object + "对象分析出现问题。\r\n" + ex.Message);
                }
            }
            return listObject;
        }

        public bool ImpModule(string filename)
        {
            bool ok = false;
            DisplayHelper.Show("正在获取模块及对象数据，请稍等...", "提示");

            this.DataModule = new CDictModule();
            this.DataModule.UsedFlag = 1;
            try
            {
                Assembly theDll = Assembly.LoadFrom(filename);
                object[] attributes = theDll.GetCustomAttributes(typeof(ManagedModuleAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    this.DataModule.Code = (attributes[0] as ManagedModuleAttribute).Code;
                }
                else
                {
                    DisplayHelper.Close();
                    MessageHelper.ShowError("选择的文件不是Wonder His功能模块，请重新选择！");
                    return false;
                }
                attributes = theDll.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    this.DataModule.Name = (attributes[0] as AssemblyTitleAttribute).Title;
                }
                attributes = theDll.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    this.DataModule.Describe = (attributes[0] as AssemblyDescriptionAttribute).Description;
                }

                //  文件时间及名称
                filename = filename.Substring(0, filename.Length - 4);
                int pos = filename.LastIndexOf(@"\");
                filename = filename.Substring(pos + 1);
                this.DataModule.FileTime = System.IO.File.GetLastWriteTime(theDll.Location).ToString("yyyy-MM-dd HH:mm:ss");
                this.DataModule.FileName = filename;

                //  取版本信息
                string _ver = theDll.FullName;
                pos = _ver.IndexOf("Version=");
                _ver = _ver.Substring(pos + 8);
                pos = _ver.IndexOf(",");
                this.DataModule.Version = _ver.Substring(0, pos);

                //  TODO: 用于比较性能，正式代码清理
                //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                //sw.Start();
                //this.DataObjectList = getModuleObjectList(theDll, this.DataModule.Code);
                //long t1 = sw.ElapsedMilliseconds;
                //sw.Restart();
                this.DataObjectList = getModuleObjectListNew(theDll, this.DataModule.Code, this.DataModule.FileName);
                //long t2 = sw.ElapsedMilliseconds;
                //sw.Stop();

                //  按代码排序
                this.DataObjectList.Sort((left, right) =>
                    {
                        int result = left.Code.CompareTo(right.Code);
                        if (result > 0) return 1;
                        else if (result < 0) return -1;
                        return 0;
                    }
                 );

                this.ucSysModule1.Init(this.DataModule);
                this.gcObject.DataSource = this.DataObjectList;
                ok = true;

            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message + "\r\n" + ex.StackTrace);
            }

            finally
            {
                this.gvObject.MasterRowExpanded += GvObject_MasterRowExpanded;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                DisplayHelper.Close();
            }

            return ok;
        }

        private void GvObject_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView fpView = gvObject.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;

            fpView.BeginUpdate();
            fpView.Columns["Code"].Caption = "代码";
            fpView.Columns["Name"].Caption = "名称";
            fpView.Columns["Describe"].Caption = "说明";

            fpView.Columns["ObjectCode"].Visible = false;
            fpView.Columns["Code"].OptionsColumn.ReadOnly = true;
            fpView.Columns["Name"].OptionsColumn.ReadOnly = true;
            fpView.EndUpdate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DataModule = this.ucSysModule1.GetData();
            if (this.DataModule != null)
            {
                CustomException ce = null;
                //  加入数据处理
                String json = StringHelper.SerializeObject<CDictModule>(this.DataModule);
                String jsono = StringHelper.SerializeObject<List<CDictObject>>(this.DataObjectList);
                List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
                parms.Add(new KeyValuePair<string, string>("moduleJson", json));
                parms.Add(new KeyValuePair<string, string>("objectJson", jsono));

                int rst = int.Parse(HttpDataHelper.HttpPostFormUrlWithInfo("BASE", "/setup/moduleadd", out ce, parms));
                if (rst == 1) this.DialogResult = DialogResult.OK;
                else MessageHelper.ShowError("新增模块发生错误。\r\n" + ce.Message);
            }
        }
    }
}
