using NorthwindContextLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public interface IRepoCustomer
    {
        Task<CustomerDto> CreateAsync(CustomerDto customer);
        Task<IEnumerable<CustomerDto>> ReadAllAsync();
        Task<CustomerDto> ReadAsync(string id);
        Task<CustomerDto> UpdateAsync(string id, CustomerDto customer);
        Task<bool> DeleteAsync(string id);
    }
}
