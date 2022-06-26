using System.Diagnostics;

namespace EvilGenius.Common.Logging
{
    internal class DebugLogger : ILogger
    {
        public void Log(LogLevel logLevel, string tag, string message)
        {
            Debug.WriteLine($"{tag}: {logLevel}: {message}");
        }
    }
}
