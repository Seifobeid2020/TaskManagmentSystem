using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    interface ITasksCategoriesRepository:IRepository<TasksCategories>
    {
        Task<List<TasksCategories>> Delete(int? CategoryId, int? TaskId);
        Task<TasksCategories> Update(int CategoryId, int TaskId, TasksCategories entity);
    }
}
