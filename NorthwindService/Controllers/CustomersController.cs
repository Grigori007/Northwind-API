using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Repositories;
using NorthwindContextLib;

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
        public async Task<IEnumerable<Customer>> ReadCustomersAsync(string country)
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
            Customer customer = await customersRepo.ReadAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return new ObjectResult(customer); // 200 OK
        }


        // POST: api/customers
        // BODY: Customer(JSON, XML)
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            Customer added = await customersRepo.CreateAsync(customer);
            return CreatedAtRoute("ReadOneCustomerAsync", new { id = added.CustomerID.ToLower() }, customer);
        }


        // PUT: api/customers/[id]
        // BODY: Customer(JSON, XML)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] Customer customer)
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
