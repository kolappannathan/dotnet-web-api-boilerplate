using API.Models;

namespace API.Operations.Interfaces;

public interface IUserLib
{
    public User GetUser(string userName);
}
