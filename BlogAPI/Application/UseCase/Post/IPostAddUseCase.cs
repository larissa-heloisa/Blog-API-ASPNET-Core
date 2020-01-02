using Domain.Entities.Post;

namespace Application.UseCase.Post
{
    public interface IPostAddUseCase
    {
        int Add(Domain.Entities.Post.Post post);
    }
}