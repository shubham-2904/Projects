using CustomAtrributes;
using Microsoft.AspNetCore.Mvc;
using Reference.Domain.Model;
using Reference.Infrastructure.DBContext;
using ReferenceServices.Dtos;
using ReferenceServices.ServicesInterfaces;

namespace Auction.Reference.API.Controllers;

[ApiController]
[Route("api/[controller]/")]
[ConcurrencyHandler(typeof(ReferenceDbContext), typeof(AuctionHouse))]
public class AuctionHousesController(IServiceManager services) : ControllerBase
{

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAuctionHouseByIdAsync(long id)
    {
        var response = await services.AuctionHouseService.GetAuctionHouseIdAsync(id, false);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuctionHousesAsync()
    {
        var response = await services.AuctionHouseService.GetAllAuctionHousesAsync(false);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuctionHouseAsync(AuctionHouseForCreationDto auctionHouseDto)
    {
        var response = await services.AuctionHouseService.CreateAuctionHouseAsync(auctionHouseDto);
        return Ok(response);
    }

    [HttpPut]
    
    public async Task<ActionResult> UpdateAuctionHouseAsync(AuctionHouseForUpdationDto auctionHouseDto)
    {
        var response = await services.AuctionHouseService.UpdateAuctionHouseAsync(auctionHouseDto);
        return Ok(response);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAuctionHouseByIdAsync(long id)
    {
        var response = await services.AuctionHouseService.DeleteAuctionHouseAsync(id);
        return Ok(response);
    }
}
