using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : Controller
{
    [HttpGet("healt-check")]
    public async Task<IActionResult> GetApiHealth() => Ok("Api is running...");
}
