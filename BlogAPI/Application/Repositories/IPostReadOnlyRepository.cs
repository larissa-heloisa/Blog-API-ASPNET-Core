using Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IPostReadOnlyRepository
    {
        List<Post> GetAll();

        Post GetById(Guid id);
    }
}
