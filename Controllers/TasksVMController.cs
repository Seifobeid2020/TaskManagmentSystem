using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using TaskManagmentSystem.Repository;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Controllers
{
    [Route("api/viewmodel/[controller]")]
    [ApiController]
    public class TasksVMController: ControllerBase
    {
        private readonly TasksRepository repository;
        private readonly IMapper _mapper;
        public TasksVMController(TasksRepository _repository, IMapper mapper)
        {
            repository = _repository; _mapper = mapper;
        }
        [HttpGet]
      /*  public async Task<ActionResult<IEnumerable<TasksViewModel>>> Get()
        {
            var tasks = await repository.GetAll();
            TasksViewModel maped = _mapper.Map<TasksViewModel>(tasks);

            return Ok(maped);


        }*/
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var task = await repository.Get(id);
            TasksViewModel maped = _mapper.Map<TasksViewModel>(task);

            return Ok(maped);


        }

       
    }
}
