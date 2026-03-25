using LoggerService;
using ReferenceRepositoryManager;
using ReferenceServices.ServicesInterfaces;

namespace ReferenceServices.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IAuctionHouseService> _auctionHouseService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, loggerManager));
        _auctionHouseService = new Lazy<IAuctionHouseService>(() => new AuctionHouseService(repositoryManager, loggerManager));
    }

    public IUserService UserService => _userService.Value;

    public IAuctionHouseService AuctionHouseService => _auctionHouseService.Value;
}
