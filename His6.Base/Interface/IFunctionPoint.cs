using System.Collections.Generic;
using System.ComponentModel;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：带功能点的接口
    /// 功能描述：实现有功能点的控件,功能点通过FunctionPointAtribute定义
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public interface IFunctionPoint
    {
        /// <summary>
        /// 功能点列表
        /// </summary>
        [Browsable(false)]
        List<DataFunctionPoint> FunctionPointList { get; }

        /// <summary>
        /// 容器控件代码（对应控件ControlCode）
        /// </summary>
        [Browsable(false)]
        string ContainerCode { get; }
    }
}
