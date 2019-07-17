using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class SuppliersRepository : BaseRepository<Supplier>, ISuppliers
    {
        public SuppliersRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext.Suppliers.Include(p => p.Products).ToList();
        }
    }
}
