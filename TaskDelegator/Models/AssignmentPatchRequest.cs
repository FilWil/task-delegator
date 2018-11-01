using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskDelegator.Models
{
    public class AssignmentPatchRequest
    {
        public int ID { get; set; }
        public User User { get; set; }
    }
}
