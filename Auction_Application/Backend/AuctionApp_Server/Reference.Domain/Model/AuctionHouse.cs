using System.ComponentModel.DataAnnotations;

namespace Reference.Domain.Model;

public class AuctionHouse
{
    [Key]
    public long AuctionHouseId { get; set; }

    public required string Name { get; set; }

    public long OwnerUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public User? User { get; set; }
}
