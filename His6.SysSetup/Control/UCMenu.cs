using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

using His6.Base;
using His6.Model;

namespace His6.SysSetup
{
    public partial class UCMenu : UserControl
    {

        private int systemId = -1;
        private string objectCode = string.Empty;
        private bool editStatus = false;

        #region 增加修改需要的选择数据

        /// <summary>
        ///  模块列表
        /// </summary>
        public List<CDictModule> ModuleList
        {
            get;
            set;
        }

        /// <summary>
        ///  对象列表
        /// </summary>
        public List<CDictObject> ObjectList
        {
            get;
            set;
        }

        /// <summary>
        ///  角色列表
        /// </summary>
        public List<BDictRole> RoleList
        {
            get;
            set;
        }

        /// <summary>
        ///  员工列表
        /// </summary>
        public List<DataEmpDir> EmpList
        {
            get;
            set;
        }

        #endregion

        public UCMenu()
        {
            InitializeComponent();
        }

        public void Init(BDictMenu menu, List<BDictRole> roleList, List<DataEmpDir> empList)
        {
            this.systemId = menu.SystemId;
            this.objectCode = menu.ObjectCode;

            this.teCode.Text = menu.Code;
            this.teTitle.Text = menu.Title;
            this.tePrompt.Text = menu.Prompt;
            this.beIco.Text = menu.Ico;
            this.beParameter.Text = menu.Parameter;
            this.icbeOpenFlag.EditValue = menu.WinState;
            this.beObjectName.Text = getObjectName();

            this.changedObject();

            gcRole.DataSource = roleList;
            gcEmp.DataSource = empList;
            //按钮不可见
            //if (editStatus == true)
            //{
            //    groupControl2.Visible = false;
            //}
        }

        /// <summary>
        ///  获取对象名称（模块名 + 对象名）
        /// </summary>
        /// <returns></returns>
        private string getObjectName()
        {
            string object_name = string.Empty;
            if (!string.IsNullOrEmpty(this.objectCode))
            {
                CDictObject obj = this.ObjectList.Find(o => { return o.Code == this.objectCode; });
                if (obj != null)
                {
                    CDictModule module = this.ModuleList.Find(o => { return o.Code == obj.ModuleCode; });
                    if (module != null)
                    {
                        object_name = module.Name + " --- " + obj.Name;
                        try
                        {
                            //  查找参数说明
                            Assembly theDll = Assembly.LoadFrom(EnvInfo.RunPath + module.FileName + ".dll");
                            Type type = theDll.GetType(module.FileName + "." + obj.Object);
                            FormParmDescAttribute attr = type.GetCustomAttribute(typeof(FormParmDescAttribute)) as FormParmDescAttribute;
                            if (attr != null)
                            {
                                this.beParameter.Properties.Buttons[0].Visible = true;
                                this.beParameter.Properties.Buttons[0].ToolTip = "描述：" + attr.Description + "\r\n实例：" + attr.Example;
                            }
                            else
                            {
                                this.beParameter.Properties.Buttons[0].Visible = false;
                            }
                        }
                        catch { }
                    }
                }
            }

            return object_name;
        }

        private void changedObject()
        {
            bool isObject = !(this.beObjectName.Text == string.Empty);

            this.icbeOpenFlag.Visible = isObject;
            this.lblOpenFlag.Visible = isObject;
            this.beParameter.Visible = isObject;
            this.lblParameter.Visible = isObject;

            //  修改时有对象显示“清除对象"
            this.beObjectName.Properties.Buttons[1].Visible = isObject && !this.teTitle.Properties.ReadOnly;
        }

        /// <summary>
        ///  状态设置
        /// </summary>
        /// <param name="isEdit"></param>
        public void SetStatus(bool isEdit)
        {
            //  代码表示层级关系，不允许修改
            this.teCode.Properties.ReadOnly = true ;
            this.teTitle.Properties.ReadOnly = !isEdit;
            this.tePrompt.Properties.ReadOnly = !isEdit;
            this.beParameter.Properties.ReadOnly = !isEdit;

            this.beIco.Properties.ReadOnly = true;
            this.beIco.Properties.Buttons[0].Visible = isEdit;

            this.beObjectName.Properties.ReadOnly = true;
            this.beObjectName.Properties.Buttons[0].Visible = isEdit;
            this.beObjectName.Properties.Buttons[1].Visible = isEdit;

            this.icbeOpenFlag.Properties.ReadOnly = !isEdit;

            this.editStatus = isEdit;
        }

        /// <summary>
        ///  获取菜单数据
        /// </summary>
        /// <returns></returns>
        public BDictMenu GetData()
        {
            BDictMenu menu = new BDictMenu();
            menu.Code = this.teCode.Text;
            menu.Title = this.teTitle.Text;
            menu.Prompt = this.tePrompt.Text;
            menu.Parameter = this.beParameter.Text;
            menu.Ico = this.beIco.Text;
            menu.WinState = Convert.ToInt32(this.icbeOpenFlag.EditValue);

            menu.SystemId = this.systemId;
            menu.ObjectCode = this.objectCode == null ? "" : this.objectCode;

            return menu;
        }

        /// <summary>
        ///  获取角色
        /// </summary>
        /// <returns></returns>
        public List<BDictRole> GetRoles()
        {
            return this.gcRole.DataSource as List<BDictRole>;
        }

        /// <summary>
        ///  获取人员
        /// </summary>
        /// <returns></returns>
        public List<DataEmpDir> GetEmps()
        {
            return this.gcEmp.DataSource as List<DataEmpDir>;
        }

        private void beIco_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = beIco.Text;
            openFileDialog.InitialDirectory = EnvInfo.RunPath + "ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                beIco.Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf(@"\") + 1);
            }

        }

        private void beObjectName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 0)
            {
                //  选择功能
                FrmObjectChoose frm = new FrmObjectChoose();
                frm.Init(this.ModuleList, this.ObjectList, this.objectCode);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.objectCode = frm.GetData();
                    this.beObjectName.Text = getObjectName();
                    this.changedObject();
                }
                frm.Dispose();
            }
            else
            {
                //  清除
                this.objectCode = string.Empty;
                this.beObjectName.Text = string.Empty;
                this.changedObject();
            }
        }

        public void SelectRole()
        {
            if (this.editStatus)
            {
                FrmSelectRole frm = new FrmSelectRole();
                frm.SetDataSource(this.RoleList, this.gcRole.DataSource as List<BDictRole>);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<BDictRole> new_selected = frm.RoleSelected;
                    gcRole.DataSource = new_selected;
                }
                frm.Dispose();
            }
        }

        public void SelectEmp()
        {
            if (this.editStatus)
            {
                FrmSelectEmp frm = new FrmSelectEmp();
                frm.SetDataSource(this.EmpList, this.gcEmp.DataSource as List<DataEmpDir>);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<DataEmpDir> new_selected = frm.EmpSelected;
                    gcEmp.DataSource = new_selected;
                }
                frm.Dispose();
            }
        }

        private void gvRole_DoubleClick(object sender, EventArgs e)
        {
            this.SelectRole();
        }

        private void gvEmp_DoubleClick(object sender, EventArgs e)
        {
            this.SelectEmp();
        }
    }
}
