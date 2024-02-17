using DotNetCore.Service.Interfaces;

namespace DotNetCore.Service;

public class LoggerService : ILoggerService
{
    private readonly string _loggerPropertyKey;
    private readonly ILoggerWrapper _loggerWrapper;

    public LoggerService(ILoggerWrapper loggerWrapper)
    {
        _loggerPropertyKey = "SubFolderName";
        _loggerWrapper = loggerWrapper;
    }
        
    public void Trace(string message)
    {            
        _loggerWrapper.LogTrace($"{message}");
    }
        
    public void Debug(string message)
    {            
        _loggerWrapper.LogDebug($"{message}");
    }

    public void Info(string message)
    {
        _loggerWrapper.LogInformation($"{message}");
    }

    public virtual void Error(string message, Exception ex = null)
    {
        _loggerWrapper.LogError($"{message}", ex);
    }
}