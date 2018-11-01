using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskDelegator.Models;

namespace TaskDelegator.Data
{
    public class TaskDelegatorSeeder
    {
        private readonly TaskDelegatorContext _context;

        public TaskDelegatorSeeder(TaskDelegatorContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated(); //check if db is arleady created to avoid errors

            if (!_context.Users.Any()) //seeds only if there are no records in db created
            {
                var users = new User[]
                {
                    new User { Name = "User1" },
                    new User { Name = "User2" },
                    new User { Name = "User3" }
                };

                foreach (var user in users)
                {
                    _context.Users.Add(user);
                }

                _context.SaveChanges();
            }

            if (!_context.Assignments.Any())
            {
                var assignments = new Assignment[]
                {
                    new Assignment { Name = "Assignment1", Description = "Do Something1" },
                    new Assignment { Name = "Assignment2", Description = "Do something2" },
                    new Assignment { Name = "Assignment3", Description = "Do something3" },
                    new Assignment { Name = "Assignment4", Description = "Do something4" },
                    new Assignment { Name = "Assignment5", Description = "Do something5" },
                    new Assignment { Name = "Assignment6", Description = "Do something6" },
                    new Assignment { Name = "Assignment7", Description = "Do something7" },
                    new Assignment { Name = "Assignment8", Description = "Do something8" },
                    new Assignment { Name = "Assignment9", Description = "Do something9" },
                    new Assignment { Name = "Assignment10", Description = "Do something10" },
                    new Assignment { Name = "Assignment11", Description = "Do something11" },
                    new Assignment { Name = "Assignment12", Description = "Do something12" },
                    new Assignment { Name = "Assignment13", Description = "Do something13" },
                    new Assignment { Name = "Assignment14", Description = "Do something14" },
                    new Assignment { Name = "Assignment15", Description = "Do something15" }
                };

                foreach (var assignment in assignments)
                {
                    _context.Assignments.Add(assignment);
                }

                _context.SaveChanges();
            }
        }
    }
}
