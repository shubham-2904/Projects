using Microsoft.AspNetCore.Mvc;

namespace Auction.Reference.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReferenceController : Controller
{
    [HttpGet("healt-check")]
    public async Task<IActionResult> GetApiHealth() => Ok("Refernce api is running...");
}
