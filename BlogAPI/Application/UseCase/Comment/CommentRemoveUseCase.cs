using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public class CommentRemoveUseCase : ICommentRemoveUseCase
    {
        private readonly ICommentWriteOnlyRepository commentWriteOnlyRepository;
        public int Remove(Domain.Entities.Comment.Comment comment)
        {
            return commentWriteOnlyRepository.Remove(comment);
        }
        public CommentRemoveUseCase(ICommentWriteOnlyRepository commentWriteOnlyRepository)
        {
            this.commentWriteOnlyRepository = commentWriteOnlyRepository;
        }
    }
}
