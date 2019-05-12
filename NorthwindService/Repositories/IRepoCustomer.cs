using NorthwindContextLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public interface IRepoCustomer
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<IEnumerable<Customer>> ReadAllAsync();
        Task<Customer> ReadAsync(string id);
        Task<Customer> UpdateAsync(string id, Customer customer);
        Task<bool> DeleteAsync(string id);
    }
}
