using Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITeste.Builder
{
    public class CategoryBuilder
    {
        private string Name = "name";

        public static CategoryBuilder NewCategoryBuilder()
        {
            return new CategoryBuilder();
        }

        public Category Build => new Category(Name);

        public CategoryBuilder CheckName(string name)
        {
            Name = name;
            return this;
        }
    }
}
