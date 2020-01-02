using Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITeste.Builder
{
    public class PostBuilder
    {
        public string Title = "title";
        public string Description = "description";

        public static PostBuilder NewPostBuilder()
        {
            return new PostBuilder();
        }
        public Post Build => new Post(Title, Description);

        public PostBuilder CheckTitle(string title)
        {
            Title = title;
            return this;
        }
        public PostBuilder CheckDescription(string description)
        {
            Description = description;
            return this;
        }
    }
}
