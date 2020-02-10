
namespace His6.Base
{
    /// <summary>
    /// 文 件 名：可管理的控件
    /// 功能描述：带有代码名称的控件，可用于功能权限等管理
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public interface IManagedControl
    {
        /// <summary>
        /// 控件代码
        /// </summary>
        string ControlCode { get; }

        /// <summary>
        /// 控件名称
        /// </summary>
        string ControlName { get; }
    }
}
