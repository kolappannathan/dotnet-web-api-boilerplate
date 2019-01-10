using Core.Constants;
using System.Collections.Generic;
using System.Net;

namespace API.Helpers
{
    public static class Notification
    {
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
        public static (string, HttpStatusCode) GetNotification(int code)
        {
            (string, HttpStatusCode) value;
            bool hasValue = notifications.TryGetValue(code, out value);
            if (!hasValue)
            {
                value = (Errors.InternalServerError, HttpStatusCode.InternalServerError);
            }
            return value;
        }
    }
}
