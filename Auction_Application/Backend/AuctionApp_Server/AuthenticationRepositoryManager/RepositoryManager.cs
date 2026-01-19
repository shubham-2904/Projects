using Authentication.Infrastructure.DBContext;
using AuthenticationRepositories.Interfaces;
using AuthenticationRepositories.Repositories;

namespace AuthenticationRepositoryManager;

public class RepositoryManager : IRepositoryManager
{
    private readonly AuthenticationDbContext _authenticationContext;

    private readonly Lazy<IUserLoginRepository> _userLoginRepository;
    private readonly Lazy<ILoginStatusRepository> _loginStatusRepository;

    public RepositoryManager(AuthenticationDbContext authenticationContext)
    {
        _authenticationContext = authenticationContext;
        _userLoginRepository = new(() => new UserLoginRepository(_authenticationContext));
        _loginStatusRepository = new(() => new LoginStatusRepository());
    }
    
    public IUserLoginRepository UserLogin => _userLoginRepository.Value;
    public ILoginStatusRepository LoginStatus => _loginStatusRepository.Value;

    public async Task CommitAsync()
    {
        await _authenticationContext.SaveChangesAsync();
    }
}
