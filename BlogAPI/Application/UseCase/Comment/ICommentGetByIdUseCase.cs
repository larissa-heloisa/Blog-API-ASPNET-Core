using System;

namespace Application.UseCase.Comment
{
    public interface ICommentGetByIdUseCase
    {
        Domain.Entities.Comment.Comment GetById(Guid id);
    }
}