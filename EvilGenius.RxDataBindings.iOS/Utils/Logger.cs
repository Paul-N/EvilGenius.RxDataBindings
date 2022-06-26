using CoreFoundation;
using EvilGenius.Common.Logging;
using CoreFoundationLog = CoreFoundation.OSLog;

namespace EvilGenius.RxDataBindings.iOS.Utils
{
    internal class Logger : ILogger
    {
        public void Log(LogLevel logLevel, string tag, string message)
        {
            var osLogLvl = default(OSLogLevel);

            switch (logLevel)
            {
                case LogLevel.Info:
                    osLogLvl = OSLogLevel.Info;
                    break;
                case LogLevel.Debug:
                    //same as LogLevel.Warn:
                    osLogLvl = OSLogLevel.Debug;
                    break;
                case LogLevel.Error:
                    osLogLvl = OSLogLevel.Error;
                    break;
                case LogLevel.Fault:
                    osLogLvl = OSLogLevel.Fault;
                    break;
                default:
                    break;
            }

            CoreFoundationLog.Default.Log(osLogLvl, $"{tag}: {message}");
        }
    }
}