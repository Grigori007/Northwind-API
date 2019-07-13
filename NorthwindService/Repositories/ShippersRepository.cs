using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;

namespace NorthwindService.Repositories
{
    public class ShippersRepository : BaseRepository<Shipper>, IShippers
    {
        public ShippersRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
