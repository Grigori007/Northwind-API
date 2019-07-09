using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IBaseRepository<Customer> _repo) : base(_repo)
        {
        }

    }
}
