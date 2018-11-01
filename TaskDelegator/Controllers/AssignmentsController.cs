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
        private readonly TaskDelegatorContext _context;

        public AssignmentsController(TaskDelegatorContext context)
        {
            _context = context;
        }

        //Returns every tasks that is not assigned to particular user
        [HttpGet]
        public IEnumerable<Assignment> GetNotDelegatedTasks()
        {
            var response = _context.Assignments.Include(a => a.User).Where(t => t.User == null);
            return response;
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        //[Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignments.Include(a => a.User).Where(a => a.ID == id).FirstOrDefaultAsync();

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAssignment([FromRoute] int id, [FromQuery]int _id)
        {
            var assigment = _context.Assignments.Include(a => a.User).Where(a => a.ID == id).FirstOrDefault();
            if (assigment == null)
                return NotFound();
            else
            {
                var user = _context.Users.Include(u => u.Assignments).Where(u => u.ID == _id).FirstOrDefault();
      
                assigment.User = user;

               _context.SaveChanges();
            }    

            return Ok();
        }
    }
}