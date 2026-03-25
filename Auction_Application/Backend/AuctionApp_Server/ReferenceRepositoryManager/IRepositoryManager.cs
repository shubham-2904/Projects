using ReferenceRepositories.Interfaces;

namespace ReferenceRepositoryManager;

public interface IRepositoryManager
{
    IUserRepository User { get; }

    IAuctionHouseRepository AuctionHouse { get; }

    /// <summary>
    /// Used to commit changes into DB
    /// </summary>
    Task CommitAsync();
}
