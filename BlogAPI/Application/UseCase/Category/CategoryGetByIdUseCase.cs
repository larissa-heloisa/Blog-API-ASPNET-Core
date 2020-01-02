using System;
using System.Collections.Generic;
using System.Text;
using Application.Repositories;
using Domain.Entities.Category;

namespace Application.UseCase.Category
{
    public class CategoryGetByIdUseCase : ICategoryGetByIdUseCase
    {
        private readonly ICategoryReadOnlyRepository categoryReadOnlyRepository;

        public Domain.Entities.Category.Category GetById(Guid id)
        {
            return categoryReadOnlyRepository.GetById(id);
        }
        public CategoryGetByIdUseCase(ICategoryReadOnlyRepository categoryReadOnlyRepository)
        {
            this.categoryReadOnlyRepository = categoryReadOnlyRepository;
        }
    }
}
