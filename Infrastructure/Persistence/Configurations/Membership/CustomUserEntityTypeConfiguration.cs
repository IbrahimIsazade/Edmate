using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    class CustomUserEntityTypeConfiguration : IEntityTypeConfiguration<CustomUser>
    {
        public void Configure(EntityTypeBuilder<CustomUser> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("Users", "Membership");
        }
    }
}
