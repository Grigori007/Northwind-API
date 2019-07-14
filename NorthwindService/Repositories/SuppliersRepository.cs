using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class SuppliersRepository : BaseRepository<Supplier>, ISuppliers
    {
        public SuppliersRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
            dbContext.Suppliers.Include(p => p.Products).ToList();
        }
    }
}
