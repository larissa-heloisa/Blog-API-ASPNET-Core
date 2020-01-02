using System;
using System.Collections.Generic;
using System.Text;
using Application.Repositories;
using Domain.Entities.Category;

namespace Application.UseCase.Category
{
    public class CategoryAddUseCase : ICategoryAddUseCase
    {
        private readonly ICategoryWriteOnlyRepository categoryWriteOnlyRepository;

        public int Add(Domain.Entities.Category.Category category)
        {
            return categoryWriteOnlyRepository.Add(category);
        }
        public CategoryAddUseCase(ICategoryWriteOnlyRepository categoryWriteOnlyRepository)
        {
            this.categoryWriteOnlyRepository = categoryWriteOnlyRepository;
        }
        
    }
}
