using LoggerService;
using ReferenceRepositoryManager;
using ReferenceServices.ServicesInterfaces;

namespace ReferenceServices.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> _userService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, loggerManager));
    }

    public IUserService UserService => _userService.Value;
}
