using Microsoft.EntityFrameworkCore;
using Property.API.Data;
using Property.API.Services.Concrete;
using Property.API.Services.Interfaces;
using Property.API.Services.NewFolder;

namespace Property.API.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PropertyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PropertyConnectionString")));


            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IPropertySearchService, PropertySearchService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IJwtService>(new JwtService("mysecretkey123", "PropertyBackend", "PropertyClient"));

            return services;
        }
    }
}
