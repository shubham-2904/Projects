using System.ComponentModel.DataAnnotations;

namespace Reference.Domain.Model;

public class User
{
    [Key]
    public long UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public short? Category { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;
}
