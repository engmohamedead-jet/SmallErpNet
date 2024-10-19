using Microsoft.AspNetCore.Mvc;

namespace SmallErpNet_1.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
