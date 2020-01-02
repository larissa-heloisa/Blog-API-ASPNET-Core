using Application.Repositories;

namespace Application.UseCase.User
{
    public class UserUpdateUseCase : IUserUpdateUseCase
    {
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;

        public int Update(Domain.Entities.User.User user)
        {
            return userWriteOnlyRepository.Update(user);
        }

        public UserUpdateUseCase(IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            this.userWriteOnlyRepository = userWriteOnlyRepository;
        }
    }
}
