using API.Helpers;
using Business.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : CustomBaseController
    {
        private UserLib userLib;

        public LoginController()
        {
            userLib = new UserLib();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginDTO loginDTO)
        {
            var result = userLib.ValidateLogin(loginDTO);
            if (result == 1)
            {
                var user = userLib.GetUser(loginDTO.UserName);
                var jwtHelper = new JWTHelper();
                var token = jwtHelper.GenerateToken(user.Id, user.Roles, user.Name, user.CompanyId);
                return webAPIHelper.CreateResponse(token);
            }
            return webAPIHelper.CreateResponse(result);
        }
    }
}