using Application.UseCase.Category;
using Autofac;
using BlogAPI.UseCase.Category.CreateCategory;
using Domain.Entities.Category;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace APITeste.BlogAPITest
{
    public class CategoryControllerTest
    {
        public class UserControllerTest : IClassFixture<Fixed.Fixture>
        {
            public readonly ICategoryAddUseCase categoryAddUseCase;
            public readonly ICategoryGetByIdUseCase categoryGetByIdUseCase;
            public readonly ICategoryGetAllUseCase categoryGetAllUseCase;
            public CategoryController categoryController;
            public Guid guid;

            public Category category { get; set; }

            public UserControllerTest(Fixed.Fixture fix)
            {
                this.categoryAddUseCase = fix.Container.Resolve<ICategoryAddUseCase>();
                this.categoryGetByIdUseCase = fix.Container.Resolve<ICategoryGetByIdUseCase>();
                this.categoryGetAllUseCase = fix.Container.Resolve<ICategoryGetAllUseCase>();
                this.category = new Category("categorydeTest");
                this.guid = new Guid();
                this.categoryController = new CategoryController(categoryAddUseCase, categoryGetByIdUseCase, categoryGetAllUseCase);
            }
            [Fact]
            public void GetAllCategory()
            {
                new CategoryRepository().Add(category); 
                var retorno = categoryController.GetAllCategory();

                Assert.IsType<OkObjectResult>(retorno);
            }    
          
            [Fact]
            public void GetByIdCategory()
            {
                new CategoryRepository().Add(category);
                var categoryId = category.CategoryId;
                var retorno = categoryController.GetByIdCategory(categoryId);

                Assert.IsType<OkObjectResult>(retorno);
            }

            [Fact]
            public void GetByIdCommentBad()
            {
                var retorno = categoryController.GetByIdCategory(guid);

                Assert.IsType<BadRequestResult>(retorno);
            }

            [Fact]
            public void CreateCategory()
            {
                var retorno = categoryController.CreateCategory(category.Name);

                Assert.IsType<OkObjectResult>(retorno);
            }
            [Fact]
            public void BadRequestCategory()
            {
                var retorno = categoryController.CreateCategory(null);

                Assert.IsType<BadRequestObjectResult>(retorno);
            }
        }
    }
}
