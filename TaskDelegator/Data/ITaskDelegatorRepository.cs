using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskDelegator.Models;

namespace TaskDelegator.Data
{
    public interface ITaskDelegatorRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<Assignment> GetAllAssingments();
        User GetUserById(int id);
        Assignment GetAssignmentById(int id);
        bool SaveAll();
    }
}
