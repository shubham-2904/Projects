using ReferenceServices.Dtos;
using SharedData;

namespace ReferenceServices.ServicesInterfaces;

public interface IAuctionHouseService
{
    Task<Response<IEnumerable<AuctionHouseDto>>> GetAllAuctionHousesAsync(bool trackChanges);

    Task<Response<AuctionHouseDto>> GetAuctionHouseIdAsync(long id, bool trackChanges);

    Task<Response<IEnumerable<AuctionHouseDto>>> GetAuctionHousesByIdsAsync(IEnumerable<long> ids, bool trackChanges);

    Task<Response<AuctionHouseDto>> CreateAuctionHouseAsync(AuctionHouseForCreationDto auctionHouseForCreationDto);

    Task<Response<AuctionHouseDto>> UpdateAuctionHouseAsync(AuctionHouseForUpdationDto auctionHouseForUpdationDto);

    Task<Response<bool>> DeleteAuctionHouseAsync(long id);
}
