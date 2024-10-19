using SmallErpNet.Infrastructure;

namespace SmallErpNet.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(SmallErpNetDbContext context)
        : base(context) { }
}
