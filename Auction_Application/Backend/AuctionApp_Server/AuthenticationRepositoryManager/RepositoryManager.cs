using Authentication.Infrastructure.DBContext;
using AuthenticationRepositories.Interfaces;
using AuthenticationRepositories.Repositories;

namespace AuthenticationRepositoryManager;

public class RepositoryManager(AuthenticationDbContext authenticationContext) : IRepositoryManager
{
    private readonly AuthenticationDbContext _authenticationContext = authenticationContext;
    
    private readonly Lazy<IUserLoginRepository> _userLoginRepository = new(() => new UserLoginRepository());
    private readonly Lazy<ILoginStatusRepository> _loginStatusRepository = new(() => new LoginStatusRepository());

    public IUserLoginRepository UserLogin => _userLoginRepository.Value;
    public ILoginStatusRepository LoginStatus => _loginStatusRepository.Value;

    public async Task CommitAsync()
    {
        await _authenticationContext.SaveChangesAsync();
    }
}
