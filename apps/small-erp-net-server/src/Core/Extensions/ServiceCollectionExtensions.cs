using SmallErpNet_1.APIs;

namespace SmallErpNet_1;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITenantsService, TenantsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
