using Reference.Domain.Model;

namespace ReferenceServices.Dtos;

public record AuctionHouseDto
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public long OwnerUserId { get; set; }
    public DateTime? CreatedAt { get; init; }
    public DateTime? LastModifyDate { get; set; }
    public int LockId { get; init; }
}

public record AuctionHouseForCreationDto
{
    public long OwnerUserId { get; set; }
    public required string Name { get; init; }
    public int LockId { get; set; }

    public AuctionHouseForCreationDto(long ownerUserId, string name)
    {
        OwnerUserId = ownerUserId;
        Name = name;
    }
}

public record AuctionHouseForUpdationDto
{
    public long Id { get; set; }
    public long OwnerUserId { get; set; }
    public required string Name { get; init; }
    public int LockId { get; set; }

    public AuctionHouseForUpdationDto(long id, long ownerUserId, string name, int lockId)
    {
        Id = id;
        OwnerUserId = ownerUserId;
        Name = name;
        LockId = lockId;
    }
}

public static class AuctionHouseMapper
{
    public static AuctionHouseDto ToDto(this AuctionHouse entity)
    {
        return new AuctionHouseDto
        {
            Id = entity.AuctionHouseId,
            Name = entity.Name,
            OwnerUserId = entity.OwnerUserId,
            CreatedAt = entity.CreatedAt,
            LastModifyDate = entity.LastModifyDate,
            LockId = entity.LockId,
        };
    }

    /// <summary>
    /// Convert creation dto to entity
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>AuctionHouse entity from dto for new record</returns>
    public static AuctionHouse ToEntity(this AuctionHouseForCreationDto dto)
    {
        return new AuctionHouse
        {
            AuctionHouseId = 0,
            Name = dto.Name,
            OwnerUserId = dto.OwnerUserId,
            CreatedAt = DateTime.UtcNow,
            LastModifyDate = DateTime.UtcNow,
            LockId = dto.LockId
        };
    }

    /// <summary>
    /// Replace the existing AuctionHouse entity with update value
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="AuctionHouse"></param>
    public static void ToEntity(this AuctionHouseForUpdationDto dto, AuctionHouse AuctionHouse)
    {
        AuctionHouse.AuctionHouseId = dto.Id;
        AuctionHouse.Name = dto.Name;
        AuctionHouse.OwnerUserId = dto.OwnerUserId;
        AuctionHouse.LastModifyDate = DateTime.UtcNow;
        AuctionHouse.LockId = dto.LockId;
    }
}