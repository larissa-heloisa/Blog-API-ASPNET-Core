using Domain.Entities.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfig
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post", "Blog");
            builder.HasKey(x => x.IdPost);
            
            builder
                .Property(x => x.CreationDate)
                .IsRequired();

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(1500);
                
        }
    }
}
