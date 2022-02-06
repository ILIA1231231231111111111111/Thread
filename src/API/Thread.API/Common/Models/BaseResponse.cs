using System.Net;
using System.Text.Json.Serialization;

#nullable enable

namespace Thread.API.Common.Models;

public abstract class BaseResponse
{
    protected BaseResponse(HttpStatusCode code, bool succeeded, IEnumerable<string>? errors)
    {
        Code = code;
        Succeeded = succeeded;
        Errors = errors;
    }
    
    protected BaseResponse(bool succeeded)
    {
        Succeeded = succeeded;
    }
    

    [JsonPropertyName("code")]
    public HttpStatusCode Code { get; set; }
    
    
    [JsonPropertyName("succeeded ")]
    public bool Succeeded  { get; set; }
    
    
    [JsonPropertyName("errors")]
    public IEnumerable<string>? Errors { get; set; }
}