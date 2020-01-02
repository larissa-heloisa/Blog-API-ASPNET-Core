using Application.Repositories;
using Application.UseCase.Comment;
using Domain.Entities.Comment;
using Moq;
using System;
using Xunit;

namespace APITeste.ApplicationTest
{
    public class CommentUseCase
    {
        [Fact]
        public void AddComment() 
        {
            var comment = new Comment("This is a message");
            var commentRepositoryMock = new Mock<ICommentWriteOnlyRepository>(); 
            var commentAddUse = new CommentAddUseCase(commentRepositoryMock.Object);
            commentAddUse.Add(comment);
            commentRepositoryMock.Verify(r => r.Add(It.IsAny<Comment>()));
        }

        [Fact]
        public void RemoveComment() 
        {
            var comment = new Comment("This is a message");
            var commentRepositoryMock = new Mock<ICommentWriteOnlyRepository>(); 
            var commentRemoveUse = new CommentRemoveUseCase(commentRepositoryMock.Object);
            commentRemoveUse.Remove(comment);
            commentRepositoryMock.Verify(r => r.Remove(It.IsAny<Comment>()));
        }

        [Fact]
        public void UpdateComment()
        {
            var comment = new Comment("This is a message");
            var commentRepositoryMock = new Mock<ICommentWriteOnlyRepository>(); 
            var commentUpdateUse = new CommentUpdateUseCase(commentRepositoryMock.Object);
            commentUpdateUse.Update(comment);
            commentRepositoryMock.Verify(r => r.Update(It.IsAny<Comment>()));
        }

        [Fact]
        public void GetByIdCommentTest() 
        {
            var comment = new Comment("This is a message");
            var commentRepositoryMock = new Mock<ICommentReadOnlyRepository>();
            var commentGetById = new CommentGetByIdUseCase(commentRepositoryMock.Object);
            commentGetById.GetById(comment.IdComment);
            commentRepositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()));
        }
        
        [Fact]
        public void GetAllCommentTest()     
        {
            var comment = new Comment("This is a message");
            var commentRepositoryMock = new Mock<ICommentReadOnlyRepository>();
            var commentGetAllUse = new CommentGetAllUseCase(commentRepositoryMock.Object);
            commentGetAllUse.GetAll();
            commentRepositoryMock.Verify(r => r.GetAll());
        }
    }
}
