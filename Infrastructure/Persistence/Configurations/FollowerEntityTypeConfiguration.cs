using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    class FollowerEntityTypeConfiguration : IEntityTypeConfiguration<Follower>
	{
		public void Configure(EntityTypeBuilder<Follower> builder)
		{
			builder.Property(m => m.FollowedId).HasColumnType("int").IsRequired();
            builder.Property(m => m.FollowingId).HasColumnType("int").IsRequired();

			builder.HasKey(m => new { m.FollowingId, m.FollowedId });
			builder.ToTable("Followers");
		}
	}
}
