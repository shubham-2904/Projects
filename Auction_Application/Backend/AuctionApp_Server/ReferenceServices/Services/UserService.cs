using LoggerService;
using Reference.Domain.Model;
using ReferenceRepositoryManager;
using ReferenceServices.Dtos;
using ReferenceServices.ServicesInterfaces;
using SharedData;

namespace ReferenceServices.Services;

sealed class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;

    public UserService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _logger = loggerManager;
    }

    public async Task<Response<UserDto>> CreateUserAsync(UserForCreationDto userForCreationDto)
    {
        try
        {
            User user = userForCreationDto.ToEntity();
            _repositoryManager.User.CreateUser(user);
            await _repositoryManager.CommitAsync();
            UserDto userDto = user.ToDto();
            return Response<UserDto>.Ok(userDto, "User created successfully");
        }
        catch (Exception ex)
        {
            return Response<UserDto>.Fail("Error occured while creating user");
        }
    }

    public Task<Response<bool>> DeleteUserAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<IEnumerable<UserDto>>> GetAllUsersAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<UserDto>> GetUserIdAsync(long id, bool trackChanges)
    {
        try
        {
            User user = await _repositoryManager.User.GetUserByIdAsync(id, trackChanges);
            if (user == null)
            {
                _logger.LogError("User not found");
                return Response<UserDto>.Fail("User not found");
            }
            UserDto userDto = user!.ToDto();
            return Response<UserDto>.Ok(userDto, "User fetched successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<UserDto>.Fail("Error while fetching user");
        }
    }

    public Task<Response<IEnumerable<UserDto>>> GetUsersByIdsAsync(IEnumerable<long> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> UpdateUserAsync(UserForUpdationDto userForUpdationDto)
    {
        throw new NotImplementedException();
    }
}
