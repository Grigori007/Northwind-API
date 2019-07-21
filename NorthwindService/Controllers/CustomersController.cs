using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

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
        public IActionResult ReadOneCustomer(string id)
        {
            Customer customer = _convertedRepo.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return new ObjectResult(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            id = id.ToUpper();
            Customer customer = _convertedRepo.Get(id);
            if(customer == null)
            {
                return NotFound();
            }
            bool isCustomerDeleted = _convertedRepo.Remove(id);
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
