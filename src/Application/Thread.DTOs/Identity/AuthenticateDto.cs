using System.Text.Json.Serialization;

namespace Thread.DTOs.Identity;

public class AuthenticateDto
{
    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
    
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}