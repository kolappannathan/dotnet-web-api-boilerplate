using System.ComponentModel.DataAnnotations;

namespace API.Models;

public sealed class LoginDTO
{
    public LoginDTO()
    {

    }

    [Required(ErrorMessage = "No name. No game.", AllowEmptyStrings = false)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "No password?! Are you kidding?", AllowEmptyStrings = false)]
    public string Password { get; set; }
}
