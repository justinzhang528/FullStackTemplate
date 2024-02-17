namespace DotNetCore.Service.Interfaces;

public interface ILoggerService
{
    void Trace(string message);
        
    void Debug(string message);

    void Info(string message);

    void Error(string message, Exception ex = null);
}