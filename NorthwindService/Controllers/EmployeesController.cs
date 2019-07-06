using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GenericController<Employee>
    {
        public EmployeesController(IBaseRepository<Employee> _repo) : base(_repo)
        { 
        }
    }
}