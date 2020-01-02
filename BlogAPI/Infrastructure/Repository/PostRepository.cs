using Application.Repositories;
using Domain.Entities.Post;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class PostRepository : IPostReadOnlyRepository, IPostWriteOnlyRepository
    {
        public int Add(Post post)
        {
            using (var applicationContext = new ApplicationContext())
            {
                applicationContext.Post.Add(post);
                return applicationContext.SaveChanges();
            }
        }

        public List<Post> GetAll()
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.Post.ToList();
            }
        }

        public Post GetById(Guid id)
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.Post.Find(id);
            }
        }

        public int Remove(Post post)
        {
            using (var applicationContext = new ApplicationContext())
            {
                post = applicationContext.Post.Find(post.IdPost);

                applicationContext.Post.Remove(post);
                return applicationContext.SaveChanges();
            }
        }

        public int Update(Post post)
        {
            using (var applicationContext = new ApplicationContext())
            {
                applicationContext.Update(post);
                return applicationContext.SaveChanges();
            }
        }
    }
}
