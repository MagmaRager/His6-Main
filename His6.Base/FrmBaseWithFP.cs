using System.Collections.Generic;
using System.ComponentModel;

namespace His6.Base
{
    /// <summary>
    /// 
    /// 文 件 名：带功能点的基类窗口
    /// 功能描述：属性： 功能点列表 FunctionPointList         用于记录本窗口的功能点数据信息。
    ///                  功能点处理对象 _FunctionPointHelper  用于功能点注册处理
    ///           注册方法：注册多个功能点对象  _FunctionPointHelper.RegisterFunctionPoints(this, ... ) ; 
    ///                     完成后在FunctionPointList中存入注册的数据，并关联上功能点对象的相关事件。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：

    /// </summary>
    public partial class FrmBaseWithFP : FrmBase, IFunctionPoint
    {
        public FrmBaseWithFP()
        {
            InitializeComponent();
        }

        #region 功能点有关处理

        /// <summary>
        ///  功能点信息数据
        /// </summary>
        private List<EntityFunctionPoint> _FunctionPointList = new List<EntityFunctionPoint>();

        /// <summary>
        ///  功能点处理对象
        /// </summary>
        protected FunctionPointHelper _FunctionPointHelper = new FunctionPointHelper();

        /// <summary>
        /// 功能点列表
        /// </summary>
        [Browsable(false)]
        public List<EntityFunctionPoint> FunctionPointList
        {
            get { return this._FunctionPointList; }
        }

        /// <summary>
        /// 功能容器代码
        /// </summary>
        [Browsable(false)]
        public string ContainerCode
        {
            get { return this.ControlCode; }
        }

        #endregion

    }
}
