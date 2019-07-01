using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepoCustomer customersRepo;

        public CustomersController(IRepoCustomer _customersRepo)
        {
            customersRepo = _customersRepo;
        }

        // GET: api/customers
        // GET: api/customers/?country=[country]
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> ReadCustomersAsync(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return await customersRepo.ReadAllAsync();
            }
            else
            {
                return (await customersRepo.ReadAllAsync())
                    .Where(customer => customer.Country == country);
            }
        }


        // GET: api/customers/[id]
        [HttpGet("{id}", Name = "ReadOneCustomerAsync")]
        public async Task<IActionResult> ReadOneCustomerAsync(string id)
        {
            CustomerDto customer = await customersRepo.ReadAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return new ObjectResult(customer); // 200 OK
        }


        // POST: api/customers
        // BODY: Customer(JSON, XML)
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            CustomerDto added = await customersRepo.CreateAsync(customer);
            return CreatedAtRoute("ReadOneCustomerAsync", new { id = added.CustomerID.ToLower() }, customer);
        }


        // PUT: api/customers/[id]
        // BODY: Customer(JSON, XML)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] CustomerDto customer)
        {
            id = id.ToUpper();
            customer.CustomerID = customer.CustomerID.ToUpper();
            if (customer == null || customer.CustomerID != id)
            {
                return BadRequest();
            }
            var existingCustomer = await customersRepo.ReadAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            await customersRepo.UpdateAsync(id, customer);
            return new NoContentResult();
        }


        // DELETE: api/customers/[id]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var existingCustomer = await customersRepo.ReadAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            bool deletedCustomer = await customersRepo.DeleteAsync(id);
            if (deletedCustomer)
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

// test
