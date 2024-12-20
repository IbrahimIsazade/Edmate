﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{

    class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

			builder.ConfigureAuditable();
			builder.HasKey(m => m.Id);
			builder.ToTable("Categories");
		}
	}
}
