using System;
using System.Collections.Generic;
using Application.UseCase.Category;
using Application.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.UseCase.Category.CreateCategory
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAddUseCase categoryAddUseCase;
        private readonly ICategoryGetByIdUseCase categoryGetByIdUseCase;
        private readonly ICategoryGetAllUseCase categoryGetAllUseCase;

        public CategoryController(
            ICategoryAddUseCase categoryAddUseCase,
            ICategoryGetByIdUseCase categoryGetByIdUseCase,
            ICategoryGetAllUseCase categoryGetAllUseCase)
        {
            this.categoryAddUseCase = categoryAddUseCase;
            this.categoryGetByIdUseCase = categoryGetByIdUseCase;
            this.categoryGetAllUseCase = categoryGetAllUseCase;
        }

        /// <summary>
        /// Create a category
        /// </summary>
        /// <response code="200">Category has been created. It returns a Guid</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateCategory(string name)
        {
            var category = new Domain.Entities.Category.Category(name);

            var validationResult = new CategoryValidation().Validate(category);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            categoryAddUseCase.Add(category);
            return new OkObjectResult(category);
        }

        /// <summary>
        /// Get a category id
        /// </summary>
        /// <response code="200">Category has been created. It returns a Guid</response>
        /// <response code="204">Category not found.</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetByIdCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetByIdCategory(Guid categoryId)
        {
            if (categoryGetByIdUseCase.GetById(categoryId) == null)
                return BadRequest();

            var category = categoryGetByIdUseCase.GetById(categoryId);
            return new OkObjectResult(category);

        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <response code="200">Category has been created. It returns a Guid</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetAllCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllCategory()
        {
            var category = categoryGetAllUseCase.GetAll();

            return new OkObjectResult(category);
        }
    }
}