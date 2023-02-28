﻿using API.Helpers.Interfaces;
using Core.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Helpers;

public sealed class JwtTokenBuilder: IJwtTokenBuilder
{
    #region [Declarations]

    private SecurityKey securityKey = null;
    private int expiryInDays = 0;
    private List<Claim> claims = new();

    #endregion [Declarations]

    public string GenerateToken()
    {
        EnsureArguments();
        var token = BuildJwtSecurityToken();
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    #region [Private Functions]

    /// <summary>
    /// Validates important arguments
    /// </summary>
    private void EnsureArguments()
    {
        ArgumentNullException.ThrowIfNull(securityKey);

        if (expiryInDays == 0)
        {
            throw new ArgumentNullException("Expiry Time");
        }
    }

    /// <summary>
    /// Adds the final claim for issued at, jwt id and builds JwtSecurityToken object
    /// </summary>
    /// <returns></returns>
    private JwtSecurityToken BuildJwtSecurityToken()
    {
        AddClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D"));

        var currentUnixTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, currentUnixTime, ClaimValueTypes.Integer64));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, currentUnixTime, ClaimValueTypes.Integer64));

        return new JwtSecurityToken(
                          claims: claims,
                          expires: DateTime.UtcNow.AddDays(expiryInDays),
                          signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
    }

    #endregion [Private Functions]

    #region [Adding values]

    public IJwtTokenBuilder AddSecurityKey(string securityKey)
    {
        this.securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        return this;
    }

    public IJwtTokenBuilder AddExpiry(int expiryInDays)
    {
        this.expiryInDays = expiryInDays;
        return this;
    }

    #endregion [Adding values]

    #region [Adding Claims]

    public IJwtTokenBuilder AddIssuer(string issuer)
    {
        return AddClaim(JwtRegisteredClaimNames.Iss, issuer);
    }

    public IJwtTokenBuilder AddAudience(string audience)
    {
        return AddClaim(JwtRegisteredClaimNames.Aud, audience);
    }

    public IJwtTokenBuilder AddSubject(string subject)
    {
        return AddClaim(JwtRegisteredClaimNames.Sub, subject);
    }

    public IJwtTokenBuilder AddName(string username)
    {
        return AddClaim(JwtRegisteredClaimNames.NameId, username);
    }

    public IJwtTokenBuilder AddEmail(string email)
    {
        return AddClaim(JwtRegisteredClaimNames.Email, email);
    }

    public IJwtTokenBuilder AddRole(string value)
    {
        // Changing this to JwtRegisteredClaimNames will break role based authentication
        return AddClaim(ClaimTypes.Role, value);
    }

    #region [Custom Claims]

    public IJwtTokenBuilder AddUserId(string value)
    {
        return AddClaim(CustomClaims.UserIdentifier, value);
    }

    public IJwtTokenBuilder AddCompanyId(string value)
    {
        return AddClaim(CustomClaims.CompanyIdentifier, value);
    }

    #endregion [Custom Claims]

    #region [Generic Claims]

    public IJwtTokenBuilder AddClaim(string type, string value)
    {
        if (value != null && type != null)
        {
            claims.Add(new Claim(type, value));
        }
        return this;
    }

    public IJwtTokenBuilder AddClaims(Dictionary<string, string> claimList)
    {
        foreach (var claim in claimList)
        {
            if (claim.Value != null && claim.Key != null)
            {
                claims.Add(new Claim(claim.Key, claim.Value));
            }
        }
        return this;
    }

    #endregion [Generic Claims]

    #endregion [Adding Claims]
}
