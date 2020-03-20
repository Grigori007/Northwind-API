using NorthwindContextLib;

namespace NorthwindService.Repositories.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customer>
    {
        Customer Get(string id);
    }
}
