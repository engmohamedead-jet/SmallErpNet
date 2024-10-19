namespace SmallErpNet.APIs.Dtos;

public class TenantCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string Email { get; set; }

    public string? Id { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public string NormalizedName { get; set; }

    public string Note { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<User>? Users { get; set; }
}
