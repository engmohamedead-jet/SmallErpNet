using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallErpNet_1.Infrastructure.Models;

[Table("Tenants")]
public class TenantDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public List<UserDbModel>? Users { get; set; } = new List<UserDbModel>();
}
