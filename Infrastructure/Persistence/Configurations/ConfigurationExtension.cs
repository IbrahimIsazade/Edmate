using Domain.Entities.common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Configurations
{
    public static class ConfigurationExtension
    {
        public static EntityTypeBuilder<T> ConfigureAuditable<T>(this EntityTypeBuilder<T> builder)
            where T : AuditableEntity
        {
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.ModifiedBy).HasColumnType("int").IsRequired(false);
            builder.Property(m => m.ModifiedAt).HasColumnType("datetime").IsRequired(false);
            builder.Property(m => m.DeletedBy).HasColumnType("int").IsRequired(false);
            builder.Property(m => m.DeletedAt).HasColumnType("datetime").IsRequired(false);

            return builder;
        }
    }
}
