using Core.Constants;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
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
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.JWT.Key));
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
                .AddIssuer(Config.JWT.Issuer)
                .AddAudience(Config.JWT.Audience)
                .AddExpiry(Config.JWT.DaysValid)
                .AddRole(userRole)
                .AddName(userName)
                .AddUserId(userId)
                .AddCompanyId(companyId)
                .Build();
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion [Token Generation]
    }
}
