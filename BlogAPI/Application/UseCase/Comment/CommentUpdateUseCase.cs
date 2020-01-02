using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public class CommentUpdateUseCase : ICommentUpdateUseCase
    {
        private readonly ICommentWriteOnlyRepository commentWriteOnlyRepository;

        public int Update(Domain.Entities.Comment.Comment comment)
        {
            return commentWriteOnlyRepository.Update(comment);
        }
        public CommentUpdateUseCase(ICommentWriteOnlyRepository commentWriteOnlyRepository )
        {
            this.commentWriteOnlyRepository = commentWriteOnlyRepository;
        }
    }
}