using Core.Lib.Utilities.Interfaces;
using Core.Lib.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using Core.Constants;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Core.Test.Utilities;

[TestClass]
public sealed class JwtUtilsTest
{
    private const string SecurityKey = "This is a test key for JWT token builder";
    private const string Audience = "Test Audience";
    private readonly IJwtUtils _jwtUtils;

    public JwtUtilsTest()
    {
        _jwtUtils = new JwtUtils();
    }

    [TestMethod]
    public void TestJwtTokenBuilder()
    {
        _jwtUtils
            .AddSecurityKey(SecurityKey)
            .AddIssuer(nameof(JwtUtilsTest))
            .AddAudience(Audience)
            .AddExpiry(10)
            .AddRole(Roles.User)
            .AddName("Eddard Stark")
            .AddUserId("STARK002")
            .AddCompanyId("GOT");

        var token = _jwtUtils.GenerateToken();
        Assert.IsNotNull(token);

        var tokenHandler = new JwtSecurityTokenHandler();
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey)),
            ValidIssuer = nameof(JwtUtilsTest),
            ValidAudience = Audience
        }, out var validatedToken);
        var jwtToken = (JwtSecurityToken)validatedToken;
        Assert.AreEqual(token, jwtToken.RawData);
    }

}
