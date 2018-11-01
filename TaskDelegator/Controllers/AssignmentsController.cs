using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDelegator.Data;
using TaskDelegator.Models;

namespace TaskDelegator.Controllers
{
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly TaskDelegatorContext _context;

        public AssignmentsController(TaskDelegatorContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        //Returns every tasks that is not assigned to particular user
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Assignment> GetNotDelegatedTasks()
        {
            var response = _context.Assignments.Where(t => t.User == null);
            return response;
        }

        // GET: api/Tasks/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }
    }
}