using API.Helpers.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API.Helpers;

public sealed class JWTHelper : IJWTHelper
{
    #region [Declarations]

    private readonly SecurityKey _securityKey;
    private readonly IConfiguration _configuration;
    private IJwtTokenBuilder jwtTokenBuilder;

    #endregion [Declarations]

    public JWTHelper(IConfiguration configuration, IJwtTokenBuilder jwtTokenBuilder)
    {
        _configuration = configuration;
        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppConfig:JWT:Key"]));
        this.jwtTokenBuilder = jwtTokenBuilder;
    }

    #region [Token Generation]

    public string GenerateToken(string userId, string userRole = null, string userName = null, string companyId = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(userId);

        var token = jwtTokenBuilder
            .AddSecurityKey(_securityKey)
            .AddIssuer(_configuration["AppConfig:JWT:Issuer"])
            .AddAudience(_configuration["AppConfig:JWT:Audience"])
            .AddExpiry(Convert.ToInt32(_configuration["AppConfig:JWT:DaysValid"]))
            .AddRole(userRole)
            .AddName(userName)
            .AddUserId(userId)
            .AddCompanyId(companyId)
            .Build();
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    #endregion [Token Generation]
}
