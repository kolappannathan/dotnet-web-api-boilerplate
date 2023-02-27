using System.ComponentModel.DataAnnotations;

namespace API.Models;

public sealed class LoginDTO
{
    public LoginDTO()
    {

    }

    [Required(ErrorMessage = "No name. No game.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "No password?! Are you kidding?")]
    public string Password { get; set; }
}
