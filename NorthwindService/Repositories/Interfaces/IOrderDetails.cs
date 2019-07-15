using NorthwindContextLib;

namespace NorthwindService.Repositories.Interfaces
{
    interface IOrderDetails : IBaseRepository<OrderDetail>
    {
        OrderDetail Get(int orderId, int productId);
    }
}
