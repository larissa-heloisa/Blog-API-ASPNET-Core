using Application.Repositories;
using Application.UseCase.User;
using Domain.Entities.User;
using Moq;
using System;
using Xunit;

namespace APITeste.ApplicationTest
{
    public class UserUseCaseTest
    {
        [Fact]
        public void AddUser()
        {
            var newUser = new User("Usuario1", "usuario@gmail.com", "usuario1");
            var userRepositoryMock = new Mock<IUserWriteOnlyRepository>();
            var UserAddUse = new UserAddUseCase(userRepositoryMock.Object);
            UserAddUse.Add(newUser);
            userRepositoryMock.Verify(r => r.Add(It.IsAny<User>()));
        }

        [Fact]
        public void RemoveUser()
        {
            var newUser = new User("Usuario1", "usuario@gmail.com", "usuario1");
            var userRepositoryMock = new Mock<IUserWriteOnlyRepository>();
            var userRemoveUse = new UserRemoveUseCase(userRepositoryMock.Object);
            userRemoveUse.Remove(newUser);
            userRepositoryMock.Verify(r => r.Remove(It.IsAny<User>()));
        }

        [Fact]
        public void UpdateUser()
        {
            var newUser = new User("Usuario1", "usuario@gmail.com", "usuario1");
            var userRepositoryMock = new Mock<IUserWriteOnlyRepository>();
            var userUpdateUse = new UserUpdateUseCase(userRepositoryMock.Object);
            userUpdateUse.Update(newUser);
            userRepositoryMock.Verify(r => r.Update(It.IsAny<User>()));
        }

        [Fact]
        public void GetByIdUserTest()
        {
            var newUser = new User("Usuario1", "usuario@gmail.com", "usuario1");
            var userRepositoryMock = new Mock<IUserReadOnlyRepository>();
            var userGetById = new UserGetByIdUseCase(userRepositoryMock.Object);
            userGetById.GetById(newUser.IdUser);
            userRepositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()));
        }

        [Fact]
        public void GetAllCommentTest() 
        {
            var newUser = new User("Usuario1", "usuario@gmail.com", "usuario1");
            var userRepositoryMock = new Mock<IUserReadOnlyRepository>();
            var userGetAllUse = new UserGetAllUseCase(userRepositoryMock.Object);
            userGetAllUse.GetAll();
            userRepositoryMock.Verify(r => r.GetAll());
        }
    }
}
