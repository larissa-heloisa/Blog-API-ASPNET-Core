using Application.Repositories;
using Domain.Entities.User;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        public int Add(User user)
        {
            using (var applicationContext = new ApplicationContext())
            {
                applicationContext.User.Add(user);
                return applicationContext.SaveChanges();
            }

        }

        public List<User> GetAll()
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.User.ToList();
            }

        }

        public User GetById(Guid id)
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.User.Find(id);
            }
        }

        public int Remove(User user)
        {
            using (var applicationContext = new ApplicationContext())
            {
                user = applicationContext.User.Find(user.IdUser);

                applicationContext.User.Remove(user);
                return applicationContext.SaveChanges();
            }
        }

        public int Update(User user)
        {
            using (var applicationContext = new ApplicationContext())
            {
                applicationContext.Update(user);
                return applicationContext.SaveChanges();
            }
        }
    }
}
