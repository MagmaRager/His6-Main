using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：服务数据类
    /// 功能描述：用于对Http的GET，POST数据服务处理
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public static class HttpDataHelper
    {
        /// <summary>
        ///  所有服务地址目录: Key为名称，Value为地址
        /// </summary>
        static Dictionary<String, String> _Urls;

        static HttpClient _HttpClient;
        static HttpDataHelper()
        {
            _HttpClient = new HttpClient();
            _Urls = new Dictionary<string, string>();
            SetServiceUrl();
        }

        #region 基本的Http地址对应

        /**
         * 设置服务URL列表
         */
        //public static int SetServiceUrl(String app, String url, int branchId)
        //{
        //    CustomException ei;
        //    _Urls = PathGetWithInfo<Dictionary<String, String>>(app, url, out ei, branchId.ToString());
        //    if (ei == null) { return _Urls.Count; }
        //    else throw ei;
        //}

        private static void SetServiceUrl()
        {            
            string keys = ConfigurationManager.AppSettings.Get("ServiceKeys");
            string[] keyls = keys.Split(',');
            foreach(string key in keyls)
            {
                string url = ConfigurationManager.AppSettings.Get(key);
                _Urls.Add(key, url);
            }            
        }

        /**
         * 获取对应模块&服务的Url 
         */
        private static String GetUrl(String app, String url)
        {
            String urlf;
            if (_Urls.TryGetValue(app, out urlf))
            {
                return urlf + url;
            }
            return null;
        }

        #endregion


        #region GET 数据获取(错误返回异常信息)

        /// <summary>
        ///  GET 字符串数据获取（同步），同时获取状态码，按状态码识别是否成功。
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数对列表</param>
        /// <returns></returns>
        public static String GetStringWithInfo(String app, String url, out CustomException ce, List<KeyValuePair<String, String>> parmList = null)
        {
            String result = String.Empty;
            String urlcomp = GetUrl(app, url);
            if (parmList != null && parmList.Count > 0)
            {
                urlcomp = AppendUrlWithParameter(urlcomp, parmList);
            }
            try
            {
                SetHeader();
                HttpResponseMessage response = _HttpClient.GetAsync(urlcomp).Result;
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    GetToken(response);
                    ce = null;
                }
                else if (statusCode.Equals("Conflict")) //业务错误
                {
                    CustomExceptionInfo info = JsonConvert.DeserializeObject<CustomExceptionInfo>(result);
                    ce = new CustomException(info);
                }
                else if (statusCode.Equals("PreconditionFailed")) //jwt过期
                {
                    if (DoRelogin())
                    {
                        return GetStringWithInfo(app, url, out ce, parmList); //产生新的jwt，方法重新执行
                    }
                    else ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
                else //其它错误
                {
                    ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
            }
            catch (Exception e)
            {
                ce = new CustomException("服务异常", e.Message + " [" + urlcomp + "]", e.StackTrace);
                RemoveHeader();
                return String.Empty;
            }
            RemoveHeader();
            return result;
        }

        /// <summary>
        ///  restful路径方式GET 实体数据获取（同步），同时获取状态码，按状态码识别是否成功。
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数值数组</param>
        /// <returns></returns>
        public static T GetWithInfo<T>(String app, String url, out CustomException exInfo, List<KeyValuePair<String, String>> parmList = null)
        {
            String result = GetStringWithInfo(app, url, out exInfo, parmList);
            Nullable<int> i;
                if (exInfo != null || result.Length == 0)
            {
                return default(T);
            }            
            return JsonConvert.DeserializeObject<T>(result);
        }

        #endregion 

        #region POST 提交数据(错误返回异常信息)

        /// <summary>
        /// POST方法，json传入RequestBody
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static String HttpPostWithInfo(String app, String url, out CustomException ce, String json)
        {
            String result = String.Empty;
            String urlcomp = GetUrl(app, url);
            var content = new StringContent(json, Encoding.UTF8, "application/json"); //Content-Type设置
            try
            {
                SetHeader();
                HttpResponseMessage response = _HttpClient.PostAsync(urlcomp, content).Result;
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    GetToken(response);
                    ce = null;
                }
                else if (statusCode.Equals("Conflict")) //业务错误
                {
                    CustomExceptionInfo info = JsonConvert.DeserializeObject<CustomExceptionInfo>(result);
                    ce = new CustomException(info);
                }
                else if (statusCode.Equals("PreconditionFailed")) //jwt过期
                {
                    if (DoRelogin())
                    {
                        return HttpPostWithInfo(app, url, out ce, json); //产生新的jwt，方法重新执行
                    }
                    else ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
                else //其它错误
                {
                    ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
            }
            catch (Exception e)
            {
                ce = new CustomException("服务异常", e.Message + " [" + urlcomp + "]", e.StackTrace);
                RemoveHeader();
                return String.Empty;
            }
            RemoveHeader();
            return result;
        }

        /// <summary>
        /// POST方法，键值对传入RequestBody参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static String HttpPostFormUrlWithInfo(String app, String url, out CustomException ce, List<KeyValuePair<String, String>> list)
        {
            String result = String.Empty;
            var content = new FormUrlEncodedContent(list);
            String urlcomp = GetUrl(app, url);
            try
            {
                SetHeader();
                HttpResponseMessage response = _HttpClient.PostAsync(urlcomp, content).Result;
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    GetToken(response);
                    ce = null;
                }
                else if (statusCode.Equals("Conflict")) //业务错误
                {
                    CustomExceptionInfo info = JsonConvert.DeserializeObject<CustomExceptionInfo>(result);
                    ce = new CustomException(info);
                }
                else if (statusCode.Equals("PreconditionFailed")) //jwt过期
                {
                    if (DoRelogin())
                    {
                        return HttpPostFormUrlWithInfo(app, url, out ce, list); //产生新的jwt，方法重新执行
                    }
                    else ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
                else //其它错误
                {
                    ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
            }
            catch (Exception e)
            {
                ce = new CustomException("服务异常", e.Message + " [" + urlcomp + "]", e.StackTrace);
                RemoveHeader();
                return String.Empty;
            }
            RemoveHeader();
            return result;
        }

        /// <summary>
        /// POST方法，键值对传入UrlParam
        /// </summary>
        /// <param name="url"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static String HttpPostFormUrlParamWithInfo(String app, String url, out CustomException ce, List<KeyValuePair<String, String>> parmList)
        {
            String result = String.Empty;
            String urlcomp = GetUrl(app, url);
            if (parmList != null && parmList.Count > 0)
            {
                urlcomp = AppendUrlWithParameter(urlcomp, parmList);
            }
            try
            {
                SetHeader();
                HttpResponseMessage response = _HttpClient.PostAsync(urlcomp, null).Result;
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    GetToken(response);
                    ce = null;
                }
                else if (statusCode.Equals("Conflict")) //业务错误
                {
                    CustomExceptionInfo info = JsonConvert.DeserializeObject<CustomExceptionInfo>(result);
                    ce = new CustomException(info);
                }
                else if (statusCode.Equals("PreconditionFailed")) //jwt过期
                {
                    if (DoRelogin())
                    {
                        return HttpPostFormUrlParamWithInfo(app, url, out ce, parmList); //产生新的jwt，方法重新执行
                    }
                    else ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
                else //其它错误
                {
                    ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
            }
            catch (Exception e)
            {
                ce = new CustomException("服务异常", e.Message + " [" + urlcomp + "]", e.StackTrace);
                RemoveHeader();
                return String.Empty;
            }
            RemoveHeader();
            return result;
        }

        /// <summary>
        /// POST方法（解压缩方法），json传入RequestBody
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static String HttpPostGZipWithInfo(String app, String url, out CustomException ce, String json)
        {
            String result = String.Empty;
            var content = new StringContent(json);
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            String urlcomp = GetUrl(app, url);
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                SetHeader();
                var response = http.PostAsync(urlcomp, content).Result; //await异步等待回应
                                                                    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;//result就是返回的结果。

                if (response.IsSuccessStatusCode)
                {
                    GetToken(response);
                    ce = null;
                }
                else if (statusCode.Equals("Conflict")) //业务错误
                {
                    CustomExceptionInfo info = JsonConvert.DeserializeObject<CustomExceptionInfo>(result);
                    ce = new CustomException(info);
                }
                else if (statusCode.Equals("PreconditionFailed")) //jwt过期
                {
                    if (DoRelogin())
                    {
                        return HttpPostGZipWithInfo(app, url, out ce, json); //产生新的jwt，方法重新执行
                    }
                    else ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
                else //其它错误
                {
                    ce = new CustomException(statusCode, "at " + urlcomp, "");
                }
                RemoveHeader();
            }
            return result;
        }

        #endregion

        #region Url组成
        

        /// <summary>
        ///  形成带参数的GET Url地址
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parmList">参数对列表</param>
        /// <returns></returns>
        private static string AppendUrlWithParameter(string url, List<KeyValuePair<string, string>> parmList)
        {
            Boolean first = true;
            StringBuilder sb = new StringBuilder(url);
            foreach (KeyValuePair<String, String> parm in parmList)
            {
                if (first)
                {
                    sb.Append("?");
                    first = false;
                }
                else
                {
                    sb.Append("&");
                }
                sb.Append(parm.Key);
                sb.Append("=");
                sb.Append(parm.Value);
            }

            return sb.ToString();
        }

        /// <summary>
        ///  形成带参数的GET Url Path地址
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parmList">参数值列表</param>
        /// <returns></returns>
        //private static string AppendUrlWithPath(string url, params String[] parms)
        //{
        //    StringBuilder sb = new StringBuilder(url);
        //    foreach (String parm in parms)
        //    {
        //        sb.Append("/");
        //        sb.Append(parm);
        //    }

        //    return sb.ToString();
        //}
        #endregion

        #region GET 数据获取（以HttpDataGeneric<T>方式返回）

        /// <summary>
        ///  GET 字符串数据获取（同步），同时获取状态码，按状态码识别是否成功。
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数对列表</param>
        /// <returns></returns>
        public static HttpDataGeneric<String> GetStringByHD(String app, String url, List<KeyValuePair<String, String>> parmList = null)
        {
            String result = String.Empty;
            CustomException exInfo = null;
            String urlcomp = GetUrl(app, url);
            if (parmList != null && parmList.Count > 0)
            {
                urlcomp = AppendUrlWithParameter(urlcomp, parmList);
            }
            try
            {
                SetHeader();
                HttpResponseMessage response = _HttpClient.GetAsync(urlcomp).Result;
                String statusCode = response.StatusCode.ToString();
                result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    GetToken(response);
                    exInfo = null;
                }
                else if (statusCode.Equals("Conflict")) //业务错误
                {
                    exInfo = JsonConvert.DeserializeObject<CustomException>(result);
                }
                else if (statusCode.Equals("PreconditionFailed")) //jwt过期
                {
                    if (DoRelogin())
                    {
                        return GetStringByHD(app, url, parmList); //产生新的jwt，方法重新执行
                    }
                    exInfo = new CustomException(statusCode, "at " + urlcomp, "");
                }
                else //其它错误
                {
                    exInfo = new CustomException(statusCode, "at " + urlcomp, "");
                }
            }
            catch (Exception e)
            {
                exInfo = new CustomException("服务异常", e.Message + " [" + urlcomp + "]", e.StackTrace);
                RemoveHeader();
            }
            RemoveHeader();
            HttpDataGeneric<String> data = new HttpDataGeneric<string>();
            data.DataEntity = result;
            data.ExceptionInfo = exInfo;
            return data;
        }

        /// <summary>
        ///  restful路径方式GET 实体数据获取（同步），同时获取状态码，按状态码识别是否成功。
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数值数组</param>
        /// <returns></returns>
        public static HttpDataGeneric<T> GetByHD<T>(String app, String url, List<KeyValuePair<String, String>> parmList = null)
        {
            CustomException ei = null;
            T data = GetWithInfo<T>(app, url, out ei, parmList);
            HttpDataGeneric<T> rst = new HttpDataGeneric<T>();
            rst.DataEntity = data;
            rst.ExceptionInfo = ei;
            return rst;
        }

        #endregion

        #region POST 提交数据（以HttpDataGeneric<T>方式返回）

        /// <summary>
        /// POST方法，json传入RequestBody
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static HttpDataGeneric<String> HttpPostByHD(String app, String url, String json)
        {
            CustomException ei = null;
            String data = HttpPostWithInfo(app, url, out ei, json);
            HttpDataGeneric<String> rst = new HttpDataGeneric<string>();
            rst.DataEntity = data;
            rst.ExceptionInfo = ei;
            return rst;
        }

        /// <summary>
        /// POST方法，键值对传入RequestBody参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static HttpDataGeneric<String> HttpPostFormUrlByHD(String app, String url, List<KeyValuePair<String, String>> list)
        {
            CustomException ei = null;
            String data = HttpPostFormUrlWithInfo(app, url, out ei, list);
            HttpDataGeneric<String> rst = new HttpDataGeneric<string>();
            rst.DataEntity = data;
            rst.ExceptionInfo = ei;
            return rst;
        }

        /// <summary>
        /// POST方法（解压缩方法），json传入RequestBody
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static HttpDataGeneric<String> HttpPostGZipByHD(String app, String url, String json)
        {
            CustomException ei = null;
            String data = HttpPostGZipWithInfo(app, url, out ei, json);
            HttpDataGeneric<String> rst = new HttpDataGeneric<string>();
            rst.DataEntity = data;
            rst.ExceptionInfo = ei;
            return rst;
        }
        #endregion

        #region Header相关处理

        private static void SetHeader()
        {
            // SQL调试参数
            if (!String.IsNullOrEmpty(EnvInfo.SqlHeader)) _HttpClient.DefaultRequestHeaders.Add("DEBUG_SQL", EnvInfo.SqlHeader);
            // JWT  
            if (!String.IsNullOrEmpty(EnvInfo.JwtToken)) _HttpClient.DefaultRequestHeaders.Add("JWT_TOKEN", EnvInfo.JwtToken);
            // IP
            _HttpClient.DefaultRequestHeaders.Add("X-Forwarded-For", EnvInfo.ComputerIp);

            //token
            //if (!String.IsNullOrEmpty(EnvInfo.Access_Token))
            //{
            //    _HttpClient.DefaultRequestHeaders.Add("access-token", EnvInfo.Access_Token);
            //}
            //_HttpClient.DefaultRequestHeaders.Add("request-id", HttpDataHelper.GetRequestId());
            //_HttpClient.DefaultRequestHeaders.Add("request-time", Utilities.GetLongTimeStamp(DateTime.Now).ToString());

        }

        /// <summary>
        /// 每次请求生成随机id  格式:32位guid
        /// </summary>
        /// <returns></returns>
        //private static string GetRequestId()
        //{
        //    return Guid.NewGuid().ToStringN();
        //}

        private static void RemoveHeader()
        {
            // SQL调试参数
            _HttpClient.DefaultRequestHeaders.Remove("DEBUG_SQL");
            // JWT     
            _HttpClient.DefaultRequestHeaders.Remove("JWT_TOKEN");
            // IP
            _HttpClient.DefaultRequestHeaders.Remove("X-Forwarded-For");
            //
           // _HttpClient.DefaultRequestHeaders.Remove("access-token");
            //_HttpClient.DefaultRequestHeaders.Remove("request-id");
            //_HttpClient.DefaultRequestHeaders.Remove("request-time");
        }

        private static void GetToken(HttpResponseMessage response)
        {
            IEnumerable<String> jt = null;
            response.Headers.TryGetValues("JWT_TOKEN", out jt);
            if (jt != null)
            {
                String jwtToken = jt.ToList<String>()[0];
                EnvInfo.JwtToken = jwtToken;
            }
        }

        #endregion

        private static bool DoRelogin()
        {
            EnvInfo.JwtToken = null; //jwt清空重置
            FrmRelogin frm_relogin = new FrmRelogin();
            frm_relogin.Text = "登录超时";
            DisplayHelper.Hide();
            DialogResult dr = frm_relogin.ShowDialog();
            if (dr == DialogResult.OK)
            {                
                DisplayHelper.Show();
                return true;
            }
            if (dr == DialogResult.Abort)
            {
                Application.Exit();
            }
            return false;
        }

    }
        
}
