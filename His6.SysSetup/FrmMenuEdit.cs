using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using His6.Model;
using His6.Base;

namespace His6.SysSetup
{
    public partial class FrmMenuEdit : XtraForm
    {
        bool _IsNew = false;

        public FrmMenuEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  初始化参照数据
        /// </summary>
        /// <param name="moduleList">模块列表</param>
        /// <param name="objectList">对象列表</param>
        /// <param name="roleListAll">角色列表</param>
        /// <param name="empListAll">员工列表</param>
        public void SetRefData(List<CDictModule> moduleList, List<CDictObject> objectList, List<BDictRole> roleListAll, List<DataEmpDir> empListAll)
        {
            this.ucMenu1.RoleList = roleListAll;
            this.ucMenu1.EmpList = empListAll;
            this.ucMenu1.ModuleList = moduleList;
            this.ucMenu1.ObjectList = objectList;

        }
        
        /// <summary>
        ///  自定义控件初始化
        /// </summary>
        /// <param name="isNew">是否新增</param>
        /// <param name="menu">菜单实体</param>
        /// <param name="roleList">选择的角色列表</param>
        /// <param name="empList">选择的人员列表</param>
        public void Init(bool isNew ,BDictMenu menu, List<BDictRole> roleList, List<DataEmpDir> empList)
        {
            this._IsNew = isNew;
            if (isNew)
            {
                this.Text = "菜单新增";
            }
            this.ucMenu1.SetStatus(true);
            this.ucMenu1.Init(menu, roleList, empList);
            //按钮不可见
            //btnRole.Visible = false;
            //btnEmp.Visible = false;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //  获取数据
            BDictMenu menu = this.ucMenu1.GetData();
            List<BDictRole> roles = this.ucMenu1.GetRoles();
            List<DataEmpDir> emps = this.ucMenu1.GetEmps();
            MenuWithRight menuToSave = new MenuWithRight();
            menuToSave.MenuInfo = menu;
            menuToSave.RoleList = roles;
            menuToSave.EmpList = emps;
            
            //  保存数据
            String str = StringHelper.SerializeObject<MenuWithRight>(menuToSave);
            CustomException ce = null;
            if (_IsNew) {
                HttpDataHelper.HttpPostWithInfo("BASE", "/setup/menuadd", out ce, str);
            }
            else
            {
                HttpDataHelper.HttpPostWithInfo("BASE", "/setup/menuset", out ce, str);
            }
            

            this.DialogResult = DialogResult.OK;
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            this.ucMenu1.SelectRole();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            this.ucMenu1.SelectEmp();
        }

        #region 菜单有关数据

        public BDictMenu GetData()
        {
            return this.ucMenu1.GetData();
        }

        public List<BDictRole> GetRoles()
        {
            return this.ucMenu1.GetRoles();
        }
        public List<DataEmpDir> GetEmps()
        {
            return this.ucMenu1.GetEmps();
        }

        #endregion

    }
}
