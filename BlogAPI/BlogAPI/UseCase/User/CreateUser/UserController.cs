using System;
using Application.UseCase.User;
using Application.Validation;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.UseCase.User.CreateUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAddUseCase userAddUseCase;
        private readonly IUserUpdateUseCase userUpdateUseCase;
        private readonly IUserRemoveUseCase userRemoveUseCase;
        private readonly IUserGetByIdUseCase userGetByIdUseCase;
        private readonly IUserGetAllUseCase userGetAllUseCase;

        public UserController(
            IUserRemoveUseCase userRemoveUseCase,
            IUserUpdateUseCase userUpdateUseCase,
            IUserAddUseCase userAddUseCase,
            IUserGetByIdUseCase userGetByIdUseCase,
            IUserGetAllUseCase userGetAllUseCase)
        {
            this.userRemoveUseCase = userRemoveUseCase;
            this.userUpdateUseCase = userUpdateUseCase;
            this.userAddUseCase = userAddUseCase;
            this.userGetByIdUseCase = userGetByIdUseCase;
            this.userGetAllUseCase = userGetAllUseCase;
        }

        /// <summary>
        /// Create an user
        /// </summary>
        /// <response code="200">Post has been added.  It returns a Guid.</response>
        /// <response code="400">Bad request.</response>
        /// <returns>The post id.</returns>
        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult CreateUser(string name, string email, string login)
        {
            var user = new Domain.Entities.User.User(name, email, login);
            var validationResult = new UserValidation().Validate(user);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var output = userAddUseCase.Add(user);
            return new OkObjectResult(user);

        }

        /// <summary>
        /// Get an user id
        /// </summary>
        /// <response code="200">Post has been updated.</response>
        /// <response code="400">Bad request.</response>
        /// <returns>The post id.</returns>
        [HttpPost]
        [Route("GetByIdUser")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetByIdUser(Guid idUser)
        {
            if (userGetByIdUseCase.GetById(idUser) == null)
                return BadRequest();
            var user = userGetByIdUseCase.GetById(idUser);
            return new OkObjectResult(user);

        }

        /// <summary>
        /// Get all users information
        /// </summary>
        /// <response code="200">Post has been updated.</response>
        /// <response code="400">Bad request.</response>
        /// <returns>The post id.</returns>
        [HttpPost]
        [Route("GetAllUser")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllUser()
        {
            var user = userGetAllUseCase.GetAll();

            return new OkObjectResult(user);

        }

        /// <summary>
        /// Update an user
        /// </summary>
        /// <response code="200">Post has been updated.</response>
        /// <response code="400">Bad request.</response>
        /// <returns>The post id.</returns>
        [HttpPut]
        [Route("UpdateUser")]
        [ProducesResponseType(typeof(ProblemDetails), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateUser(Guid guid, string name, string email, string login)
        {
            if (userGetByIdUseCase.GetById(guid) == null)
                return BadRequest();

            var user = new Domain.Entities.User.User(guid, name, email, login);
            var validationResult = new UserValidation().Validate(user);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            userUpdateUseCase.Update(user);

            return new OkObjectResult(user);
        }


        /// <summary>
        /// Delete an user
        /// </summary>
        /// <response code="200">Post has been deleted.</response>
        /// <response code="400">Bad request.</response>
        /// <returns>The object.</returns>
        [HttpDelete]
        [Route("DeleteUser")]
        [ProducesResponseType(typeof(ProblemDetails), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteUser(Guid guid)
        {
            if (userGetByIdUseCase.GetById(guid) == null)
                return BadRequest();

            var user = new Domain.Entities.User.User(guid);

            userRemoveUseCase.Remove(user);

            return new OkObjectResult(user);
        }
    }
}