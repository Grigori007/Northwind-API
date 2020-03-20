using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : GenericController<OrderDetail>
    {
        private readonly OrderDetailsRepository _convertedRepo;

        public OrderDetailsController(IBaseRepository<OrderDetail> repo) : base(repo)
        {
            _convertedRepo = (OrderDetailsRepository)_repository;
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> ReadOneEntity(int id)
        {
            IEnumerable<OrderDetail> orderDetails = await _convertedRepo.GetAsync(id);
            if (!orderDetails.Any())
            {
                return NotFound();
            }
            return new ObjectResult(orderDetails);        
        }

        [HttpPost]
        [ActionName("OrderDetails post")]
        public async Task<IActionResult> CreateEntity([FromBody] IEnumerable<OrderDetail> orderDetails)
        {
            if (orderDetails.Any() == false || ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            await _convertedRepo.AddRangeAsync(orderDetails);
            return new ObjectResult(orderDetails);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEntity(int id, IEnumerable<OrderDetail> newOrderDetails)
        {
            if (newOrderDetails.Any() == false || ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var existingEntities = await _convertedRepo.GetAsync(id);
            if (existingEntities == null)
            {
                return NotFound();
            }
            // TODO: Use list of Tasks and WhenAll() method
            foreach (OrderDetail orderDetail in newOrderDetails)
            {
                await _convertedRepo.UpdateAsync(orderDetail);
            }
            return new NoContentResult();
        }

        [HttpDelete("{id:int}")]
        public override async Task<IActionResult> DeleteEntity(int id)
        {
            IEnumerable<OrderDetail> existingOrderDetails = await _convertedRepo.GetAsync(id);
            if (!existingOrderDetails.Any())
            {
                return NotFound();
            }
            bool hasDeletedEntities = await _convertedRepo.RemoveRangeAsync(existingOrderDetails);
            if (hasDeletedEntities)
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