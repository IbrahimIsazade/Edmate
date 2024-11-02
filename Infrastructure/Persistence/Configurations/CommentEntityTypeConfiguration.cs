using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.common;

namespace Persistence.Configurations
{

    class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Content).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
			builder.Property(m => m.CourseId).HasColumnType("int").IsRequired();
			builder.Property(m => m.UserId).HasColumnType("int").IsRequired();
			builder.Property(m => m.CommentId).HasColumnType("int").IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("Comments");

			// users

			builder.HasOne<Course>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.CourseId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
