using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

using DevExpress.XtraEditors;

using His6.Base;

namespace His6.Base
{
    /// <summary>
    /// 
    /// 文 件 名：基类窗口
    /// 功能描述：增加了以下属性： 窗口代码、窗口名称、参数（调用本窗口时传入的参数）
    ///           增加了以下函数： 系统初始化 public virtual bool Init() 用于主程序调用时需要执行的功能
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public partial class FrmBase : XtraForm
    {

        #region 私有成员与属性

        private string m_code;
        /// <summary>
        /// 窗口代码
        /// </summary>
        [Browsable(false)]
        public string ControlCode
        {
            get
            {
                if (string.IsNullOrEmpty(m_code))
                {
                    GetControlInfo();
                }
                return m_code;
            }
        }

        private string m_name;
        /// <summary>
        /// 窗口名称
        /// </summary>
        [Browsable(false)]
        public string ControlName
        {
            get
            {
                if (string.IsNullOrEmpty(m_name))
                {
                    GetControlInfo();
                }
                return m_name;
            }
        }

        /// <summary>
        ///  通过程序集获取ControlCode及ControlName的值
        /// </summary>
        private void GetControlInfo()
        {
            Assembly ass = Assembly.GetAssembly(this.GetType());
            object[] customs = ass.GetCustomAttributes(false);
            foreach (var item in customs)
            {
                if (item.GetType() == typeof(ManagedObjectAttribute))
                {
                    ManagedObjectAttribute objAttr = item as ManagedObjectAttribute;

                    if (objAttr.ObjectName == this.GetType().Name)
                    {
                        m_code = objAttr.Code;
                        m_name = objAttr.Name;
                    }
                }

            }
        }

        private string m_parameter;
        /// <summary>
        /// 窗口参数
        /// </summary>
        [Browsable(false)]
        public string ControlParameter
        {
            get
            {
                return this.m_parameter;
            }
        }

        #endregion

        #region 构造及初始化函数

        public FrmBase()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        /// <summary>
        /// 系统初始化
        /// </summary>
        /// <returns>是否成功</returns>
        public virtual bool Init()
        {
            string Info = "进入窗口-" + this.Text;
            LogHelper.Info(this, Info);
            return true;
        }

        /// <summary>
        ///  参数设置
        /// </summary>
        /// <param name="parameter">参数值</param>
        public virtual void SetParameter(string parameter)
        {
            this.m_parameter = parameter;
        }

        #endregion

    }
}
