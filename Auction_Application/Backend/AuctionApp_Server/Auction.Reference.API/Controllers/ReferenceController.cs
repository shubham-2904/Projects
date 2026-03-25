using CustomAtrributes;
using Microsoft.AspNetCore.Mvc;
using Reference.Domain.Model;
using Reference.Infrastructure.DBContext;
using ReferenceServices.Dtos;
using ReferenceServices.ServicesInterfaces;

namespace Auction.Reference.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReferenceController(IServiceManager services) : Controller
{
    [HttpGet("health-check")]
    public async Task<IActionResult> GetApiHealth() => Ok("Refernce api is running...");

    #region ========== USERS ENDPOINTS ==========

    [HttpGet("get-user/{id:long}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] long id)
    {
        var response = await services.UserService.GetUserIdAsync(id, false);
        return Ok(response);
    }

    [HttpGet("get-all-user")]
    public async Task<IActionResult> GetAllUserAsync()
    {
        var response = await services.UserService.GetAllUsersAsync(false);
        return Ok(response);
    }

    [HttpPost("create-user")]
    [ConcurrencyHandler(typeof(ReferenceDbContext), typeof(User))]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserForCreationDto userDto)
    {
        var response = await services.UserService.CreateUserAsync(userDto);
        return Ok(response);
    }

    [HttpPost("update-user")]
    [ConcurrencyHandler(typeof(ReferenceDbContext), typeof(User))]
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

    #endregion

    #region ========== AUCTION HOUSE ENDPOINTS ==========

    [HttpGet("get-auction-house/{id:long}")]
    public async Task<IActionResult> GetAuctionHouseByIdAsync([FromRoute] long id)
    {
        var response = await services.AuctionHouseService.GetAuctionHouseIdAsync(id, false);
        return Ok(response);
    }

    [HttpGet("get-all-auction-houses")]
    public async Task<IActionResult> GetAllAuctionHousesAsync()
    {
        var response = await services.AuctionHouseService.GetAllAuctionHousesAsync(false);
        return Ok(response);
    }

    [HttpPost("create-auction-house")]
    [ConcurrencyHandler(typeof(ReferenceDbContext), typeof(AuctionHouse))]
    public async Task<IActionResult> CreateAuctionHouseAsync([FromBody] AuctionHouseForCreationDto auctionHouseDto)
    {
        var response = await services.AuctionHouseService.CreateAuctionHouseAsync(auctionHouseDto);
        return Ok(response);
    }

    [HttpPost("update-auction-house")]
    [ConcurrencyHandler(typeof(ReferenceDbContext), typeof(AuctionHouse))]
    public async Task<IActionResult> UpdateAuctionHouseAsync([FromBody] AuctionHouseForUpdationDto auctionHouseDto)
    {
        var response = await services.AuctionHouseService.UpdateAuctionHouseAsync(auctionHouseDto);
        return Ok(response);
    }

    [HttpDelete("delete-auction-house/{id:long}")]
    public async Task<IActionResult> DeleteAuctionHouseByIdAsync([FromRoute] long id)
    {
        var response = await services.AuctionHouseService.DeleteAuctionHouseAsync(id);
        return Ok(response);
    }

    #endregion
}
