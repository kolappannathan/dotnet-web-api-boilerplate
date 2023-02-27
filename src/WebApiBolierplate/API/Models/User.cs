namespace API.Models;

public sealed class User
{
    public User()
    {

    }

    public string Email { get; set; }
    public string Name { get; set; }
    public string CompanyId { get; set; }
    public string Roles { get; set; }
    public string Id { get; set; }
}
