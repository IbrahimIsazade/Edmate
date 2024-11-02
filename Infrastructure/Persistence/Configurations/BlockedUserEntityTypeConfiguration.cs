using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    class BlockedUserEntityTypeConfiguration : IEntityTypeConfiguration<BlockedUser>
	{
		public void Configure(EntityTypeBuilder<BlockedUser> builder)
		{
			builder.Property(m => m.BlockerId).HasColumnType("int").IsRequired();
			builder.Property(m => m.BlockedId).HasColumnType("int").IsRequired();

			builder.HasKey(m => new { m.BlockerId, m.BlockedId });
			builder.ToTable("BlockedUsers");
		}
	}
}
