using DotNetCore.Enums;

namespace DotNetCore.Models;

public class ApiBaseResponse<TResult>
{
    public ApiErrorEnum ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public TResult Result { get; set; }

    public ApiBaseResponse(ApiErrorEnum errorCode)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorCode.ToString();
        Result = default;
    }

    public ApiBaseResponse(ApiErrorEnum errorCode, string message)
    {
        ErrorCode = errorCode;
        ErrorMessage = message;
        Result = default;
    }

    public ApiBaseResponse()
    {
    }

    public bool IsSuccess() => ErrorCode == ApiErrorEnum.NoError;

    public ApiBaseResponse(TResult result)
    {
        Result = result;
        ErrorCode = ApiErrorEnum.NoError;
        ErrorMessage = ApiErrorEnum.NoError.ToString();
    }
}