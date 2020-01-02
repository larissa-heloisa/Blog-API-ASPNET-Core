using Application.Repositories;
using Application.UseCase.Category;
using Domain.Entities.Category;
using Moq;
using System;
using Xunit;

namespace APITeste.ApplicationTest
{
    public class CategoryUseCaseTest
    {
        public CategoryAddUseCase categoryAddUse { get; set; }
        public CategoryGetByIdUseCase categoryGetByIdUse { get; set; }
        public CategoryGetAllUseCase categoryGetAllUse { get; set; }
        
        [Fact]
        public void AddCategory()
        {
            var category = new Category("Jornal");
            var categoryRepositoryMock = new Mock<ICategoryWriteOnlyRepository>();
            var categoryAddUse = new CategoryAddUseCase(categoryRepositoryMock.Object);
            categoryAddUse.Add(category);
            categoryRepositoryMock.Verify(r => r.Add(It.IsAny<Category>()));
        }

        [Fact]
        public void GetByIdCategoryTest()
        {
            var category = new Category("Jornal");
            var categoryRepositoryMock = new Mock<ICategoryReadOnlyRepository>();
            var categoryGetById = new CategoryGetByIdUseCase(categoryRepositoryMock.Object);
            categoryGetById.GetById(category.CategoryId);
            categoryRepositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()));
        }

        [Fact]
        public void GetAllCategoryTest()  
        {
            var category = new Category("Jornal");
            var categoryRepositoryMock = new Mock<ICategoryReadOnlyRepository>();
            var categoryGetAll = new CategoryGetAllUseCase(categoryRepositoryMock.Object);
            categoryGetAll.GetAll();
            categoryRepositoryMock.Verify(r => r.GetAll());
        }
    }
}
