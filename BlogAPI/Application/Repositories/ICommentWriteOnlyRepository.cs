using Domain.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ICommentWriteOnlyRepository
    {
        int Remove(Comment comment);
        int Update(Comment comment);
        int Add(Comment comment);
    }
}
