using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public interface ICommentUpdateUseCase
    {
        int Update(Domain.Entities.Comment.Comment comment);
    }
}
