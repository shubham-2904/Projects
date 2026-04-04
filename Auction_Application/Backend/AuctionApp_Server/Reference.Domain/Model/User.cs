using System.ComponentModel.DataAnnotations;
using AuctionApp.Utilities.Indicators;

namespace Reference.Domain.Model;

public class User
{
    [Key]
    public long UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public UserCategoryInd? Category { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;

    // Navigation Properties
    public ICollection<AuctionHouse>? AuctionHouses { get; set; }
    public ICollection<AuctionEvent>? AuctionEvents { get; set; }
    public ICollection<AuctionParticipant>? AuctionParticipants { get; set; }
}
