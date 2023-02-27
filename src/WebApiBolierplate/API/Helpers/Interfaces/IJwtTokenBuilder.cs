using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace API.Helpers.Interfaces;

public interface IJwtTokenBuilder
{
    public JwtSecurityToken Build();

    #region [Adding values]

    /// <summary>
    /// Adds the security key used for signing JWT token
    /// </summary>
    public IJwtTokenBuilder AddSecurityKey(SecurityKey securityKey);

    /// <summary>
    /// Adds expiry time in days to JWT token
    /// </summary>
    public IJwtTokenBuilder AddExpiry(int expiryInDays);

    #endregion [Adding values]

    #region [Adding Claims]

    /// <summary>
    /// Adds issuer to JWT token
    /// </summary>
    public IJwtTokenBuilder AddIssuer(string issuer);

    /// <summary>
    /// Adds audience value to JWT token
    /// </summary>
    public IJwtTokenBuilder AddAudience(string audience);

    /// <summary>
    /// Adds subject as a claim to the token
    /// </summary>
    public IJwtTokenBuilder AddSubject(string subject);

    /// <summary>
    /// Adds user name as claim to the token
    /// </summary>
    public IJwtTokenBuilder AddName(string username);

    /// <summary>
    /// Adds email as claim to JWT token
    /// </summary>
    public IJwtTokenBuilder AddEmail(string email);

    /// <summary>
    /// Adds user role as claim to the token
    /// </summary>
    public IJwtTokenBuilder AddRole(string value);

    #region [Custom Claims]

    public IJwtTokenBuilder AddUserId(string value);

    public IJwtTokenBuilder AddCompanyId(string value);

    #endregion [Custom Claims]

    #region [Generic Claims]

    /// <summary>
    /// Adds a given value to the given claim
    /// </summary>
    /// <param name="type">claim type</param>
    /// <param name="value">value for the claim</param>
    /// <returns></returns>
    public IJwtTokenBuilder AddClaim(string type, string value);

    /// <summary>
    /// Bulk add claims to the JWT tokens
    /// </summary>
    /// <param name="claimList">list of claim types and its corresponding values</param>
    /// <returns></returns>
    public IJwtTokenBuilder AddClaims(Dictionary<string, string> claimList);

    #endregion [Generic Claims]

    #endregion [Adding Claims]
}
