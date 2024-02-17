using DotNetCore.Models.Requests;
using DotNetCore.Models.Responses;
using DotNetCore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : Controller
{
    private readonly IAdminService _adminService;
    
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }
    
    [HttpPost]
    [Route("Login")]
    public BaseApiResponse? Login(LoginRequest req)
    {
        return _adminService.Login(req);
    }
    
    [HttpPost]
    [Route("Register")]
    public BaseApiResponse? Register(RegisterRequest req)
    {
        return _adminService.Register(req);
    }
}