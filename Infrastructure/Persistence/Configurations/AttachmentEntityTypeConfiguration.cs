using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.common;

namespace Persistence.Configurations
{

    class AttachmentEntityTypeConfiguration : IEntityTypeConfiguration<Attachment>
	{
		public void Configure(EntityTypeBuilder<Attachment> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.CourseId).HasColumnType("int").IsRequired();
			builder.Property(m => m.FilePath).HasColumnType("varchar").HasMaxLength(50).IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("Attachments");

			builder.HasOne<Course>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.CourseId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
