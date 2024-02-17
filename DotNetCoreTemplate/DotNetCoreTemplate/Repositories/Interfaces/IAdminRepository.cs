using DotNetCore.Models.Requests;
using DotNetCore.Models.Responses;
using DotNetCore.Repositories.Dto;

namespace DotNetCore.Repositories.Interfaces;

public interface IAdminRepository
{
    public BaseApiResponse? Login(LoginRequest req);
    public BaseApiResponse? Register(RegisterRequest req);
    public List<Customer> GetAllCustomer();
}