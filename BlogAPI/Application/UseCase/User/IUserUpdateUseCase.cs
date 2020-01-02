using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.User
{
    public interface IUserUpdateUseCase
    {
        int Update(Domain.Entities.User.User user);
    }
}
