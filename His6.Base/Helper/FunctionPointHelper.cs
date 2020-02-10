
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DevExpress.XtraBars;
using DevExpress.XtraEditors;

using His6.Model;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：功能点处理类
    /// 功能描述：对功能点相关功能进行处理, 一般使用“批量注册功能点”对实现IFunctionPoint接口的对象注册功能点
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public class FunctionPointHelper
    {

        #region 功能点有关处理

        /// <summary>
        /// 批量注册功能点
        /// </summary>
        /// <param name="ifp">实现IFunctionPoint接口对象</param>
        /// <param name="ctls">控件或组件列表</param>
        public void RegisterFunctionPoints(IFunctionPoint ifp, params object[] ctls)
        {
            FunctionPointAttribute[] fpas = (FunctionPointAttribute[])ifp.GetType().GetCustomAttributes(typeof(FunctionPointAttribute), false);
            Array.Sort(fpas);
            if (fpas.Length == ctls.Length)
            {
                for (int i = 0; i < fpas.Length; i++)
                {
                    //  取功能点的权限
                    bool authority = GetFunctionPointAuthority(ifp.ContainerCode, fpas[i].Code, fpas[i].Name, fpas[i].Describe);

                    //  记录功能点信息
                    string controlName = SetEvent(ctls[i], authority);
                    if (controlName == null)
                    {
                        controlName = "";
                    }
                    ifp.FunctionPointList.Add(new DataFunctionPoint(ifp.ContainerCode + "-" + fpas[i].Code, fpas[i].Name, controlName));
                }
            }
            else
            {
                LogHelper.Error(typeof(FunctionPointHelper).FullName, ifp.ContainerCode + "  " + ifp.GetType().ToString() + " 功能点参数与对象实体数量不一致。");
            }
        }

        /// <summary>
        ///  设置功能点事件
        /// </summary>
        /// <param name="ctl">功能点对象</param>
        /// <param name="authority">是否有权</param>
        /// <returns>返回控件名称</returns>
        private string SetEvent(object ctl, bool authority)
        {
            string controlName = "";
            //  根据功能点取值给控件加事件
            if (ctl is System.Windows.Forms.Control)
            {
                if (ctl is BaseEdit)        //  部分Dev控件继承自BasEdit可设置只读属性
                {
                    if (!authority)
                    {
                        ((BaseEdit)ctl).PropertiesChanged += new EventHandler(Ctl_PropertiesChanged);
                        ((BaseEdit)ctl).Properties.ReadOnly = true;
                    }
                    else
                    {
                        ((BaseEdit)ctl).Properties.ReadOnly = false;
                    }
                }
                else
                {
                    if (!authority)
                    {
                        ((System.Windows.Forms.Control)ctl).Enabled = false;
                        ((System.Windows.Forms.Control)ctl).EnabledChanged += new EventHandler(Ctl_EnabledChanged);
                    }
                }
                controlName = ((System.Windows.Forms.Control)ctl).Name;
            }
            else
            {   //  非Control类的功能点目前支持以下类型

                //  Dev下的BarButtonItem不是Control的子类
                if (ctl is UCBarButtonItemWithFP)
                {
                    UCBarButtonItemWithFP ctlfp = ctl as UCBarButtonItemWithFP;
                    ctlfp.ControlAuthority = authority;
                    controlName = ctlfp.Name;
                    ctlfp.Enabled = authority;
                }

                //  Dev下的BarEditItem不是Control的子类
                if (ctl is UCBarEditItemWithFP)
                {
                    UCBarEditItemWithFP ctlfp = ctl as UCBarEditItemWithFP;
                    ctlfp.ControlAuthority = authority;
                    controlName = ctlfp.Name;
                    ctlfp.Enabled = authority;
                }

                //  Dev下的NavBarItem不是Control的子类
                if (ctl is UCNavBarItemWithFP)
                {
                    UCNavBarItemWithFP ctlfp = ctl as UCNavBarItemWithFP;
                    ctlfp.ControlAuthority = authority;
                    controlName = ctlfp.Name;
                    ctlfp.Enabled = authority;
                }
            }

            return controlName;

        }

        /// <summary>
        ///  Dev控件基于BaseEdit控件的属性处理
        /// </summary>
        void Ctl_PropertiesChanged(object sender, EventArgs e)
        {
            if (e is System.ComponentModel.PropertyChangedEventArgs)
            {
                if (((System.ComponentModel.PropertyChangedEventArgs)e).PropertyName == "ReadOnly")
                {
                    if (sender is BaseEdit)
                    {
                        if (!((BaseEdit)sender).Properties.ReadOnly)
                        {
                            ((BaseEdit)sender).Properties.ReadOnly = true;
                        }
                    }
                }
            }
        }



        /// <summary>
        ///  普通控件的enabledChanged事件
        /// </summary>
        void Ctl_EnabledChanged(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.Control)sender).Enabled)
            {
                ((System.Windows.Forms.Control)sender).Enabled = false;
            }
        }

        #endregion


        /// <summary>
        ///  判别是否有功能点权限
        /// </summary>
        /// <param name="container_code">容器代码</param>
        /// <param name="code">代码</param>
        /// <param name="name">名称</param>
        /// <param name="describe">描述信息</param>
        /// <returns>是否有权限</returns>
        public static bool GetFunctionPointAuthority(string container_code,
            string code, string name, string describe)
        {
            if (String.IsNullOrEmpty(code))
            {
                return false;
            }

            //  判别是否有功能点记录，返回记录数（>0有权)
            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("fpCode", container_code + "-" + code),
                new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()),
                new KeyValuePair<string, string>("roles", EmpInfo.Roles)
            };
            CustomException ce = null;
            CDictFunctionPoint fp = HttpDataHelper.GetWithInfo<CDictFunctionPoint>("BASE", "/setup/funcpoint", out ce, parmList);

            return fp != null && fp.Code.Length > 0;
        }

    }
}
