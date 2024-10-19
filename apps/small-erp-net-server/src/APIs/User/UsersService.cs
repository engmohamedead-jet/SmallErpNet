using SmallErpNet_1.Infrastructure;

namespace SmallErpNet_1.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(SmallErpNet_1DbContext context)
        : base(context) { }
}
