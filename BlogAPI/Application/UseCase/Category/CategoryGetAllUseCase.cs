using System;
using System.Collections.Generic;
using System.Text;
using Application.Repositories;
using Domain.Entities.Category;

namespace Application.UseCase.Category
{
    public class CategoryGetAllUseCase : ICategoryGetAllUseCase
    {
        private readonly ICategoryReadOnlyRepository categoryReadOnlyRepository;

        public List<Domain.Entities.Category.Category> GetAll()
        {
            return categoryReadOnlyRepository.GetAll();
        }
        public CategoryGetAllUseCase(ICategoryReadOnlyRepository categoryReadOnlyRepository)
        {
            this.categoryReadOnlyRepository = categoryReadOnlyRepository;
        }
    }
}
