using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfig
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TBL_User", "Blog"); 
            builder.HasKey(x => x.IdUser);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40);
            builder
                .Property(x => x.CreationDate)
                .IsRequired();
        }
    }
}
