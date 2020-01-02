using Domain.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ExpectedObjects;
using System.Collections;


namespace APITeste.DomainTest
{
    public class CommentTest
    {
        [Fact(DisplayName = "Create Comment")]
        public void CreateComment()
        {
            var createComment = new
            {
                Message = "Comment Test"
            };

            var comment = new Comment(createComment.Message);
            createComment.ToExpectedObject().ShouldMatch(comment);

        }
        [Fact(DisplayName = "Notnull Comment")]
        public void NotNullCommentComment()
        {
            var builder = new Builder.CommentBuilder();

            var commentTest = builder
                .CheckComment("Comment test");
            
            Assert.NotNull(commentTest);
        }
    }
}
