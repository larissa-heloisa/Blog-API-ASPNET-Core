using Domain.Entities.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfig
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("TBL_Comment", "Blog");
            builder.HasKey(x => x.IdComment);

            builder
                .Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(140);
        }
    }
}
