using Application.Repositories;
using Domain.Entities.Comment;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class CommentRepository : ICommentReadOnlyRepository, ICommentWriteOnlyRepository
    {
        public int Add(Comment comment)
        {
            using(var applicationContext = new ApplicationContext())
            {
                applicationContext.Comment.Add(comment);
                return applicationContext.SaveChanges();
            }
            
        }

        public List<Comment> GetAll()
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.Comment.ToList();
            }
                
        }

        public Comment GetById(Guid id)
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.Comment.Find(id);
            }
        }

        public int Remove(Comment comment)
        {
            using (var applicationContext = new ApplicationContext()) 
            {
                comment = applicationContext.Comment.Find(comment.IdComment);

                applicationContext.Comment.Remove(comment);
                return applicationContext.SaveChanges();
            }
        }

        public int Update(Comment comment)
        {
            using (var applicationContext = new ApplicationContext())
            {
                applicationContext.Update(comment);
                return applicationContext.SaveChanges();
            }
        }

    }
}
