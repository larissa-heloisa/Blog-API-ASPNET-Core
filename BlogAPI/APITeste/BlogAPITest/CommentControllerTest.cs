using Application.UseCase.Comment;
using Autofac;
using BlogAPI.UseCase.Comment.CreateComment;
using Domain.Entities.Comment;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace APITeste.BlogAPITest
{
    public class CommentControllerTest : IClassFixture<Fixed.Fixture>
    {
        public readonly ICommentAddUseCase commentAddUseCase;
        public readonly ICommentUpdateUseCase commentUpdateUseCase;
        public readonly ICommentRemoveUseCase commentRemoveUseCase;
        public readonly ICommentGetAllUseCase commentGetAllUseCase;
        public readonly ICommentGetByIdUseCase commentGetByIdUseCase;
        public CommentController commentController;
        public Comment commentOne { get; set; }
        public Comment commentTwo { get; set; }

        public CommentControllerTest(Fixed.Fixture fix)
        {
            this.commentAddUseCase = fix.Container.Resolve<ICommentAddUseCase>();
            this.commentUpdateUseCase = fix.Container.Resolve<ICommentUpdateUseCase>();
            this.commentRemoveUseCase = fix.Container.Resolve<ICommentRemoveUseCase>();
            this.commentGetAllUseCase = fix.Container.Resolve<ICommentGetAllUseCase>();
            this.commentGetByIdUseCase = fix.Container.Resolve<ICommentGetByIdUseCase>();
            this.commentOne = new Comment("CommentTestOne");
            this.commentTwo = new Comment("CommentTestTwo");
            this.commentController = new CommentController(commentAddUseCase, commentUpdateUseCase, commentRemoveUseCase, commentGetAllUseCase, commentGetByIdUseCase);
        }

        [Fact]
        public void GetAllComment()
        {
            new CommentRepository().Add(commentOne);
            new CommentRepository().Add(commentTwo);
            var retorno = commentController.GetAllComment();

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void GetByIdComment()
        {
            new CommentRepository().Add(commentOne);
            new CommentRepository().Add(commentTwo);
            var commentOneId = commentOne.IdComment;
            var retorno = commentController.GetByIdComment(commentOneId);

            Assert.IsType<OkObjectResult>(retorno);
        }


        [Fact]
        public void GetByIdCommentBad()
        {
            var retorno = commentController.GetByIdComment(commentOne.IdComment);

            Assert.IsType<BadRequestResult>(retorno);
        }

        [Fact]
        public void CreateComment()
        {
            var retorno = commentController.CreateComment(commentOne.Message);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void CreateCommentBad()
        {
            var retorno = commentController.CreateComment(commentOne.Message);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void UpdateComment()
        {
            new CommentRepository().Add(commentOne);
            var retorno = commentController.UpdateComment(commentOne.IdComment, commentTwo.Message);
            
            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void UpdateCommentBad()
        {
            var retorno = commentController.DeleteComment(commentOne.IdComment);

            Assert.IsType<BadRequestResult>(retorno);
        }

        [Fact]
        public void DeleteComment()
        {
            new CommentRepository().Add(commentOne);
            var retorno = commentController.DeleteComment(commentOne.IdComment);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void DeleteCommentBad()
        {
            var retorno = commentController.DeleteComment(commentOne.IdComment);

            Assert.IsType<BadRequestResult>(retorno);
        }

        [Fact]
        public void BadRequestComment()
        {
            var retorno = commentController.CreateComment(null);

            Assert.IsType<BadRequestObjectResult>(retorno);
        }
    }
}
