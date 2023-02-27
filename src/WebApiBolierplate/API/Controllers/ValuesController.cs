using API.Operations.Interfaces;
using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : CustomBaseController
{
    private readonly IValueLib _valueLib;

    public ValuesController(IValueLib valueLib)
    {
        _valueLib = valueLib;
    }

    [HttpGet("")]
    [Authorize(Roles = AuthRoles.All)]
    public IActionResult Get()
    {
        var result = _valueLib.GetValueList();
        return webAPIHelper.CreateResponse(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = AuthRoles.All)]
    public IActionResult Get([FromRoute]int id)
    {
        var result = _valueLib.GetValueById(id);
        if (result == string.Empty)
        {
            return new NotFoundResult();
        }
        return webAPIHelper.CreateResponse(result);
    }

    [HttpPost("")]
    [Authorize(Roles = AuthRoles.Admin)]
    public IActionResult Post([FromBody] string value)
    {
        var result = _valueLib.AddValue(value);
        return webAPIHelper.CreateResponse(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = AuthRoles.Admin)]
    public IActionResult Put([FromRoute]int id, [FromBody] string value)
    {
        var result = _valueLib.UpdateValue(value, id);
        return webAPIHelper.CreateResponse(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = AuthRoles.Admin)]
    public IActionResult Delete([FromRoute]int id)
    {
        var result = _valueLib.DeleteValue(id);
        return webAPIHelper.CreateResponse(result);
    }
}
