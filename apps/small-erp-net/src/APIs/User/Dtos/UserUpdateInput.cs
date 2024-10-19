namespace SmallErpNet.APIs.Dtos;

public class UserUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public bool? IsActive { get; set; }

    public string? LastName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Note { get; set; }

    public string? Password { get; set; }

    public string? Roles { get; set; }

    public string? Tenant { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Username { get; set; }
}
