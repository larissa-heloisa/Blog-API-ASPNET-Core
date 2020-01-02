using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;
using ExpectedObjects;

namespace APITeste.DomainTest
{
    public class UserTest
    {
        [Fact(DisplayName = "Create User")]
        public void CreateUser()
        {
            var expectedUser = new
            {
                Name = "Joao",
                Email = "joao@gmail.com",
                Login = "joao1",
            };

            var user = new User(expectedUser.Name, expectedUser.Email, expectedUser.Login);
            expectedUser.ToExpectedObject().ShouldMatch(user);
        }

        [Fact(DisplayName = "Notnull User")]
        public void NotNullUser()
        {
            var builder = new Builder.UserBuilder();

            var userTest = builder
                .checkName("Joao")
                .checkEmail("joao@gmail.com")
                .checkLogin("joao1");
                
            Assert.NotNull(userTest);
        }
    }
}
