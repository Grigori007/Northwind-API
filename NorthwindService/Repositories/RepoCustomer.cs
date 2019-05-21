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
        private static ConcurrentDictionary<string, Customer> cacheMemory;
        private NorthwindDbContext dbContext;


        public RepoCustomer(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

            if (cacheMemory == null)
            {
                cacheMemory = new ConcurrentDictionary<string, Customer>
                    (dbContext.Customers.ToDictionary(c => c.CustomerID));
            }
        }


        #region CRUD Methods
        public async Task<Customer> CreateAsync(Customer customer)
        {
            // normalise customer ID -> capital letters only
            customer.CustomerID = customer.CustomerID.ToUpper();
            EntityEntry<Customer> added = await dbContext.Customers.AddAsync(customer);
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
                Customer customer = dbContext.Customers.Find(id);
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


        public async Task<IEnumerable<Customer>> ReadAllAsync()
        {
            // get data from cache memory. That's a faster way.
            return await Task.Run<IEnumerable<Customer>>(() => cacheMemory.Values);
        }


        public async Task<Customer> ReadAsync(string id)
        {
            return await Task.Run(() =>
            {
                id = id.ToUpper();
                Customer customer;
                cacheMemory.TryGetValue(id, out customer);
                return customer;
            });
        }


        public async Task<Customer> UpdateAsync(string id, Customer customer)
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
        private Customer UpdateCacheMemory(string id, Customer customer)
        {
            Customer oldCustomer;
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
