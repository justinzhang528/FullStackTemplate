using DotNetCore.Enums;

namespace DotNetCore.Exceptions;

public class ApiException: Exception
{
    public ApiErrorEnum Error { get; set; }

    public string ExceptionTag { get; set; }

    public ApiException(ApiErrorEnum code, string message, string exceptionTag = "") : base(message)
    {
        Error = code;
        ExceptionTag = exceptionTag;
    }
    
}