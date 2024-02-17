using DotNetCore.Models.Requests;
using DotNetCore.Models.Responses;

namespace DotNetCore.Service.Interfaces;

public interface IAdminService
{
    public BaseApiResponse? Login(LoginRequest req);
    public BaseApiResponse? Register(RegisterRequest req);
}