using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallErpNet.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    [StringLength(256)]
    public string Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public bool IsActive { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [Required()]
    [StringLength(256)]
    public string NormalizedUserName { get; set; }

    [Required()]
    [StringLength(256)]
    public string Note { get; set; }

    [Required()]
    [StringLength(256)]
    public string Password { get; set; }

    [Required()]
    public string Roles { get; set; }

    public string? TenantId { get; set; }

    [ForeignKey(nameof(TenantId))]
    public TenantDbModel? Tenant { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    [StringLength(256)]
    public string Username { get; set; }
}
