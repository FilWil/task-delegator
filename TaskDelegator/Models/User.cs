using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskDelegator.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
