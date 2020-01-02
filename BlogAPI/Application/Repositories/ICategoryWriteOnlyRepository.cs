using Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ICategoryWriteOnlyRepository
    {
        int Add(Category category);
    }
}
