using Crud.Web.Api.Migrations;
using Crud.Web.Api.Models;
using Crud.Web.Api.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Crud.Web.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository) {
            _repository = repository;
        }


        [HttpGet]
        [Route("get/user/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            return NotFound(new { Message = "User not found" });
            return Ok(user);
        }


        [HttpPost]
        [Route("upsert/user")]
        public IActionResult UpsertUser([FromBody] Users value)
        {
            var createdUser = _repository.AddUser(value);
            return Ok( new { userId = createdUser.Id });
        }

    }
}

