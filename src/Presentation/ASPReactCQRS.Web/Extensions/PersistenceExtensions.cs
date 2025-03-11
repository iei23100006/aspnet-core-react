using Microsoft.EntityFrameworkCore.Storage;

namespace ASPReactCQRS.Web.Extensions
{
    public static class PersistenceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseProvider = configuration.GetValue<string>("PersistenceProvider");
            if (databaseProvider != null && String.Equals(databaseProvider,  typeof(ASPReactCQRS.Persistence.MySql.ServiceExtensions).Assembly.GetName().Name))
            {
                ASPReactCQRS.Persistence.MySql.ServiceExtensions.ConfigurePersistence(services, configuration);
            }
            else if (databaseProvider != null && String.Equals(databaseProvider, typeof(ASPReactCQRS.Persistence.SqlServer.ServiceExtensions).Assembly.GetName().Name))
            {
                ASPReactCQRS.Persistence.SqlServer.ServiceExtensions.ConfigurePersistence(services, configuration);
            }
            else
            {
                throw new Exception("Invalid database provider: " + databaseProvider);
            }
        }
    }
}
