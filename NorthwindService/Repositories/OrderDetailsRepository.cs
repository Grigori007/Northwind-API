using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;

namespace NorthwindService.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetail>, IOrderDetails
    {
        public OrderDetailsRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {

        }

        public OrderDetail Get(int orderId, int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
