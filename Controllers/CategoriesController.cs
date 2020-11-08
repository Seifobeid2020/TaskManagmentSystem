using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repository;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRepository _repository;
        private readonly IMapper _mapper;


        public CategoriesController(CategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriesViewModel>>> GetAll()
        {

            var categories = await _repository.GetAll();
            IEnumerable<CategoriesViewModel> maped = _mapper.Map<IEnumerable<CategoriesViewModel>>(categories);


            return Ok(maped);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriesViewModel>> Get(int id)
        {
            var category = await _repository.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            CategoriesViewModel maped = _mapper.Map<CategoriesViewModel>(category);

            return Ok(maped);

        }

        // PUT: api/[controller]/5
        [HttpPut]
        public async Task<IActionResult> Put(CategoriesViewModel category)
        {
            Categories maped = _mapper.Map<Categories>(category);
            var updatedTask = await _repository.Update(maped);
            if (updatedTask == null)
            {
                return NotFound();
            }


            return Ok(category);



        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<CategoriesViewModel>> Post(CategoriesViewModel category)
        {
            Categories maped = _mapper.Map<Categories>(category);
          await _repository.Add(maped);



            return Ok(category);
         
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriesViewModel>> Delete(int id)
        {
            var category = await _repository.Delete(id);
            if (category == null)
            {
                return NotFound();
            }
            CategoriesViewModel maped = _mapper.Map<CategoriesViewModel>(category);
            return Ok(maped);
        }
    }
}
