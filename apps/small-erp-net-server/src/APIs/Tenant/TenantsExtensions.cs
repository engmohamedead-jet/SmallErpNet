using SmallErpNet_1.APIs.Dtos;
using SmallErpNet_1.Infrastructure.Models;

namespace SmallErpNet_1.APIs.Extensions;

public static class TenantsExtensions
{
    public static Tenant ToDto(this TenantDbModel model)
    {
        return new Tenant
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
            Users = model.Users?.Select(x => x.Id).ToList(),
        };
    }

    public static TenantDbModel ToModel(
        this TenantUpdateInput updateDto,
        TenantWhereUniqueInput uniqueId
    )
    {
        var tenant = new TenantDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            tenant.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            tenant.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return tenant;
    }
}
