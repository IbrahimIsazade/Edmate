using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.common;

namespace Persistence.Configurations
{
    class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Description).HasColumnType("nvarchar(max)").IsRequired();
			builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
			builder.Property(m => m.PublisherId).HasColumnType("int").IsRequired();
			builder.Property(m => m.ThumbnailPath).HasColumnType("varchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.PdfPath).HasColumnType("varchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.AproximateReading).HasColumnType("int").IsRequired();

			builder.ConfigureAuditable();
			builder.HasKey(m => m.Id);
			builder.ToTable("Books");

			builder.HasOne<Category>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne<Mentor>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.PublisherId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
