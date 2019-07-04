using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : GenericController<CategoryDto>
    {
        public CategoriesController(IBaseRepository<CategoryDto> _repo) : base(_repo)
        {
        }
    }
}