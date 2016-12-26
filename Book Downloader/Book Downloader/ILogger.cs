namespace Book_Downloader
{
    public interface ILogger
    {
        void Error(Severity severity,string message,params object[] elements);
        void Warning(Severity severity, string message, params object[] elements);
        void Signal(Severity severity, string message, params object[] elements);
    }
    public enum Severity
    {
        Low,
        Medium,
        High,
        HUGE
    }
}
