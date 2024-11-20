using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.common;

namespace Persistence.Configurations
{

    class AwardEntityTypeConfiguration : IEntityTypeConfiguration<Award>
	{
		public void Configure(EntityTypeBuilder<Award> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.CourseId).HasColumnType("int").IsRequired();

            builder.ConfigureAuditable();
			builder.HasKey(m => m.Id);
            builder.ToTable("Awards");

			builder.HasOne<Course>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.CourseId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
