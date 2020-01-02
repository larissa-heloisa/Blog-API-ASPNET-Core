using APITeste.Builder;
using Domain.Entities.Category;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace APITeste.DomainTest
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory()
        {
            var expectedCategory = new
            {
                Name = "name",
            };
            var category = new Category(expectedCategory.Name);
            expectedCategory.ToExpectedObject().ShouldMatch(category);
        }

        [Fact]
        public void NotNullNameTest()
        {
            var builder = new CategoryBuilder();

            var CategoryTest = builder
            .CheckName("name");

            Assert.NotNull(CategoryTest);
        }
    }
}
