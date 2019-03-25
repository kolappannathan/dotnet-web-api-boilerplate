using API.Helpers;
using Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        protected readonly WebAPIHelper webAPIHelper;
        protected string loginId => User.FindFirst(CustomClaims.UserIdentifier)?.Value;
        protected string companyId => User.FindFirst(CustomClaims.CompanyIdentifier).Value;

        public CustomBaseController()
        {
            webAPIHelper = new WebAPIHelper();
        }
    }
}