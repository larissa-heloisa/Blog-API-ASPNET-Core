using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Post
{
    public interface IPostGetAllUseCase
    {
        List<Domain.Entities.Post.Post> GetAll();
    }
}
