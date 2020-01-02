using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.User
{
    public interface IUserAddUseCase
    {
        int Add(Domain.Entities.User.User user);
    }
}
