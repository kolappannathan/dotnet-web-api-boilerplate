using Core.Constants;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace API.Helpers
{
    public class JWTHelper
    {
        #region [Declarations]

        private readonly SecurityKey securityKey;

        #endregion [Declarations]

        public JWTHelper()
        {
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT.Key));
        }

        #region [Token Generation]

        /// <summary>
        /// Generates a signed token for the given user Id and role
        /// </summary>
        /// <param name="userId">Unique Identifier of the user</param>
        /// <param name="userRole">Role of the user</param>
        /// <param name="userName">Name of the user</param>
        /// <param name="companyId">Company Identfier</param>
        /// <returns></returns>
        /// /// <exception cref="ArgumentNullException">User Id is a must</exception>
        public string GenerateToken(string userId, string userRole = null, string userName = null, string companyId = null)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", Errors.UserIdMandatory);
            }

            var token = new JwtTokenBuilder()
                .AddSecurityKey(securityKey)
                .AddIssuer(JWT.Issuer)
                .AddAudience(JWT.Audience)
                .AddExpiry(30)
                .AddRole(userRole)
                .AddName(userName)
                .AddUserId(userId)
                .AddCompanyId(companyId)
                .Build();
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion [Token Generation]

        #region [Extract Claims]

        /// <summary>
        /// Generates <see cref="JwtSecurityToken"/> from signed JWT token string
        /// </summary>
        /// <param name="authToken">Signed JWT Token</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentNullException("authToken", Errors.AuthTokenMandatory);
            }

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudiences = new string[] { JWT.Audience },
                ValidIssuers = new string[] { JWT.Issuer },
                IssuerSigningKey = securityKey
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;
            try
            {
                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;
            }
            return validatedToken as JwtSecurityToken;
        }


        /// <summary>
        /// Extracts login Id from the authentication token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetLoginId(string token)
        {
            var decodedToken = GenerateUserClaimFromJWT(token);
            var claim = decodedToken.Claims.FirstOrDefault(c => c.Type == CustomClaims.UserIdentifier);
            var loginId = claim.Value;
            return loginId;
        }

        /// <summary>
        /// Extracts CompanyId from authentication token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetCompanyId(string token)
        {
            var decodedToken = GenerateUserClaimFromJWT(token);
            var claim = decodedToken.Claims.FirstOrDefault(c => c.Type == CustomClaims.CompanyIdentifier);
            var companyId = claim.Value;
            return companyId;
        }

        #endregion [Extract Claims]
    }
}
