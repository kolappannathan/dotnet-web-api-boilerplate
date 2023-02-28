using API.Helpers.Interfaces;

namespace API.Helpers;

public sealed class JWTHelper : IJWTHelper
{
    #region [Declarations]

    private readonly IConfiguration _configuration;
    private IJwtTokenBuilder _jwtTokenBuilder;

    #endregion [Declarations]

    public JWTHelper(IConfiguration configuration, IJwtTokenBuilder jwtTokenBuilder)
    {
        _configuration = configuration;
        _jwtTokenBuilder = jwtTokenBuilder;
    }

    #region [Token Generation]

    public string GenerateToken(string userId, string userRole = null, string userName = null, string companyId = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(userId);

        _jwtTokenBuilder
            .AddSecurityKey(_configuration["AppConfig:JWT:Key"])
            .AddIssuer(_configuration["AppConfig:JWT:Issuer"])
            .AddAudience(_configuration["AppConfig:JWT:Audience"])
            .AddExpiry(Convert.ToInt32(_configuration["AppConfig:JWT:DaysValid"]))
            .AddRole(userRole)
            .AddName(userName)
            .AddUserId(userId)
            .AddCompanyId(companyId);

        return _jwtTokenBuilder.GenerateToken();
    }

    #endregion [Token Generation]
}
