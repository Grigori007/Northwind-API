using NorthwindContextLib;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NorthwindService.Repositories
{
    public interface IRepoProduct
    {
        Task<Product> CreateAsync(Product product);
        Task<IEnumerable<Product>> ReadAllAsync();
        Task<Product> ReadAsync(int id);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
