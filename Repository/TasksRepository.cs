using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Repository
{
    public  class TasksRepository :ITasksRepository


    {
        private readonly TasksCategoriesRepository _repository;
        private readonly TaskManagmentContext context;
        public TasksRepository(TaskManagmentContext context, TasksCategoriesRepository repository)
        {
            _repository = repository;
            this.context = context;
        }

        public async Task<Tasks> Add(Tasks entity)
        {
            context.Set<Tasks>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Tasks> Delete(int id)
        {
            var entity = await context.Set<Tasks>().FindAsync(id);
            await _repository.Delete(null, id);
           


            if (entity == null)
            {
                return entity;
            }

            context.Set<Tasks>().Remove(entity);

            try
            {

                await context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);


            }


      

            return entity;
        }

        public async Task<Tasks> Get(int id)
        {
        


            return await context.Set<Tasks>().FindAsync(id);
        }

        public async Task<List<Tasks>> GetAll()
        {
            return await context.Set<Tasks>().ToListAsync();
        }

        public async Task<Tasks> Update(Tasks entity)
        {

         /*   Tasks task = await context.Tasks.AsNoTracking().FirstOrDefaultAsync(entry => entry.TaskId.Equals(entity.TaskId));

            if (task == null)
            {
               
                return null;

            }

            //context.Entry(entity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;*/

            context.Tasks.Update(entity);

            await context.SaveChangesAsync();
            return entity;
        }
    }
}
