using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmallErpNet.Infrastructure;

public class SmallErpNetDbContext : IdentityDbContext<IdentityUser>
{
    public SmallErpNetDbContext(DbContextOptions<SmallErpNetDbContext> options)
        : base(options) { }
}
