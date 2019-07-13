using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;

namespace NorthwindService.Repositories
{
    public class EmployeesRepository : BaseRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
