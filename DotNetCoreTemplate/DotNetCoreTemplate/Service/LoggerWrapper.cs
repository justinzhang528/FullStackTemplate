using DotNetCore.Models;
using DotNetCore.Service.Interfaces;
using NLog;

namespace DotNetCore.Service;

public class LoggerWrapper : ILoggerWrapper
{
    private readonly Logger _logger;

    public LoggerWrapper()
    {
        _logger = LogManager.GetCurrentClassLogger();
    }

    public void LogTrace(string message)
    {
        _logger.WithProperty(NlogTag.Time, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Trace(message);
    }

    public void LogDebug(string message)
    {
        _logger.WithProperty(NlogTag.Time, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Debug(message);
    }

    public void LogInformation(string message)
    {
        _logger.WithProperty(NlogTag.Time, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Info(message);
    }

    public void LogError(string message, Exception ex = null)
    {
        _logger.WithProperty(NlogTag.Time, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Error(ex, message);
    }
}