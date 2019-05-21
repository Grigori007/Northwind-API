using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NorthwindContextLib;

namespace NorthwindService.Repositories
{
    public class RepoProduct : IRepoProduct
    {
        private static ConcurrentDictionary<int, Product> cacheMemory;
        private NorthwindDbContext dbContext;

        public RepoProduct(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

            if (cacheMemory == null)
            {
                cacheMemory = new ConcurrentDictionary<int, Product>
                    (dbContext.Products.ToDictionary(c => c.ProductID));
            }
        }

        #region CRUD Methods
        public async Task<Product> CreateAsync(Product product)
        {
            EntityEntry<Product> added = await dbContext.Products.AddAsync(product);
            int changed = await dbContext.SaveChangesAsync();
            if (changed == 1)
            {
                return cacheMemory.AddOrUpdate(product.ProductID, product, UpdateCacheMemory);
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.Run(() =>
            {
                Product product = dbContext.Products.Find(id);
                dbContext.Remove(product);
                int changed = dbContext.SaveChanges();
                if (changed == 1)
                {
                    return Task.Run(() => cacheMemory.TryRemove(id, out product));
                }
                else
                {
                    return null;
                }
            });
        }


        public async Task<IEnumerable<Product>> ReadAllAsync()
        {
            return await Task.Run<IEnumerable<Product>>(() => cacheMemory.Values);
        }


        public async Task<Product> ReadAsync(int id)
        {
            return await Task.Run(() =>
            {
                Product product;
                cacheMemory.TryGetValue(id, out product);
                return product;
            });      
        }


        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region OtherMethods
        private Product UpdateCacheMemory(int id, Product product)
        {
            Product oldProduct;
            if (cacheMemory.TryGetValue(id, out oldProduct))
            {
                if (cacheMemory.TryUpdate(id, product, oldProduct))
                {
                    return product;
                }
            }
            return null;
        }
        #endregion
    }
}
