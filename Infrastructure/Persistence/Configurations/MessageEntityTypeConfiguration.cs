using Domain.Entities;
using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
	class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Content).HasColumnType("nvarchar(max)").IsRequired();
			builder.Property(m => m.SenderId).HasColumnType("int").IsRequired();
			builder.Property(m => m.RecieverId).HasColumnType("int").IsRequired();
			builder.Property(m => m.IsSeen).HasColumnType("bit").IsRequired();

			builder.ConfigureAuditable();


			builder.HasKey(m => m.Id);
			builder.ToTable("Messages");
		}
	}

}
