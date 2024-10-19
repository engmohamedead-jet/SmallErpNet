using SmallErpNet.Infrastructure;

namespace SmallErpNet.APIs;

public class TenantsService : TenantsServiceBase
{
    public TenantsService(SmallErpNetDbContext context)
        : base(context) { }
}
