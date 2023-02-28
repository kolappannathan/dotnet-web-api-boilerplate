using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Operations.Interfaces;
using API.Helpers.Interfaces;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : CustomBaseController
{
    private readonly IUserLib _userLib;
    private readonly IJWTHelper _jwtHelper;
    private readonly IWebAPIHelper _webAPIHelper;

    public LoginController(IUserLib userLib, IJWTHelper jwtHelper, IWebAPIHelper webAPIHelper)
    {
        _userLib = userLib;
        _jwtHelper = jwtHelper;
        _webAPIHelper = webAPIHelper;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody]LoginDTO loginDTO)
    {
        var result = _userLib.ValidateLogin(loginDTO);
        if (result == 1)
        {
            var user = _userLib.GetUser(loginDTO.UserName);
            var token = _jwtHelper.GenerateToken(userId: user.Id,
                                                 userRole: user.Roles,
                                                 userName: user.Name,
                                                 companyId: user.CompanyId);
            return _webAPIHelper.CreateResponse(token);
        }
        return _webAPIHelper.CreateResponse(result);
    }
}
