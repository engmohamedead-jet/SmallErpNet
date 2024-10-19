using SmallErpNet_1.Infrastructure;

namespace SmallErpNet_1.APIs;

public class TenantsService : TenantsServiceBase
{
    public TenantsService(SmallErpNet_1DbContext context)
        : base(context) { }
}
