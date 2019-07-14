using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : GenericController<Customer>
    {
        private CustomersRepository convertedRepo;
        
        public CustomersController(IBaseRepository<Customer> _repo) : base(_repo)
        {
            convertedRepo = (CustomersRepository)repository;
        }

        [HttpGet("{id}")]
        public IActionResult ReadOneCustomer(string id)
        {
            Customer customer = convertedRepo.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return new ObjectResult(customer);
        }

    }
}
