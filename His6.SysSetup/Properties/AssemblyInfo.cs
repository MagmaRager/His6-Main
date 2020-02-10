using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using His6.Base;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("系统设置")]
[assembly: AssemblyDescription("系统基础信息设置")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("His6.SysSetup")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("a1cbf9be-5b9d-4851-a802-5385b08a66a0")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: ManagedModule("SYS")]
[assembly: ManagedObject("FrmObjectSetup", "SYS-W01", "系统对象设置")]
[assembly: ManagedObject("FrmMenuSetup", "SYS-W02", "系统菜单设置")]
[assembly: ManagedObject("FrmFunctionPointSetup", "SYS-W03", "功能点权限设置")]
[assembly: ManagedObject("FrmParameterSetup", "SYS-W04", "系统参数设置")]
[assembly: ManagedObject("FrmParameterEmpSetup", "SYS-W05", "人员参数设置")]
[assembly: ManagedObject("FrmReportSet", "SYS-W06", "报表模板设置")]
[assembly: ManagedObject("FrmComputerPrintSet", "SYS-W07", "指定打印机设置")]

