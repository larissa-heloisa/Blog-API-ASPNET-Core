using APITeste.Builder;
using Domain.Entities.Post;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace APITeste.DomainTest
{
    public class PostTest
    {

        [Fact]
        public void CreatePost()
        {
            var expectedPost = new
            {
                Title = "title",
                Description = "description",
            };
            var post = new Post(expectedPost.Title, expectedPost.Description);
            expectedPost.ToExpectedObject().ShouldMatch(post);
        }

        [Fact]
        public void NotNullTitleTest()
        {
            var builder = new Builder.PostBuilder();

            var postTest = builder
            .CheckTitle("Title");

            Assert.NotNull(postTest);
        }

        [Fact]
        public void NotNullDescriptionTest()
        {
            var builder = new PostBuilder();

            var postTest = builder
            .CheckDescription("Description");

            Assert.NotNull(postTest);
        }
    }
}
