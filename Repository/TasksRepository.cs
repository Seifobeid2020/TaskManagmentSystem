using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Data;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public class TasksRepository : AbTasksRepository<Tasks, TaskManagmentSystemContext>
    {
        public TasksRepository(TaskManagmentSystemContext context) : base(context)
        {

        }
    }
}
