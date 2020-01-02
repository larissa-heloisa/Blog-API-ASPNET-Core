using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Post
{
    public interface IPostGetByIdUseCase
    {
        Domain.Entities.Post.Post GetById(Guid id);
    }
}
