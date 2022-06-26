namespace EvilGenius.Common.Logging
{
    internal interface ILogger
    {
        void Log(LogLevel logLevel, string tag, string message);
    }
}