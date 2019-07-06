using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : GenericController<Supplier>
    {
        public SuppliersController(IBaseRepository<Supplier> _repo) : base(_repo)
        {
        }
    }
}