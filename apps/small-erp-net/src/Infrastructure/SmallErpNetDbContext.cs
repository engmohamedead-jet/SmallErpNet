using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallErpNet.Infrastructure.Models;

namespace SmallErpNet.Infrastructure;

public class SmallErpNetDbContext : IdentityDbContext<IdentityUser>
{
    public SmallErpNetDbContext(DbContextOptions<SmallErpNetDbContext> options)
        : base(options) { }

    public DbSet<UserDbModel> Users { get; set; }

    public DbSet<TenantDbModel> Tenants { get; set; }
}
