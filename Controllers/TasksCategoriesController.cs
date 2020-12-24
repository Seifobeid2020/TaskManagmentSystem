using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repository;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksCategoriesController : ControllerBase
    {
        private readonly TasksCategoriesRepository _repository;
        private readonly IMapper _mapper;


        public TasksCategoriesController(TasksCategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/[controller]
        [HttpGet]
        public  IActionResult GetAllTasksCategories()
        {
            var tasks =  _repository.GetAll().Result;
         List<TasksCategoriesViewModel> maped = _mapper.Map<List<TasksCategoriesViewModel>>(tasks);


            return  Ok(maped);
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TasksCategoriesViewModel>> Post(TasksCategoriesViewModel entity)
        {
            TasksCategories maped = _mapper.Map<TasksCategories>(entity);
            await _repository.Add(maped);



            return Ok(entity);

        }




        // DELETE: api/[controller]/1/1
          [HttpDelete("{categoryId}/{taskId}")]
        public async Task<ActionResult<TasksCategoriesViewModel>> Delete( int categoryId ,int taskId)
        {
        
            var task = await _repository.Delete(categoryId, taskId);
            if (task == null)
            {
                return NotFound();
            }
            List<TasksCategoriesViewModel> maped = _mapper.Map<List<TasksCategoriesViewModel>>(task);
       
            return Ok(maped);
        }

        // PUT: api/[controller]/5
        [HttpPut("{categoryId}/{taskId}")]
        public async Task<IActionResult> Put(int categoryId, int taskId, TasksCategoriesViewModel entity)
        {
            TasksCategories maped = _mapper.Map<TasksCategories>(entity);
            var updatedTask = await _repository.Update(categoryId, taskId, maped);

            if (updatedTask == null)
            {
                return NotFound();
            }


            return Ok(entity);



        }

    }
}
