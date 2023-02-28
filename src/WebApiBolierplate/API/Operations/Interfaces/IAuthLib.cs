using API.Models;

namespace API.Operations.Interfaces;

public interface IAuthLib
{
    public int ValidateLogin(LoginDTO login);

    /// <summary>
    /// Generates a signed token for the given user Id and role
    /// </summary>
    /// <param name="userId">Unique Identifier of the user</param>
    /// <param name="userRole">Role of the user</param>
    /// <param name="userName">Name of the user</param>
    /// <param name="companyId">Company Identfier</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">User Id is a must</exception>
    public string GenerateToken(string userId, string userRole = null, string userName = null, string companyId = null);
}
