using System.Collections.Generic;
using Application.Repositories;

namespace Application.UseCase.User
{
    public class UserGetAllUseCase : IUserGetAllUseCase
    {
        private readonly IUserReadOnlyRepository userReadOnlyRepository;

        public List<Domain.Entities.User.User> GetAll()
        {
            return userReadOnlyRepository.GetAll();
        }

        public UserGetAllUseCase(IUserReadOnlyRepository userReadOnlyRepository)
        {
            this.userReadOnlyRepository = userReadOnlyRepository;
        }
    }
}
