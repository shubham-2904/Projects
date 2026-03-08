using Serilog;

namespace LoggerService;

public class LoggerManager : ILoggerManager
{
    public void LogError(string message)
    {
        Log.Error(message);
    }

    public void LogError(Exception ex, string message)
    {
        Log.Error(ex, message);
    }

    public void LogInfo(string message)
    {
        Log.Information(message);
    }

    public void LogWarning(string message)
    {
        Log.Warning(message);
    }
}
