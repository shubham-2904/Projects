using System.ComponentModel.DataAnnotations;

namespace Reference.Domain.Model;

public class AuctionEvent
{
    [Key]
    public long AuctionEventId { get; set; }

    public long ActionHouseId { get; set; }

    public long OrganizerId { get; set; }

    public string? Title { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime ActualEndTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;

    // Navigation Properties
    public AuctionHouse? AuctionHouse { get; set; }
    public User? Organizer { get; set; }
    public ICollection<AuctionParticipant>? AuctionParticipants { get; set; }
}
