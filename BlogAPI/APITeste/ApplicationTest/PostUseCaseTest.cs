using Application.Repositories;
using Application.UseCase.Post;
using Domain.Entities.Post;
using Moq;
using System;
using Xunit;

namespace APITeste.ApplicationTest
{
    public class PostUseCaseTest
    {
        [Fact]
        public void AddPost()
        {
            var newPost = new Post("The new Post", "This is a description");
            var postRepositoryMock = new Mock<IPostWriteOnlyRepository>();
            var postAddUse = new PostAddUseCase(postRepositoryMock.Object);
            postAddUse.Add(newPost);
            postRepositoryMock.Verify(r => r.Add(It.IsAny<Post>()));
        }

        [Fact]
        public void RemovePost()
        {
            var newPost = new Post("The new Post", "This is a description");
            var postRepositoryMock = new Mock<IPostWriteOnlyRepository>();
            var postRemoveUse = new PostRemoveUseCase(postRepositoryMock.Object);
            postRemoveUse.Remove(newPost);
            postRepositoryMock.Verify(r => r.Remove(It.IsAny<Post>()));
        }

        [Fact]
        public void UpdatePost()
        {
            var newPost = new Post("The new Post", "This is a description");
            var postRepositoryMock = new Mock<IPostWriteOnlyRepository>();
            var postUpdateUse = new PostUpdateUseCase(postRepositoryMock.Object);
            postUpdateUse.Update(newPost);
            postRepositoryMock.Verify(r => r.Update(It.IsAny<Post>()));
        }

        [Fact]
        public void GetByIdPostTest()
        {
            var newPost = new Post("The new Post", "This is a description");
            var postRepositoryMock = new Mock<IPostReadOnlyRepository>();
            var postGetById = new PostGetByIdUseCase(postRepositoryMock.Object);
            postGetById.GetById(newPost.IdPost);
            postRepositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()));
        }

        [Fact]
        public void GetAllPostTest()
        {
            var newPost = new Post("The new Post", "This is a description");
            var postRepositoryMock = new Mock<IPostReadOnlyRepository>();
            var postGetAll = new PostGetAllUseCase(postRepositoryMock.Object);
            postGetAll.GetAll();
            postRepositoryMock.Verify(r => r.GetAll());
        }

    }
}
