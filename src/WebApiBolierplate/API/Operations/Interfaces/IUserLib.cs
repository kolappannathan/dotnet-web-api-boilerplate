using API.Models;

namespace API.Operations.Interfaces;

public interface IUserLib
{
    public int ValidateLogin(LoginDTO login);

    public User GetUser(string userName);
}
