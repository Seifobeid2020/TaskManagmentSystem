using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public class TasksCategoriesRepository : ITasksCategoriesRepository
    {

        private readonly TaskManagmentContext context;
        public TasksCategoriesRepository(TaskManagmentContext context)
        {
            this.context = context;
        }
        public Task<TasksCategories> Add(TasksCategories entity)
        {
            throw new NotImplementedException();
        }

        public Task<TasksCategories> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TasksCategories> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TasksCategories>> GetAll()
        {
            return context.TasksCategories.Include(e => e.Task).Include(e => e.Category).ToList();
             
        }

        public Task<TasksCategories> Update(TasksCategories entity)
        {
            throw new NotImplementedException();
        }
    }
}
