using System.Collections.Generic;

namespace Core.Lib.Utilities.Interfaces;

public interface IJwtUtils
{
    public string GenerateToken();

    #region [Adding values]

    /// <summary>
    /// Adds the security key used for signing JWT token
    /// </summary>
    public IJwtUtils AddSecurityKey(string securityKey);

    /// <summary>
    /// Adds expiry time in hours to JWT token
    /// </summary>
    public IJwtUtils AddExpiry(int expiryInHours);

    #endregion [Adding values]

    #region [Adding Claims]

    /// <summary>
    /// Adds issuer to JWT token
    /// </summary>
    public IJwtUtils AddIssuer(string issuer);

    /// <summary>
    /// Adds audience value to JWT token
    /// </summary>
    public IJwtUtils AddAudience(string audience);

    /// <summary>
    /// Adds subject as a claim to the token
    /// </summary>
    public IJwtUtils AddSubject(string subject);

    /// <summary>
    /// Adds user name as claim to the token
    /// </summary>
    public IJwtUtils AddName(string username);

    /// <summary>
    /// Adds email as claim to JWT token
    /// </summary>
    public IJwtUtils AddEmail(string email);

    /// <summary>
    /// Adds user role as claim to the token
    /// </summary>
    public IJwtUtils AddRole(string value);

    #region [Custom Claims]

    public IJwtUtils AddUserId(string value);

    public IJwtUtils AddCompanyId(string value);

    #endregion [Custom Claims]

    #region [Generic Claims]

    /// <summary>
    /// Adds a given value to the given claim
    /// </summary>
    /// <param name="type">claim type</param>
    /// <param name="value">value for the claim</param>
    /// <returns></returns>
    public IJwtUtils AddClaim(string type, string value);

    /// <summary>
    /// Bulk add claims to the JWT tokens
    /// </summary>
    /// <param name="claimList">list of claim types and its corresponding values</param>
    /// <returns></returns>
    public IJwtUtils AddClaims(Dictionary<string, string> claimList);

    #endregion [Generic Claims]

    #endregion [Adding Claims]
}
