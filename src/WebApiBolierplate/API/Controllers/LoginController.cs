﻿using API.Helpers;
using API.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : CustomBaseController
{
    private readonly UserLib _userLib;

    public LoginController(UserLib userLib)
    {
        _userLib = userLib;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody]LoginDTO loginDTO)
    {
        var result = _userLib.ValidateLogin(loginDTO);
        if (result == 1)
        {
            var user = _userLib.GetUser(loginDTO.UserName);
            var jwtHelper = new JWTHelper();
            var token = jwtHelper.GenerateToken(user.Id, user.Roles, user.Name, user.CompanyId);
            return webAPIHelper.CreateResponse(token);
        }
        return webAPIHelper.CreateResponse(result);
    }
}
