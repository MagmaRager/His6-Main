using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using His6.Model.Base;

namespace His6.Base.Helper
{
    public static class Utilities
    {
        /// <summary>
        /// 获取服务数据集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="isShow">Status不为0: 是否弹窗</param>
        /// <returns></returns>
        public static T GetServiceData<T>(this BaseResultData<T> result, bool isShow = true)
        {
            var data = default(T);
            //todo 硬编码，需要调整
            if (result.Status == 0)
            {
                data = result.Data;
            }
            else
            {
                if (isShow)
                {
                    MessageHelper.ShowWarning(result.Msg);
                }

                LogHelper.Info(typeof(Utilities).FullName, result.Msg);
            }

            return data;
        }
        /// <summary>
        /// 时间戳计时开始时间
        /// </summary>
        private static DateTime TimeStampStartTime = new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc);

        public static string ToStringN(this Guid guid)
        {
            return guid.ToString("N");
        }
        /// <summary>
        /// DateTime转换为13位时间戳（单位：毫秒）utc模式
        /// </summary>
        /// <param name="dateTime"> DateTime</param>
        /// <returns>13位时间戳（单位：毫秒）</returns>
        public static long GetLongTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - TimeStampStartTime).TotalMilliseconds;
        }
        /// <summary>
        /// 服务是否调用成功
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsServiceSucc(this BaseResult result)
        {
            if (result?.Status == BaseConst.ServiceState.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 实体是否处于编辑状态 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsModifyOrAdd(this BaseEntity entity)
        {
            var result = false;
            if (entity != null)
            {
                if (entity.EditState == BaseConst.EditState.Add || entity.EditState == BaseConst.EditState.Edit)
                {
                    result = true;
                }
            }

            return result;
        }
        /// <summary>
        /// 实体是否处于修改状态
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsModify(this BaseEntity entity)
        {
            var result = entity?.EditState == BaseConst.EditState.Edit;
            return result;
        }
        /// <summary>
        /// /实体是否处于新增状态
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsAdd(this BaseEntity entity)
        {
            var result = entity?.EditState == BaseConst.EditState.Add;
            return result;
        }
        /// <summary>
        /// 转换为 int?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToIntNull(this object obj)
        {
            var value = obj?.ToString();
            if (int.TryParse(value, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 转换为 long?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long? ToLongNull(this object obj)
        {
            var value = obj?.ToString();
            if (long.TryParse(value, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 转换为 datetime?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToDateNull(this object obj)
        {
            var value = obj?.ToString();
            if (DateTime.TryParse(value, out var result))
            {
                return result.Date;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 转换为 short?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short? ToShortNull(this object obj)
        {
            var value = obj?.ToString();
            if (short.TryParse(value, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 转换为 double?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToDoubleNull(this object obj)
        {
            var value = obj?.ToString();
            if (double.TryParse(value, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 转换为 decimal?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNull(this object obj)
        {
            var value = obj?.ToString();
            if (decimal.TryParse(value, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 转换为 short?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? NullToShort(object obj)
        {
            var value = obj?.ToString();
            if (float.TryParse(value, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 转换为 int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(this object obj)
        {
            var value = obj?.ToString();
            int.TryParse(value, out var result);
            return result;
        }
        /// <summary>
        /// 转换为 long
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToLong(this object obj)
        {
            var value = obj?.ToString();
            long.TryParse(value, out var result);
            return result;
        }
        /// <summary>
        /// 转换为 DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDate(this object obj)
        {
            var value = obj?.ToString();
            DateTime.TryParse(value, out var result);
            return result;
        }
        /// <summary>
        /// 转换为 short
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short ToShort(this object obj)
        {
            var value = obj?.ToString();
            short.TryParse(value, out var result);
            return result;
        }
        /// <summary>
        /// 转换为 double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble(this object obj)
        {
            var value = obj?.ToString();
            double.TryParse(value, out var result);
            return result;
        }
        /// <summary>
        /// 转换为 decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj)
        {
            var value = obj?.ToString();
            decimal.TryParse(value, out var result);
            return result;
        }
        /// <summary>
        /// 转换为 float
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ToFloat(object obj)
        {
            var value = obj?.ToString();
            float.TryParse(value, out var result);
            return result;
        }

        /// <summary>
        /// 日期转字符串  yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDateStr(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
