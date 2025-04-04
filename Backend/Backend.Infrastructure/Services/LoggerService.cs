using Backend.Application.Common.Interfaces.Services;
using Serilog;

namespace Backend.Infrastructure.Services;

public class LoggerService : ILoggerService
{
    public void LogInformation(string message, params object[] args)
    {
        Log.Information(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
        Log.Warning(message, args);
    }

    public void LogError(Exception exception, string message, params object[] args)
    {
        Log.Error(exception, message, args);
    }

    public void LogCritical(Exception exception, string message, params object[] args)
    {
        Log.Fatal(exception, message, args);
    }

    public void LogDebug(string message, params object[] args)
    {
        Log.Debug(message, args);
    }
}