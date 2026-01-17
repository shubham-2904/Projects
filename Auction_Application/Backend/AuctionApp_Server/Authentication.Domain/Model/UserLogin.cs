using System.ComponentModel.DataAnnotations;

namespace Authentication.Domain.Model;

public class UserLogin
{
    [Key]
    public long LoginId { get; set; }

    public required string UserName { get; set; }
    
    public required string Password {  get; set; }

    public int LoginFailureCount { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<LoginStatus>? LoginStatuses { get; set; }
}
