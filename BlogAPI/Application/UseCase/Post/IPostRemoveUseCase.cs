using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Post
{
    public interface IPostRemoveUseCase
    {
        int Remove(Domain.Entities.Post.Post post);
    }
}
