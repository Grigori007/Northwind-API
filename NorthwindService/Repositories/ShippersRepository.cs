using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class ShippersRepository : BaseRepository<Shipper>, IShippers
    {
        public ShippersRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext.Shippers.Include(p => p.Orders).ToList();
        }
    }
}
