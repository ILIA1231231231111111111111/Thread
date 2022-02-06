namespace Thread.Interfaces.Identity;

public interface ITokenClaimsService
{
    Task<string> GenerateTokenAsync(string? userName);
}