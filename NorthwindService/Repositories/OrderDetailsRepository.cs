using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;

namespace NorthwindService.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetail>, IOrderDetails
    {
        public OrderDetailsRepository(NorthwindDbContext dbContext) : base(dbContext)
        {

        }

        public OrderDetail Get(int orderId, int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
