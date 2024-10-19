using SmallErpNet_1.APIs.Common;
using SmallErpNet_1.APIs.Dtos;

namespace SmallErpNet_1.APIs;

public interface ITenantsService
{
    /// <summary>
    /// Create one Tenant
    /// </summary>
    public Task<Tenant> CreateTenant(TenantCreateInput tenant);

    /// <summary>
    /// Delete one Tenant
    /// </summary>
    public Task DeleteTenant(TenantWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Tenants
    /// </summary>
    public Task<List<Tenant>> Tenants(TenantFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Tenant records
    /// </summary>
    public Task<MetadataDto> TenantsMeta(TenantFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Tenant
    /// </summary>
    public Task<Tenant> Tenant(TenantWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Tenant
    /// </summary>
    public Task UpdateTenant(TenantWhereUniqueInput uniqueId, TenantUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Users records to Tenant
    /// </summary>
    public Task ConnectUsers(TenantWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Disconnect multiple Users records from Tenant
    /// </summary>
    public Task DisconnectUsers(TenantWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Find multiple Users records for Tenant
    /// </summary>
    public Task<List<User>> FindUsers(
        TenantWhereUniqueInput uniqueId,
        UserFindManyArgs UserFindManyArgs
    );

    /// <summary>
    /// Update multiple Users records for Tenant
    /// </summary>
    public Task UpdateUsers(TenantWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);
}
