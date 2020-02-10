using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base.Helper
{
   public static class BaseConst
    {
        /// <summary>
        /// 服务调用返回状态
        /// </summary>
        public static class ServiceState
        {
            /// <summary>
            /// 成功
            /// </summary>
            public const int Success = 0;
        }
        public static class StateFlag
        {
            /// <summary>
            /// 删除标记
            /// </summary>
            public const string DeleteFlag = "2";
            /// <summary>
            /// 在用标记
            /// </summary>
            public const string UseFlag = "1";
            /// <summary>
            /// 停用标记
            /// </summary>
            public const string UnUseFlag = "0";
        }
        /// <summary>
        /// 编辑状态
        /// </summary>
        public static class EditState
        {
            /// <summary>
            /// 新增
            /// </summary>
            public const int Add = 1;
            /// <summary>
            /// 修改
            /// </summary>
            public const int Edit = 2;
        }
    }
}
