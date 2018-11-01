using Microsoft.EntityFrameworkCore;
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

        public TaskDelegatorRepository(TaskDelegatorContext context)
        {
            _context = context;
        }

        public IEnumerable<Assignment> GetAllAssingments()
        {
            try
            {
                return _context.Assignments.Include(a => a.User).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _context.Users.Include(u => u.Assignments).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Assignment GetAssignmentById(int id)
        {
            try
            {
                return _context.Assignments.Include(a => a.User).Where(a => a.ID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _context.Users.Include(u => u.Assignments).Where(u => u.ID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
