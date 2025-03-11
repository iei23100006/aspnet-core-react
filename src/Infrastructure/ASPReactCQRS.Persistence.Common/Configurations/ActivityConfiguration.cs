namespace ASPReactCQRS.Persistence.Common.Configurations
{
     public class ActivityConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<ASPReactCQRS.Domain.Entities.Activity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ASPReactCQRS.Domain.Entities.Activity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ActivityName).IsRequired(true);
            builder.Property(c => c.CreatedAt).IsRequired(true);
            builder.Property(c => c.CreatedById).IsRequired(true);
            builder.Property(c => c.UpdatedAt).IsRequired(false);
            builder.Property(c => c.UpdatedById).IsRequired(false);
            builder.Property(c => c.DeletedAt).IsRequired(false);
            builder.Property(c => c.DeletedById).IsRequired(false);

            builder.HasIndex(c => c.ActivityName).IsUnique(true);
            builder.HasIndex(c => c.DeletedAt).IsUnique(false);

            builder.HasOne(c => c.CreatedBy)
                   .WithMany()
                   .HasForeignKey(c => c.CreatedById)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(c => c.UpdatedBy)
                   .WithMany()
                   .HasForeignKey(c => c.UpdatedById)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(c => c.DeletedBy)
                   .WithMany()
                   .HasForeignKey(c => c.DeletedById)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}