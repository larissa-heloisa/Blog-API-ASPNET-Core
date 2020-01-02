using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IUserWriteOnlyRepository
    {
        int Add(User user);
        int Remove(User user);
        int Update(User user);
       
    }
}
