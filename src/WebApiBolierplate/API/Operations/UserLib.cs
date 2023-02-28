using Core.Constants;
using API.Models;
using API.Operations.Interfaces;

namespace API.Operations;

public sealed class UserLib : IUserLib
{
    private const string BrandonStark = "Brandon Stark";
    private const string EddardStark = "Eddard Stark";
    private readonly ILogger _logger;

    public UserLib(IConfiguration configuration, ILogger<IUserLib> logger)
    {
        _logger = logger;
    }

    public int ValidateLogin(LoginDTO login)
    {
        try
        {
            _logger.LogInformation("Login validation started");

            if (login.UserName == BrandonStark && login.Password == "My direwolf is Summer")
            {
                return 1;
            }
            else if (login.UserName == EddardStark && login.Password == "I'm the lord of WinterFell")
            {
                return 1;
            }
            else if (login.UserName == BrandonStark && login.Password == "My direwolf is Lady")
            {
                return -103; // invalid credential
            }
            else if(login.UserName == BrandonStark && login.Password == "Eddard's elder brother")
            {
                return -104; // account deleted
            }
            else if (login.UserName == "No one" && login.Password == "A man wants an exception")
            {
                throw new Exception("This is an excpetion");
            }
            return -102; // account not found
        }
        catch (Exception ex)
        {
            _logger.LogError("ValidateLogin - {message}", ex.Message);
            return -1;
        }
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
                Roles = userName == EddardStark ? Roles.Admin : Roles.User,
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
