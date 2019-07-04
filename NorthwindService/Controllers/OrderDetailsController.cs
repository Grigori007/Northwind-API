using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : GenericController<OrderDetailDto>
    {
        public OrderDetailsController(IBaseRepository<OrderDetailDto> _repo) : base(_repo)
        {
        }
    }
}