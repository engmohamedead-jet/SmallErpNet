namespace SmallErpNet_1.APIs.Dtos;

public class TenantUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<string>? Users { get; set; }
}
