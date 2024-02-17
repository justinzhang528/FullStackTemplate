namespace DotNetCore.Models.Responses;

public class BaseApiResponse
{
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}