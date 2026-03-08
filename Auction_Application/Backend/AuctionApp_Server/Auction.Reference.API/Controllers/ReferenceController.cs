using Microsoft.AspNetCore.Mvc;
using ReferenceServices.ServicesInterfaces;

namespace Auction.Reference.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReferenceController(IServiceManager services) : Controller
{
    [HttpGet("healt-check")]
    public async Task<IActionResult> GetApiHealth() => Ok("Refernce api is running...");

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetUserById([FromRoute] long id)
    {
        var data = await services.UserService.GetUserIdAsync(id, false);
        return Ok(data);
    }
}
