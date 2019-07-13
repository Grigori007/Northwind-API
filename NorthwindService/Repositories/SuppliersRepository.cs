using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;

namespace NorthwindService.Repositories
{
    public class SuppliersRepository : BaseRepository<Supplier>, ISuppliers
    {
        public SuppliersRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
