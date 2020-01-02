using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IUserReadOnlyRepository
    {
        List<User> GetAll();

        User GetById(Guid idUser);
    }
}
