using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrders
    {
        public OrdersRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext.Orders.Include(p => p.Customer);
            _dbContext.Orders.Include(p => p.Employee);
            _dbContext.Orders.Include(p => p.Shipper);
            _dbContext.Orders.Include(p => p.OrderDetails).ToList();
        }
    }
}
