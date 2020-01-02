using System;
using Application.Repositories;

namespace Application.UseCase.User
{
    public class UserGetByIdUseCase : IUserGetByIdUseCase
    {
        private readonly IUserReadOnlyRepository userReadOnlyRepository;

        public Domain.Entities.User.User GetById(Guid idUser)
        {
            return userReadOnlyRepository.GetById(idUser);
        }

        public UserGetByIdUseCase(IUserReadOnlyRepository userReadOnlyRepository)
        {
            this.userReadOnlyRepository = userReadOnlyRepository;
        }
    }
}
