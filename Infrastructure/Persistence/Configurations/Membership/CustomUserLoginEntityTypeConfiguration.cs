using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    class CustomUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<CustomUserLogin>
    {
        public void Configure(EntityTypeBuilder<CustomUserLogin> builder)
        {
            //builder.HasKey(m => m.Id);
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
