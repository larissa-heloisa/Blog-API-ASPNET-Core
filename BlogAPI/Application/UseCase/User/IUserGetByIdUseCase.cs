using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.User
{
    public interface IUserGetByIdUseCase
    {
        Domain.Entities.User.User GetById(Guid idUser);
    }
}
