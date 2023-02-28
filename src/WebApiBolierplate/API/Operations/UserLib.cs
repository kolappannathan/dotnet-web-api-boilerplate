using Core.Constants;
using API.Models;
using API.Operations.Interfaces;

namespace API.Operations;

public sealed class UserLib : IUserLib
{
    private const string _eddardStark = "Eddard Stark";
    private readonly ILogger _logger;

    public UserLib(IConfiguration configuration, ILogger<IUserLib> logger)
    {
        _logger = logger;
    }

    public User GetUser(string userName)
    {
        try
        {
            var user = new User()
            {
                Name = userName,
                Email = $"{userName}@gameofthrones.com",
                CompanyId = "GOT",
                Roles = userName == _eddardStark ? Roles.Admin : Roles.User,
                Id = Guid.NewGuid().ToString("D")
            };
            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError("GetUser - {message}", ex.Message);
            return null;
        }
    }
}
