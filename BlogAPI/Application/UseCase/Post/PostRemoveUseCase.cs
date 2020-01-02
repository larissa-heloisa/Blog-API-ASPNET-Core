using Application.Repositories;

namespace Application.UseCase.Post
{
    public class PostRemoveUseCase : IPostRemoveUseCase
    {
        private readonly IPostWriteOnlyRepository postWriteOnlyRepository;

        public int Remove(Domain.Entities.Post.Post post)
        {
            return postWriteOnlyRepository.Remove(post);
        }
        public PostRemoveUseCase(IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            this.postWriteOnlyRepository = postWriteOnlyRepository;
        }
    }
}
