using Core.Constants;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Net;

namespace API.Helpers
{
    public class WebAPIHelper
    {
        #region [Declarations]

        private APIResponse apiResponse;

        #endregion [Declarations]

        /// <summary>
        /// Creates a error or successful response based on the data to be sent
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult CreateResponse(object data)
        {
            if (data == null || (data is bool && Convert.ToBoolean(data) == false))
            {
                apiResponse = new APIResponse(string.Empty, Errors.InternalServerError, true);
                return new JsonResult(apiResponse)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else if (data is int && Convert.ToInt32(data) < 0)
            {
                (string resText, HttpStatusCode resCode) = Notification.GetNotification(Convert.ToInt32(data));
                apiResponse = new APIResponse(string.Empty, resText, true);
                return new JsonResult(apiResponse)
                {
                    StatusCode = (int)resCode
                };
            }
            else if (data is APIResponse)
            {
                apiResponse = (APIResponse)data;
                return new JsonResult(apiResponse)
                {
                    StatusCode = apiResponse.IsError ? (int)HttpStatusCode.InternalServerError : (int)HttpStatusCode.OK
                };
            }
            else
            {
                apiResponse = new APIResponse(data, string.Empty, false);
                return new JsonResult(apiResponse);
            }
        }

        /// <summary>
        /// Creates a Json response with 400 status code(Bad Request)
        /// </summary>
        /// <param name="errorText">Error message to be sent</param>
        /// <returns>The http response</returns>
        public BadRequestObjectResult CreateBadRequest(string errorText)
        {
            apiResponse = new APIResponse(string.Empty, errorText, true);
            return new BadRequestObjectResult(apiResponse);
        }

        /// <summary>
        /// Creates an error response with a 500 status code(Internal Server error)
        /// </summary>
        /// <param name="errorText">Error message to be sent</param>
        /// <param name="data">Data to be sent</param>
        /// <returns></returns>
        public JsonResult CreateErrorResponse(string errorText, dynamic data = null)
        {
            apiResponse = new APIResponse(data, errorText, true);
            return new JsonResult(apiResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
