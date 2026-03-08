using Reference.Domain.Model;

namespace ReferenceServices.Dtos;

public record UserDto
{
    public long Id { get; init; }
    public string ? FirstName { get; init; }
    public string ? LastName { get; init; }
    public string ? FullName { get; init; }
    public short? Category { get; init; }
    public DateTime? CreatedAt { get; init; }
    public int LockId { get; init; }
}

public record UserForCreationDto(
    string FirstName,
    string LastName,
    short? Category,
    int LockId
);

public record UserForUpdationDto(
    long Id,
    string FirstName,
    string LastName,
    short? Category,
    int LockId
);

public static class UserDtoMethods
{
    public static UserDto ToDto(this User entity)
    {
        return new UserDto
        {
            Id = entity.UserId,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            FullName = entity.FirstName + " " + entity.LastName,
            Category = entity.Category,
            CreatedAt = entity.CreatedAt,
            LockId = entity.LockId,
        };
    }

    /// <summary>
    /// Convert creation dto to entity
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>User entity from dto for new record</returns>
    public static User ToEntity(this UserForCreationDto dto)
    {
        return new User
        {
            UserId = 0,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Category = dto.Category,
            CreatedAt = DateTime.UtcNow,
            LastModifyDate = DateTime.UtcNow,
            LockId = 0
        };
    }

    /// <summary>
    /// Replace the existing user entity with update value
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="user"></param>
    public static void ToEntity(this UserForUpdationDto dto, User user)
    {
        user.UserId = dto.Id;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Category = dto.Category;
        user.LastModifyDate = DateTime.UtcNow;
    }
}