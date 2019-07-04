using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : GenericController<ShipperDto>
    {
        public ShippersController(IBaseRepository<ShipperDto> _repo) : base(_repo)
        {
        }
    }
}