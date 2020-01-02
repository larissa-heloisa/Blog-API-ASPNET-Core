using Application.Repositories;

namespace Application.UseCase.User
{
    public class UserRemoveUseCase : IUserRemoveUseCase
    {
        private readonly IUserWriteOnlyRepository usertWriteOnlyRepository;

        public int Remove(Domain.Entities.User.User user)
        {
            return usertWriteOnlyRepository.Remove(user);
        }

        public UserRemoveUseCase(IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            this.usertWriteOnlyRepository = userWriteOnlyRepository;
        }
    }

}
