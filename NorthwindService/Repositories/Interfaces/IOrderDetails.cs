using NorthwindContextLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindService.Repositories.Interfaces
{
    interface IOrderDetails : IBaseRepository<OrderDetail>
    {
        new Task<IEnumerable<OrderDetail>> Get(int orderId);
    }
}
