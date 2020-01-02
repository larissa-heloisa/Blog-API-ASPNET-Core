using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Comment
{
    public class CommentGetAllUseCase : ICommentGetAllUseCase
    {
        private readonly ICommentReadOnlyRepository commentReadOnlyRepository;

        public List<Domain.Entities.Comment.Comment> GetAll()
        {
            return commentReadOnlyRepository.GetAll();
        }

        public CommentGetAllUseCase(ICommentReadOnlyRepository commentReadOnlyRepository)
        {
            this.commentReadOnlyRepository = commentReadOnlyRepository;
        }
    }
}
