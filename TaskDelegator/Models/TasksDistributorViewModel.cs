using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskDelegator.Models
{
    public class TasksDistributorViewModel
    {
        public IEnumerable<Assignment> Assignments { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
