namespace DotNetCore.Service.Interfaces;

public interface ILoggerWrapper
{
    void LogTrace(string message);
    void LogDebug(string message);
    void LogInformation(string message);
    void LogError(string message, Exception ex = null);

}