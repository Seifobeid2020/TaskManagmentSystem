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
        public async Task<ActionResult<List<TasksCategoriesViewModel>>> GetAll()
        {
            var tasks =  _repository.GetAllTasksCategories().ToList();
         List<TasksCategoriesViewModel> maped = _mapper.Map<List<TasksCategoriesViewModel>>(tasks);


            return  Ok(maped);
        }

       
        
    }
}
