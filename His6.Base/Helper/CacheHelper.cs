using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：本地缓存处理类
    /// 功能描述：通过本地磁盘缓存实体列表数据，缓存格式通过JSON（适合通用）或自定义（适合简单大数据集有性能要求的）
    ///      处理流程：  1. 获取服务器缓存的版本
    ///                  2. 查询本地是否存在对应版本的磁盘缓存文件
    ///                  3. 如果存在从本地磁盘获取数据后反序列化，返回结果，失败转入4
    ///                  4. 如果不存在或本地获取失败 1、从服务端获取数据，2、清除本地磁盘数据，3、序列化后写入本地文件， 返回结果
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public static class CacheHelper
    {

        /// <summary>
        ///  获取自定义格式缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cacheName">缓存名</param>
        /// <param name="url">服务地址</param>
        /// <param name="parms">服务参数</param>
        /// <returns></returns>
        public static List<T> GetFast<T>(String cacheName, String url, List<KeyValuePair<String, String>> parms = null) where T : IFastSerialize, new()
        {
            List<T> list = null;
            string remote_ver = GetRemoteVer(cacheName);    //  1. 获取服务器缓存的版本
            string file = EnvInfo.RunPath + "Cache\\" + cacheName + "(" + remote_ver + ").cache";
            bool ok = false;

            if (File.Exists(file))
            {
                try
                {
                    LogHelper.Info(typeof(CacheHelper).FullName, "开始获取" + cacheName + "本地磁盘缓存");
                    byte[] cache_bytes = System.IO.File.ReadAllBytes(file);
                    list = FastSerializeHelper.DeSerialize<T>(cache_bytes);
                    LogHelper.Info(typeof(CacheHelper).FullName, "成功获取" + cacheName + "本地磁盘缓存");
                    ok = true;
                }
                catch (Exception ex)
                {
                    LogHelper.Warn(typeof(CacheHelper).FullName, "获取" + cacheName + "本地磁盘缓存失败\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                }
            }

            if (!ok)
            {
                try
                {
                    LogHelper.Info(typeof(CacheHelper).FullName, "开始获取" + cacheName + "服务端数据");
                    CustomException ce = null;
                    string result = HttpDataHelper.GetStringWithInfo("BASE", url, out ce, parms);
                    if(ce != null) { throw ce; }
                    list = JsonConvert.DeserializeObject<List<T>>(result);

                    LogHelper.Info(typeof(CacheHelper).FullName, "开始序列化" + cacheName);
                    List<byte> list_bytes = FastSerializeHelper.Serialize(list);

                    LogHelper.Info(typeof(CacheHelper).FullName, "删除" + cacheName + "旧的缓存文件");
                    RemoveFile(cacheName);

                    LogHelper.Info(typeof(CacheHelper).FullName, "写入" + cacheName + "新的磁盘缓存文件");
                    File.WriteAllBytes(file, list_bytes.ToArray());
                }
                catch (Exception ex)
                {
                    LogHelper.Error(typeof(CacheHelper).FullName, "获取" + cacheName + "服务端数据失败\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            return list;
        }


        /// <summary>
        ///  获取JSON格式缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cacheName">缓存名</param>
        /// <param name="url">服务地址</param>
        /// <param name="parms">服务参数</param>
        /// <returns></returns>
        public static List<T> Get<T>(String cacheName, String url, List<KeyValuePair<String, String>> parms = null)
        {
            //  1. 获取服务器缓存的版本
            //  2. 查询本地是否存在对应版本的磁盘缓存文件
            //  3. 
            //     a) 如果存在从本地磁盘获取数据后反序列化，返回结果，失败转入b）
            //     b) 如果不存在或本地获取失败 1、从服务端获取数据，2、清除本地磁盘数据，3、序列化后写入本地文件， 返回结果

            List<T> list = null;
            string remote_ver = GetRemoteVer(cacheName);    //  1. 获取服务器缓存的版本
            string file = EnvInfo.RunPath + "Cache\\" + cacheName + "(" + remote_ver + ").cache";
            bool ok = false;

            if (File.Exists(file))
            {
                try
                {
                    LogHelper.Info(typeof(CacheHelper).FullName, "开始获取" + cacheName + "本地磁盘缓存");
                    string result = File.ReadAllText(file);
                    list = JsonConvert.DeserializeObject<List<T>>(result);
                    LogHelper.Info(typeof(CacheHelper).FullName, "成功获取" + cacheName + "本地磁盘缓存");
                    ok = true;
                }
                catch (Exception ex)
                {
                    LogHelper.Warn(typeof(CacheHelper).FullName, "获取" + cacheName + "本地磁盘缓存失败\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                }
            }

            if (!ok) {
                try
                {
                    LogHelper.Info(typeof(CacheHelper).FullName, "开始获取" + cacheName + "服务端数据");
                    CustomException ce = null;
                    string result = HttpDataHelper.GetStringWithInfo("BASE", url, out ce, parms);
                    if (ce != null) { throw ce; }

                    LogHelper.Info(typeof(CacheHelper).FullName, "开始序列化" + cacheName);
                    list = JsonConvert.DeserializeObject<List<T>>(result);

                    LogHelper.Info(typeof(CacheHelper).FullName, "删除" + cacheName + "旧的缓存文件");
                    RemoveFile(cacheName);

                    LogHelper.Info(typeof(CacheHelper).FullName, "写入" + cacheName + "新的磁盘缓存文件");
                    File.WriteAllText(file, result);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(typeof(CacheHelper).FullName, "获取" + cacheName + "服务端数据失败\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            return list;
        }

        /// <summary>
        ///  删除旧磁盘缓存文件
        /// </summary>
        /// <param name="cache_name">缓存名称</param>
        private static void RemoveFile(string cache_name)
        {
            string path = EnvInfo.RunPath + "Cache\\";
            DirectoryInfo folder = new DirectoryInfo(path);
            FileInfo[] files = folder.GetFiles(cache_name + "(*).cache");
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
        }

        /// <summary>
        /// 获取服务端缓存最新版本
        /// </summary>
        /// <param name="cacheName">缓存名</param>
        /// <returns>版本</returns>
        private static String GetRemoteVer(String cacheName)
        {
            //  TODO: 从服务中获取服务端缓存版本

            return "1.5";
        }

    }
}
