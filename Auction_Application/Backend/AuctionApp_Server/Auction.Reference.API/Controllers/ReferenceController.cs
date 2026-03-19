using CustomAtrributes;
using Microsoft.AspNetCore.Mvc;
using ReferenceServices.Dtos;
using ReferenceServices.ServicesInterfaces;

namespace Auction.Reference.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ConcurrencyHandler]
public class ReferenceController(IServiceManager services) : Controller
{
    [HttpGet("healt-check")]
    public async Task<IActionResult> GetApiHealth() => Ok("Refernce api is running...");

    [HttpGet("get-user/{id:long}")]
    public async Task<IActionResult> GetUserById([FromRoute] long id)
    {
        var response = await services.UserService.GetUserIdAsync(id, false);
        return Ok(response);
    }

    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserForCreationDto userDto)
    {
        var response = await services.UserService.CreateUserAsync(userDto);
        return Ok(response);
    }

    [HttpPost("update-user")]
    public async Task<IActionResult> UpdateUserAsync([FromBody] UserForUpdationDto userDto)
    {
        var response = await services.UserService.UpdateUserAsync(userDto);
        return Ok(response);
    }

    [HttpDelete("delete-user/{id:long}")]
    public async Task<IActionResult> DeleteUserByIdAsync([FromRoute] long id)
    {
        var response = await services.UserService.DeleteUserAsync(id);
        return Ok(response);
    }
}
