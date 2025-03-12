using Microsoft.EntityFrameworkCore;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using ASPReactCQRS.Persistence.Common.Comparers;
using ASPReactCQRS.Persistence.Common.Converters;
using ASPReactCQRS.Persistence.Common.Repositories;
using System.Reflection;


namespace ASPReactCQRS.Persistence.Common.Context
{
    public class ASPReactCQRSDbContext : DbContext, IASPReactCQRSDbContext
    {
        public ASPReactCQRSDbContext(DbContextOptions<ASPReactCQRSDbContext> options) : base(options) { }

        public virtual DbSet<Domain.Entities.Activity> Activities => Set<Domain.Entities.Activity>();
        public virtual DbSet<Domain.Entities.User> Users => Set<Domain.Entities.User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        // omitted for brevity
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
                .HaveColumnType("date");
            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter, TimeOnlyComparer>();
        }

        public async Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return new DbTransaction(await base.Database.BeginTransactionAsync(cancellationToken));
        }
    }
}
