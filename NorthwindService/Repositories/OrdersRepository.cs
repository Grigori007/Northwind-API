using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrders
    {
        public OrdersRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
            dbContext.Orders.Include(p => p.Customer);
            dbContext.Orders.Include(p => p.Employee);
            dbContext.Orders.Include(p => p.Shipper);
            dbContext.Orders.Include(p => p.OrderDetails).ToList();
        }
    }
}
