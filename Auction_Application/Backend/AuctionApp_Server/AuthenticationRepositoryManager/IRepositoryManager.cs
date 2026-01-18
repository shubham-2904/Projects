using AuthenticationRepositories.Interfaces;

namespace AuthenticationRepositoryManager;

public interface IRepositoryManager
{
    IUserLoginRepository UserLogin { get; }
    ILoginStatusRepository LoginStatus { get; }

    /// <summary>
    /// Used to commit changes into DB
    /// </summary>
    Task CommitAsync();
}
