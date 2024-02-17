using DotNetCore.Repositories.Dto;

namespace DotNetCore.Models.Responses;

public class GetAllCustomerResponse : BaseApiResponse
{
    public List<Customer> Customers { get; set; }
}