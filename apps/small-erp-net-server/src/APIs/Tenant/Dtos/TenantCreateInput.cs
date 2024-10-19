namespace SmallErpNet_1.APIs.Dtos;

public class TenantCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<User>? Users { get; set; }
}
