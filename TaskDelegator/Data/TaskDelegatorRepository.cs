using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskDelegator.Models;

namespace TaskDelegator.Data
{
    public class TaskDelegatorRepository : ITaskDelegatorRepository
    {
        private readonly TaskDelegatorContext _context;
        private readonly ILogger<TaskDelegatorRepository> _logger;

        public TaskDelegatorRepository(TaskDelegatorContext context, ILogger<TaskDelegatorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Assignment> GetAllAssingments()
        {
            try
            {
                return _context.Assignments.Include(a => a.User).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetAllAssingments {ex}");
                return null;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _context.Users.Include(u => u.Assignments).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetAllUsers {ex}");
                return null;
            }
        }

        public Assignment GetAssignmentById(int id)
        {
            try
            {
                return _context.Assignments.Include(a => a.User).Where(a => a.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetAssignmentById {ex}");
                return null;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _context.Users.Include(u => u.Assignments).Where(u => u.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetUserById {ex}");
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
