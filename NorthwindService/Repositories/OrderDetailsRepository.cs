using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<OrderDetail>> GetAsync(int orderId)
        {
            return await Task.Run(() => 
            {
                return _dbContext.OrderDetails.Where(o => o.OrderId == orderId);
            });           
        }

        public override async Task<OrderDetail> UpdateAsync(OrderDetail entity)
        {
            OrderDetail existingEntity = await _dbContext.OrderDetails.FindAsync(new { entity.OrderId, entity.ProductId});
            if (existingEntity == null)
            {
                return null;
            }
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return existingEntity;
        }

    }
}
