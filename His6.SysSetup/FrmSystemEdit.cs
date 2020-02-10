using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using His6.Base;
using His6.Model;

namespace His6.SysSetup
{
    public partial class FrmSystemEdit : XtraForm
    {
        bool _IsNew = false;

        public FrmSystemEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  初始化参照数据
        /// </summary>
        /// <param name="roleListAll">角色列表</param>
        /// <param name="empListAll">员工列表</param>
        public void SetRefData(List<BDictRole> roleListAll, List<DataEmpDir> empListAll)
        {
            this.ucSystem1.RoleList = roleListAll;
            this.ucSystem1.EmpList = empListAll;
        }

        /// <summary>
        ///  自定义控件初始化
        /// </summary>
        /// <param name="isNew">是否新增</param>
        /// <param name="system">系统实体</param>
        /// <param name="roleList">选择的角色列表</param>
        /// <param name="empList">选择的人员列表</param>
        public void Init(bool isNew, BDictSystem system, List<BDictRole> roleList, List<DataEmpDir> empList)
        {
            this._IsNew = isNew;
            if (isNew)
            {
                this.Text = "系统新增";
            }
            this.ucSystem1.SetStatus(true, isNew);
            this.ucSystem1.Init(system, roleList, empList);
            //按钮不可见
            //btnRole.Visible = false;
            //btnEmp.Visible = false;
        }

        #region 系统有关数据

        public BDictSystem GetData()
        {
            return this.ucSystem1.GetData();
        }

        public List<BDictRole> GetRoles()
        {
            return this.ucSystem1.GetRoles();
        }
        public List<DataEmpDir> GetEmps()
        {
            return this.ucSystem1.GetEmps();
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //  获取数据
            BDictSystem system = this.ucSystem1.GetData();
            List<BDictRole> roles = this.ucSystem1.GetRoles();
            List<DataEmpDir> emps = this.ucSystem1.GetEmps();
            SystemWithRight systemToSave = new SystemWithRight();            
            systemToSave.RoleList = roles;
            systemToSave.EmpList = emps;

            
            if (_IsNew)
            {
                bool common = false; 
                if(EmpInfo.IsCenterAdmin)
                {
                    if(MessageHelper.ShowYesNoAndQuestion("是否加入到公共系统？") == DialogResult.Yes)
                    {
                        common = true;
                    }
                }
                int new_id = 0;
                CustomException ce = null;
                //  获取下一个系统ID，common为true时在10000以内找，否则在 机构ID + [0001-9999] 找
                if (common)
                {
                    new_id = HttpDataHelper.GetWithInfo<int>("BASE", "/setup/newsysidcenter", out ce);
                }
                else
                {
                    var parmList = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("branchId", EnvInfo.BranchId.ToString())
                    };
                    new_id = HttpDataHelper.GetWithInfo<int>("BASE", "/setup/newsysid", out ce, parmList);                    
                }
                if (new_id == -1)
                {
                    MessageHelper.ShowError("可用的机构ID已满！");
                    return;
                }
                systemToSave.SystemInfo = system;
                system.Id = new_id;
                String str = StringHelper.SerializeObject<SystemWithRight>(systemToSave);

                // 加入数据
                HttpDataHelper.HttpPostWithInfo("BASE", "/setup/systemadd", out ce, str);
            }
            else
            {
                systemToSave.SystemInfo = system;
                String str = StringHelper.SerializeObject<SystemWithRight>(systemToSave);
                // 保存数据
                CustomException ce = null;
                HttpDataHelper.HttpPostWithInfo("BASE", "/setup/systemset", out ce, str);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            this.ucSystem1.SelectRole();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            this.ucSystem1.SelectEmp();
        }

    }
}
