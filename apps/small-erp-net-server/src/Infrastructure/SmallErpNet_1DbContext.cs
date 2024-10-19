using Microsoft.EntityFrameworkCore;
using SmallErpNet_1.Infrastructure.Models;

namespace SmallErpNet_1.Infrastructure;

public class SmallErpNet_1DbContext : DbContext
{
    public SmallErpNet_1DbContext(DbContextOptions<SmallErpNet_1DbContext> options)
        : base(options) { }

    public DbSet<TenantDbModel> Tenants { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
