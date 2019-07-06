using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : GenericController<Order>
    {
        public OrdersController(IBaseRepository<Order> _repo) : base(_repo)
        {
        }
    }
}