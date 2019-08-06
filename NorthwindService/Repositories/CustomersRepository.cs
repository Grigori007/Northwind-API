using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            dbContext.Customers.Include(p => p.Orders).ToList();
        }

        public Customer Get(string id)
        {
            id = id.ToUpper();
            return _dbContext.Customers.Find(id);
        }

        public async Task<Customer> GetAsync(string id)
        {
            id = id.ToUpper();
            return await _dbContext.Customers.FindAsync(id);
        }

    }
}
