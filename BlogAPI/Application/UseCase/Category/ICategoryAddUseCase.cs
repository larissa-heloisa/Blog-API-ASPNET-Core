using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Category
{
    public interface ICategoryAddUseCase
    {
        int Add(Domain.Entities.Category.Category category);
    }
}
