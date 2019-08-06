using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;
using System.Threading.Tasks;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : GenericController<Customer>
    {
        private readonly CustomersRepository _convertedRepo;
        
        public CustomersController(IBaseRepository<Customer> repo) : base(repo)
        {
            _convertedRepo = (CustomersRepository)_repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadOneCustomer(string id)
        {
            Customer customer = await _convertedRepo.GetAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return new ObjectResult(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] Customer customer)
        {
            if (customer == null || ModelState.IsValid == false)
            {
                return BadRequest();
            }
            id = id.ToUpper();
            Customer existingCustomer = await _convertedRepo.GetAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            await _convertedRepo.UpdateAsync(customer);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            id = id.ToUpper();
            Customer customer = await _convertedRepo.GetAsync(id);
            if(customer == null)
            {
                return NotFound();
            }
            bool isCustomerDeleted = await _convertedRepo.RemoveAsync(customer);
            if (isCustomerDeleted)
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
