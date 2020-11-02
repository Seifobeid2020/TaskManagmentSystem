using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Data
{
    public class TaskManagmentSystemContext : DbContext
    {
        public TaskManagmentSystemContext (DbContextOptions<TaskManagmentSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
