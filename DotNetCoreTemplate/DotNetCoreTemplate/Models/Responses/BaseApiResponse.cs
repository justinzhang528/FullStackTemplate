namespace DotNetCore.Models.Responses;

public class BaseApiResponse
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}