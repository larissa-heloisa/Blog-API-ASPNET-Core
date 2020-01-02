using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Post
{
    public interface IPostUpdateUseCase
    {
        int Update(Domain.Entities.Post.Post post);
    }
}
