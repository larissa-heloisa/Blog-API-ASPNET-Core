using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public interface ICommentRemoveUseCase
    {
        int Remove(Domain.Entities.Comment.Comment comment);
    }
}
