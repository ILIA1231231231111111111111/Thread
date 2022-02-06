using System.Net;
using System.Text.Json.Serialization;

#nullable enable

namespace Thread.API.Common.Models;

public class ApiResponse<TData> : BaseResponse
{
    private ApiResponse(bool succeeded, HttpStatusCode code, TData? data, IEnumerable<string>? errors) : base(code, succeeded, errors)
    {
        Data = data;
    }


    [JsonPropertyName("data")]
    public TData? Data { get; set; }

    public static ApiResponse<TData> Success(HttpStatusCode code, TData? data)
        => new ApiResponse<TData>(succeeded: true, code, data, errors: new List<string>());

    public static ApiResponse<TData> Success200(TData? data)
        => Success(code: HttpStatusCode.OK, data);

    public static ApiResponse<TData> Failure(HttpStatusCode code, IEnumerable<string>? errors)
        => new ApiResponse<TData>(succeeded: false, code, data: default, errors);
}