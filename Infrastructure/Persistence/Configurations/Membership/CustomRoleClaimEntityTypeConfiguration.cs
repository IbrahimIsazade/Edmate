using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class CustomRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<CustomRoleClaim>
    {
        public void Configure(EntityTypeBuilder<CustomRoleClaim> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
