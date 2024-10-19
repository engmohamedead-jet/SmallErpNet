using Microsoft.EntityFrameworkCore;
using SmallErpNet.APIs;
using SmallErpNet.APIs.Common;
using SmallErpNet.APIs.Dtos;
using SmallErpNet.APIs.Errors;
using SmallErpNet.APIs.Extensions;
using SmallErpNet.Infrastructure;
using SmallErpNet.Infrastructure.Models;

namespace SmallErpNet.APIs;

public abstract class TenantsServiceBase : ITenantsService
{
    protected readonly SmallErpNetDbContext _context;

    public TenantsServiceBase(SmallErpNetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Tenant
    /// </summary>
    public async Task<Tenant> CreateTenant(TenantCreateInput createDto)
    {
        var tenant = new TenantDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            IsActive = createDto.IsActive,
            Name = createDto.Name,
            NormalizedName = createDto.NormalizedName,
            Note = createDto.Note,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            tenant.Id = createDto.Id;
        }
        if (createDto.Users != null)
        {
            tenant.Users = await _context
                .Users.Where(user => createDto.Users.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        _context.Tenants.Add(tenant);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TenantDbModel>(tenant.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Tenant
    /// </summary>
    public async Task DeleteTenant(TenantWhereUniqueInput uniqueId)
    {
        var tenant = await _context.Tenants.FindAsync(uniqueId.Id);
        if (tenant == null)
        {
            throw new NotFoundException();
        }

        _context.Tenants.Remove(tenant);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Tenants
    /// </summary>
    public async Task<List<Tenant>> Tenants(TenantFindManyArgs findManyArgs)
    {
        var tenants = await _context
            .Tenants.Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return tenants.ConvertAll(tenant => tenant.ToDto());
    }

    /// <summary>
    /// Meta data about Tenant records
    /// </summary>
    public async Task<MetadataDto> TenantsMeta(TenantFindManyArgs findManyArgs)
    {
        var count = await _context.Tenants.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Tenant
    /// </summary>
    public async Task<Tenant> Tenant(TenantWhereUniqueInput uniqueId)
    {
        var tenants = await this.Tenants(
            new TenantFindManyArgs { Where = new TenantWhereInput { Id = uniqueId.Id } }
        );
        var tenant = tenants.FirstOrDefault();
        if (tenant == null)
        {
            throw new NotFoundException();
        }

        return tenant;
    }

    /// <summary>
    /// Update one Tenant
    /// </summary>
    public async Task UpdateTenant(TenantWhereUniqueInput uniqueId, TenantUpdateInput updateDto)
    {
        var tenant = updateDto.ToModel(uniqueId);

        if (updateDto.Users != null)
        {
            tenant.Users = await _context
                .Users.Where(user => updateDto.Users.Select(t => t).Contains(user.Id))
                .ToListAsync();
        }

        _context.Entry(tenant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tenants.Any(e => e.Id == tenant.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Users records to Tenant
    /// </summary>
    public async Task ConnectUsers(
        TenantWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Tenants.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Users);

        foreach (var child in childrenToConnect)
        {
            parent.Users.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Users records from Tenant
    /// </summary>
    public async Task DisconnectUsers(
        TenantWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Tenants.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Users?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Users records for Tenant
    /// </summary>
    public async Task<List<User>> FindUsers(
        TenantWhereUniqueInput uniqueId,
        UserFindManyArgs tenantFindManyArgs
    )
    {
        var users = await _context
            .Users.Where(m => m.TenantId == uniqueId.Id)
            .ApplyWhere(tenantFindManyArgs.Where)
            .ApplySkip(tenantFindManyArgs.Skip)
            .ApplyTake(tenantFindManyArgs.Take)
            .ApplyOrderBy(tenantFindManyArgs.SortBy)
            .ToListAsync();

        return users.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Users records for Tenant
    /// </summary>
    public async Task UpdateUsers(
        TenantWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var tenant = await _context
            .Tenants.Include(t => t.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (tenant == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        tenant.Users = children;
        await _context.SaveChangesAsync();
    }
}
