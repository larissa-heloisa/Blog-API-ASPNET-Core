using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Category
{
     public class Category 
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            this.CategoryId = Guid.NewGuid();
            this.Name = name;
        }
        protected Category()
        {

        }
    }
}
