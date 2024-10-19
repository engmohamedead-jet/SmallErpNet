using Microsoft.AspNetCore.Mvc;

namespace SmallErpNet_1.APIs;

[ApiController()]
public class TenantsController : TenantsControllerBase
{
    public TenantsController(ITenantsService service)
        : base(service) { }
}
