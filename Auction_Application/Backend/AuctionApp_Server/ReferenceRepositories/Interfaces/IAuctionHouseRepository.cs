using Reference.Domain.Model;
using System.Linq.Expressions;

namespace ReferenceRepositories.Interfaces;

public interface IAuctionHouseRepository
{
    Task<IEnumerable<AuctionHouse>> GetAllAuctionHouseOrByConditionAsync(bool trackChanges, Expression<Func<AuctionHouse, bool>>? condition);

    Task<AuctionHouse?> GetAuctionHouseByIdAsync(long auctionHouseId, bool trackChanges);

    void CreateAuctionHouse(AuctionHouse auctionHouse);

    void UpdateAuctionHouse(AuctionHouse auctionHouse);

    void DeleteAuctionHouse(AuctionHouse auctionHouse);
}
