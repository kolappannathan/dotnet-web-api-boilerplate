using Core.Constants;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Net;
using API.Helpers.Interfaces;

namespace API.Helpers;

public sealed class WebAPIHelper: IWebAPIHelper
{
    public JsonResult CreateResponse(object data)
    {
        var apiResponse = data switch
        {
            bool resData when resData == false => CreateErrorResponse(Errors.InternalServerError),
            int resData when resData < 0 => CreateErrorResponse(resData),
            APIResponse resData => resData,
            _ => new APIResponse(data, string.Empty, false),
        };
        return new JsonResult(apiResponse)
        {
            StatusCode = (int)apiResponse.StatusCode
        };
    }

    public BadRequestObjectResult CreateBadRequest(string errorText)
    {
        var apiResponse = new APIResponse(string.Empty, errorText, true, HttpStatusCode.BadRequest);
        return new BadRequestObjectResult(apiResponse);
    }

    public APIResponse CreateErrorResponse(string errorText, dynamic data = null)
    {
        if (data is int code && code < 0)
        {
            return CreateErrorResponse(code, data);
        }
        return new APIResponse(data, errorText, true, HttpStatusCode.InternalServerError);
    }

    #region Private Functions

    private APIResponse CreateErrorResponse(int errorCode, dynamic data = null)
    {
        (var resText, var resCode) = GetNotification(Convert.ToInt32(errorCode));
        return new APIResponse(data, resText, true, resCode);
    }

    /// <summary>
    /// Contains mapping for error codes to the Error messages and status
    /// </summary>
    private static readonly Dictionary<int, (string, HttpStatusCode)> notifications = new Dictionary<int, (string, HttpStatusCode)>()
    {
        { -1, (Errors.InternalServerError, HttpStatusCode.InternalServerError) },
        { -102, (Errors.AccountNotFound, HttpStatusCode.Unauthorized) },
        { -103, (Errors.InvalidCredentials, HttpStatusCode.Unauthorized) },
        { -104, (Errors.AccountDeleted, HttpStatusCode.Unauthorized) }
    };

    /// <summary>
    /// Returns the error message, and <see cref="HttpStatusCode"/> for the specified error code
    /// </summary>
    /// <param name="code">The error code obtained from business layer or other functions</param>
    /// <returns></returns>
    private static (string, HttpStatusCode) GetNotification(int code)
    {
        (string, HttpStatusCode) value;
        bool hasValue = notifications.TryGetValue(code, out value);
        if (!hasValue)
        {
            value = (Errors.InternalServerError, HttpStatusCode.InternalServerError);
        }
        return value;
    }

    #endregion Private Functions
}
