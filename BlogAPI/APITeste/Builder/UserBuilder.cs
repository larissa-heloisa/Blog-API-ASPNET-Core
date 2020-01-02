using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITeste.Builder
{
    public class UserBuilder
    {

        private string Name = "Joao";
        private string Email = "joao@gmail.com";
        private string Login = "joao1";
        public static UserBuilder NewUser()
        {
            return new UserBuilder();
        }

        public User Build => new User(Name, Email, Login);

        public UserBuilder checkName(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder checkEmail(string email)
        {
            Email = email;
            return this;
        }
        public UserBuilder checkLogin(string login)
        {
            Login = login;
            return this;
        }

        
    }
}
