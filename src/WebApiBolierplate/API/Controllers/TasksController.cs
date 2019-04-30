using Business.Lib.Core;
using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : CustomBaseController
    {
        private StarupLib startupLib;
        public IConfiguration Configuration { get; }

        public TasksController(IConfiguration configuration)
        {
            startupLib = new StarupLib();
            Configuration = configuration;
        }

        [HttpPut("reload/config")]
        [Authorize(Roles = AuthRoles.Admin)]
        public IActionResult LoadConfig()
        {
            startupLib.LoadConfig(Configuration);
            return webAPIHelper.CreateResponse(InfoTexts.Success);
        }
    }
}