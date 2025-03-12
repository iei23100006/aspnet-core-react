namespace ASPReactCQRS.Persistence.Common.Configurations
{
     public class UserConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<ASPReactCQRS.Domain.Entities.User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ASPReactCQRS.Domain.Entities.User> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(255).IsUnicode(true).IsRequired(true);
            builder.Property(c => c.Company).HasMaxLength(255).IsUnicode(true).IsRequired(false);
            builder.Property(c => c.VendorCode).HasMaxLength(6).IsUnicode(false).IsRequired(false);
            builder.Property(c => c.Email).HasMaxLength(255).IsUnicode(true).IsRequired(false);
            builder.Property(c => c.CreatedAt).IsRequired(true);
            builder.Property(c => c.CreatedById).IsRequired(true);
            builder.Property(c => c.UpdatedAt).IsRequired(false);
            builder.Property(c => c.UpdatedById).IsRequired(false);
            builder.Property(c => c.DeletedAt).IsRequired(false);
            builder.Property(c => c.DeletedById).IsRequired(false);

            builder.HasIndex(c => c.Name).IsUnique(true);
            builder.HasIndex(c => c.Email).IsUnique(true);
            builder.HasIndex(c => c.VendorCode).IsUnique(false);
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