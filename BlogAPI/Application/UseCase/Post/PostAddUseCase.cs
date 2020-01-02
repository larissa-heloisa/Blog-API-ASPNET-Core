using Application.Repositories;


namespace Application.UseCase.Post
{
    public class PostAddUseCase : IPostAddUseCase
    {
        private readonly IPostWriteOnlyRepository postWriteOnlyRepository;

        public int Add(Domain.Entities.Post.Post post)
        {
            return postWriteOnlyRepository.Add(post);
        }
        public PostAddUseCase(IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            this.postWriteOnlyRepository = postWriteOnlyRepository;
        }
    }
}
