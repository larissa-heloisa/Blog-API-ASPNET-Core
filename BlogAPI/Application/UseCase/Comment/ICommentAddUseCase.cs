using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public interface ICommentAddUseCase
    {
        int Add(Domain.Entities.Comment.Comment comment);
    }
}
