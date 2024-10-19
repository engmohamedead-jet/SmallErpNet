using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallErpNet.Infrastructure.Models;

[Table("Tenants")]
public class TenantDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    [StringLength(256)]
    public string Email { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public bool IsActive { get; set; }

    [Required()]
    [StringLength(256)]
    public string Name { get; set; }

    [Required()]
    [StringLength(256)]
    public string NormalizedName { get; set; }

    [Required()]
    [StringLength(256)]
    public string Note { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public List<UserDbModel>? Users { get; set; } = new List<UserDbModel>();
}
