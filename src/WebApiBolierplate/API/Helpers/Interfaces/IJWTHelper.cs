namespace API.Helpers.Interfaces;

public interface IJWTHelper
{
    public string GenerateToken(string userId, string userRole = null, string userName = null, string companyId = null);
}
