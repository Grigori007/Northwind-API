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




    }
}
