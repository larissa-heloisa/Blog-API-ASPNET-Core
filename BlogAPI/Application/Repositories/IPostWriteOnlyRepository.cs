using Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IPostWriteOnlyRepository
    {

        int Remove(Post post);
        int Update(Post post);
        int Add(Post post);
        

        
    }
}
