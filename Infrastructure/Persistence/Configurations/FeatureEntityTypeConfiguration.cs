using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.common;

namespace Persistence.Configurations
{

    class FeatureEntityTypeConfiguration : IEntityTypeConfiguration<Feature>
	{
		public void Configure(EntityTypeBuilder<Feature> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.BookId).HasColumnType("int").IsRequired();

			builder.ConfigureAuditable();
			builder.HasKey(m => m.Id);
			builder.ToTable("Features");

			builder.HasOne<Book>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.BookId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
