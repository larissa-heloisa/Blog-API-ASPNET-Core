using Domain.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ICommentReadOnlyRepository
    {
        List<Comment> GetAll();

        Comment GetById(Guid id);
    }
}
