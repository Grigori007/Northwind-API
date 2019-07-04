using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : GenericController<SupplierDto>
    {
        public SuppliersController(IBaseRepository<SupplierDto> _repo) : base(_repo)
        {
        }
    }
}