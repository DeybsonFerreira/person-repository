using app.Data;
using app.Interfaces;
using app.Repository;
using Microsoft.EntityFrameworkCore;

namespace app.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            return services;
        }

        public static IServiceCollection AddCustomDependence(this IServiceCollection services)
        {
            services.AddScoped<ProjectContext, ProjectContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            return services;
        }
    }
}