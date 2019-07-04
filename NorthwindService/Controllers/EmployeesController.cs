using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GenericController<EmployeeDto>
    {
        public EmployeesController(IBaseRepository<EmployeeDto> _repo) : base(_repo)
        { 
        }
    }
}