using Microsoft.AspNetCore.Mvc;
using NorthwindEntityLib;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<T> : ControllerBase where T : class, INorthwindDb
    {
        private readonly IBaseRepository<T> repository;

        public GenericController(IBaseRepository<T> _repository)
        {
            repository = _repository;
        }

        // GET: api/[name_of_entity]
        [HttpGet]
        public async Task<IEnumerable<T>> ReadEntitiesAsync()
        {
            return await repository.ReadAllAsync();
        }

        // TODO: Find a way to create this atrribute name for each controller
        // GET: api/[name_of_entity]/[id]
        [HttpGet("{id}")]
        public async Task<IActionResult> ReadOneEntityAsync(int id)
        {
            T entity = await repository.ReadAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return new ObjectResult(entity); // 200 OK
        }


        // POST: api/[name_of_entity]
        // BODY: [name_of_entity](JSON, XML)
        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            T added = await repository.CreateAsync(entity);
            //return CreatedAtRoute("ReadOneEntityAsync", new { id = added.EntityId }, entity);
            return new ObjectResult(entity);
        }


        // PUT: api/[name_of_entity]/[id]
        // BODY: [name_of_entity](JSON, XML)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(int id, [FromBody] T entity)
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


        // DELETE: api/entitys/[id]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
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