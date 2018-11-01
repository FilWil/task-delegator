using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDelegator.Data;
using TaskDelegator.Models;

namespace TaskDelegator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITaskDelegatorRepository _repository;

        public UsersController(ITaskDelegatorRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var users = _repository.GetAllUsers();

            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _repository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}