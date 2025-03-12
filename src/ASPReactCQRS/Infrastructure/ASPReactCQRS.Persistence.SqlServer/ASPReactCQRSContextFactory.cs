using ASPReactCQRS.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ASPReactCQRS.Persistence.SqlServer
{
    public class ASPReactCQRSContextFactory : IDesignTimeDbContextFactory<ASPReactCQRSDbContext>
    {
        public ASPReactCQRSDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            var builder = new DbContextOptionsBuilder<ASPReactCQRSDbContext>();
            var connectionString = configuration.GetSection("ConnectionString").Value; 
            if (!string.IsNullOrEmpty(connectionString))
            {
                builder.UseSqlServer(connectionString,
                    options => options.MigrationsAssembly(typeof(ASPReactCQRSContextFactory).Assembly.GetName().Name));
            }
            return new ASPReactCQRSDbContext(builder.Options);
        }
    }
}
