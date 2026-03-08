using Reference.Domain.Model;
using ReferenceRepositoryManager;
using ReferenceServices.Dtos;
using ReferenceServices.ServicesInterfaces;
using SharedData;

namespace ReferenceServices.Services;

sealed class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
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

    public Task<Response<UserDto>> GetUserIdAsync(long id, bool trackChanges)
    {
        throw new NotImplementedException();
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
