using System;
using System.Configuration;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：日志处理类
    /// 功能描述：使用log4gnet记录本地日志文件，对于Error保存到远程日志中。
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public class LogHelper
    {
        //当前系统日志等级 0=不记录/1=Error级/2=Warn级/3=Debug级/4=Info级（全部记录）
        public static int _logLevel { get; set; }        

        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure();            
            //  TODO：设置远程日志服务
        }
        

        /// <summary>
        ///  记录Info日志
        /// </summary>
        /// <param name="logName">log名</param>
        /// <param name="message">信息</param>
        public static void Info(String logName, String message)
        {
            if (_logLevel >= 4)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(logName);
                log.Info(message);
            }
        }

        /// <summary>
        ///  记录Info日志
        /// </summary>
        /// <param name="obj>对象</param>
        /// <param name="message">信息</param>
        public static void Info(object obj, String message)
        {
            Info(obj.GetType().FullName, message);
        }

        /// <summary>
        ///  记录Debug日志
        /// </summary>
        /// <param name="logName">log名</param>
        /// <param name="message">信息</param>
        public static void Debug(String logName, String message)
        {
            if (_logLevel >= 3)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(logName);
                log.Debug(message);
            }
        }

        /// <summary>
        ///  记录Debug日志
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="message">信息</param>
        public static void Debug(object obj, String message)
        {
            Debug(obj.GetType().FullName, message);
        }

        /// <summary>
        ///  记录Warn日志
        /// </summary>
        /// <param name="logName">log名</param>
        /// <param name="message">信息</param>
        public static void Warn(String logName, String message)
        {
            if (_logLevel >= 2)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(logName);
                log.Warn(message);
            }
        }

        /// <summary>
        ///  记录Warn日志
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="message">信息</param>
        public static void Warn(object obj, String message)
        {
            Warn(obj.GetType().FullName, message);
        }

        /// <summary>
        ///  记录Error日志
        /// </summary>
        /// <param name="logName">log名</param>
        /// <param name="message">信息</param>
        public static void Error(String logName, String message)
        {
            if (_logLevel >= 1)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(logName);
                log.Error(message);
                //  TODO：写入远程日志服务（系统时间、人员信息、系统信息、机器信息、消息体）with MONGODB
            }
        }

        /// <summary>
        ///  记录Error日志
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="message">信息</param>
        public static void Error(object obj, String message)
        {
            Error(obj.GetType().FullName, message);
        }
        
    }
}

