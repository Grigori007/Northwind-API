using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : GenericController<Shipper>
    {
        public ShippersController(IBaseRepository<Shipper> _repo) : base(_repo)
        {
        }
    }
}