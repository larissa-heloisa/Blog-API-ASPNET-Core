using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Category
{
    public interface ICategoryGetAllUseCase
    {
        List<Domain.Entities.Category.Category> GetAll();
    }
}
