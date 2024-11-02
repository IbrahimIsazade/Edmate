using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    class CustomUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<CustomUserToken>
    {
        public void Configure(EntityTypeBuilder<CustomUserToken> builder)
        {
            builder.Property(m => m.Type).HasColumnType("tinyint").IsRequired();
            builder.Property(m => m.ExpireDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(m => m.IsDisable).HasColumnType("int").IsRequired();

            builder.HasKey(m => new { m.UserId, m.LoginProvider, m.Name, m.Type, m.ExpireDate });
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
