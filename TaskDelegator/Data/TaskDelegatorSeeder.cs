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
                    new Assignment { Name = "Prepare a presentation", Description = "Do Something1" },
                    new Assignment { Name = "Continous improvements", Description = "Do something2" },
                    new Assignment { Name = "Bug fixes", Description = "Do something3" },
                    new Assignment { Name = "Design the database", Description = "Do something4" },
                    new Assignment { Name = "Update .NET Framework", Description = "Do something5" },
                    new Assignment { Name = "Fix dependency problems", Description = "Do something6" },
                    new Assignment { Name = "Implement error handling", Description = "Do something7" },
                    new Assignment { Name = "Merge branch with Master", Description = "Do something8" },
                    new Assignment { Name = "SharePoint improvements", Description = "Do something9" },
                    new Assignment { Name = "Create indexes on db", Description = "Do something10" },
                    new Assignment { Name = "Prepare backend for a new app", Description = "Do something11" },
                    new Assignment { Name = "Configure services", Description = "Do something12" },
                    new Assignment { Name = "Deploy an app to Azure", Description = "Do something13" },
                    new Assignment { Name = "Prepare Unit Tests", Description = "Do something14" },
                    new Assignment { Name = "Update documentation", Description = "Do something15" }
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
