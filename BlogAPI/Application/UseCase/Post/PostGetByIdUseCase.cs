using System;
using System.Collections.Generic;
using System.Text;
using Application.Repositories;
using Domain.Entities.Post;

namespace Application.UseCase.Post
{
    public class PostGetByIdUseCase : IPostGetByIdUseCase
    {
        private readonly IPostReadOnlyRepository postReadOnlyRepository;

        public Domain.Entities.Post.Post GetById(Guid id)
        {
            return postReadOnlyRepository.GetById(id);
        }

        public PostGetByIdUseCase(IPostReadOnlyRepository postReadOnlyRepository)
        {
            this.postReadOnlyRepository = postReadOnlyRepository;
        }
    }
}
