using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public class CommentAddUseCase : ICommentAddUseCase
    {
        private readonly ICommentWriteOnlyRepository commentWriteOnlyRepository;
        public int Add(Domain.Entities.Comment.Comment comment)
        {
            return commentWriteOnlyRepository.Add(comment);
        }
        public CommentAddUseCase(ICommentWriteOnlyRepository commentWriteOnlyRepository)
        {
            this.commentWriteOnlyRepository = commentWriteOnlyRepository;
        }
    }
}

