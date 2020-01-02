using Application.UseCase.Post;
using Autofac;
using BlogAPI.UseCase.Post.CreatePost;
using Domain.Entities.Post;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace APITeste.BlogAPITest
{
    public class PostControllerTest : IClassFixture<Fixed.Fixture>
    {
        public readonly IPostAddUseCase postAddUseCase;
        public readonly IPostUpdateUseCase postUpdateUseCase;
        public readonly IPostRemoveUseCase postRemoveUseCase;
        private readonly IPostGetByIdUseCase getByIdUseCase;
        private readonly IPostGetAllUseCase postGetAllUseCase;
        public PostController postController;
        public Post postOne { get; set; }
        public Post postTwo { get; set; }

        public PostControllerTest(Fixed.Fixture fix)
        {
            this.postAddUseCase = fix.Container.Resolve<IPostAddUseCase>();
            this.postUpdateUseCase = fix.Container.Resolve<IPostUpdateUseCase>();
            this.postRemoveUseCase = fix.Container.Resolve<IPostRemoveUseCase>();
            this.getByIdUseCase = fix.Container.Resolve<IPostGetByIdUseCase>();
            this.postGetAllUseCase = fix.Container.Resolve<IPostGetAllUseCase>();
            this.postOne = new Post("PostdeTestTitleOne", "PostdeTesteDescriptionOne");
            this.postTwo = new Post("PostdeTestTitleTwo", "PostdeTesteDescriptionTwo");
            this.postController = new PostController(postRemoveUseCase, postUpdateUseCase, postAddUseCase, getByIdUseCase, postGetAllUseCase);
        }

        [Fact]
        public void CreatePost()
        {
            var retorno = postController.CreatePost(postOne.Title, postOne.Description);

            Assert.IsType<OkObjectResult>(retorno);
        }
        
        [Fact]
        public void GetByIdPost()
        {
            new PostRepository().Add(postOne);

            var retorno = postController.GetPostId(postOne.IdPost);

            Assert.IsType<OkObjectResult>(retorno);
        }        
        [Fact]
        public void GetAllPost()
        {
            new PostRepository().Add(postOne);
            
            var retorno = postController.GetAllPost();

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void UpdatePost()
        {
            new PostRepository().Add(postOne);
            
            var retorno = postController.UpdatePost(postOne.IdPost, postTwo.Title, postTwo.Description);

            Assert.IsType<OkObjectResult>(retorno);
        }
        [Fact]
        public void DeletePost()
        {
            new PostRepository().Add(postOne);
            
            var retorno = postController.DeletePost(postOne.IdPost);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void BadRequestPost()
        {
            var retorno = postController.CreatePost(null, postOne.Description);

            Assert.IsType<BadRequestObjectResult>(retorno);
        }
        [Fact]
        public void UpdatePostBad()
        {
            var retorno = postController.UpdatePost(postOne.IdPost, postTwo.Title, postTwo.Description);

            Assert.IsType<BadRequestResult>(retorno);
        } 
        [Fact]
        public void DeletePostBad()
        {
            var retorno = postController.DeletePost(postOne.IdPost);

            Assert.IsType<BadRequestResult>(retorno);
        }
        
        [Fact]
        public void GetByIdPostBad()
        {
            var retorno = postController.GetPostId(postOne.IdPost);

            Assert.IsType<BadRequestResult>(retorno);
        }
    }
}
