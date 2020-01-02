using System;
using System.Collections.Generic;
using System.Text;
using Application.Repositories;
using Domain.Entities.Comment;

namespace Application.UseCase.Comment
{
    public class CommentGetByIdUseCase : ICommentGetByIdUseCase
    {
        private readonly ICommentReadOnlyRepository commentReadOnlyRepository;

        public Domain.Entities.Comment.Comment GetById(Guid id)
        {
            return commentReadOnlyRepository.GetById(id);
        }
        public CommentGetByIdUseCase(ICommentReadOnlyRepository commentReadOnlyRepository)
        {
            this.commentReadOnlyRepository = commentReadOnlyRepository;
        }
    }
}
