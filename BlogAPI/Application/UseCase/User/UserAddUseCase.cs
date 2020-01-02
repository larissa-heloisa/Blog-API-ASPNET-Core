using Application.Repositories;

namespace Application.UseCase.User
{
    public class UserAddUseCase : IUserAddUseCase
    {
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;

        public int Add(Domain.Entities.User.User user)
        {
            return userWriteOnlyRepository.Add(user);
        }
        public UserAddUseCase(IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            this.userWriteOnlyRepository = userWriteOnlyRepository;
        }
    }
}
