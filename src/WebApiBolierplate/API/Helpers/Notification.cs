using Core.Constants;
using System;
using System.Collections.Generic;
using System.Net;

namespace API.Helpers
{
    public static class Notification
    {
        /// <summary>
        /// Contains mapping for error codes to the Error messages and status
        /// </summary>
        private static readonly Dictionary<int, Tuple<string, HttpStatusCode>> notifications = new Dictionary<int, Tuple<string, HttpStatusCode>>()
        {
            { -1,  Tuple.Create(Errors.InternalServerError, HttpStatusCode.InternalServerError) },
            { -102,  Tuple.Create(Errors.AccountNotFound, HttpStatusCode.Unauthorized) },
            { -103,  Tuple.Create(Errors.InvalidCredentials, HttpStatusCode.Unauthorized) },
            { -104,  Tuple.Create(Errors.AccountDeleted, HttpStatusCode.Unauthorized) }
        };

        /// <summary>
        /// Returns the error message, and <see cref="HttpStatusCode"/> for the specified error code
        /// </summary>
        /// <param name="code">The error code obtained from business layer or other functions</param>
        /// <returns></returns>
        public static Tuple<string, HttpStatusCode> GetNotification(int code)
        {
            Tuple<string, HttpStatusCode> value;
            bool hasValue = notifications.TryGetValue(code, out value);
            if (!hasValue)
            {
                value = Tuple.Create(Errors.InternalServerError, HttpStatusCode.InternalServerError);
            }
            return value;
        }
    }
}
