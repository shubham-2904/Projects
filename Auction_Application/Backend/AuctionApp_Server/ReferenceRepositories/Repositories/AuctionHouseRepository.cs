using Microsoft.EntityFrameworkCore;
using Reference.Domain.Model;
using Reference.Infrastructure.DBContext;
using ReferenceRepositories.Interfaces;
using System.Linq.Expressions;

namespace ReferenceRepositories.Repositories;

public sealed class AuctionHouseRepository : Repository<AuctionHouse>, IAuctionHouseRepository
{
    public AuctionHouseRepository(ReferenceDbContext referenceContext)
        : base(referenceContext) { }

    public void CreateAuctionHouse(AuctionHouse auctionHouse)
    {
        Create(auctionHouse);
    }

    public void DeleteAuctionHouse(AuctionHouse AuctionHouse)
    {
        Delete(AuctionHouse);
    }

    /// <summary>
    /// Get all records else if we pass value for condition parameter then it will return the records according to condition
    /// </summary>
    /// <param name="trackChanges"></param>
    /// <param name="condition"></param>
    /// <returns>return collection of ActionHouse</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<AuctionHouse>> GetAllAuctionHouseOrByConditionAsync(bool trackChanges, Expression<Func<AuctionHouse, bool>>? condition)
    {
        if (condition is not null)
        {
            return await FindByCondition(condition, trackChanges).ToListAsync();
        }
        else
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }

    public async Task<AuctionHouse?> GetAuctionHouseByIdAsync(long auctionHouseId, bool trackChanges)
    {
        return await FindByCondition(x => x.AuctionHouseId.Equals(auctionHouseId), trackChanges).SingleOrDefaultAsync();
    }

    public void UpdateAuctionHouse(AuctionHouse AuctionHouse)
    {
        Update(AuctionHouse);
    }
}
