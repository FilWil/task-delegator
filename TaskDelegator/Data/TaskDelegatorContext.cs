using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskDelegator.Models;

namespace TaskDelegator.Data
{
    public class TaskDelegatorContext : DbContext
    {
        public TaskDelegatorContext(DbContextOptions<TaskDelegatorContext> options) : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
