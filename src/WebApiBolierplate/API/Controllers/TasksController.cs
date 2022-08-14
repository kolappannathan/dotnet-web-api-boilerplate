using API.Operations;
using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers;

[Route("api/tasks")]
[ApiController]
public class TasksController : CustomBaseController
{
    private readonly StarupLib _startupLib;
    public IConfiguration Configuration { get; }

    public TasksController(IConfiguration configuration, StarupLib starupLib)
    {
        _startupLib = starupLib;
        Configuration = configuration;
    }

    [HttpPut("reload/config")]
    [Authorize(Roles = AuthRoles.Admin)]
    public IActionResult LoadConfig()
    {
        _startupLib.LoadConfig(Configuration);
        return webAPIHelper.CreateResponse(InfoTexts.Success);
    }
}
