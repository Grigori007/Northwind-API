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
        public virtual async Task<IEnumerable<T>> ReadEntitiesAsync()
        {
            return await repository.ReadAllAsync();
        }

        // TODO: Find a way to create this atrribute name for each controller
        // GET: api/[controller]/[id]
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> ReadOneEntityAsync(int id)
        {
            T entity = await repository.ReadAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return new ObjectResult(entity); // 200 OK
        }


        // POST: api/[controller]
        // BODY: [controller](JSON, XML)
        [HttpPost]
        public virtual async Task<IActionResult> CreateEntity([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            T added = await repository.CreateAsync(entity);
            //return CreatedAtRoute("ReadOneEntityAsync", new { id = added.EntityId }, entity);
            return new ObjectResult(entity);
        }


        // PUT: api/[controller]/[id]
        // BODY: [controller](JSON, XML)
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateEntity(int id, [FromBody] T entity)
        {
            if (entity == null || entity.EntityId != id)
            {
                return BadRequest();
            }
            var existingEntity = await repository.ReadAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            await repository.UpdateAsync(id, entity);
            return new NoContentResult();
        }


        // DELETE: api/[controller]/[id]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteEntity(int id)
        {
            var existingEntity = await repository.ReadAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            bool deletedEntity = await repository.DeleteAsync(id);
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