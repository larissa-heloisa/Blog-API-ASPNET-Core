using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Post
{
    public class Post
    {
        public Guid IdPost { get;  private set; }
        public DateTime CreationDate { get; private set; }
        public string Title { get;  private set; }
        public string Description { get;  private set; }


        public Post(string title,string description)
        {
            this.IdPost = Guid.NewGuid();
            this.CreationDate = DateTime.Now;
            this.Title = title;
            this.Description = description;
        }

        public Post(Guid idPost)
        {
            IdPost = idPost;
        }
        public Post(Guid guid, string title, string description)
        {
            this.IdPost = guid;
            this.Title = title;
            this.Description = description;
        }

        protected Post()
        {

        }

        
    }
}