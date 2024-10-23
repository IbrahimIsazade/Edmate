using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    class CustomUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<CustomUserRole>
    {
        public void Configure(EntityTypeBuilder<CustomUserRole> builder)
        {
            builder.HasKey(m => new { m.UserId, m.RoleId });
            builder.ToTable("UserRoles", "Membership");
        }
    }
}
