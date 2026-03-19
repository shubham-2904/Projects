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

public record UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public short? Category { get; set; }
    public int LockId { get; set; }

    public UserForCreationDto(string firstName, string lastName, short? category, int lockId)
    {
        FirstName = firstName;
        LastName = lastName;
        Category = category;
        LockId = lockId;
    }
}

public record UserForUpdationDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public short? Category { get; set; }
    public int LockId { get; set; }

    public UserForUpdationDto(long id, string firstName, string lastName, short? category, int lockId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Category = category;
        LockId = lockId;
    }
}

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
            LockId = dto.LockId
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
        user.LockId = dto.LockId;
    }
}