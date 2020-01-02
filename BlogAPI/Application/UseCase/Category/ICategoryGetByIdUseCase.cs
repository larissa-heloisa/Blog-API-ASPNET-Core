using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Category
{
   public interface ICategoryGetByIdUseCase
    {
        Domain.Entities.Category.Category GetById(Guid id);
    }
}
