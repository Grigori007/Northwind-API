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
        protected readonly IBaseRepository<T> repository;

        public GenericController(IBaseRepository<T> _repository)
        {
            repository = _repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public virtual Task<IEnumerable<T>> ReadEntitiesAsync()
        {
            return Task.Run(() => 
            {
                return repository.GetAll();
            });  
        }


        // TODO: Find a way to create this atrribute name for each controller
        // GET: api/[controller]/[id]
        [HttpGet("{id}")]
        public virtual IActionResult ReadOneEntityAsync(int id)
        {
                T entity = repository.Get(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return new ObjectResult(entity); // 200 OK         
        }


        // POST: api/[controller]
        // BODY: [name_of_entity](JSON, XML)
        [HttpPost]
        public virtual IActionResult CreateEntity([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            repository.Add(entity);
            //return CreatedAtRoute("ReadOneEntityAsync", new { id = added.EntityId }, entity);
            return new ObjectResult(entity);
        }


        // PUT: api/[controller]/[id]
        // BODY: [controller](JSON, XML)
        //[HttpPut("{id}")]
        //public virtual async Task<IActionResult> UpdateEntity(int id, [FromBody] T entity)
        //{
        //    if (entity == null || entity.EntityId != id)
        //    {
        //        return BadRequest();
        //    }
        //    var existingEntity = repository.Get(id);
        //    if (existingEntity == null)
        //    {
        //        return NotFound();
        //    }
        //    repository.UpdateAsync(id, entity);
        //    return new NoContentResult();
        //}


        // DELETE: api/[controller]/[id]
        [HttpDelete("{id}")]
        public virtual IActionResult DeleteEntity(int id)
        {
            T existingEntity = repository.Get(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            repository.Remove(id);
            if (deletedEntity)
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