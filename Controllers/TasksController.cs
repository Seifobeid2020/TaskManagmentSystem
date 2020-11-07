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
    public class TasksController : ControllerBase
    {
        private readonly TasksRepository _repository;
        private readonly IMapper _mapper;


        public TasksController(TasksRepository repository ,IMapper mapper )
        {
            _repository= repository  ;
            _mapper = mapper;
        }
        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetAll()
        {
            var tasks = await _repository.GetAll();
            IEnumerable<TasksViewModel> maped = _mapper.Map< IEnumerable<TasksViewModel>>(tasks);


            return Ok(maped);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> Get(int id)
        {
            var task = await _repository.Get(id);
            if (task == null)
            {
                return NotFound();
            }
            TasksViewModel maped = _mapper.Map<TasksViewModel>(task);

            return Ok(maped);
        
        }

        // PUT: api/[controller]/5
        [HttpPut]
        public async Task<IActionResult> Put(Tasks task)
        {

            var updatedTask = await _repository.Update(task);
            if (updatedTask == null)
            {
                return NotFound();
            }
            TasksViewModel maped = _mapper.Map<TasksViewModel>(task);
    
            return Ok(maped);


   
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<Tasks>> Post(Tasks task)
        {
            await _repository.Add(task);


            return CreatedAtAction("Get", new { id = task.TaskId }, task);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tasks>> Delete(int id)
        {
            var task = await _repository.Delete(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }
    }
}
