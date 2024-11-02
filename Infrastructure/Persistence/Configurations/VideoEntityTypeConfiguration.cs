﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.common;

namespace Persistence.Configurations
{

    class VideoEntityTypeConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.VideoPath).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.CourseId).HasColumnType("int").IsRequired();
            builder.Property(m => m.CoursePartId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Duration).HasColumnType("int").IsRequired();

            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("Videos");

            // video part

            builder.HasOne<Course>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}