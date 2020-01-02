using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.User
{
    public interface IUserGetAllUseCase
    {
        List<Domain.Entities.User.User> GetAll();
    }
}
