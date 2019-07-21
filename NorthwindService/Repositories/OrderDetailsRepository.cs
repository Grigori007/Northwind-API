using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetail>, IOrderDetails
    {
        public OrderDetailsRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<OrderDetail>> Get(int orderId)
        {
            return await Task.Run(() => 
            {
                return _dbContext.OrderDetails.Where(o => o.OrderId == orderId);
            });           
        }
    }
}
