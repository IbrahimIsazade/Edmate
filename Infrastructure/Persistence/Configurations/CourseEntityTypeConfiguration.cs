using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.common;

namespace Persistence.Configurations
{
    class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Description).HasColumnType("nvarchar(max)").IsRequired();
			builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
			builder.Property(m => m.MentorId).HasColumnType("int").IsRequired();
			builder.Property(m => m.Rating).HasColumnType("decimal").HasPrecision(18, 3).IsRequired();
			builder.Property(m => m.ThumbnailPath).HasColumnType("varchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.Duration).HasColumnType("int").IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("Courses");

			builder.HasOne<Category>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne<Mentor>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.MentorId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
