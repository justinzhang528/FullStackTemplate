using DotNetCore.Models.Requests;
using DotNetCore.Models.Responses;
using DotNetCore.Repositories.Dto;
using DotNetCore.Repositories.Interfaces;
using DotNetCore.Service.Interfaces;

namespace DotNetCore.Repositories;

public class AdminRepository : BaseRepository, IAdminRepository
{
    public AdminRepository(ILoggerService logger, IConfiguration configuration) : base(logger, configuration)
    {
    }
    
    public BaseApiResponse? Login(LoginRequest req)
    {
        return Query<BaseApiResponse>("[dbo].[Login_1.0.0]", req).ToList().FirstOrDefault();
    }

    public BaseApiResponse? Register(RegisterRequest req)
    {
        return Query<BaseApiResponse>("[dbo].[Register_1.0.0]", req).ToList().FirstOrDefault();
    }

    public List<Customer> GetAllCustomer()
    {
        return Query<Customer>("[dbo].[GetAllCustomer_1.0.0]").ToList();
    }
}