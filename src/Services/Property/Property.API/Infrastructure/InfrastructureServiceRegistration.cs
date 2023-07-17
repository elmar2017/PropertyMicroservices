using Microsoft.EntityFrameworkCore;
using Property.API.Data;

namespace Property.API.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PropertyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PropertyConnectionString")));

            return services;
        }
    }
}
