using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Membership;

namespace Persistence.Contexts.Configurations.Membership
{
    class CustomRoleEntityTypeConfiguration : IEntityTypeConfiguration<CustomRole>
    {
        public void Configure(EntityTypeBuilder<CustomRole> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("Roles", "Membership");
        }
    }
}
