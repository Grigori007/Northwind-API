﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindContextLib;

namespace NorthwindService.Repositories
{
    public class RepoProduct : IRepoProduct
    {
        private static ConcurrentDictionary<string, Product> cacheMemory;
        private NorthwindDbContext dbContext;

        public RepoProduct(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

            if (cacheMemory == null)
            {
                cacheMemory = new ConcurrentDictionary<string, Product>
                    (dbContext.Products.ToDictionary(c => c.ProductID));
            }
        }


        public Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
