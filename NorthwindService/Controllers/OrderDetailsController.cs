using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : GenericController<OrderDetail>
    {
        public OrderDetailsController(IBaseRepository<OrderDetail> repo) : base(repo)
        {
        }
    }
}