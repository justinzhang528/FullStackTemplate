using DotNetCore.Models.Requests;
using DotNetCore.Models.Responses;

namespace DotNetCore.Repositories.Interfaces;

public interface IAdminRepository
{
    public BaseApiResponse? Login(LoginRequest req);
    public BaseApiResponse? Register(RegisterRequest req);
}