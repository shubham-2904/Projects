
using System.ComponentModel.DataAnnotations;

namespace Authentication.Domain.Model;

public class LoginStatus
{
    [Key]
    public long LoginStatusId { get; set; }

    public long LoginId { get; set; }

    public string? Token { get; set; }

    public DateTime? LoginDate { get; set; }

    public DateTime? LogoutDate { get; set; }

    public DateTime? LastModifyDate { get; set; }

    public int LockId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public UserLogin? Login { get; set; }
}
