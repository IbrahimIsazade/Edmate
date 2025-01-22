using Domain.Entities;
using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{

    class MentorEntityTypeConfiguration : IEntityTypeConfiguration<Mentor>
	{
		public void Configure(EntityTypeBuilder<Mentor> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.IdentityId).HasColumnType("int").IsRequired();

			builder.Property(m => m.FirstName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
			builder.Property(m => m.LastName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
			builder.Property(m => m.Location).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.PhoneNumber).HasColumnType("varchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Bio).HasColumnType("nvarchar(max)").IsRequired();
			builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
			builder.Property(m => m.ProfilePath).HasColumnType("varchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.CoverPath).HasColumnType("varchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.Followers).HasColumnType("int").IsRequired();
			builder.Property(m => m.Following).HasColumnType("int").IsRequired();
			builder.Property(m => m.Likes).HasColumnType("int").IsRequired();
			builder.Property(m => m.IsVerified).HasColumnType("tinyint").IsRequired();

            builder.HasKey(m => m.Id);
			builder.ToTable("Mentors");

			builder.HasOne<Category>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

			//builder.HasOne<CustomUser>()
			//	.WithMany()
			//	.HasPrincipalKey(m => m.Id)
			//	.HasForeignKey(m => m.IdentityId)
			//	.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
