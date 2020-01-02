using Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfig
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "Blog"); 
            builder.HasKey(x => x.CategoryId);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
