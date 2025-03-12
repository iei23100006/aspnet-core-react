using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Persistence.Common.Context;
using ASPReactCQRS.Persistence.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPReactCQRS.Persistence.SqlServer
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ASPReactCQRS");
            services.AddDbContext<IASPReactCQRSDbContext, ASPReactCQRSDbContext>(opt => opt.UseSqlServer(connectionString,
                options => options.MigrationsAssembly(typeof(ServiceExtensions).Assembly.GetName().Name)));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
        }
    }
}
