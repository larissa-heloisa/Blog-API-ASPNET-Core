using Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ICategoryReadOnlyRepository
    {
        List<Category> GetAll();

        Category GetById(Guid id);
    }
}
