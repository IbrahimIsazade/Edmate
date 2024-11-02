using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{

    class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.FirstName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.LastName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.ProfileImagePath).HasColumnType("varchar").HasMaxLength(80).IsRequired();
			builder.Property(m => m.IsStudying).HasColumnType("tinyint").HasMaxLength(80).IsRequired();
			builder.Property(m => m.PlanId).HasColumnType("int").HasMaxLength(80).IsRequired();

			builder.HasKey(m => m.Id);
			builder.ToTable("Students");

			builder.HasOne<Plan>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.PlanId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
