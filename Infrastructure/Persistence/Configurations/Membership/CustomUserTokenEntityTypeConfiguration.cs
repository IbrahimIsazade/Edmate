using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    class CustomUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<CustomUserToken>
    {
        public void Configure(EntityTypeBuilder<CustomUserToken> builder)
        {
            //builder.HasKey(m => m.Id);
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
