using System.Text.Json.Serialization;

#nullable enable

namespace Thread.API.Common.Models;

public class ApiResponse<TData> : BaseResponse
{
    private ApiResponse(bool succeeded, int code, TData? data, IEnumerable<string>? errors) : base(code, succeeded, errors)
    {
        Data = data;
    }


    [JsonPropertyName("data")]
    public TData? Data { get; set; }

    public static ApiResponse<TData> Success(int code, TData? data)
        => new ApiResponse<TData>(succeeded: true, code, data, errors: new List<string>());

    public static ApiResponse<TData> Success200(TData? data)
        => Success(code: 200, data);

    public static ApiResponse<TData> Failure(int code, IEnumerable<string>? errors)
        => new ApiResponse<TData>(succeeded: false, code, data: default, errors);
}