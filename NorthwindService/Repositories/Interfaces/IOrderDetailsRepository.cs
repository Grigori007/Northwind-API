using NorthwindContextLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindService.Repositories.Interfaces
{
    public interface IOrderDetailsRepository : IBaseRepository<OrderDetail>
    {
        new Task<IEnumerable<OrderDetail>> GetAsync(int orderId);
    }
}
