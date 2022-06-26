using AndroidLog = Android.Util.Log;
using EvilGenius.Common.Logging;
using Android.Util;

namespace EvilGenius.RxDataBindings.Android.Utils
{
    internal class Logger : ILogger
    {
        public void Log(LogLevel logLevel, string tag, string message)
        {
            LogPriority logPriority = default;

            switch (logLevel)
            {
                case LogLevel.Info:
                    logPriority = LogPriority.Info;
                    break;
                case LogLevel.Debug:
                //same as case LogLevel.Warn:
                    logPriority = LogPriority.Debug;
                    break;
                case LogLevel.Error:
                    logPriority = LogPriority.Error;
                    break;
                case LogLevel.Fault:
                    logPriority = LogPriority.Assert;
                    break;
                default:
                    break;
            }

            AndroidLog.WriteLine(logPriority, tag, message);
        }
    }
}