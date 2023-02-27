using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Helpers.Interfaces;

public interface IWebAPIHelper
{
    /// <summary>
    /// Creates a error or successful response based on the data to be sent
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public JsonResult CreateResponse(object data);

    /// <summary>
    /// Creates a Json response with 400 status code(Bad Request)
    /// </summary>
    /// <param name="errorText">Error message to be sent</param>
    /// <returns>The http response</returns>
    public BadRequestObjectResult CreateBadRequest(string errorText);

    /// <summary>
    /// Creates an error response with a 500 status code(Internal Server error)
    /// </summary>
    /// <param name="errorText">Error message to be sent</param>
    /// <param name="data">Data to be sent</param>
    /// <returns></returns>
    public APIResponse CreateErrorResponse(string errorText, dynamic data = null);
}
