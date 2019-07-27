using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class EmployeesRepository : BaseRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            //dbContext.Employees.Include(p => p.Manager).ToList();
            //dbContext.Employees.Include(p => p.Orders).ToList();
        }
    }
}
