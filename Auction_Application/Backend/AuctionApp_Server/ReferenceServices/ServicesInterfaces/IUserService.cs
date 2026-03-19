using ReferenceServices.Dtos;
using SharedData;

namespace ReferenceServices.ServicesInterfaces;

public interface IUserService
{
    Task<Response<IEnumerable<UserDto>>> GetAllUsersAsync(bool trackChanges);

    Task<Response<UserDto>> GetUserIdAsync(long id, bool trackChanges);

    Task<Response<IEnumerable<UserDto>>> GetUsersByIdsAsync(IEnumerable<long> ids, bool trackChanges);

    Task<Response<UserDto>> CreateUserAsync(UserForCreationDto userForCreationDto);

    Task<Response<UserDto>> UpdateUserAsync(UserForUpdationDto userForUpdationDto);

    Task<Response<bool>> DeleteUserAsync(long id);
}
