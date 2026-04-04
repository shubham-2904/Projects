using AuctionApp.Utilities.Indicators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reference.Domain.Model;

public class AuctionItem
{
    [Key]
    public long AuctionItemId { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public long? AuctionHouseId { get; set; }

    public AuctionItemCategoryInd? Category { get; set; }

    public int count { get; set; }

    [Column(TypeName = "decimal(24,9)")]
    public decimal? BuyPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;

    // Naviation Properties
    public AuctionHouse? AuctionHouse { get; set; }
}
