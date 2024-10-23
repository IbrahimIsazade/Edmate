using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    class CustomUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<CustomUserClaim>
    {
        public void Configure(EntityTypeBuilder<CustomUserClaim> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
