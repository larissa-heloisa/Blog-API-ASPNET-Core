using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.User
{
    public interface IUserRemoveUseCase
    {
        int Remove(Domain.Entities.User.User user);
    }
}
