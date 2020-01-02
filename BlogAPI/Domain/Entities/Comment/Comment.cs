using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Comment
{
    public class Comment
    {
        public Guid IdComment { get; private set; }
        public string Message { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Comment(string message)
        {
            this.IdComment = Guid.NewGuid();
            this.Message = message;
            this.CreationDate = DateTime.Now;
        }

        public Comment(Guid guid, string message)
        {
            this.IdComment = guid;
            this.Message = message;
        }
        public Comment(Guid guid)
        {
            this.IdComment = guid;
        }
        protected Comment()
        {

        }
    }
}
