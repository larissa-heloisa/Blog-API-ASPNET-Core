using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.User
{
    public class User 
    {
        public Guid IdUser { get;  private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string login)
        {
            this.IdUser = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
            this.CreationDate  = DateTime.Now;
            this.Login = login;
        }

        public User(Guid idUser)
        {
            IdUser = idUser;
        }

        public User(Guid guid, string name, string email, string login)
        {
            this.IdUser = guid;
            this.Name = name;
            this.Email = email;
            this.Login = login;
        }
        protected User()
        {

        }
    }
}
