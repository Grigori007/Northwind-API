using Microsoft.AspNetCore.Mvc;
using NorthwindEntityLib;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<T> : ControllerBase where T : class, IBaseEntity
    {
        protected readonly IBaseRepository<T> _repository;

        public GenericController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<IEnumerable<T>> ReadEntities()
        {
            IEnumerable<T> entities = await _repository.GetAllAsync();
            return entities;
        }


        // GET: api/[controller]/[id]
        [HttpGet("{id:int}")]
        [ActionName("Generic post")]
        public virtual async Task<IActionResult> ReadOneEntity(int id)
        {
                T entity = await _repository.GetAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return new ObjectResult(entity); // 200 OK         
        }


        // POST: api/[controller]
        // BODY: [name_of_entity](JSON, XML)
        [HttpPost]
        public virtual async Task<IActionResult> CreateEntity([FromBody] T entity)
        {
            if (entity == null || ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _repository.AddAsync(entity);
            return new ObjectResult(entity);
        }


        //PUT: api/[controller]/[id]
        //BODY: [controller]
        //(JSON, XML)
       [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> UpdateEntity(int id, [FromBody] T entity)
        {
            if (entity == null || ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var existingEntity = await _repository.GetAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            
            _repository.Update(entity);
            return new NoContentResult();
        }


        // DELETE: api/[controller]/[id]
        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> DeleteEntity(int id)
        {
            T existingEntity = await _repository.GetAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            bool hasDeletedEntity = await _repository.RemoveAsync(existingEntity);
            if (hasDeletedEntity)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}