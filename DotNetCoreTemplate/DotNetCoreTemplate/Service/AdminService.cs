using DotNetCore.Models.Requests;
using DotNetCore.Models.Responses;
using DotNetCore.Repositories.Interfaces;
using DotNetCore.Service.Interfaces;

namespace DotNetCore.Service;

public class AdminService : IAdminService
{
    private IAdminRepository _adminRepository;
    
    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    
    public BaseApiResponse? Login(LoginRequest req)
    {
        return _adminRepository.Login(req);
    }

    public BaseApiResponse? Register(RegisterRequest req)
    {
        return _adminRepository.Register(req);
    }

    public GetAllCustomerResponse? GetAllCustomer()
    {
        var result =  _adminRepository.GetAllCustomer();
        return new GetAllCustomerResponse()
        {
            Customers = result,
            ErrorCode = 0,
            ErrorMessage = "Success"
        };
    }
}