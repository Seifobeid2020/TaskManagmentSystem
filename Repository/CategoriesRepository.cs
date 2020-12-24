using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly TasksCategoriesRepository _repository;
        private readonly TaskManagmentContext context;
        public CategoriesRepository(TaskManagmentContext context, TasksCategoriesRepository repository)
        {
            _repository = repository;
            this.context = context;
        }

        public async Task<Categories> Add(Categories entity)
        {
            context.Set<Categories>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Categories> Delete(int id)
        {
            var entity = await context.Set<Categories>().FindAsync(id);
            await _repository.Delete(id, null);
        
            if (entity == null)
            {
                return entity;
            }

            context.Set<Categories>().Remove(entity);

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

        public async Task<Categories> Get(int id)
        {
            return await context.Set<Categories>().FindAsync(id);
        }

        public async Task<List<Categories>> GetAll()
        {
            return await context.Set<Categories>().ToListAsync();
        }

        public async Task<Categories> Update(Categories entity)
        {
           // Categories category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(entry => entry.CategoryId.Equals(entity.CategoryId));


            context.Categories.Update(entity);

 


            await context.SaveChangesAsync();
            return entity;
        }
    }
}
