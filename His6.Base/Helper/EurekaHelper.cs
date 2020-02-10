using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：Eureka服务数据类
    /// 功能描述：用于Eureka Server及其下属Application的服务处理
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public static class EurekaHelper
    {
        /// <summary>
        /// 所有Eureka服务地址
        /// </summary>
        static List<String> _EurekaServers;
        /// <summary>
        ///  所有地址目录: Key为模块名称，Value为地址
        /// </summary>
        static Dictionary<String, List<EurekaUrlAction>> _EurekaUrls;

        /// <summary>
        /// 刷新计时器
        /// </summary>
        static Timer timer;
        /// <summary>
        /// 刷新间隔时间
        /// </summary>
        static int period;

        static int invalidCount = 3;

        static int revokeCount = 5;


        static EurekaHelper()
        {
            //获取所有Eureka服务地址
            String eurekaUrl = ConfigurationManager.AppSettings.Get("EurekaServerUrls");      
            _EurekaServers = eurekaUrl.Split(';').ToList<String>();
            _EurekaUrls = new Dictionary<string, List<EurekaUrlAction>>();

            //获取Eureka刷新时间，若不存在则设为5分钟
            try
            {
                period = int.Parse(ConfigurationManager.AppSettings.Get("EurekaRefreshPeriod"));
            }
            catch
            {
                period = 300000;
            }                        

            timer = new Timer(delegate{
                List<String> keys = _EurekaUrls.Keys.ToList<String>();
                //每隔period的时间，刷新一次Url                
                foreach (String key in keys)
                {
                    RefreshEurekaUrls(key);
                }
            }, null, period, period);
            
        }

        #region Eureka服务地址对应
        
        /// <summary>
        /// 刷新对应模块的Url
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static bool RefreshEurekaUrls(String app)
        {
            try
            {
                List<EurekaUrlAction> urlsOfApp = new List<EurekaUrlAction>();
                foreach (String serverUrl in _EurekaServers) //遍历EUREKA服务的APP内容
                {
                    String eurekaServerInfo = HttpDataHelper.GetString(serverUrl);

                    XmlDocument d = new XmlDocument();
                    d.LoadXml(eurekaServerInfo);

                    XmlNode top = d.SelectNodes("//applications")[0];
                    XmlNodeList applications = top.SelectNodes("//application");
                    foreach (XmlElement element in applications)
                    {
                        string name = element.GetElementsByTagName("name")[0].InnerText;
                        if (name.Equals(app))   //找到对应的application
                        {
                            XmlNodeList instances = element.GetElementsByTagName("instance");

                            foreach (XmlElement ele in instances)
                            {
                                string ipAddress = ele.GetElementsByTagName("ipAddr")[0].InnerText;
                                string port = ele.GetElementsByTagName("port")[0].InnerText;
                                string newUrl = "http://" + ipAddress + ":" + port;

                                EurekaUrlAction ua = new EurekaUrlAction();
                                ua.Url = newUrl;
                                
                                if (!Contains(urlsOfApp, newUrl))
                                {
                                    EurekaUrlAction eua = new EurekaUrlAction();
                                    eua.Url = newUrl;
                                    eua.IsActive = true;
                                    eua.Count = 0;
                                    urlsOfApp.Add(eua);
                                }
                            }
                        }
                    }
                }
                lock (_EurekaUrls)
                {
                    _EurekaUrls.Remove(app);
                    _EurekaUrls.Add(app, urlsOfApp);
                }
                return true;
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        private static bool Contains(List<EurekaUrlAction> list, String url)
        {
            bool contains = false;
            foreach (EurekaUrlAction eua in list)
            {
                if(eua.Url.Equals(url))
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

        #endregion

        private delegate T MyCom<T, U>(String url, U parms);

        private delegate T MyComWithStatus<T, U>(String url, out String statusCode, U parms);

        private static T Comm<T, U>(MyCom<T, U> func, String app, String relativeUrl, U parms)
        {
            List<EurekaUrlAction> urls = new List<EurekaUrlAction>();
            if (!_EurekaUrls.TryGetValue(app, out urls))
            {
                RefreshEurekaUrls(app);
                urls = _EurekaUrls[app];
            }

            bool success = false;
            String errorMessage = String.Empty;
            T result = default(T);

            int count = urls.Count;
            if (count == 0)
            {
                errorMessage = "没有可用的服务，请检查服务提供者！";
            }
            for (int i = 0; i < count; i++)
            {
                EurekaUrlAction eua = urls[i];
                try
                {
                    if ((eua.IsActive && eua.Count < invalidCount) || (!eua.IsActive && eua.Count == revokeCount))
                    {
                        //  获取数据 
                        result = func(eua.Url + relativeUrl, parms);

                        success = true;
                        lock (urls) // 获取数据成功，将已使用的地址轮换至最后以平衡服务器
                        {
                            eua.IsActive = true;
                            eua.Count = 0;
                            urls.Remove(eua);
                            urls.Add(eua);
                        }
                    }
                    else
                    {
                        lock (urls)
                        {
                            if (eua.IsActive)
                            {
                                //该地址失效次数过多，被熔断      
                                eua.IsActive = false;
                                eua.Count = 0;
                            }
                            else
                            {
                                //次数+1
                                eua.Count++;
                            }
                        }
                    }
                }
                catch (BizCustomException bex)                
                {                    
                    lock (urls) // 出现业务异常，跳出，将已使用的地址轮换至最后以平衡服务器
                    {
                        eua.IsActive = true;
                        eua.Count = 0;
                        urls.Remove(eua);
                        urls.Add(eua);
                    }
                    throw bex;
                }
                catch (Exception ex)
                {
                    errorMessage += eua.Url + relativeUrl + " --- " + ex.Message + "\r\n";
                    lock (urls)
                    {
                        if (eua.IsActive)
                        {
                            eua.Count++;
                        }
                        else
                        {
                            eua.Count = 0;
                        }
                    }

                }
                if (success) break;
            }

            if (success)
            {
                return result;
            }
            else throw new Exception(errorMessage);
        }

        private static T CommWithStatus<T, U>(MyComWithStatus<T, U> func, String app, String relativeUrl, out String statusCode, U parms)
        {
            List<EurekaUrlAction> urls = new List<EurekaUrlAction>();
            if (!_EurekaUrls.TryGetValue(app, out urls))
            {
                RefreshEurekaUrls(app);
                urls = _EurekaUrls[app];
            }

            bool success = false;
            String errorMessage = String.Empty;
            T result = default(T);
            String status = String.Empty;

            int count = urls.Count;
            for (int i = 0; i < count; i++)
            {
                EurekaUrlAction eua = urls[i];
                try
                {
                    if ((eua.IsActive && eua.Count < invalidCount) || (!eua.IsActive && eua.Count == revokeCount))
                    {
                        //  获取数据 
                        result = func(eua.Url + relativeUrl, out status, parms);

                        success = true;
                        lock (urls) // 获取数据成功，将已使用的地址轮换至最后以平衡服务器
                        {
                            eua.IsActive = true;
                            eua.Count = 0;
                            urls.Remove(eua);
                            urls.Add(eua);
                        }
                    }
                    else
                    {
                        lock (urls)
                        {
                            if (eua.IsActive)
                            {
                                //该地址失效次数过多，被熔断      
                                eua.IsActive = false;
                                eua.Count = 0;
                            }
                            else
                            {
                                //次数+1
                                eua.Count++;
                            }
                        }
                    }
                }
                catch (BizCustomException bex)
                {
                    lock (urls) // 出现业务异常，跳出，将已使用的地址轮换至最后以平衡服务器
                    {
                        eua.IsActive = true;
                        eua.Count = 0;
                        urls.Remove(eua);
                        urls.Add(eua);
                    }
                    throw bex;
                }
                catch (Exception ex)
                {
                    errorMessage += eua.Url + relativeUrl + " --- " + ex.Message + "\r\n";
                    lock (urls)
                    {
                        if (eua.IsActive)
                        {
                            eua.Count++;
                        }
                        else
                        {
                            eua.Count = 0;
                        }
                    }

                }
                if (success) break;
            }

            if (success)
            {
                statusCode = status;
                return result;
            }
            else throw new Exception(errorMessage);
        }


        
        #region GET

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">相对地址</param>
        /// <param name="parms">参数值数组</param>
        /// <returns></returns>
        public static String PathGetString(String app, String relativeUrl, params String[] parms)
        {
            return Comm<String, String[]>(HttpDataHelper.PathGetString, app, relativeUrl, parms);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数值数组</param>
        /// <returns></returns>
        public static String PathGetStringWithStatus(String app, String relativeUrl, out String statusCode, params String[] parms)
        {
            return CommWithStatus<String, String[]>(HttpDataHelper.PathGetStringWithStatus, app, relativeUrl, out statusCode, parms);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">地址</param>
        /// <param name="parms">参数对列表</param>
        /// <returns></returns>
        public static String GetString(String app, String relativeUrl, List<KeyValuePair<String, String>> parmList = null)
        {
            return Comm<String, List<KeyValuePair<String, String>>>(HttpDataHelper.GetString, app, relativeUrl, parmList);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数对列表</param>
        /// <returns></returns>
        public static String GetStringWithStatus(String app, String relativeUrl, out String statusCode, List<KeyValuePair<String, String>> parmList = null)
        {
            return CommWithStatus<String, List<KeyValuePair<String, String>>>(HttpDataHelper.GetStringWithStatus, app, relativeUrl, out statusCode, parmList);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">地址</param>
        /// <param name="parms">参数值数组</param>
        /// <returns></returns>
        public static T PathGet<T>(String app, String relativeUrl, params String[] parms)
        {
            return Comm<T, String[]>(HttpDataHelper.PathGet<T>, app, relativeUrl, parms);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数值数组</param>
        /// <returns></returns>
        public static T PathGetWithStatus<T>(String app, String relativeUrl, out String statusCode, params String[] parms)
        {
            return CommWithStatus<T, String[]>(HttpDataHelper.PathGetWithStatus<T>, app, relativeUrl, out statusCode, parms);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">地址</param>
        /// <param name="parms">参数对列表</param>
        /// <returns></returns>
        public static T Get<T>(String app, String relativeUrl, List<KeyValuePair<String, String>> parmList = null)
        {
            return Comm<T, List<KeyValuePair<String, String>>>(HttpDataHelper.Get<T>, app, relativeUrl, parmList);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="app">模块</param>
        /// <param name="relativeUrl">地址</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="parms">参数对列表</param>
        /// <returns></returns>
        public static T GetWithStatus<T>(String app, String relativeUrl, out String statusCode, List<KeyValuePair<String, String>> parmList = null)
        {
            return CommWithStatus<T, List<KeyValuePair<String, String>>>(HttpDataHelper.GetWithStatus<T>, app, relativeUrl, out statusCode, parmList);
        }

        #endregion

        #region POST

        public static String Post(String app, String relativeUrl, String json)
        {
            return Comm<String, String>(HttpDataHelper.HttpPost, app, relativeUrl, json);
        }

        public static String PostFormUrl(String app, String relativeUrl, List<KeyValuePair<String, String>> list)
        {
            return Comm<String, List<KeyValuePair<String, String>>>(HttpDataHelper.HttpPostFormUrl, app, relativeUrl, list);
        }

        public static String PostGZip(String app, String relativeUrl, String json)
        {
            return Comm<String, String>(HttpDataHelper.HttpPostGZip, app, relativeUrl, json);
        }

        #endregion



    }
}
