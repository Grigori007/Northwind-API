using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;

namespace NorthwindService.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrders
    {
        public OrdersRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
