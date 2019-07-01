using Microsoft.EntityFrameworkCore.ChangeTracking;
using NorthwindContextLib;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public class RepoCustomer : IRepoCustomer
    {
        private NorthwindDbContext dbContext;
        private static ConcurrentDictionary<string, CustomerDto> cacheMemory;


        public RepoCustomer(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

            if (cacheMemory == null)
            {
                cacheMemory = new ConcurrentDictionary<string, CustomerDto>
                    (dbContext.Customers.ToDictionary(c => c.CustomerID));
            }
        }


        #region CRUD Methods
        public async Task<CustomerDto> CreateAsync(CustomerDto customer)
        {
            // normalise customer ID -> capital letters only
            customer.CustomerID = customer.CustomerID.ToUpper();
            EntityEntry<CustomerDto> added = await dbContext.Customers.AddAsync(customer);
            int changed = await dbContext.SaveChangesAsync();

            if (changed == 1)
            {
                // if it's a new customer, add them  to cacheMemory
                // otherwise, invoke AddOrUpdate cache memory method
                return cacheMemory.AddOrUpdate(customer.CustomerID, customer, UpdateCacheMemory);
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> DeleteAsync(string id)
        {
            return await Task.Run(() =>
            {
                id = id.ToUpper();
                CustomerDto customer = dbContext.Customers.Find(id);
                dbContext.Remove(customer);
                // the number of state entries written to the database
                int changed = dbContext.SaveChanges();
                if (changed == 1)
                {
                    return Task.Run(() => cacheMemory.TryRemove(id, out customer));
                }
                else
                {
                    return null;
                }
            });
        }


        public async Task<IEnumerable<CustomerDto>> ReadAllAsync()
        {
            // get data from cache memory. That's a faster way.
            return await Task.Run<IEnumerable<CustomerDto>>(() => cacheMemory.Values);
        }


        public async Task<CustomerDto> ReadAsync(string id)
        {
            return await Task.Run(() =>
            {
                id = id.ToUpper();
                CustomerDto customer;
                cacheMemory.TryGetValue(id, out customer);
                return customer;
            });
        }


        public async Task<CustomerDto> UpdateAsync(string id, CustomerDto customer)
        {
            return await Task.Run(() =>
            {
                id = id.ToUpper();
                customer.CustomerID = customer.CustomerID.ToUpper();
                dbContext.Customers.Update(customer);
                int changed = dbContext.SaveChanges();
                if (changed == 1)
                {
                    return Task.Run(() => UpdateCacheMemory(id, customer));
                }
                return null;
            });
        }
        #endregion


        #region OtherMethods
        private CustomerDto UpdateCacheMemory(string id, CustomerDto customer)
        {
            CustomerDto oldCustomer;
            if (cacheMemory.TryGetValue(id, out oldCustomer))
            {
                if (cacheMemory.TryUpdate(id, customer, oldCustomer))
                {
                    return customer;
                }
            }
            return null;
        }
        #endregion
    }
}
