using Application.UseCase.User;
using Autofac;
using BlogAPI.UseCase.User.CreateUser;
using Domain.Entities.User;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace APITeste.BlogAPITest
{
    public class UserControllerTest : IClassFixture<Fixed.Fixture>
    {

        public readonly IUserAddUseCase userAddUseCase;
        public readonly IUserUpdateUseCase userUpdateUseCase;
        public readonly IUserRemoveUseCase userRemoveUseCase;
        private readonly IUserGetByIdUseCase userGetByIdUseCase;
        private readonly IUserGetAllUseCase userGetAllUseCase;
        public UserController userController;
        public User userOne { get; set; }
        public User userTwo { get; set; }
        public UserControllerTest(Fixed.Fixture fix)
        {
            this.userAddUseCase = fix.Container.Resolve<IUserAddUseCase>();
            this.userUpdateUseCase = fix.Container.Resolve<IUserUpdateUseCase>();
            this.userRemoveUseCase = fix.Container.Resolve<IUserRemoveUseCase>();
            this.userGetByIdUseCase = fix.Container.Resolve<IUserGetByIdUseCase>();
            this.userGetAllUseCase = fix.Container.Resolve<IUserGetAllUseCase>();
            this.userOne = new User("userTestNameOne", "userTest@EmailOne.com", "userTestLoginOne");
            this.userTwo = new User("userTestNameTwo", "userTest@EmailTwo.com", "userTestLoginTwo");
            this.userController = new UserController(userRemoveUseCase, userUpdateUseCase, userAddUseCase, userGetByIdUseCase, userGetAllUseCase);

        }
        [Fact]
        public void GetByIdUser()
        {
            new UserRepository().Add(userOne);

            var retorno = userController.GetByIdUser(userOne.IdUser);

            Assert.IsType<OkObjectResult>(retorno);
        }
        [Fact]
        public void GetAllUser()
        {
            new UserRepository().Add(userOne);
            var retorno = userController.GetAllUser();

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void CreateUser()
        {
            var retorno = userController.CreateUser(userOne.Name, userOne.Email, userOne.Login);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void UpdateUser()
        {

            new UserRepository().Add(userOne);
            var retorno = userController.UpdateUser(userOne.IdUser, userTwo.Name, userTwo.Email, userTwo.Login);


            Assert.IsType<OkObjectResult>(retorno);
        }
        [Fact]
        public void DeleteUser()
        {

            new UserRepository().Add(userOne);
            var retorno = userController.DeleteUser(userOne.IdUser);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void BadRequestUser()
        {
            var retorno = userController.CreateUser(null, userOne.Email, userOne.Login);

            Assert.IsType<BadRequestObjectResult>(retorno);
        }

        [Fact]
        public void UpdateUserBadRequest()
        {
            var retorno = userController.UpdateUser(userOne.IdUser, userTwo.Name, "teste", userTwo.Login);

            Assert.IsType<BadRequestResult>(retorno);
        }

        [Fact]
        public void DeleteUserBadRequest()
        {
            var retorno = userController.DeleteUser(userOne.IdUser);

            Assert.IsType<BadRequestResult>(retorno);
        }

        [Fact]
        public void GetByIdUserBadRequest()
        {
            var retorno = userController.GetByIdUser(userOne.IdUser);

            Assert.IsType<BadRequestResult>(retorno);
        }
    }
}
