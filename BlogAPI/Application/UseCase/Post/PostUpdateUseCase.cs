using Application.Repositories;

namespace Application.UseCase.Post
{
    public class PostUpdateUseCase : IPostUpdateUseCase
    {
        private readonly IPostWriteOnlyRepository postWriteOnlyRepository;

        public int Update(Domain.Entities.Post.Post post)
        {
            return postWriteOnlyRepository.Update(post);
        }
        public PostUpdateUseCase(IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            this.postWriteOnlyRepository = postWriteOnlyRepository;
        }
    }
}
