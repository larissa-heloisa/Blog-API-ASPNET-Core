using Domain.Entities.Category;
using Domain.Entities.Comment;
using Domain.Entities.Post;
using Domain.Entities.User;
using Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(Environment.GetEnvironmentVariable("DATABASE_CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONN"), npgsqlOptionsAction: options =>
                 {
                     options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                     options.MigrationsHistoryTable("_MigrationHistory", "postgres");
                 });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());

            modelBuilder.Entity<Post>().HasData(
                new Post("Aula de docker", "Outra string"),
                new Post("Equipe Gang of Five", "GoF e a melhor equipe que tem"));
            
            modelBuilder.Entity<Comment>().HasData(
                new Comment("Aula de docker"),
                new Comment("Equipe Gang of Five"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
