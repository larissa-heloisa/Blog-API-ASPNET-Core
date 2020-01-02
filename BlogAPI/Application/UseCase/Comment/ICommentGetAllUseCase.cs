using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public interface ICommentGetAllUseCase
    {
        List<Domain.Entities.Comment.Comment> GetAll();
    }
}
