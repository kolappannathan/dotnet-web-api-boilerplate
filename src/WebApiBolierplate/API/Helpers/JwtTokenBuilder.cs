using Core.Constants;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Helpers
{
    public class JwtTokenBuilder
    {
        #region [Declarations]

        private SecurityKey securityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";
        private int expiryInDays = 30;
        private List<Claim> claims = new List<Claim>();

        #endregion [Declarations]

        public JwtSecurityToken Build()
        {
            EnsureArguments();

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var token = new JwtSecurityToken(
                              issuer: issuer,
                              audience: audience,
                              claims: claims,
                              expires: DateTime.UtcNow.AddDays(expiryInDays),
                              signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

        #region [Private Functions]

        /// <summary>
        /// Validates important arguments
        /// </summary>
        private void EnsureArguments()
        {
            if (securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrEmpty(this.issuer))
                throw new ArgumentNullException("Issuer");
        }

        #endregion [Private Functions]

        #region [Adding values]

        /// <summary>
        /// Adds the security key used for signing JWT token
        /// </summary>
        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        /// <summary>
        /// Adds subject for JWT token and adds it to subject claim
        /// </summary>
        public JwtTokenBuilder AddSubject(string subject)
        {
            this.subject = subject;
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, this.subject));
            return this;
        }

        /// <summary>
        /// Adds issuer to JWT token
        /// </summary>
        public JwtTokenBuilder AddIssuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        /// <summary>
        /// Adds audience value to JWT token
        /// </summary>
        public JwtTokenBuilder AddAudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        /// <summary>
        /// Adds expiry time in days to JWT token
        /// </summary>
        public JwtTokenBuilder AddExpiry(int expiryInDays)
        {
            this.expiryInDays = expiryInDays;
            return this;
        }

        #region [Adding Claims]

        /// <summary>
        /// Adds user role as claim to the token
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public JwtTokenBuilder AddRole(string value)
        {
            if (value != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, value));
            }
            return this;
        }

        /// <summary>
        /// Adds user name as claim to the token
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public JwtTokenBuilder AddName(string value)
        {
            if (value != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, value));
            }
            return this;
        }

        #region [Custom Claims]

        public JwtTokenBuilder AddUserId(string value)
        {
            if (value != null)
            {
                claims.Add(new Claim(CustomClaims.UserIdentifier, value));
            }
            return this;
        }

        public JwtTokenBuilder AddCompanyId(string value)
        {
            if (value != null)
            {
                claims.Add(new Claim(CustomClaims.CompanyIdentifier, value));
            }
            return this;
        }

        #endregion [Custom Claims]

        #region [Generic Claims]

        /// <summary>
        /// Adds a given value to the given claim
        /// </summary>
        /// <param name="type">claim type</param>
        /// <param name="value">value for the claim</param>
        /// <returns></returns>
        public JwtTokenBuilder AddClaim(string type, string value)
        {
            if (value != null)
            {
                claims.Add(new Claim(type, value));
            }
            return this;
        }

        /// <summary>
        /// Bulk add claims to the JWT tokens
        /// </summary>
        /// <param name="claimList">list of claim types and its corresponding values</param>
        /// <returns></returns>
        public JwtTokenBuilder AddClaims(Dictionary<string, string> claimList)
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

        #endregion [Adding values]
    }
}