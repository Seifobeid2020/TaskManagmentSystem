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
        public async Task<TasksCategories> Add(TasksCategories entity)
        {
            context.Set<TasksCategories>().Add(entity);
            await context.SaveChangesAsync();
            return entity;

          
        }

       
        //NOT USED YET
        public Task<TasksCategories> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TasksCategories>> Delete(int? CategoryId,  int? TaskId)
        {
            List<TasksCategories> entity;
            if (CategoryId == null) {

             entity= context.TasksCategories.Where(s => s.TaskId == TaskId ).ToList();
            }
            else if (TaskId == null) {

              entity = context.TasksCategories.Where(s => s.CategoryId == CategoryId).ToList();

            }
            else {
             entity = context.TasksCategories.Where(s => s.TaskId == TaskId && s.CategoryId == CategoryId).ToList();
            }






          
            if (entity == null)
            {
                return entity;
            }

            context.Set<TasksCategories>().RemoveRange(entity);
           

         

            try {

                await context.SaveChangesAsync();

            } catch (Exception e) {
                Console.WriteLine(e);
               context.Database.ExecuteSqlCommand("Delete from TasksCategories Where TaskId = {0} and CategoryId ={1}", TaskId, CategoryId);
            }





            return  entity;
            }

        public Task<TasksCategories> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TasksCategories>> GetAll()
        {
            return context.TasksCategories.Include(e => e.Task).Include(e => e.Category).ToList();
             
        }

        public async Task<TasksCategories> Update(TasksCategories entity)
        {



            context.TasksCategories.Update(entity);

            await context.SaveChangesAsync();
            return entity;
          
        }

        public async  Task<TasksCategories> Update(int CategoryId, int TaskId, TasksCategories entity)
        {

          
            await Delete(CategoryId, TaskId);
            context.TasksCategories.Add(entity);
            
            await context.SaveChangesAsync();


            return entity;
        }
    }
}
