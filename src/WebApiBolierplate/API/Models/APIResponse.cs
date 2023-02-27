using System.Net;

namespace API.Models;

/// <summary>
/// A class for standard formatting of Data
/// </summary>
public sealed class APIResponse
{
    public APIResponse(dynamic data, string message, bool isError, HttpStatusCode statusCode)
    {
        Data = data;
        Message = message;
        IsError = isError;
        StatusCode = statusCode;
    }

    public APIResponse(dynamic data, string message, bool isError)
    {
        Data = data;
        Message = message;
        IsError = isError;
        StatusCode = isError? HttpStatusCode.InternalServerError : HttpStatusCode.OK;
    }

    /// <summary>
    /// Contains error meaasage and the likess
    /// </summary>
    public string Message { get; private set; }

    /// <summary>
    /// The actual data sent for the request
    /// </summary>
    public dynamic Data { get; private set; }

    /// <summary>
    /// Indicates if it is an error or not
    /// </summary>
    public bool IsError { get; private set; }

    /// <summary>
    /// HTTP status code
    /// </summary>
    public HttpStatusCode StatusCode { get; private set; }
}
