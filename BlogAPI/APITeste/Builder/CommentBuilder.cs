using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Comment;

namespace APITeste.Builder
{
    public class CommentBuilder
    {
        private string Message = "comment test";

        public static CommentBuilder NewComment()
        {
            return new CommentBuilder();
        }

        public Comment Build => new Comment(Message);

        public CommentBuilder CheckComment(string message)
        {
            Message = message;
            return this;
        }
    }

    

   
}
