using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDelegator.Data;
using TaskDelegator.Models;

namespace TaskDelegator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly ITaskDelegatorRepository _repository;

        public AssignmentsController(ITaskDelegatorRepository repository)
        {
            _repository = repository;
        }

        //Returns every tasks that is not assigned to particular user
        [HttpGet]
        public IEnumerable<Assignment> GetNotDelegatedTasks()
        {
            var response = _repository.GetAllAssingments().Where(a => a.User == null);
            return response;
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        //[Route("api/[controller]/{id}")]
        public  ActionResult GetAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = _repository.GetAssignmentById(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        [HttpPut("{id}")]
        public IActionResult PutAssignment([FromRoute] int id, [FromQuery]int _id)
        {
            var assigngment = _repository.GetAssignmentById(id);
            if (assigngment == null)
                return NotFound();
            else
            {
                var user = _repository.GetUserById(_id);

                assigngment.User = user;

                _repository.SaveAll();
            }    

            return Ok();
        }
    }
}