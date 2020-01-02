using System;
using System.Collections.Generic;
using Application.UseCase.Comment;
using Application.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.UseCase.Comment.CreateComment
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentAddUseCase commentAddUseCase;
        private readonly ICommentUpdateUseCase commentUpdateUseCase;
        private readonly ICommentRemoveUseCase commentRemoveUseCase;
        private readonly ICommentGetAllUseCase commentGetAllUseCase;
        private readonly ICommentGetByIdUseCase commentGetByIdUseCase;

        public CommentController(
            ICommentAddUseCase commentAddUseCase, 
            ICommentUpdateUseCase commentUpdateUseCase,
            ICommentRemoveUseCase commentRemoveUseCase,
            ICommentGetAllUseCase commentGetAllUseCase,
            ICommentGetByIdUseCase commentGetByIdUseCase)
        {
            this.commentAddUseCase = commentAddUseCase;
            this.commentUpdateUseCase = commentUpdateUseCase;
            this.commentRemoveUseCase = commentRemoveUseCase;
            this.commentGetAllUseCase = commentGetAllUseCase;
            this.commentGetByIdUseCase = commentGetByIdUseCase;
        }

        /// <summary>
        /// Create a comment
        /// </summary>
        /// <response code="200">Comment has been created. It returns a Guid </response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("CreateComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateComment(string description)
        {
            var comment = new Domain.Entities.Comment.Comment(description);
            var validationResult = new CommentValidation().Validate(comment);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            commentAddUseCase.Add(comment);
            return new OkObjectResult(comment);
        }

        /// <summary>
        /// Get a comment id
        /// </summary>
        /// <response code="200">Comment has been created. It returns a Guid </response>
        /// <response code="204">Post not found.</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetByIdComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetByIdComment(Guid guid)
        {
            if (commentGetByIdUseCase.GetById(guid) == null)
                return BadRequest();

            var comment = commentGetByIdUseCase.GetById(guid);
            return new OkObjectResult(comment);
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <response code="200">Comment has been created. It returns a Guid </response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetAllComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllComment()
        {
            var comment = commentGetAllUseCase.GetAll();

            return new OkObjectResult(comment);
        }

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <response code="200">Comment has been updated. </response>
        /// <response code="400">Bad request.</response>
        [HttpPut]
        [Route("UpdateComment")]
        [ProducesResponseType(typeof(ProblemDetails), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateComment(Guid guid, string message)
        {
            if (commentGetByIdUseCase.GetById(guid) == null)
                return BadRequest();

            var comment = new Domain.Entities.Comment.Comment(guid, message);

            var validationResult = new CommentValidation().Validate(comment);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            commentUpdateUseCase.Update(comment);
            return new OkObjectResult(comment);
        }


        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <response code="200">Comment has been deleted. Return 1.</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
        [Route("DeleteComment")]
        [ProducesResponseType(typeof(ProblemDetails), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]

        public IActionResult DeleteComment(Guid guid)
        {
            if (commentGetByIdUseCase.GetById(guid) == null)
                return BadRequest();

            var comment = new Domain.Entities.Comment.Comment(guid);

            var output = commentRemoveUseCase.Remove(comment);

            return new OkObjectResult(output);
        }
    }
}