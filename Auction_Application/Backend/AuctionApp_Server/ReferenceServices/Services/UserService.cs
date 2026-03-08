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
            _logger.LogError(ex, ex.Message);
            return Response<UserDto>.Fail("Error occured while creating user");
        }
    }

    public async Task<Response<bool>> DeleteUserAsync(long id)
    {
        try
        {
            var user = await _repositoryManager.User.GetUserByIdAsync(id, true);
            if (user is null)
            {
                _logger.LogError("User not found");
                return Response<bool>.Fail("Error occured deleting user");
            }
            user.LastModifyDate = DateTime.UtcNow;
            user.IsDeleted = true;
            await _repositoryManager.CommitAsync();
            return Response<bool>.Ok(true, "User deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<bool>.Fail("Error occured deleting user");
        }
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

    public async Task<Response<bool>> UpdateUserAsync(UserForUpdationDto userForUpdationDto)
    {
        try
        {
            User user = await _repositoryManager.User.GetUserByIdAsync(userForUpdationDto.Id, true);
            if (user == null)
            {
                _logger.LogError("User not found");
                return Response<bool>.Fail("User not found");
            }
            userForUpdationDto.ToEntity(user);
            await _repositoryManager.CommitAsync();
            return Response<bool>.Ok(true, "User updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<bool>.Fail("Error while updating user");
        }
    }
}
