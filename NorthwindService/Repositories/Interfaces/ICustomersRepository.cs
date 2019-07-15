using NorthwindContextLib;

namespace NorthwindService.Repositories.Interfaces
{
    interface ICustomersRepository : IBaseRepository<Customer>
    {
        Customer Get(string id);
        bool Remove(string id);
    }
}
