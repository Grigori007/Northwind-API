using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IBaseRepository<Product> repo) : base(repo)
        {
        }
    }
}