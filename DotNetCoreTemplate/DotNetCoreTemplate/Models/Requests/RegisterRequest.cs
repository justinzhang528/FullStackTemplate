using System.ComponentModel.DataAnnotations;

namespace DotNetCore.Models.Requests;

public class RegisterRequest
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Phone { get; set; }
    
    [Required]
    public string Address { get; set; }
}