namespace Core.Constants
{
    /// <summary>
    /// Constains all the error messages across the application
    /// </summary>
    public class Errors
    {
        public const string InternalServerError = "Oops! An Internal Error Occured.";
        public const string DatabaseSaveFailed = "Failed to save to the database";

        #region [Authorization]

        public const string InvalidCredentials = "The credentials are invalid.";
        public const string UnauthorizedRequest = "The request is unauthorised.";
        public const string AccountNotFound = "No acount exists for the specified username. Are you trying to Signup?";
        public const string AccountDeleted = "The user account has been deleted. Contact administrator.";

        #endregion [Authorization]

        #region [Mandatory Fields]

        public const string UserIdMandatory = "User Id is mandatory";
        public const string AuthTokenMandatory = "Authentication token is mandatory";

        #endregion [Mandatory Fields]
    }
}
