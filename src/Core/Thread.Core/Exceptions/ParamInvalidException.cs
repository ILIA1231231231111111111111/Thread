#nullable enable

namespace Thread.Core.Exceptions;

public class ParamInvalidException : ArgumentException
{
    public ParamInvalidException(string? message, string? paramName) : base(message, paramName)
    {
    }
}