using Reference.Infrastructure.DBContext;
using ReferenceRepositories.Interfaces;
using ReferenceRepositories.Repositories;

namespace ReferenceRepositoryManager;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ReferenceDbContext _referenceContext;
    private readonly Lazy<IUserRepository> _userRepository;

    public RepositoryManager(ReferenceDbContext referenceContext)
    {
        _referenceContext = referenceContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(referenceContext));
    }

    public IUserRepository User => _userRepository.Value;

    public async Task CommitAsync()
    {
        await _referenceContext.SaveChangesAsync();
    }
}
