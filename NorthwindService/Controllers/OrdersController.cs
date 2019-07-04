using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : GenericController<OrderDto>
    {
        public OrdersController(IBaseRepository<OrderDto> _repo) : base(_repo)
        {
        }
    }
}