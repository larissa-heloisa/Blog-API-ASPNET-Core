using Application.Repositories;
using Domain.Entities.Category;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class CategoryRepository : ICategoryReadOnlyRepository, ICategoryWriteOnlyRepository
    {
        public int Add(Category category)
        {
            using (var applicationContext = new ApplicationContext())
            { 
                applicationContext.Category.Add(category);
                return applicationContext.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.Category.ToList();
            }

        }

        public Category GetById(Guid id)
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.Category.Find(id);
            }
        }
    }
}
