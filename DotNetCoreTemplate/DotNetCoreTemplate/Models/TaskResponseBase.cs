using Newtonsoft.Json;

namespace DotNetCore.Models;

public class TaskResponseBase
{
    
    [JsonProperty("Status")]
    public int? Status { get; set; }

    [JsonProperty("Description")]
    public string? Description { get; set; }

    [JsonProperty("ResponseDateTime")]
    public DateTime ResponseDateTime { get; set; } = DateTime.Now.ToUniversalTime().AddHours(-4);
}