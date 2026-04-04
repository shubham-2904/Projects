using System.ComponentModel.DataAnnotations;

namespace Reference.Domain.Model;

public class AuctionParticipant
{
    [Key]
    public long AuctionParticipantId { get; set; }

    public long AuctionEventId { get; set; }

    public long UserId { get; set; }

    public DateTime? JoinedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;

    // Navigation Properties
    public User? User { get; set; }
    public AuctionEvent? AuctionEvent { get; set; }
}
