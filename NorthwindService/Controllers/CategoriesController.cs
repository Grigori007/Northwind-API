using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(IBaseRepository<Category> repo) : base(repo)
        {
        }
    }
}