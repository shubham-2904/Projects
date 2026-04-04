using CustomAtrributes;
using Microsoft.AspNetCore.Mvc;
using Reference.Domain.Model;
using Reference.Infrastructure.DBContext;
using ReferenceServices.Dtos;
using ReferenceServices.ServicesInterfaces;

namespace Auction.Reference.API.Controllers;

[ApiController]
[Route("api/[controller]/")]
[ConcurrencyHandler(typeof(ReferenceDbContext), typeof(User))]
public class UsersController(IServiceManager services) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetUserByIdAsync(long id)
    {
        var response = await services.UserService.GetUserIdAsync(id, false);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserAsync()
    {
        var response = await services.UserService.GetAllUsersAsync(false);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(UserForCreationDto userDto)
    {
        var response = await services.UserService.CreateUserAsync(userDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync(UserForUpdationDto userDto)
    {
        var response = await services.UserService.UpdateUserAsync(userDto);
        return Ok(response);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteUserByIdAsync(long id)
    {
        var response = await services.UserService.DeleteUserAsync(id);
        return Ok(response);
    }
}
