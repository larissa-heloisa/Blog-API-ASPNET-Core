using System;
using System.Collections.Generic;
using Application.UseCase.Post;
using Application.Validation;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.UseCase.Post.CreatePost
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostAddUseCase postAddUseCase;
        private readonly IPostGetByIdUseCase getByIdUseCase;
        private readonly IPostGetAllUseCase postGetAllUseCase;
        private readonly IPostUpdateUseCase postUpdateUseCase;
        private readonly IPostRemoveUseCase postRemoveUseCase;
        public Domain.Entities.Post.Post post;
        public PostRepository postRepository { get; }

        public PostController(
           IPostRemoveUseCase postRemoveUseCase,
           IPostUpdateUseCase postUpdateUseCase,
           IPostAddUseCase postAddUseCase,
           IPostGetByIdUseCase getByIdUseCase,
           IPostGetAllUseCase postGetAllUseCase)
        {
            this.postRemoveUseCase = postRemoveUseCase;
            this.postUpdateUseCase = postUpdateUseCase;
            this.postAddUseCase = postAddUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.postGetAllUseCase = postGetAllUseCase;
        }

        /// <summary>
        /// Create a post
        /// </summary>
        /// <response code="200">Post has been added. It returns a Guid.</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("CreatePost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreatePost(string title, string description)
        {
            var post = new Domain.Entities.Post.Post(title, description);
            var validationResult = new PostValidation().Validate(post);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var output = postAddUseCase.Add(post);
            return new OkObjectResult(post);
        }

        /// <summary>
        /// Get a post id
        /// </summary>
        /// <response code="200">Post has been added. It returns a Guid.</response>
        /// <response code="204">Post not found.</response>
        /// <response code="400">Bad request. Post not found.</response>
        [HttpPost]
        [Route("GetPostId")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetPostId(Guid guid)
        {
            var post = getByIdUseCase.GetById(guid);

            if (getByIdUseCase.GetById(guid) == null)
                return BadRequest();

            return new OkObjectResult(post);
        }

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <response code="200">Post has been added. It returns a Guid.</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetAllPost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllPost()
        {
            var post = postGetAllUseCase.GetAll();

            return new OkObjectResult(post);
        }


        /// <summary>
        /// Update a post
        /// </summary>
        /// <response code="200">Post has been updated.</response>
        /// <response code="400">Bad request. Post not found.</response>
        [HttpPut]
        [Route("UpdatePost")]
        [ProducesResponseType(typeof(ProblemDetails), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdatePost(Guid guid, string title, string description)
        {
            if (getByIdUseCase.GetById(guid) == null)
                return BadRequest();

            var post = new Domain.Entities.Post.Post(guid, title, description);

            postUpdateUseCase.Update(post);

            return new OkObjectResult(post);
        }


        /// <summary>
        /// Delete post
        /// </summary>
        /// <response code="200">Post has been deleted.</response>
        /// <response code="400">Bad request. Post not found</response>
        [HttpDelete]
        [Route("DeletePost")]
        [ProducesResponseType(typeof(ProblemDetails), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeletePost(Guid guid)
        {
            if (getByIdUseCase.GetById(guid) == null)
                return BadRequest();

            var post = new Domain.Entities.Post.Post(guid);

             postRemoveUseCase.Remove(post);

            return new OkObjectResult(post);
        }
    }
}
